using System;
using GhostHunter.Runtime.Features.LifeCycle;
using Zenject;

namespace GhostHunter.Runtime.Features.Ghost
{
    public class PointsCounter : IInitializable
    {
        private GhostGameLifeCycle lifeCycle;

        public int PointsCount { get; private set; }

        public Action PointChanged;

        public PointsCounter(GhostGameLifeCycle lifeCycle) => 
            this.lifeCycle = lifeCycle;

        public void IncrementPointsCount()
        {
            PointsCount++;
            PointChanged.Invoke();
        }

        public void DecrementPointsCount()
        {
            PointsCount--;
            PointChanged.Invoke();
        }

        public void Initialize() => 
            Subscribe();

        private void Subscribe() => 
            lifeCycle.Win += (sender, args) => PointsCount = 0;
    }
}