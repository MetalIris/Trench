using Databases.PlayerSpriteDatabase.Impl;
using UnityEngine;
using Zenject;

public class EnemyBehaviour : MonoBehaviour
{
   [Inject] private IPrefabDatabase _prefabDatabase;
   
   [SerializeField] private ParticleSystem _bloodParticles;

   public void OnEnemyHit(Transform enemyTransform, string corpseName)
    {
        var corpse = _prefabDatabase.GetPrefab(corpseName);
        var bloodTrail = _prefabDatabase.GetPrefab("bloodTrail");

        var position = enemyTransform.position;
        
        Instantiate(corpse, position, transform.rotation);
        Instantiate(bloodTrail, position, Quaternion.identity);
        Instantiate(_bloodParticles, position, Quaternion.identity);
        
        _bloodParticles.Play();
    }
}
