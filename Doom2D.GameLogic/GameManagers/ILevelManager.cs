using Microsoft.Xna.Framework;

using Doom2D.Models;
using NuciXNA.Primitives;

namespace Doom2D.GameLogic.GameManagers
{
    public interface ILevelManager
    {
        /// <summary>
        /// Loads the content.
        /// </summary>
        void LoadContent();

        /// <summary>
        /// Unloads the content.
        /// </summary>
        void UnloadContent();

        /// <summary>
        /// Update the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        void Update(GameTime gameTime);

        Size2D GetSize();

        WorldTile GetTile(int x, int y);
    }
}
