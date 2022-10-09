using UnityEngine;

namespace GhostHunter.Runtime.Features.GamesInfo
{
    public class AnchorsContainer : MonoBehaviour
    {
        public Transform GhostsParent;
        
        public Vector3 RightXAnchor => Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0));
        public Vector3 LeftXAnchor => Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        
        public Vector3 TopYAnchor => Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
        public Vector3 BottomYAnchor => Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }
}