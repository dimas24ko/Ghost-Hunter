using UnityEngine;

namespace GhostHunter.Runtime.Features.GamesInfo
{
    [CreateAssetMenu(fileName = "GhostGameInformation", menuName = "GamesInfo")]
    public class GhostGameInformation : ScriptableObject
    {
        public int PointToWin;
    }
}