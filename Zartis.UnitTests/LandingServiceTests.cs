using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zartis.Core.Entities;
using Zartis.Core.Enums;
using Zartis.Service.Services;

namespace Zartis.UnitTests
{
    public class LandingServiceTests
    {
        [Fact]
        public void LandRocket_Returns_OkForLanding()
        {
            // Arrange
            var landingArea = new LandingArea(100, 100);
            var landingPlatform = new LandingPlatform(5, 10, 5, 10);
            var landingService = new LandingService(landingPlatform, landingArea);
            var rocket = new Rocket("TestRocket", new LandingZone(5, 6));

            // Act
            var result = landingService.LandRocket(rocket);

            // Assert
            Assert.Equal(Availability.OkForLanding, result);
        }

        [Fact]
        public void LandRocket_Returns_Clash()
        {
            var landingArea = new LandingArea(100, 100);
            var landingPlatform = new LandingPlatform(5, 10, 5, 10);
            var landingService = new LandingService(landingPlatform, landingArea);
            var rocket = new Rocket("TestRocket", new LandingZone(5, 6));
            var rocket2 = new Rocket("TestRocket2", new LandingZone(5, 7));

            _ = landingService.LandRocket(rocket);
            var result2 = landingService.LandRocket(rocket2);

            Assert.Equal(Availability.Clash, result2);
        }

        [Fact]
        public void LandRocket_Returns_OutOfPlatform()
        {
            var landingArea = new LandingArea(100, 100);
            var landingPlatform = new LandingPlatform(5, 10, 5, 10);
            var landingService = new LandingService(landingPlatform, landingArea);
            var rocket = new Rocket("TestRocket", new LandingZone(50, 60));

            var result = landingService.LandRocket(rocket);

            Assert.Equal(Availability.OutOfPlatform, result);
        }
    }
}