using System.Collections.Generic;

using NuciXNA.DataAccess.DataObjects;

namespace Doom2D.DataAccess.DataObjects
{
    public sealed class WorldObjectEntity : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MinimapColour { get; set; }
    }
}
