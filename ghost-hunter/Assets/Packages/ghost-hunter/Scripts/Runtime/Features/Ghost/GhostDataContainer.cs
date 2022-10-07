using UnityEngine;

namespace GhostHunter.Runtime.Features.Ghost
{
    [CreateAssetMenu(fileName = "GhostData", menuName = "Data/Gameplay/Ghost")]
    public class GhostDataContainer : ScriptableObject
    {
        public GameObject GhostPrefab;
        public float TimeStepToSpawn;
        public int AllowingGhostCountOnScene;
    }
}