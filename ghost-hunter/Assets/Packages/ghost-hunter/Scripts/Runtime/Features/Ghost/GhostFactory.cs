using GhostHunter.Runtime.Extensions;
using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Features.Ghost
{
    public class GhostFactory : IFactory<Vector3,GhostBehavior>
    {
        private DiContainer container;
        private GhostDataContainer ghostData;

        public GhostFactory(GhostDataContainer ghostData, DiContainer container)
        {
            this.ghostData = ghostData;
            this.container = container;
        }

        public GhostBehavior Create(Vector3 position)
        {
            var newGhost = container.InstantiateInjectablePrefab(ghostData.GhostPrefab, position);
            var behavior = newGhost.GetComponent<GhostBehavior>();
            
            return behavior;
        }
    }
}