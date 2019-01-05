using NuciXNA.Primitives;

namespace Doom2D.Models
{
    public sealed class Mob
    {
        public string Id { get; set; }

        public string MobId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public PointF2D Location { get; set; }

        public MobAction Action { get; set; }

        public MobDirection Direction { get; set; }

        public Mob()
        {
            Direction = MobDirection.South;
        }
    }
}
