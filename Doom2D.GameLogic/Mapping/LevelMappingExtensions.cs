using System.Collections.Generic;
using System.Linq;

using NuciXNA.Primitives;
using NuciXNA.Primitives.Mapping;

using Doom2D.DataAccess.DataObjects;
using Doom2D.Models;

namespace Doom2D.GameLogic.Mapping
{
    /// <summary>
    /// Level mapping extensions for converting between entities and domain models.
    /// </summary>
    static class LevelMappingExtensions
    {
        /// <summary>
        /// Converts a <see cref="LevelEntity"/> data object into <see cref="Level"/> domain model.
        /// </summary>
        /// <returns>The <see cref="Level"/> domain model.</returns>
        /// <param name="levelEntity">The <see cref="LevelEntity"/> data object.</param>
        internal static Level ToDomainModel(this LevelEntity levelEntity)
        {
            Level level = new Level
            {
                Id = levelEntity.Id,
                Name = levelEntity.Name,
                Description = levelEntity.Description,
                Size = new Size2D(levelEntity.Width, levelEntity.Height),
                BackgroundColour = ColourTranslator.FromHexadecimal(levelEntity.BackgroundColour),
                Tiles = new WorldTile[levelEntity.Width, levelEntity.Height]
            };
            
            foreach (TerrainInstanceEntity terrainInstance in levelEntity.Terrain)
            {
                if (level.Tiles[terrainInstance.LocationX, terrainInstance.LocationY] == null)
                {
                    level.Tiles[terrainInstance.LocationX, terrainInstance.LocationY] = new WorldTile();
                }

                level.Tiles[terrainInstance.LocationX, terrainInstance.LocationY].TerrainId = terrainInstance.TerrainId;
            }

            foreach (WorldObjectInstanceEntity worldObjectInstance in levelEntity.WorldObjects)
            {
                if (level.Tiles[worldObjectInstance.LocationX, worldObjectInstance.LocationY] == null)
                {
                    level.Tiles[worldObjectInstance.LocationX, worldObjectInstance.LocationY] = new WorldTile();
                }

                level.Tiles[worldObjectInstance.LocationX, worldObjectInstance.LocationY].WorldObjectId = worldObjectInstance.WorldObjectId;
            }

            return level;
        }

        /// <summary>
        /// Converts the <see cref="Level"/> domain model into a <see cref="LevelEntity"/> data object.
        /// </summary>
        /// <returns>The <see cref="LevelEntity"/> data object.</returns>
        /// <param name="level">The <see cref="Level"/> domain model.</param>
        internal static LevelEntity ToEntity(this Level level)
        {
            LevelEntity levelEntity = new LevelEntity
            {
                Id = level.Id,
                Name = level.Name,
                Description = level.Description,
                BackgroundColour = level.BackgroundColour.ToHexadecimal(),
                Terrain = new List<TerrainInstanceEntity>(),
                WorldObjects = new List<WorldObjectInstanceEntity>()
            };

            for (int y = 0; y < level.Size.Height; y++)
            {
                for (int x = 0; x < level.Size.Width; x++)
                {
                    if (level.Tiles[x, y] == null)
                    {
                        continue;
                    }

                    if (level.Tiles[x, y].HasTerrain)
                    {
                        TerrainInstanceEntity terrainInstanceEntity = new TerrainInstanceEntity
                        {
                            TerrainId = level.Tiles[x, y].TerrainId,
                            LocationX = x,
                            LocationY = y
                        };

                        levelEntity.Terrain.Add(terrainInstanceEntity);
                    }

                    if (level.Tiles[x, y].HasWorldObject)
                    {
                        WorldObjectInstanceEntity worldObjectInstanceEntity = new WorldObjectInstanceEntity
                        {
                            WorldObjectId = level.Tiles[x, y].WorldObjectId,
                            LocationX = x,
                            LocationY = y
                        };

                        levelEntity.WorldObjects.Add(worldObjectInstanceEntity);
                    }
                }
            }

            return levelEntity;
        }

        /// <summary>
        /// Converts the <see cref="LevelEntity"/> data object collection into a <see cref="Level"/> domain model collection.
        /// </summary>
        /// <returns>The <see cref="Level"/> domain model collection.</returns>
        /// <param name="levelEntities">The <see cref="LevelEntity"/> data object collection.</param>
        internal static IEnumerable<Level> ToDomainModels(this IEnumerable<LevelEntity> levelEntities)
        {
            IEnumerable<Level> levels = levelEntities.Select(levelEntity => levelEntity.ToDomainModel());

            return levels;
        }

        /// <summary>
        /// Converts the <see cref="Level"/> domain model collection into a <see cref="LevelEntity"/> data object collection.
        /// </summary>
        /// <returns>The <see cref="LevelEntity"/> data object collection.</returns>
        /// <param name="levels">The <see cref="Level"/> domain model collection.</param>
        internal static IEnumerable<LevelEntity> ToEntities(this IEnumerable<Level> levels)
        {
            IEnumerable<LevelEntity> levelEntities = levels.Select(level => level.ToEntity());

            return levelEntities;
        }
    }
}
