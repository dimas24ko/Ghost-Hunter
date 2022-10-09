using GhostHunter.Runtime.Extensions;
using GhostHunter.Runtime.Features.GamesInfo;
using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Features.Ghost
{
    public class GhostFactory : IFactory<Vector3,GhostBehavior>
    {
        private DiContainer container;
        private GhostDataContainer ghostData;
        private AnchorsContainer anchorsContainer;

        public GhostFactory(GhostDataContainer ghostData, DiContainer container, AnchorsContainer anchorsContainer)
        {
            this.ghostData = ghostData;
            this.container = container;
            this.anchorsContainer = anchorsContainer;
        }

        public GhostBehavior Create(Vector3 position)
        {
            var newGhost = container.InstantiateInjectablePrefab(ghostData.GhostPrefab, position, anchorsContainer.GhostsParent);
            var behavior = newGhost.GetComponent<GhostBehavior>();
            
            return behavior;
        }
    }
}