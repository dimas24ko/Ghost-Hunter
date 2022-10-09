using GhostHunter.Runtime.Features.GamesInfo;
using GhostHunter.Runtime.Features.Ghost;
using Zenject;

namespace GhostHunter.Runtime.Installer
{
    public class GhostGameInstaller : MonoInstaller
    {
        public AnchorsContainer AnchorsContainer;
        public GhostSpawner GhostSpawner;

        public override void InstallBindings()
        {
            Container.Bind<AnchorsContainer>().FromInstance(AnchorsContainer).AsSingle();
            Container.Bind<GhostSpawner>().FromInstance(GhostSpawner).AsSingle();
            Container.BindInterfacesAndSelfTo<GhostFactory>().AsSingle();
        }
        
    }
}