using Databases.PlayerSpriteDatabase.Impl;
using DefaultNamespace;
using Factories;
using Player;
using UnityEngine;

using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private EnemyBehaviour _enemyBehaviour;
        [SerializeField] private CameraRotation _cameraRotation;
        [SerializeField] private LevelController _levelController;
        [SerializeField] private LevelTransitionAnimation _levelTransitionAnimation;

        [Inject] private IPrefabDatabase _prefabDatabase;
        public override void InstallBindings()
        {
            Container.Bind<PlayerMovement>()
                .FromInstance(_playerMovement)
                .AsSingle();
            Container.Bind<EnemyBehaviour>()
                .FromInstance(_enemyBehaviour)
                .AsSingle();
            Container.Bind<CameraRotation>()
                .FromInstance(_cameraRotation)
                .AsSingle();
            Container.Bind<LevelController>()
                .FromInstance(_levelController)
                .AsSingle();
            Container.Bind<LevelTransitionAnimation>()
                .FromInstance(_levelTransitionAnimation)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<EnemySpawner>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<LevelPassedController>()
                .AsSingle();
            
            Container.BindFactory<EnemyAI, EnemyAI.PatrolEnemyFactory>()
                .FromComponentInNewPrefab(_prefabDatabase.GetPrefab("enemyPatrol"));
            
            Container.BindFactory<EnemyAI, EnemyAI.ClockwiseEnemyFactory>()
                .FromComponentInNewPrefab(_prefabDatabase.GetPrefab("enemyClockwise"));
        }
    }
}