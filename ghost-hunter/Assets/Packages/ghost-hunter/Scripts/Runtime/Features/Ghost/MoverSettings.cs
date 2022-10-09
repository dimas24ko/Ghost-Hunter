using System;

namespace GhostHunter.Runtime.Features.Ghost
{
    [Serializable]
    public class MoverSettings
    {
        public float MaxYDelta;
        public float MinYDelta;
        public float MaxXDelta;
        public float MinXDelta;
        public float MinSpeed;
        public float MaxSpeed;
    }
}