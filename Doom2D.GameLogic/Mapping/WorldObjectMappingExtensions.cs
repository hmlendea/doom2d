using System.Collections.Generic;
using System.Linq;

using NuciXNA.Primitives.Mapping;

using Doom2D.DataAccess.DataObjects;
using Doom2D.Models;

namespace Doom2D.GameLogic.Mapping
{
    /// <summary>
    /// WorldObject mapping extensions for converting between entities and domain models.
    /// </summary>
    static class WorldObjectMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="worldObjectEntity">WorldObject entity.</param>
        internal static WorldObject ToDomainModel(this WorldObjectEntity worldObjectEntity)
        {
            WorldObject worldObject = new WorldObject
            {
                Id = worldObjectEntity.Id,
                Name = worldObjectEntity.Name,
                Description = worldObjectEntity.Description,
                MinimapColour = ColourTranslator.FromHexadecimal(worldObjectEntity.MinimapColour)
            };

            return worldObject;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="worldObject">WorldObject.</param>
        internal static WorldObjectEntity ToEntity(this WorldObject worldObject)
        {
            WorldObjectEntity worldObjectEntity = new WorldObjectEntity
            {
                Id = worldObject.Id,
                Name = worldObject.Name,
                Description = worldObject.Description,
                MinimapColour = worldObject.MinimapColour.ToHexadecimal()
            };

            return worldObjectEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="worldObjectEntities">WorldObject entities.</param>
        internal static IEnumerable<WorldObject> ToDomainModels(this IEnumerable<WorldObjectEntity> worldObjectEntities)
        {
            IEnumerable<WorldObject> worldObjects = worldObjectEntities.Select(worldObjectEntity => worldObjectEntity.ToDomainModel());

            return worldObjects;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="worldObjects">WorldObjects.</param>
        internal static IEnumerable<WorldObjectEntity> ToEntities(this IEnumerable<WorldObject> worldObjects)
        {
            IEnumerable<WorldObjectEntity> worldObjectEntities = worldObjects.Select(worldObject => worldObject.ToEntity());

            return worldObjectEntities;
        }
    }
}
