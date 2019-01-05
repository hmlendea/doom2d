using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using Doom2D.DataAccess.DataObjects;

namespace Doom2D.DataAccess.Repositories
{
    /// <summary>
    /// Mob repository implementation.
    /// </summary>
    public class MobRepository : XmlRepository<MobEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public MobRepository(string fileName) : base(fileName)
        {

        }

        /// <summary>
        /// Updates the specified <see cref="MobEntity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="MobEntity"/> to update.</param>
        public override void Update(MobEntity entity)
        {
            LoadEntitiesIfNeeded();

            MobEntity entityToUpdate = Get(entity.Id);

            if (entityToUpdate == null)
            {
                throw new EntityNotFoundException(entity.Id, nameof(MobEntity));
            }

            entityToUpdate.Name = entity.Name;
            entityToUpdate.Description = entity.Description;

            XmlFile.SaveEntities(Entities.Values);
        }
    }
}
