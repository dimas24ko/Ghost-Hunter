using System;

namespace GhostHunter.Runtime.Features.LifeCycle
{
    public interface ILifeCycle
    {
        event EventHandler OnGameStarted;
        event EventHandler OnGameEnded;

        void StartGame();
        void EndGame();
    }
}