using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Doom2D.Models;

namespace Doom2D.GameLogic.GameManagers
{
    public interface IEntityManager
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

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="id">Identifier.</param>
        Item GetItem(string id);

        /// <summary>
        /// Gets the mob.
        /// </summary>
        /// <returns>The mob.</returns>
        /// <param name="id">Identifier.</param>
        Mob GetMob(string id);

        MobDefinition GetMobDefinition(string id);

        IEnumerable<Mob> GetMobs();

        IEnumerable<MobDefinition> GetMobDefinitions();

        /// <summary>
        /// Gets the terrain.
        /// </summary>
        /// <returns>The terrain.</returns>
        /// <param name="id">Identifier.</param>
        Terrain GetTerrain(string id);

        IEnumerable<Terrain> GetTerrains();

        WorldObject GetWorldObject(string id);

        IEnumerable<WorldObject> GetWorldObjects();

        Mob GetPlayer();
    }
}
