using System;
using System.Collections;
using GhostHunter.Runtime.Features.GamesInfo;
using GhostHunter.Runtime.Features.LifeCycle;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace GhostHunter.Runtime.Features.Ghost
{
    public class GhostSpawner : MonoBehaviour
    {
        private GhostGameWinChecker winChecker;
        private GhostDataContainer ghostData;
        private IFactory<Vector3, GhostBehavior> factory;
        private AnchorsContainer anchorsContainer;
        private GhostGameLifeCycle lifecycle;
        
        private int actualGhostCount;

        [Inject]
        public void Construct(
            GhostDataContainer ghostData, 
            IFactory<Vector3, GhostBehavior> factory,
            GhostGameWinChecker winChecker, 
            AnchorsContainer anchorsContainer,
            GhostGameLifeCycle lifecycle)
        {
            this.ghostData = ghostData;
            this.factory = factory;
            this.winChecker = winChecker;
            this.anchorsContainer = anchorsContainer;
            this.lifecycle = lifecycle;
        }

        private void Awake() => 
            Subscribe();

        private void OnDestroy() => 
            UnSubscribe();
        
        private void Subscribe() => 
            lifecycle.OnGameStarted += Execute;

        private void UnSubscribe() => 
            lifecycle.OnGameStarted -= Execute;

        public void DecreasingActualGhostCount() =>
            actualGhostCount--;

        private void Execute(object sender, EventArgs eventArgs) => 
            StartCoroutine(Spawning());

        private IEnumerator Spawning()
        {
            while (!winChecker.IsWin)
            {
                yield return new WaitUntil(() => actualGhostCount < ghostData.AllowingGhostCountOnScene);
                Spawn();
            }
        }

        private void Spawn()
        {
            if (winChecker.IsWin)
                return;

            var xPosition = Random.Range(anchorsContainer.LeftXAnchor.x, anchorsContainer.RightXAnchor.x);
            var spawnPosition = new Vector3(xPosition, anchorsContainer.BottomYAnchor.y, 0);

            factory.Create(spawnPosition);
            
            actualGhostCount++;
        }
    }
}