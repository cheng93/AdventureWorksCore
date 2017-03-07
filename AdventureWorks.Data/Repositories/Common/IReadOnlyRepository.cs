using System.Collections.Generic;

namespace AdventureWorks.Data.Repositories.Common
{
    public interface IReadOnlyRepository<TEntity, in TKey>
        where TEntity : class
    {
        /// <summary>
        /// Get an entity by the <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The entity's id to find.</param>
        /// <returns>An entity or null if it doesn't exists.</returns>
        TEntity Get(TKey id);

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>All the entities.</returns>
        IEnumerable<TEntity> GetAll();
    }
}
