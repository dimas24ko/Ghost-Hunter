using UnityEngine;

namespace GhostHunter.Runtime.Features.ScenesManagment
{
    [CreateAssetMenu(fileName = "ScenesData", menuName = "Scenes")]
    public class ScenesData : ScriptableObject
    {
        [Header("Scenes Naming")]
        public string MainSceneName;
        public string GhostGameSceneName;
    }
}