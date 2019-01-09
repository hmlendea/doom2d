using Microsoft.Xna.Framework;

using Doom2D.Models;

using NuciXNA.Primitives;

namespace Doom2D.GameLogic.GameManagers
{
    /// <summary>
    /// Game manager.
    /// </summary>
    public class GameManager : IGameManager
    {
        Mob player;

        readonly IEntityManager entityManager;
        readonly ILevelManager worldManager;

        public GameManager(
            IEntityManager entityManager,
            ILevelManager worldManager)
        {
            this.entityManager = entityManager;
            this.worldManager = worldManager;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {
            player = entityManager.GetPlayer();

            player.Location = new PointF2D(64, 64);
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {
        }

        /// <summary>
        /// Update the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Update(GameTime gameTime)
        {

        }
    }
}
