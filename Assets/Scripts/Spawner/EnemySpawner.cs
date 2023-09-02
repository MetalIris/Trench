using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Factories
{
    public class EnemySpawner : MonoBehaviour
    {
        [Inject] private readonly EnemyAI.PatrolEnemyFactory _patrolEnemyFactory;
        
        [Inject] private readonly EnemyAI.ClockwiseEnemyFactory _clockwiseEnemyFactory;

        [SerializeField] private Transform[] _patrolEnemyPositions;
        [SerializeField] private Transform[] _clockwiseEnemyPositions;

        public EnemySpawner
            (
                EnemyAI.PatrolEnemyFactory enemyPatrolEnemyFactory,
                EnemyAI.ClockwiseEnemyFactory clockwiseEnemyFactory)
        {
            _patrolEnemyFactory = enemyPatrolEnemyFactory;
            _clockwiseEnemyFactory = clockwiseEnemyFactory;
        }

        private void Start()
        {
            SpawnPatrolEnemies();
            SpawnClockwiseEnemies();
        }

        private void SpawnPatrolEnemies()
        {
            for (int i = 0; i < _patrolEnemyPositions.Length; i++)
            {
                var enemyPrefab = _patrolEnemyFactory.Create();
                enemyPrefab.transform.position = _patrolEnemyPositions[i].position;
            }
        }

        private void SpawnClockwiseEnemies()
        {
            for (int i = 0; i < _clockwiseEnemyPositions.Length; i++)
            {
                var enemyPrefab = _clockwiseEnemyFactory.Create();
                enemyPrefab.transform.position = _clockwiseEnemyPositions[i].position;
            }
        }
    }
}