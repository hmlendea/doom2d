using NuciXNA.DataAccess.Exceptions;
using NuciXNA.DataAccess.Repositories;

using Doom2D.DataAccess.DataObjects;

namespace Doom2D.DataAccess.Repositories
{
    /// <summary>
    /// Item repository implementation.
    /// </summary>
    public class ItemRepository : XmlRepository<ItemEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public ItemRepository(string fileName) : base(fileName)
        {

        }

        /// <summary>
        /// Updates the specified <see cref="ItemEntity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="ItemEntity"/> to update.</param>
        public override void Update(ItemEntity entity)
        {
            LoadEntitiesIfNeeded();

            ItemEntity entityToUpdate = Get(entity.Id);

            if (entityToUpdate == null)
            {
                throw new EntityNotFoundException(entity.Id, nameof(ItemEntity));
            }

            entityToUpdate.Name = entity.Name;
            entityToUpdate.Description = entity.Description;

            XmlFile.SaveEntities(Entities.Values);
        }
    }
}
