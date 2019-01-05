using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using Doom2D.DataAccess.DataObjects;

namespace Doom2D.DataAccess.Repositories
{
    /// <summary>
    /// WorldObject repository implementation.
    /// </summary>
    public class WorldObjectRepository : XmlRepository<WorldObjectEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldObjectRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public WorldObjectRepository(string fileName) : base(fileName)
        {

        }

        /// <summary>
        /// Updates the specified <see cref="WorldObjectEntity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="WorldObjectEntity"/> to update.</param>
        public override void Update(WorldObjectEntity entity)
        {
            LoadEntitiesIfNeeded();

            WorldObjectEntity entityToUpdate = Get(entity.Id);

            if (entityToUpdate == null)
            {
                throw new EntityNotFoundException(entity.Id, nameof(WorldObjectEntity));
            }

            entityToUpdate.Name = entity.Name;
            entityToUpdate.Description = entity.Description;

            XmlFile.SaveEntities(Entities.Values);
        }
    }
}
