namespace Zartis.Core.Entities
{
    public class LandingArea
    {
        public int XAxisOfEndPoint { get; }

        public int YAxisOfEndPoint { get; }

        public LandingArea(int xAxisOfEndPoint, int yAxisOfEndPoint)
        {
            XAxisOfEndPoint = xAxisOfEndPoint;
            YAxisOfEndPoint = yAxisOfEndPoint;
        }

        public bool IsInLandingArea(int xAxisOfStartPoint, int xAxisOfEndPoint, int yAxisOfStartPoint, int yAxisOfEndPoint)
        {
            return 0 <= xAxisOfStartPoint && XAxisOfEndPoint >= xAxisOfEndPoint && 0 <= yAxisOfStartPoint && YAxisOfEndPoint >= yAxisOfEndPoint;
        }
    }
}
