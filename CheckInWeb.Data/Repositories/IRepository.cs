using System;
using System.Collections.Generic;
using System.Linq;
using CheckInWeb.Data.Entities;

namespace CheckInWeb.Data.Repositories
{
    /// <summary>
    /// Interface for the repository.
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Get an entity by ID.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="id">ID to find the entity by.</param>
        /// <returns>An entity.</returns>
        TEntity GetById<TEntity>(object id) where TEntity : class;

        /// <summary>
        /// Get a collection of entities by their ID.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="ids">The IDs to find the entity by.</param>
        /// <returns>An entity.</returns>
        IQueryable<TEntity> GetAllByIds<TEntity>(int[] ids) where TEntity : class, IIdEntity;

        /// <summary>
        /// Query entities.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <returns>An entity.</returns>
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the command.</param>
        /// <returns>An enumerable of entities</returns>
        int SqlCommand(string sql, params object[] parameters);

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the query.</param>
        /// <returns>An enumerable of entities</returns>
        IEnumerable<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters);

        /// <summary>
        /// Insert an entity.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="entity">The entity to be inserted.</param>
        void Insert<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="entity">The entity to be deleted.</param>
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Save changes.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        int SaveChanges();
    }
}
