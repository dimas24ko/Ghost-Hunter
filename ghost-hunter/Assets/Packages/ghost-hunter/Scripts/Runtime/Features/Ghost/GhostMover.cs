using System.Collections;
using System.Runtime.InteropServices;
using DG.Tweening;
using GhostHunter.Runtime.Features.GamesInfo;
using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Features.Ghost
{
    public class GhostMover : MonoBehaviour
    {
        private const float offsetZ = 0;
        
        [SerializeField]
        private MoverSettings settings;

        [SerializeField] 
        private Transform ghost;

        private AnchorsContainer anchorsContainer;

        [Inject]
        public void Construct(AnchorsContainer anchorsContainer) => 
            this.anchorsContainer = anchorsContainer;

        public void Execute()
        {
            var deltaY = Random.Range(settings.MinYDelta, settings.MaxYDelta);
            var deltaX = Random.Range(settings.MinXDelta, settings.MaxXDelta);
            var speed = Random.Range(settings.MinSpeed, settings.MaxSpeed);

            StartCoroutine(Moving(deltaY, deltaX, speed));
        }

        private IEnumerator Moving(float deltaY, float deltaX, float speed)
        {
            while (true)
            {
                var targetPosition = new Vector3(ghost.transform.position.x + deltaX, ghost.transform.position.y + deltaY, offsetZ);
                targetPosition = CalculateTargetPosition(targetPosition);

                ghost.DOMove(targetPosition, speed).OnComplete(() => deltaX = -deltaX);
                
                yield return new WaitForSeconds(speed);
            }
        }

        private Vector3 CalculateTargetPosition(Vector3 targetPosition)
        {
            if (targetPosition.x < anchorsContainer.LeftXAnchor.x)
                targetPosition = new Vector3(anchorsContainer.LeftXAnchor.x, targetPosition.y, offsetZ);

            if (targetPosition.x > anchorsContainer.RightXAnchor.x)
                targetPosition = new Vector3(anchorsContainer.RightXAnchor.x, targetPosition.y, offsetZ);
            
            return targetPosition;
        }
    }
}