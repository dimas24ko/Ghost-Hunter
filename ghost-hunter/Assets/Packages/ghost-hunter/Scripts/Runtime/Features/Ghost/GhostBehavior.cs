using System;
using GhostHunter.Runtime.Features.GamesInfo;
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
        private GhostSpawner ghostSpawner;
        private AnchorsContainer anchorsContainer;

        [Inject]
        public void Construct(GhostGameLifeCycle lifeCycle, GhostSpawner ghostSpawner, PointsCounter pointsCounter, AnchorsContainer anchorsContainer)
        {
            this.lifeCycle = lifeCycle;
            this.ghostSpawner = ghostSpawner;
            this.pointsCounter = pointsCounter;
            this.anchorsContainer = anchorsContainer;
        }

        private void Awake() => 
            Subscribe();
        
        private void Start() => 
            Mover.Execute();

        private void Update() => 
            CheckTopBorder();

        private void OnDestroy() => 
            UnSubscribe();

        private void Subscribe()
        {
            lifeCycle.Win += OnWinAction;
            Input.DownTouch += TouchReaction;
        }
        
        private void UnSubscribe()
        {
            lifeCycle.Win -= OnWinAction;
            Input.DownTouch -= TouchReaction;
        }

        private void TouchReaction()
        {
            pointsCounter.IncrementPointsCount();;
            Destroy();
        }

        private void OnWinAction(object sender, EventArgs args) =>
            Destroy(gameObject);

        private void Destroy()
        {
            ghostSpawner.DecreasingActualGhostCount();
            Destroy(gameObject);
        }

        private void CheckTopBorder()
        {
            if (transform.position.y >= anchorsContainer.TopYAnchor.y+1) 
                Destroy();
        }
    }
}