using System.Collections.Generic;
using System.Linq;

namespace Zartis.Core.Entities
{
    public class LandingPlatform
    {
        public int XAxisOfStartPoint { get; }

        public int XAxisOfEndPoint { get; }

        public int YAxisOfStartPoint { get;}

        public int YAxisOfEndPoint { get; }

        public List<LandingZone> ReservedAreas { get; }

        public LandingPlatform(int xAxisOfStartPoint, int xAxisOfEndPoint, int yAxisOfStartPoint, int yAxisOfEndPoint)
        {
            ReservedAreas = new List<LandingZone>();
            XAxisOfStartPoint = xAxisOfStartPoint;
            XAxisOfEndPoint = xAxisOfEndPoint;
            YAxisOfStartPoint = yAxisOfStartPoint;
            YAxisOfEndPoint = yAxisOfEndPoint;
        }

        public bool IsInLandingPlatform(int x, int y)
        {
            return XAxisOfStartPoint <= x &&  XAxisOfEndPoint >= x && YAxisOfStartPoint <= y && YAxisOfEndPoint >= y;
        }

        public bool IsInReservedArea(int x, int y)
        {
            if (ReservedAreas.Count == 0)
            {
                return false;
            }

            return !ReservedAreas.All(reservedArea => x > reservedArea.X + 1 && reservedArea.X - 1 > x && y > reservedArea.Y + 1 && reservedArea.Y - 1 > y);
        }
    }
}