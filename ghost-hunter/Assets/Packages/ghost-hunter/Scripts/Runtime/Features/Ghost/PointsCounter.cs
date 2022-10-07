namespace GhostHunter.Runtime.Features.Ghost
{
    public class PointsCounter
    {
        public int PointsCount
        {
            get;
            private set;
        }

        public void IncrementPointsCount() => 
            PointsCount++;

        public void DecrementPointsCount() => 
            PointsCount--;
    }
}