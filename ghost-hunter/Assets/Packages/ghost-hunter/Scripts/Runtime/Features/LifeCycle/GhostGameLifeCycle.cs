using System;

namespace GhostHunter.Runtime.Features.LifeCycle
{
    public class GhostGameLifeCycle : ILifeCycle
    {
        public event EventHandler OnGameStarted;
        public event EventHandler OnGameEnded;
        public event EventHandler Win;
        
        public void StartGame() => 
            OnGameStarted?.Invoke(this, EventArgs.Empty);

        public void EndGame() => 
            OnGameEnded?.Invoke(this, EventArgs.Empty);

        public void OnWin() => 
            Win?.Invoke(this, EventArgs.Empty);
    }
}