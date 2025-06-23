using Microsoft.Xna.Framework;
using NuciXNA.Graphics;
using NuciXNA.Graphics.SpriteEffects;
using NuciXNA.Primitives;

using Doom2D.Models;

namespace Doom2D.Gui.MobAnimationEffects
{
    public class HumanSpriteSheetEffect : SpriteSheetEffect
    {
        const int SpellcastFrames = 7;
        const int MovementFrames = 9;
        const int MeleeFrames = 6;
        const int RangedFrames = 13;

        public MobAction Action { get; set; }

        public MobDirection Direction { get; set; }

        public HumanSpriteSheetEffect()
        {
            FrameAmount = new Size2D(13, 21);
        }

        protected override void DoUpdate(GameTime gameTime)
        {
            Point2D newFrame = CurrentFrame;

            FrameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (FrameCounter >= SwitchFrame)
            {
                FrameCounter = 0;
                newFrame.X += 1;
            }

            switch (Action)
            {
                case MobAction.SpellCasting:
                    if (newFrame.X >= SpellcastFrames)
                    {
                        newFrame.X = 0;
                    }

                    newFrame.Y = 0;
                    break;

                case MobAction.Idle:
                    newFrame.X = 0;
                    newFrame.Y = 8;
                    break;

                case MobAction.Movement:
                    if (newFrame.X >= MovementFrames)
                    {
                        newFrame.X = 0;
                    }

                    newFrame.Y = 8;
                    break;

                case MobAction.MeleeFighting:
                    if (newFrame.X >= MeleeFrames)
                    {
                        newFrame.X = 0;
                    }

                    newFrame.Y = 12;
                    break;

                case MobAction.RangedFighting:
                    if (newFrame.X >= RangedFrames)
                    {
                        newFrame.X = 0;
                    }

                    newFrame.Y = 16;
                    break;
            }

            var a = Sprite.SourceRectangle;

            newFrame.Y += (int)Direction;
            CurrentFrame = newFrame;
        }
    }
}
