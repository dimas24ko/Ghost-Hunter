using System;
using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Features.LifeCycle
{
    public class GhostGameStarter : MonoBehaviour
    {
        private GhostGameLifeCycle lifecycle;

        [Inject]
        public void Construct(GhostGameLifeCycle lifecycle) => 
            this.lifecycle = lifecycle;

        private void Start() => 
            lifecycle.StartGame();
    }
}