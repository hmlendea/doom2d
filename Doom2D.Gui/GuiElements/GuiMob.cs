using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NuciXNA.Graphics.Drawing;
using NuciXNA.Primitives;

using Doom2D.GameLogic.GameManagers;
using Doom2D.Gui.MobAnimationEffects;
using Doom2D.Models;
using Doom2D.Settings;
using NuciXNA.Gui.Controls;

namespace Doom2D.Gui.GuiElements
{
    public class GuiMob : GuiControl
    {
        readonly IEntityManager entities;

        Mob mob;

        TextureSprite body;
        HumanSpriteSheetEffect bodyEffect;

        public string MobId { get; }

        public GuiMob(IEntityManager entities, string mobId)
        {
            this.entities = entities;

            MobId = mobId;
            Size = new Size2D(64, 64);
        }

        protected override void DoLoadContent()
        {
            mob = entities.GetMob(MobId);

            bodyEffect = new HumanSpriteSheetEffect();

            body = new TextureSprite
            {
                ContentFile = "SpriteSheets/Mobs/marine",
                SourceRectangle = new Rectangle2D(Point2D.Empty, Size),
                SpriteSheetEffect = bodyEffect,
                IsActive = true
            };

            body.LoadContent();

            body.SpriteSheetEffect.Activate();

            SetChildrenProperties();
        }

        protected override void DoUnloadContent()
        {
            body.UnloadContent();
        }

        protected override void DoUpdate(GameTime gameTime)
        {
            body.Update(gameTime);

            SetChildrenProperties();
        }

        protected override void DoDraw(SpriteBatch spriteBatch)
        {
            body.Draw(spriteBatch);
        }

        void SetChildrenProperties()
        {
            bodyEffect.Action = mob.Action;
            bodyEffect.Direction = mob.Direction;
            body.Location = new Point2D(
                Location.X + (body.SourceRectangle.Width - GameDefines.MapTileSize) / 2,
                Location.Y);
        }
    }
}