
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D _rb;

    [Inject] private EnemyBehaviour _enemyBehaviour;
    [Inject] private LevelPassedController _levelPassedController;

    private void Start()
    {
        _rb.velocity = transform.right * speed;
        
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Debug.Log("Bullet hit enemy!");
                _enemyBehaviour.OnEnemyHit(transform, "enemyCorpse");
                _levelPassedController.EnemyKilled(1);
                Destroy(collision.gameObject);
                break;

            case "Wall":
                Debug.Log("Bullet hit obstacle!");
                Destroy(gameObject);
                break;

            case "AnotherTag":
                Debug.Log("Bullet hit object with AnotherTag!");
                break;

            default:
                Debug.Log("Bullet hit object with unknown tag!");
                break;
        }

        Destroy(gameObject);
    }
}
