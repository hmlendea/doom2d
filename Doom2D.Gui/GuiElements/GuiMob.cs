using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NuciXNA.Graphics.Drawing;
using NuciXNA.Gui.GuiElements;
using NuciXNA.Primitives;

using Doom2D.GameLogic.GameManagers;
using Doom2D.Gui.MobAnimationEffects;
using Doom2D.Models;
using Doom2D.Settings;

namespace Doom2D.Gui.GuiElements
{
    public class GuiMob : GuiElement
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

        public override void LoadContent()
        {
            mob = entities.GetMob(MobId);

            bodyEffect = new HumanSpriteSheetEffect();

            body = new TextureSprite
            {
                ContentFile = "SpriteSheets/Mobs/marine",
                SourceRectangle = new Rectangle2D(Point2D.Empty, Size),
                SpriteSheetEffect = bodyEffect,
                Active = true
            };

            body.LoadContent();

            base.LoadContent();

            body.SpriteSheetEffect.Activate();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            body.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            body.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            body.Draw(spriteBatch);
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            bodyEffect.Action = mob.Action;
            bodyEffect.Direction = mob.Direction;
            body.Location = new Point2D(
                Location.X + (body.SourceRectangle.Width - GameDefines.MapTileSize) / 2,
                Location.Y);
        }
    }
}