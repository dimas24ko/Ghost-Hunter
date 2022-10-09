using GhostHunter.Runtime.Features.ScenesManagment;
using GhostHunter.Runtime.Features.ScenesManagment.SceneLoaders;
using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Features.ScenesManagement.SceneLoaders
{
    public class GhostGameLoader: MonoBehaviour, ISceneLoader
    {
        private SceneSwitcher sceneSwitcher;

        [Inject]
        public void Construct(SceneSwitcher sceneSwitcher) => 
            this.sceneSwitcher = sceneSwitcher;

        public void Load() => 
            sceneSwitcher.SwitchToGhostGame();
    }
}