using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CheckInWeb.Data.Context;
using CheckInWeb.Data.Entities;

namespace CheckInWeb.Data.Repositories
{
    /// <summary>
    /// Implementation of the <see cref="IAsyncRepository"/> interface which also implements <see cref="IRepository"/>.
    /// </summary>
    public class Repository : IAsyncRepository
    {
        /// <summary>
        /// The Entity Framework Context dependency.
        /// </summary>
        private readonly IDbContext databaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="databaseContext">The Entity Framework Context dependency</param>
        public Repository(IDbContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Get an entity by its identifier.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="id">The identifier of the entity you are looking for.</param>
        /// <returns>An entity from the database.</returns>
        public TEntity GetById<TEntity>(object id) where TEntity : class
        {
            return this.databaseContext.DbSet<TEntity>().Find(id);
        }

        /// <summary>
        /// Get a collection of entities by their ID.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="ids">The IDs to find the entity by.</param>
        /// <returns>An entity.</returns>
        public IQueryable<TEntity> GetAllByIds<TEntity>(int[] ids) where TEntity : class, IIdEntity
        {
            // shortcut for no ids given.
            if (!ids.Any())
            {
                return new List<TEntity>().AsQueryable();
            }

            return this.Query<TEntity>().Where(e => ids.Contains(e.Id));
        }

        /// <summary>
        /// Accesses the database for an entity type.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>An <see cref="IQueryable"/> endpoint for the type of entity given</returns>
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return this.databaseContext.Query<TEntity>();
        }

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the command.</param>
        /// <returns>An enumerable of entities</returns>
        public int SqlCommand(string sql, params object[] parameters)
        {
            return this.databaseContext.SqlCommand(sql, parameters);
        }

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the query.</param>
        /// <returns>An enumerable of entities</returns>
        public IEnumerable<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters)
        {
            return this.databaseContext.SqlQuery<TEntity>(sql, parameters);
        }

        /// <summary>
        /// Inserts a new entity to the database.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="entity">The entity to insert.</param>
        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            this.databaseContext.DbSet<TEntity>().Add(entity);
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="entity">The entity to delete.</param>
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            this.databaseContext.DbSet<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        public int SaveChanges()
        {
            return this.databaseContext.SaveChanges();
        }

        /// <summary>
        /// Get an entity by its identifier.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="id">The identifier of the entity you are looking for.</param>
        /// <returns>An entity from the database.</returns>
        [ExcludeFromCodeCoverage]
        public Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class, IIdEntity
        {
            return this.databaseContext.Query<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the command.</param>
        /// <returns>An enumerable of entities</returns>
        public Task<int> SqlCommandAsync(string sql, params object[] parameters)
        {
            return this.databaseContext.SqlCommandAsync(sql, parameters);
        }

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the command.</param>
        /// <returns>An enumerable of entities</returns>
        public Task<List<TEntity>> SqlQueryAsync<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            return this.databaseContext.SqlQueryAsync<TEntity>(sql, parameters);
        }

        /// <summary>
        /// Save changes.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        public Task<int> SaveChangesAsync()
        {
            return this.databaseContext.SaveChangesAsync();
        }

        /// <summary>
        /// The disposal method.
        /// </summary>
        public void Dispose()
        {
            this.databaseContext.Dispose();
        }
    }
}
