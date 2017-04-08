namespace AdventureWorks.Common.Repositories
{
    public interface IWriteOnlyRepository<TEntity, TKey>
        where TEntity : class
    {
        /// <summary>
        /// Create an entity.
        /// </summary>
        /// <param name="entity">The created entity.</param>
        /// <returns>Id of the created entity.</returns>
        TKey Create(TEntity entity);

        /// <summary>
        /// Update the entity.
        /// </summary>
        /// <param name="entity">The updated entity.</param>
        /// <returns>True if the update was successful, false if not.</returns>
        bool Update(TEntity entity);

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="entity">The deleted entity.</param>
        /// <returns>True if the delete was successful, false if not.</returns>
        bool Delete(TEntity entity);
    }
}
