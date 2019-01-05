using Microsoft.Xna.Framework;

using Doom2D.Models;
using Doom2D.Settings;

namespace Doom2D.GameLogic.GameManagers
{
    public sealed class WorldManager : IWorldManager
    {
        WorldTile[,] tiles;

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {
            tiles = new WorldTile[GameDefines.MaxWorldSize, GameDefines.MaxWorldSize];

            for (int y = 0; y < GameDefines.MaxWorldSize; y++)
            {
                for (int x = 0; x < GameDefines.MaxWorldSize; x++)
                {
                    tiles[x, y] = new WorldTile();
                    tiles[x, y].TerrainId = "metal_floor"; // TODO: Temporary, remove this
                }
            }
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {
            tiles = null;
        }

        /// <summary>
        /// Update the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Update(GameTime gameTime)
        {

        }

        public WorldTile GetTile(int x, int y)
        {
            return tiles[x, y];
        }
    }
}
