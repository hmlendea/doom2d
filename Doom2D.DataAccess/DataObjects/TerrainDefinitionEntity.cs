using NuciDAL.DataObjects;

namespace Doom2D.DataAccess.DataObjects
{
    public sealed class TerrainEntity : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MinimapColour { get; set; }
    }
}
