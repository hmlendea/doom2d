using Microsoft.Xna.Framework;
using NuciXNA.Graphics.SpriteEffects;
using NuciXNA.Input;
using NuciXNA.Primitives;

namespace Doom2D.Gui.SpriteEffects
{
    public class ButtonSpriteSheetEffect : SpriteSheetEffect
    {
        public ButtonSpriteSheetEffect()
        {
            FrameAmount = new Size2D(3, 1);
        }

        public override void UpdateFrame(GameTime gameTime)
        {
            if (Sprite.ClientRectangle.Contains(InputManager.Instance.MouseLocation))
            {
                CurrentFrame = new Point2D(1, 0);
            }
            else
            {
                CurrentFrame = new Point2D(0, 0);
            }
        }
    }
}
