using NuciXNA.DataAccess.DataObjects;

namespace Doom2D.DataAccess.DataObjects
{
    public sealed class WorldObjectInstanceEntity : EntityBase
    {
        public string WorldObjectId { get; set; }

        public int LocationX { get; set; }

        public int LocationY { get; set; }
    }
}
