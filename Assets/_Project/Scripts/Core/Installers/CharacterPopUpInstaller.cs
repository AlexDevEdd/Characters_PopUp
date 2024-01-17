using _Project.Scripts.Factories;
using _Project.Scripts.Systems;
using Zenject;

namespace _Project.Scripts.Core.Installers
{
    public class CharacterPopUpInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterPresenterFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterPopUpSystem>().AsSingle().NonLazy();
        }
    }
}