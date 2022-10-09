using System;
using GhostHunter.Runtime.Features.Ghost;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GhostHunter.Runtime.Features.UI
{
    public class ScoreSetter : MonoBehaviour
    {
        public Text ScoreText;

        private PointsCounter pointsCounter;

        [Inject]
        public void Construct(PointsCounter pointsCounter) =>
            this.pointsCounter = pointsCounter;

        private void Awake() =>
            Subscribe();

        private void OnDestroy() => 
            UnSubscribe();

        private void Subscribe() =>
            pointsCounter.PointChanged += Set;

        private void UnSubscribe() => 
            pointsCounter.PointChanged -= Set;

        private void Set() =>
            ScoreText.text = "Score: " + pointsCounter.PointsCount;
    }
}