using Microsoft.Xna.Framework;
using NuciXNA.Gui;
using NuciXNA.Gui.Screens;
using NuciXNA.Primitives;

using Doom2D.GameLogic.GameManagers;
using Doom2D.Gui.GuiElements;
using Doom2D.Models;

namespace Doom2D.Gui.Screens
{
    /// <summary>
    /// Gameplay screen.
    /// </summary>
    public class GameplayScreen : Screen
    {
        readonly IEntityManager entities;
        readonly IWorldManager world;
        readonly IGameManager game;

        Camera camera;
        Mob player;

        GuiWorld worldView;

        /// <summary>
        /// Gets or sets the minimap.
        /// </summary>
        /// <value>The minimap.</value>
        public GuiMinimap Minimap { get; set; }

        /// <summary>
        /// Gets or sets the minimap.
        /// </summary>
        /// <value>The minimap.</value>

        public GameplayScreen()
        {
            entities = new EntityManager();
            world = new WorldManager();
            game = new GameManager(entities, world);
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public override void LoadContent()
        {

            entities.LoadContent();
            world.LoadContent();
            game.LoadContent();

            camera = new Camera();

            player = entities.GetPlayer();

            worldView = new GuiWorld(entities, world, game);
            worldView.AssociateCamera(camera);

            Minimap = new GuiMinimap(entities, world, game)
            {
                Size = new Size2D(224, 176)
            };

            GuiManager.Instance.GuiElements.Add(worldView);
            GuiManager.Instance.GuiElements.Add(Minimap);

            base.LoadContent();
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public override void UnloadContent()
        {
            entities.UnloadContent();
            world.UnloadContent();
            game.UnloadContent();
            camera.UnloadContent();

            base.UnloadContent();
        }

        /// <summary>
        /// Update the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public override void Update(GameTime gameTime)
        {
            entities.Update(gameTime);
            world.Update(gameTime);
            game.Update(gameTime);
            camera.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void SetChildrenProperties()
        {
            worldView.Size = ScreenManager.Instance.Size;

            Minimap.Location = new Point2D(ScreenManager.Instance.Size.Width - Minimap.Size.Width, 0);
            camera.CentreOnLocation(player.Location);

            base.SetChildrenProperties();
        }
    }
}
