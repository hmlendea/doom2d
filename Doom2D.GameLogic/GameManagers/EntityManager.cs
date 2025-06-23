using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.Xna.Framework;
using NuciXNA.Primitives;

using Doom2D.GameLogic.Mapping;
using Doom2D.Models;
using Doom2D.Settings;
using NuciDAL.Repositories;
using Doom2D.DataAccess.DataObjects;

namespace Doom2D.GameLogic.GameManagers
{
    public class EntityManager : IEntityManager
    {
        string playerId = "player1";

        List<Item> items;
        Dictionary<string, Mob> mobs;
        List<MobDefinition> mobDefinitions;
        List<Terrain> terrainDefinitions;
        List<WorldObject> objectDefinitions;

        /// <summary>
        /// Loads the entities in memory.
        /// </summary>
        public void LoadContent()
        {
            string itemPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "items.xml");
            string mobPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "mobs.xml");
            string prayerPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "prayers.xml");
            string spellPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "spells.xml");
            string terrainsPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "terrains.xml");
            string worldObjectsPath = Path.Combine(ApplicationPaths.EntitiesDirectory, "worldObjects.xml");

            XmlRepository<ItemEntity> itemRepository = new(itemPath);
            XmlRepository<MobEntity> mobRepository = new(mobPath);
            XmlRepository<TerrainEntity> terrainRepository = new(terrainsPath);
            XmlRepository<WorldObjectEntity> worldObjectRepository = new(worldObjectsPath);

            items = itemRepository.GetAll().ToDomainModels().ToList();
            mobDefinitions = mobRepository.GetAll().ToDomainModels().ToList();
            terrainDefinitions = terrainRepository.GetAll().ToDomainModels().ToList();
            objectDefinitions = worldObjectRepository.GetAll().ToDomainModels().ToList();

            mobs = new Dictionary<string, Mob>();

            Mob player = new Mob();
            player.Id = playerId;
            player.MobId = "player";

            mobs.Add(player.Id, player);

            mobs.Add("mobtest", new Mob
            {
                Id = "mobtest",
                MobId = "player",
                Location = new PointF2D(4, 6)
            });
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {
            items.Clear();
            mobs.Clear();
            terrainDefinitions.Clear();
            objectDefinitions.Clear();
        }

        /// <summary>
        /// Update the content.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="id">Identifier.</param>
        public Item GetItem(string id)
        => items.FirstOrDefault(x => x.Id == id);

        /// <summary>
        /// Gets the mob.
        /// </summary>
        /// <returns>The mob.</returns>
        /// <param name="id">Identifier.</param>
        public Mob GetMob(string id)
        => mobs[id];

        public MobDefinition GetMobDefinition(string id)
        {
            return mobDefinitions.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Mob> GetMobs()
        {
            return mobs.Values;
        }

        public IEnumerable<MobDefinition> GetMobDefinitions()
        {
            return mobDefinitions;
        }

        /// <summary>
        /// Gets the terrain.
        /// </summary>
        /// <returns>The terrain.</returns>
        /// <param name="id">Identifier.</param>
        public Terrain GetTerrain(string id)
        => terrainDefinitions.FirstOrDefault(x => x.Id == id);

        /// <summary>
        /// Gets the world object.
        /// </summary>
        /// <returns>The world object.</returns>
        /// <param name="id">Identifier.</param>
        public WorldObject GetWorldObject(string id)
        => objectDefinitions.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Terrain> GetTerrains()
        => terrainDefinitions;

        public IEnumerable<WorldObject> GetWorldObjects()
        => objectDefinitions;

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns>The player.</returns>
        public Mob GetPlayer()
        {
            return GetMob(playerId);
        }
    }
}
