using GhostHunter.Runtime.Features.LifeCycle;
using GhostHunter.Runtime.Features.ScenesManagment;
using UnityEngine.SceneManagement;
using Zenject;

namespace GhostHunter.Runtime.Features.ScenesManagement
{
    public class SceneSwitcher : IInitializable
    {
        private ScenesData scenesData;
        private GhostGameLifeCycle lifeCycle;

        public SceneSwitcher(ScenesData scenesData, GhostGameLifeCycle lifeCycle)
        {
            this.scenesData = scenesData;
            this.lifeCycle = lifeCycle;
        }
        
        public void Initialize() => 
            Subscribe();

        public void SwitchToMainScene() => 
            LoadScene(scenesData.MainSceneName);

        public void SwitchToGhostGame() => 
            LoadScene(scenesData.GhostGameSceneName);

        private void LoadScene(string sceneName) => 
            SceneManager.LoadScene(sceneName);

        private void Subscribe()
        {
            lifeCycle.Win += (_, __) => SwitchToMainScene();
            lifeCycle.OnGameEnded += (_, __) => SwitchToMainScene();
        }
    }
}