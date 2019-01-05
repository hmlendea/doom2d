using NuciXNA.Primitives;

namespace Doom2D.Models
{
    public sealed class WorldTile
    {
        public Point2D WorldLocation { get; set; }

        public string TerrainId { get; set; }

        public string WorldObjectId { get; set; }

        public bool HasTerrain => !string.IsNullOrWhiteSpace(TerrainId);

        public bool HasWorldObject => !string.IsNullOrWhiteSpace(WorldObjectId);
    }
}
