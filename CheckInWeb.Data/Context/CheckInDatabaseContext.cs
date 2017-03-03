using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CheckInWeb.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CheckInWeb.Data.Context
{
    public class CheckInDatabaseContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public IDbSet<CheckIn> CheckIns { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<Achievement> Achievements { get; set; }

        public IDbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        public int SqlCommand(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommand(sql, parameters);
        }

        public Task<int> SqlCommandAsync(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        public IEnumerable<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TEntity>(sql, parameters);
        }

        public Task<List<TEntity>> SqlQueryAsync<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            return this.Database.SqlQuery<TEntity>(sql, parameters).ToListAsync();
        }
    }
}
