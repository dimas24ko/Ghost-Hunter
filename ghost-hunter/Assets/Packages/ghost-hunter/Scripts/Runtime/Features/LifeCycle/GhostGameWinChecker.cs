using GhostHunter.Runtime.Features.GamesInfo;
using GhostHunter.Runtime.Features.Ghost;
using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Features.LifeCycle
{
    public class GhostGameWinChecker : IInitializable
    {
        private PointsCounter pointsCounter;
        private GhostGameInformation gameInformation;
        private GhostGameLifeCycle lifeCycle;

        public bool IsWin => pointsCounter.PointsCount == gameInformation.PointToWin;

        public GhostGameWinChecker(PointsCounter pointsCounter, GhostGameInformation gameInformation, GhostGameLifeCycle lifeCycle)
        {
            this.pointsCounter = pointsCounter;
            this.gameInformation = gameInformation;
            this.lifeCycle = lifeCycle;
        }
        
        public void Initialize() => 
            Subscribe();

        private void Subscribe() => 
            pointsCounter.PointChanged += Execute;

        private void Execute()
        {
            if (IsWin) 
                lifeCycle.OnWin();
        }
    }
}