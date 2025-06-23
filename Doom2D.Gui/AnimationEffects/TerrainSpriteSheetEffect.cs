using Microsoft.Xna.Framework;
using NuciXNA.Graphics.SpriteEffects;
using NuciXNA.Primitives;

using Doom2D.Models;

namespace Doom2D.Gui.MobAnimationEffects
{
    public class TerrainSpriteSheetEffect : SpriteSheetEffect
    {
        public TerrainVariation Variation { get; set; }

        public TerrainSpriteSheetEffect()
        {
            FrameAmount = new Size2D(3, 6);
        }

        protected override void DoUpdate(GameTime gameTime)
        {
            CurrentFrame = new Point2D(
                (int)Variation % FrameAmount.Width,
                (int)Variation / FrameAmount.Width);
        }
    }
}
