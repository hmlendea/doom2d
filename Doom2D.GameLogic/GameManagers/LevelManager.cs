using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.Xna.Framework;

using Doom2D.DataAccess.Repositories;
using Doom2D.GameLogic.Mapping;
using Doom2D.Models;
using Doom2D.Settings;

namespace Doom2D.GameLogic.GameManagers
{
    public sealed class LevelManager : ILevelManager
    {
        List<Level> levels;
        Level level;

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {
            string levelsPath = Path.Combine(ApplicationPaths.DataDirectory, "levels.xml");
            LevelRepository levelRepository = new LevelRepository(levelsPath);
            levels = levelRepository.GetAll().ToDomainModels().ToList();

            level = levels.FirstOrDefault(x => x.Id == "test"); // TODO: Remove test data
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {
            level = null;
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
            return level.Tiles[x, y];
        }
    }
}
