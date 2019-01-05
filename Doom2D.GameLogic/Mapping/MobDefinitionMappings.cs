using System.Collections.Generic;
using System.Linq;

using Doom2D.DataAccess.DataObjects;
using Doom2D.Models;

namespace Doom2D.GameLogic.Mapping
{
    /// <summary>
    /// Mob mapping extensions for converting between entities and domain models.
    /// </summary>
    static class MobMappingExtensions
    {
        /// <summary>
        /// Converts the entity into a domain model.
        /// </summary>
        /// <returns>The domain model.</returns>
        /// <param name="mobEntity">Mob entity.</param>
        internal static MobDefinition ToDomainModel(this MobEntity mobEntity)
        {
            MobDefinition mob = new MobDefinition
            {
                Id = mobEntity.Id,
                Name = mobEntity.Name,
                Description = mobEntity.Description
            };

            return mob;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="mob">Mob.</param>
        internal static MobEntity ToEntity(this MobDefinition mob)
        {
            MobEntity mobEntity = new MobEntity
            {
                Id = mob.Id,
                Name = mob.Name,
                Description = mob.Description
            };

            return mobEntity;
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="mobEntities">Mob entities.</param>
        internal static IEnumerable<MobDefinition> ToDomainModels(this IEnumerable<MobEntity> mobEntities)
        {
            IEnumerable<MobDefinition> mobs = mobEntities.Select(mobEntity => mobEntity.ToDomainModel());

            return mobs;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="mobs">Mobs.</param>
        internal static IEnumerable<MobEntity> ToEntities(this IEnumerable<MobDefinition> mobs)
        {
            IEnumerable<MobEntity> mobEntities = mobs.Select(mob => mob.ToEntity());

            return mobEntities;
        }
    }
}
