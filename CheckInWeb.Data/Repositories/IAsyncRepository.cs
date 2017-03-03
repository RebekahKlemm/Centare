using System.Collections.Generic;
using System.Threading.Tasks;
using CheckInWeb.Data.Entities;

namespace CheckInWeb.Data.Repositories
{
    /// <summary>
    /// An asynchronous repository.
    /// </summary>
    public interface IAsyncRepository : IRepository
    {
        /// <summary>
        /// Get an entity by ID.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="id">ID to find the entity by.</param>
        /// <returns>An entity.</returns>
        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class, IIdEntity;

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the command.</param>
        /// <returns>An enumerable of entities</returns>
        Task<int> SqlCommandAsync(string sql, params object[] parameters);

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the query.</param>
        /// <returns>An enumerable of entities</returns>
        Task<List<TEntity>> SqlQueryAsync<TEntity>(string sql, params object[] parameters) where TEntity : class;

        /// <summary>
        /// Save changes.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        Task<int> SaveChangesAsync();
    }
}
