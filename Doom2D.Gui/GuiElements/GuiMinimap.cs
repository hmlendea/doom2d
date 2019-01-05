using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using NuciXNA.DataAccess.Resources;
using NuciXNA.Graphics.Drawing;
using NuciXNA.Gui.GuiElements;
using NuciXNA.Primitives;

using Doom2D.GameLogic.GameManagers;
using Doom2D.Models;

namespace Doom2D.Gui.GuiElements
{
    public class GuiMinimap : GuiElement
    {
        readonly IEntityManager entities;
        readonly IWorldManager world;
        readonly IGameManager game;

        Mob player;

        TextureSprite pixel;
        TextureSprite mobDot;

        public Rectangle2D MinimapArea
        {
            get
            {
                int minimapSize = 135;

                return new Rectangle2D(
                    (Size.Width - minimapSize) / 2,
                    (Size.Height - minimapSize) / 2,
                    minimapSize,
                    minimapSize);
            }
        }

        public Rectangle2D DisplayedWorldView
        {
            get
            {
                return new Rectangle2D(
                    (int)player.Location.X - MinimapArea.Width / 2 / ZoomLevel,
                    (int)player.Location.Y - MinimapArea.Height / 2 / ZoomLevel,
                    MinimapArea.Size / ZoomLevel);
            }
        }

        public bool IsClickable { get; set; }

        public int ZoomLevel { get; set; }

        public GuiMinimap(
            IEntityManager entities,
            IWorldManager world,
            IGameManager game)
        {
            this.entities = entities;
            this.world = world;
            this.game = game;

            IsClickable = true;
            ZoomLevel = 2;
        }

        public override void LoadContent()
        {
            pixel = new TextureSprite
            {
                ContentFile = "ScreenManager/FillImage",
                Scale = new Scale2D(ZoomLevel)
            };
            mobDot = new TextureSprite
            {
                ContentFile = "Interface/Minimap/entity_dot"
            };

            player = entities.GetPlayer();

            pixel.LoadContent();
            mobDot.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            pixel.Update(gameTime);
            mobDot.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawMinimapTerrain(spriteBatch);
            DrawMinimapEntities(spriteBatch);

            base.Draw(spriteBatch);
        }

        void DrawMinimapTerrain(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < DisplayedWorldView.Height; y++)
            {
                for (int x = 0; x < DisplayedWorldView.Width; x++)
                {
                    Point2D location = new Point2D(x * ZoomLevel, y * ZoomLevel);

                    WorldTile tile = world.GetTile(DisplayedWorldView.X + x + 1, DisplayedWorldView.Y + y + 1);

                    Colour pixelColour = Colour.Black;

                    if (tile.HasWorldObject)
                    {
                        WorldObject worldObject = entities.GetWorldObject(tile.WorldObjectId);
                        pixelColour = worldObject.MinimapColour;
                    }
                    else if (tile.HasTerrain)
                    {
                        Terrain terrain = entities.GetTerrain(tile.TerrainId);
                        pixelColour = terrain.MinimapColour;
                    }

                    DrawMinimapPixel(spriteBatch, pixelColour, location);
                }
            }
        }

        void DrawMinimapEntities(SpriteBatch spriteBatch)
        {
            foreach (Mob mob in entities.GetMobs())
            {
                Point2D mobLocation = new Point2D((int)mob.Location.X, (int)mob.Location.Y);

                if (!DisplayedWorldView.Contains(mobLocation))
                {
                    continue;
                }

                Point2D location = (mobLocation - DisplayedWorldView.Location) * ZoomLevel;

                DrawMinimapDot(spriteBatch, location, Colour.Yellow);
            }
        }

        void DrawMinimapDot(SpriteBatch spriteBatch, Point2D location, Colour colour)
        {
            Point2D screenLocation = Location + MinimapArea.Location + location + new Point2D(mobDot.SpriteSize / 2);

            if (!ClientRectangle.Contains(screenLocation))
            {
                return;
            }

            mobDot.Tint = colour;
            mobDot.Location = screenLocation;

            mobDot.Draw(spriteBatch);
        }

        void DrawMinimapPixel(SpriteBatch spriteBatch, Colour colour, Point2D location)
        {
            Point2D elementLocation = MinimapArea.Location + location;
            Point2D screenLocation = Location + elementLocation;

            if (!ClientRectangle.Contains(screenLocation))
            {
                return;
            }

            pixel.Tint = colour;
            pixel.Location = screenLocation;

            // TODO: Opacity changing doesn't work properly
            //pixel.Opacity = alphaMask[screenLocation.X - Location.X, screenLocation.Y - Location.Y];

            pixel.Draw(spriteBatch);
        }
    }
}
