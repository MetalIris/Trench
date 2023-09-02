using System.Collections;
using Player;
using UnityEngine;
using Zenject;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private bool patrol = true;
    [SerializeField] private bool clockwise;
    [SerializeField] private float patrolSpeed = 2.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform rayLeftSpawnPoint;
    [SerializeField] private Transform rayRightSpawnPoint;
    [SerializeField] private float rayDistance = 1.5f;

    [Inject] private PlayerMovement _playerMovement;
    [Inject] private EnemyBehaviour _enemyBehaviour;
    [Inject] private LevelController _levelController;

    private Transform _player;
    private Transform _enemy;

    private const float DetectionRadius = 6.0f;
    private int _layerMask;

    private Vector2 _direction;
    private RaycastHit2D _hit;

    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int IsAttackingHash = Animator.StringToHash("IsAttacking");

    private bool _playerDetected;
    private Vector2 _lastKnownPlayerPosition;

    private void Awake()
    {
        _player = _playerMovement.transform;
        _enemy = transform;

        _layerMask = LayerMask.GetMask("Wall", "Player", "Enemy", "Door");
    }

    private void Update()
    {
        if (_playerMovement != null)
        {
            DetectPlayer();
            Patrol();

            float speed = rb.velocity.magnitude;
            animator.SetFloat(SpeedHash, speed);
        }
        else
        {
            animator.SetFloat(SpeedHash, 0f);
        }

        if (!_playerDetected && !patrol)
        {
            float distanceToLastKnownPosition = Vector2.Distance(transform.position, _lastKnownPlayerPosition);
            if (distanceToLastKnownPosition <= 0.5f)
            {
                ReturnToPatrol();
            }
        }
    }
    private void DetectPlayer()
    {
        float distance = Vector2.Distance(transform.position, _player.position);
        _direction = (_player.position - _enemy.position).normalized;
        _hit = Physics2D.Raycast(_enemy.position, _direction, distance, ~LayerMask.GetMask("Enemy"));

        Debug.DrawRay(_enemy.position, _direction * distance, Color.red);

        if (_hit.collider != null && _hit.collider.CompareTag("Player") && distance <= DetectionRadius)
        {
            _enemy.right = _direction;

            rb.velocity = _direction * patrolSpeed;

            _playerDetected = true;
            patrol = false;

            _lastKnownPlayerPosition = _player.position;
        }
        else
        {
            _playerDetected = false;
        }
    }

    private void Patrol()
    {
        if (patrol)
        {
            rb.velocity = transform.right * patrolSpeed;

            Vector2 rayDirection = _enemy.right;
            RaycastHit2D hit1 = CastRay(rayLeftSpawnPoint.position, rayDirection);

            Vector2 rayDirection2 = _enemy.right;
            RaycastHit2D hit2 = CastRay(rayRightSpawnPoint.position, rayDirection2);

            if (hit1.collider != null || hit2.collider != null)
            {
                transform.Rotate(0, 0, clockwise ? -90f : 90f);
            }
        }
        else if (clockwise)
        {
            animator.SetBool("IsWaiting", !_playerDetected);
        }
    }
    
    private RaycastHit2D CastRay(Vector2 origin, Vector2 direction)
    {
        return Physics2D.Raycast(origin, direction, rayDistance, _layerMask);
    }

    private void PlayerKilled()
    {
        _enemyBehaviour.OnEnemyHit(transform, "playerCorpse");

        StartCoroutine(OnPlayerKilling());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetBool(IsAttackingHash, true);

            PlayerKilled();

            Destroy(col.gameObject);
        }
    }

    private void ReturnToPatrol()
    {
        patrol = true;
        _playerDetected = false;
    }

    private IEnumerator OnPlayerKilling()
    {
        yield return new WaitForSeconds(1);
        _levelController.OnPlayerKilled();
    }

    public class PatrolEnemyFactory : PlaceholderFactory<EnemyAI> {}
    
    public class ClockwiseEnemyFactory : PlaceholderFactory<EnemyAI> {}
}

