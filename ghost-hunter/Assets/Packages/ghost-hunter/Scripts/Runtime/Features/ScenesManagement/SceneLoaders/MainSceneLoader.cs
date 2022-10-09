using GhostHunter.Runtime.Features.ScenesManagement;
using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Features.ScenesManagment.SceneLoaders
{
    public class MainSceneLoader : MonoBehaviour
    {
        private SceneSwitcher sceneSwitcher;

        [Inject]
        public void Construct(SceneSwitcher sceneSwitcher) => 
            this.sceneSwitcher = sceneSwitcher;

        public void Load() => 
            sceneSwitcher.SwitchToMainScene();
    }
}