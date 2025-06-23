using NuciDAL.DataObjects;

namespace Doom2D.DataAccess.DataObjects
{
    public sealed class TerrainInstanceEntity : EntityBase
    {
        public string TerrainId { get; set; }

        public int LocationX { get; set; }

        public int LocationY { get; set; }
    }
}
