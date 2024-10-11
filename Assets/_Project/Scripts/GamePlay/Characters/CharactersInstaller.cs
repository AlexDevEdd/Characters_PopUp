using Zenject;

namespace GamePlay.Characters
{
    public sealed class CharactersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterCollection>()
                .AsSingle()
                .NonLazy();
        }
    }
}