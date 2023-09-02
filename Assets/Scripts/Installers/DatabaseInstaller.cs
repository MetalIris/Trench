using Databases.DialogueDatabase.Impl;
using Databases.LevelCheckDatabase.Impl;
using Databases.PlayerSpriteDatabase.Impl;
using DefaultNamespace.Databases.DialogueDatabase.Impl;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "DatabaseInstaller", menuName = "Installers/DatabaseInstaller")]
    public class DatabaseInstaller : ScriptableObjectInstaller<DatabaseInstaller>
    {
        [SerializeField] private PrefabDatabase prefabDatabase;
        [SerializeField] private DialogueDatabase dialogueDatabase;
        [SerializeField] private LevelNameDatabase levelNameDatabase;
        public override void InstallBindings()
        {
            Container.Bind<IPrefabDatabase>()
                .FromInstance(prefabDatabase)
                .AsSingle();
            Container.Bind<IDialogueDatabase>()
                .FromInstance(dialogueDatabase)
                .AsSingle();
            Container.Bind<ILevelNameDatabase>()
                .FromInstance(levelNameDatabase)
                .AsSingle();
        }
    }
}