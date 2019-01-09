using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using Doom2D.DataAccess.DataObjects;

namespace Doom2D.DataAccess.Repositories
{
    /// <summary>
    /// Level repository implementation.
    /// </summary>
    public class LevelRepository : XmlRepository<LevelEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LevelRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public LevelRepository(string fileName) : base(fileName)
        {

        }

        /// <summary>
        /// Updates the specified <see cref="LevelEntity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="LevelEntity"/> to update.</param>
        public override void Update(LevelEntity entity)
        {
            LoadEntitiesIfNeeded();

            LevelEntity entityToUpdate = Get(entity.Id);

            if (entityToUpdate == null)
            {
                throw new EntityNotFoundException(entity.Id, nameof(LevelEntity));
            }

            entityToUpdate.Name = entity.Name;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.Width = entity.Width;
            entityToUpdate.Height = entity.Height;
            entityToUpdate.Terrain = entity.Terrain;
            entityToUpdate.WorldObjects = entity.WorldObjects;

            XmlFile.SaveEntities(Entities.Values);
        }
    }
}
