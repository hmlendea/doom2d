using System.Collections.Generic;

using NuciXNA.DataAccess.DataObjects;

namespace Doom2D.DataAccess.DataObjects
{
    public sealed class LevelEntity : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BackgroundColour { get; set; }

        public byte Width { get; set; }

        public byte Height { get; set; }

        public List<TerrainInstanceEntity> Terrain { get; set; }

        public List<WorldObjectInstanceEntity> WorldObjects { get; set; }
    }
}
