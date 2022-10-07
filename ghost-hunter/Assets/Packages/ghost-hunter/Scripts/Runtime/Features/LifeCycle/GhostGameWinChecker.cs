using GhostHunter.Runtime.Features.GamesInfo;
using GhostHunter.Runtime.Features.Ghost;
using Zenject;

namespace GhostHunter.Runtime.Features.LifeCycle
{
    public class GhostGameWinChecker : IInitializable
    {
        private PointsCounter pointsCounter;
        private GhostGameInformation gameInformation;

        public bool IsWin => pointsCounter.PointsCount >= gameInformation.PointToWin;

        public GhostGameWinChecker(PointsCounter pointsCounter, GhostGameInformation gameInformation)
        {
            this.pointsCounter = pointsCounter;
            this.gameInformation = gameInformation;
        }

        public void Initialize()
        {
        }
    }
}