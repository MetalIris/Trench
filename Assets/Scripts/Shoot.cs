using System.Collections;
using Databases.PlayerSpriteDatabase.Impl;
using UnityEngine;
using Zenject;


public class Shoot : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private ParticleSystem _shootParticles;
    [SerializeField] private GameObject _aimLine;
    
    private bool canShoot = true;
    
    [Inject] private DiContainer _container;
    [Inject] private IPrefabDatabase _prefabDatabase;

    public void OnAim()
    {
        _aimLine.SetActive(true);
    }
    
    public void OnShoot()
    {
        _aimLine.SetActive(false);
        
        if (canShoot)
        {
            _animator.SetBool("IsShooting", true);
            StartCoroutine(ResetShooting());

            var bullet = _prefabDatabase.GetPrefab("bullet");
            var projectile = Instantiate(bullet, _firePoint.position, transform.rotation);
            _container.InjectGameObject(projectile);
            
            _shootParticles.Play();
            Debug.Log("bam");
        }
    }

    private IEnumerator ResetShooting()
    {
        canShoot = false; 
        yield return new WaitForSeconds(0.2f); 
        _animator.SetBool("IsShooting", false); 
        yield return new WaitForSeconds(0.5f); 
        canShoot = true; 
    }
}
