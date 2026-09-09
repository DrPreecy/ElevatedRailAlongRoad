using ICities;

namespace ElevatedRailAlongRoad
{
    public sealed class Mod : IUserMod
    {
        public string Name => "Elevated Rail Along Road";

        public string Description =>
            "Creates a separate elevated railway following selected road geometry.";
    }
}
