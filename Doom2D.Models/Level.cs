using NuciXNA.Primitives;

using Doom2D.Settings;

namespace Doom2D.Models
{
    public class Level
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Colour BackgroundColour { get; set; }

        public Size2D Size { get; set; }

        public WorldTile[,] Tiles { get; set; }
    }
}
