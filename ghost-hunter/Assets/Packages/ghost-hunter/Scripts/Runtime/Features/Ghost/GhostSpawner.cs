using System.Collections;
using GhostHunter.Runtime.Features.GamesInfo;
using GhostHunter.Runtime.Features.LifeCycle;
using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Features.Ghost
{
    public class GhostSpawner : MonoBehaviour
    {
        private GhostGameWinChecker winChecker;
        private GhostDataContainer ghostData;
        private IFactory<Vector3, GhostBehavior> factory;
        private AnchorsContainer anchorsContainer;

        private int actualGhostCount;

        [Inject]
        public void Construct(
            GhostDataContainer ghostData, 
            IFactory<Vector3, GhostBehavior> factory,
            GhostGameWinChecker winChecker, 
            AnchorsContainer anchorsContainer)
        {
            this.ghostData = ghostData;
            this.factory = factory;
            this.winChecker = winChecker;
            this.anchorsContainer = anchorsContainer;
        }

        public void DecreasingActualGhostCount() =>
            actualGhostCount--;

        public void Execute() => 
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
            var xPosition = Random.Range(anchorsContainer.LeftXAnchor.x, anchorsContainer.RightXAnchor.x);
            var spawnPosition = new Vector3(xPosition, anchorsContainer.YAnchor.y);

            factory.Create(spawnPosition);
            
            actualGhostCount++;
        }
    }
}