using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInWeb.Data.Context
{
    /// <summary>
    /// Defines a contract that is used to interact with the database.
    /// </summary>
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// Gets the set of entities represented in the database.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <returns>A <see cref="DbSet"/> for the requested entity</returns>
        IDbSet<TEntity> DbSet<TEntity>() where TEntity : class;

        /// <summary>
        /// Gets a set of entities represented in the database.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <returns>A <see cref="DbSet"/> for the requested entity</returns>
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
        /// Saves changes tracked by the context to the database.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        int SaveChanges();

        /// <summary>
        /// Saves changes tracked by the context to the database.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        Task<int> SaveChangesAsync();
    }
}
