using Zartis.Core.Entities;
using Zartis.Service.Services;

namespace Zartis
{
    class Program
    {
        static void Main(string[] args)
        {
            LandingArea landingArea = new LandingArea(100, 100);
            LandingPlatform landingPlatform = new LandingPlatform(5, 10, 5, 10);
            LandingService landingService = new LandingService(landingPlatform, landingArea);
            Rocket rocket = new Rocket("TestRocket1", new LandingZone(5, 6));
            Rocket rocket2 = new Rocket("TestRocket2", new LandingZone(6, 7));

            var result = landingService.LandRocket(rocket); //OkForLanding
            var result2 = landingService.LandRocket(rocket2); //Clash
        }
    }
}