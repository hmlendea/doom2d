using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using NuciXNA.Graphics.Drawing;
using NuciXNA.Gui.GuiElements;
using NuciXNA.Input;
using NuciXNA.Primitives;

using Doom2D.GameLogic.GameManagers;
using Doom2D.Gui.MobAnimationEffects;
using Doom2D.Models;
using Doom2D.Settings;

namespace Doom2D.Gui.GuiElements
{
    public class GuiWorld : GuiElement
    {
        readonly IEntityManager entities;
        readonly IWorldManager world;
        readonly IGameManager game;

        Camera camera;
        Mob player;

        Dictionary<string, Sprite> tileSprites;
        Dictionary<string, Sprite> worldObjects;
        Dictionary<string, GuiMob> mobs;

        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public GuiWorld(
            IEntityManager entities,
            IWorldManager world,
            IGameManager game)
        {
            this.entities = entities;
            this.world = world;
            this.game = game;
        }

        public override void LoadContent()
        {
            player = entities.GetPlayer();

            Rows = Size.Height / GameDefines.MapTileSize + 2;
            Columns = Size.Width / GameDefines.MapTileSize + 2;

            LoadTileSprites();
            LoadWorldObjects();
            LoadMobs();

            foreach (GuiMob mob in mobs.Values)
            {
                AddChild(mob);
            }

            base.LoadContent();
        }

        public override void UnloadContent()
        {
            foreach (Sprite sprite in tileSprites.Values)
            {
                sprite.UnloadContent();
            }

            foreach (Sprite worldObjectSprite in worldObjects.Values)
            {
                worldObjectSprite.UnloadContent();
            }

            foreach (GuiMob mob in mobs.Values)
            {
                mob.UnloadContent();
            }

            tileSprites.Clear();
            worldObjects.Clear();
            mobs.Clear();

            tileSprites = null;
            worldObjects = null;
            mobs = null;

            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Sprite sprite in tileSprites.Values)
            {
                sprite.Update(gameTime);
            }

            foreach (Sprite worldObjectSprite in worldObjects.Values)
            {
                worldObjectSprite.Update(gameTime);
            }

            foreach (GuiMob mob in mobs.Values)
            {
                mob.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawTerrain(spriteBatch);
            DrawWorldObjects(spriteBatch);

            base.Draw(spriteBatch);
        }

        public void AssociateCamera(Camera camera)
        {
            this.camera = camera;
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            foreach (GuiMob mobImage in mobs.Values)
            {
                Mob mob = entities.GetMob(mobImage.MobId);
                mobImage.Location = new Point2D(
                    (int)(mob.Location.X * GameDefines.MapTileSize - camera.Location.X * GameDefines.MapTileSize) - GameDefines.MapTileSize,
                    (int)(mob.Location.Y * GameDefines.MapTileSize - camera.Location.Y * GameDefines.MapTileSize) - GameDefines.MapTileSize
                );
            }
        }

        protected override void RegisterEvents()
        {
            base.RegisterEvents();
        }

        protected override void UnregisterEvents()
        {
            base.UnregisterEvents();
        }


        void LoadTileSprites()
        {
            tileSprites = new Dictionary<string, Sprite>();

            foreach (Terrain terrain in entities.GetTerrains())
            {
                TextureSprite sprite = new TextureSprite
                {
                    ContentFile = $"SpriteSheets/Terrains/{terrain.Id}",
                    SourceRectangle = new Rectangle2D(Point2D.Empty, GameDefines.MapTileSize, GameDefines.MapTileSize),
                    SpriteSheetEffect = new TerrainSpriteSheetEffect
                    {
                        Variation = TerrainVariation.RegularEmpty
                    },
                    Active = true
                };

                sprite.LoadContent();
                sprite.SpriteSheetEffect.Activate();

                if (!tileSprites.ContainsKey(terrain.Id))
                {
                    tileSprites.Add(terrain.Id, sprite);
                }
            }
        }

        void LoadWorldObjects()
        {
            worldObjects = new Dictionary<string, Sprite>();

            foreach (WorldObject worldObject in entities.GetWorldObjects())
            {
                Sprite worldObjectImage = new TextureSprite
                {
                    ContentFile = $"SpriteSheets/WorldObjects/{worldObject.Id}",
                    SourceRectangle = new Rectangle2D(Point2D.Empty, GameDefines.MapTileSize, GameDefines.MapTileSize)
                };

                worldObjectImage.LoadContent();

                worldObjects.Add(worldObject.Id, worldObjectImage);
            }
        }

        void LoadMobs()
        {
            mobs = new Dictionary<string, GuiMob>();

            foreach (Mob mob in entities.GetMobs())
            {
                GuiMob mobImage = new GuiMob(entities, mob.Id);
                mobImage.LoadContent();

                mobs.Add(mob.Id, mobImage);
            }
        }

        void DrawTerrain(SpriteBatch spriteBatch)
        {
            Size2D off = new Size2D(
                (int)((camera.Location.X - (int)camera.Location.X) * GameDefines.MapTileSize),
                (int)((camera.Location.Y - (int)camera.Location.Y) * GameDefines.MapTileSize));

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    WorldTile tile = world.GetTile(
                        (int)camera.Location.X + x,
                        (int)camera.Location.Y + y);
                    Sprite sprite = tileSprites[tile.TerrainId];

                    sprite.Location = new Point2D(
                        (x - 1) * GameDefines.MapTileSize - off.Width,
                        (y - 1) * GameDefines.MapTileSize - off.Height);
                    sprite.Draw(spriteBatch);
                }
            }
        }

        void DrawWorldObjects(SpriteBatch spriteBatch)
        {
            Size2D off = new Size2D(
                (int)((camera.Location.X - (int)camera.Location.X) * GameDefines.MapTileSize),
                (int)((camera.Location.Y - (int)camera.Location.Y) * GameDefines.MapTileSize));

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    WorldTile tile = world.GetTile(
                        (int)camera.Location.X + x,
                        (int)camera.Location.Y + y);

                    if (tile.WorldObjectId == null)
                    {
                        continue;
                    }

                    Sprite worldObjectSprite = worldObjects[tile.WorldObjectId];
                    worldObjectSprite.Location = new Point2D(
                        (x - 1) * GameDefines.MapTileSize - off.Width,
                        (y - 1) * GameDefines.MapTileSize - off.Height);
                    worldObjectSprite.Draw(spriteBatch);
                }
            }
        }
    }
}
