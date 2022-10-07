using System;
using GhostHunter.Runtime.Features.LifeCycle;
using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Features.Ghost
{
    public class GhostBehavior : MonoBehaviour
    {
        public GhostMover Mover;
        public GhostTouchInput Input;

        private PointsCounter pointsCounter;
        private GhostGameLifeCycle lifeCycle;

        [Inject]
        public void Construct(GhostGameLifeCycle lifeCycle) => 
            this.lifeCycle = lifeCycle;

        private void Awake() => 
            Subscribe();
        
        private void Start() => 
            Mover.Execute();

        private void Subscribe()
        {
            lifeCycle.Win += OnWinAction;
            Input.DownTouch += TouchReaction;
        }

        private void TouchReaction()
        {
            pointsCounter.IncrementPointsCount();;
            Destroy();
        }

        private void OnWinAction(object sender, EventArgs args) =>
            Destroy();

        private void Destroy() => 
            Destroy(gameObject);
    }
}