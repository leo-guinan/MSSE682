using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace TaskApp.Repository
{
    /// <summary>
    /// This is a generic repository for all domain objects.
    /// </summary>
    /// <typeparam name="T">The object type of the repository</typeparam>
    public interface IRepository<T>
           where T : class
    {
        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="entity">the entity to add</param>
        /// <returns>the added entity</returns>
        T addEntity(T entity);

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns>if the entity was deleted</returns>
        Boolean delete(T entity);

        /// <summary>
        /// Get an entity by id.
        /// </summary>
        /// <param name="id">the id for which to get the entity</param>
        /// <returns>the found entity</returns>
        T getEntity(object id);

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <returns>The updated Entity</returns>
        T updateEntity(T entity);

        /// <summary>
        /// Get all entities as a queryable collection.
        /// </summary>
        /// <returns>the queryable collection of all entities</returns>
        IQueryable<T> getAllEntities();

        /// <summary>
        /// Get all entities as a generic list.
        /// </summary>
        /// <returns>the list of all entities</returns>
        List<T> getAllEntitiesAsList();
    }

}
