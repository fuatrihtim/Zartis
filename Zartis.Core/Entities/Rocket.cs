namespace Zartis.Core.Entities
{
    public class Rocket
    {
        public string Name { get; }

        public LandingZone LandingZone { get; }

        public Rocket(string name, LandingZone landingZone)
        {
            Name = name;
            LandingZone = landingZone;
        }
    }
}
