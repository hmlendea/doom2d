using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using Doom2D.DataAccess.DataObjects;

namespace Doom2D.DataAccess.Repositories
{
    /// <summary>
    /// Terrain repository implementation.
    /// </summary>
    public class TerrainRepository : XmlRepository<TerrainEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TerrainRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public TerrainRepository(string fileName) : base(fileName)
        {

        }

        /// <summary>
        /// Updates the specified <see cref="TerrainEntity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="TerrainEntity"/> to update.</param>
        public override void Update(TerrainEntity entity)
        {
            LoadEntitiesIfNeeded();

            TerrainEntity entityToUpdate = Get(entity.Id);

            if (entityToUpdate == null)
            {
                throw new EntityNotFoundException(entity.Id, nameof(TerrainEntity));
            }

            entityToUpdate.Name = entity.Name;
            entityToUpdate.Description = entity.Description;

            XmlFile.SaveEntities(Entities.Values);
        }
    }
}
