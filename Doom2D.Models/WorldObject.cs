using NuciXNA.Primitives;

namespace Doom2D.Models
{
    public sealed class WorldObject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Colour MinimapColour { get; set; }

        public bool Passable { get; set; }
    }
}
