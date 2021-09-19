using System;
using Zartis.Core.Entities;
using Zartis.Core.Enums;

namespace Zartis.Service.Services
{
    public class LandingService
    {
        private readonly LandingPlatform _landingPlatform;
        private readonly LandingArea _landingArea;

        public LandingService(LandingPlatform landingPlatform, LandingArea landingArea)
        {
            _landingPlatform = landingPlatform;
            _landingArea = landingArea;
        }

        public Availability LandRocket(Rocket rocket)
        {
            var availability = CheckIfTrajectoryAvailable(rocket);

            switch (availability)
            {
                case Availability.OutOfPlatform:

                    return Availability.OutOfPlatform;
                case Availability.Clash:

                    return Availability.Clash;
                case Availability.OkForLanding:

                    _landingPlatform.ReservedAreas.Add(rocket.LandingZone);

                    return Availability.OkForLanding;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Availability CheckIfTrajectoryAvailable(Rocket rocket)
        {
            var isInLandingPlatformInLandingArea = _landingArea.IsInLandingArea(_landingPlatform.XAxisOfStartPoint,_landingPlatform.XAxisOfEndPoint,_landingPlatform.YAxisOfStartPoint,_landingPlatform.YAxisOfEndPoint);

            if (!isInLandingPlatformInLandingArea)
            {
                return Availability.OutOfPlatform;
            }

            var isInLandingPlatform = _landingPlatform.IsInLandingPlatform(rocket.LandingZone.X, rocket.LandingZone.Y);

            if (!isInLandingPlatform)
            {
                return Availability.OutOfPlatform;
            }

            var isInReservedArea = _landingPlatform.IsInReservedArea(rocket.LandingZone.X, rocket.LandingZone.Y);

            if (isInReservedArea)
            {
                return Availability.Clash;
            }

            return Availability.OkForLanding;
        }
    }
}
