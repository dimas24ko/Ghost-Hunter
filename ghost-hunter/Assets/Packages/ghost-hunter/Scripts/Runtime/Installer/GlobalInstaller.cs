using GhostHunter.Runtime.Features.GamesInfo;
using GhostHunter.Runtime.Features.Ghost;
using GhostHunter.Runtime.Features.LifeCycle;
using GhostHunter.Runtime.Features.ScenesManagement;
using GhostHunter.Runtime.Features.ScenesManagment;
using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Installer
{
    [CreateAssetMenu(fileName = "GlobalInstaller", menuName = "Installers/GlobalInstaller")]
    public class GlobalInstaller : ScriptableObjectInstaller
    {
        [Header("Data")]
        public GhostGameInformation GhostGameInformation;
        public GhostDataContainer GhostDataContainer;
        public ScenesData ScenesData;
        
        public override void InstallBindings()
        {
            InstallData();
            InstallScenesService();
            InstallGhostGameServices();
            InstallPointsServices();
        }

        private void InstallData()
        {
            Container.Bind<GhostGameInformation>().FromScriptableObject(GhostGameInformation).AsSingle();
            Container.Bind<GhostDataContainer>().FromScriptableObject(GhostDataContainer).AsSingle();
            Container.Bind<ScenesData>().FromScriptableObject(ScenesData).AsSingle();
        }

        private void InstallScenesService() => 
            Container.BindInterfacesAndSelfTo<SceneSwitcher>().AsSingle();

        private void InstallGhostGameServices()
        {
            Container.BindInterfacesAndSelfTo<GhostGameLifeCycle>().AsSingle();
            Container.BindInterfacesAndSelfTo<GhostGameWinChecker>().AsSingle();
        }

        private void InstallPointsServices() => 
            Container.BindInterfacesAndSelfTo<PointsCounter>().AsSingle();
    }
}