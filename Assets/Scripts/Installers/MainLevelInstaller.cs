using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainLevelInstaller : MonoInstaller
    {
        [SerializeField] private DialogueManager _dialogueManager;
        public override void InstallBindings()
        {
            Container.Bind<DialogueManager>()
                .FromInstance(_dialogueManager)
                .AsSingle();
        }
    }
}