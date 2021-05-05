using Dommel;
using Exchange.Domain.Entities;
using Exchange.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Exchange.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("ExchangeAppCon"));
            }
        }

        public virtual async Task<bool> Delete(long id)
        {
            using IDbConnection conn = Connection;
            var entity = await Find(id);
            return await conn.DeleteAsync<TEntity>(entity);
        }

        public virtual async Task<TEntity> Find(long id)
        {
            using IDbConnection conn = Connection;
            return await conn.GetAsync<TEntity>(id);
        }

        public async Task<TEntity> Find(int id)
        {
            using IDbConnection conn = Connection;
            return await conn.GetAsync<TEntity>(id);
        }

        public virtual async Task<long> Insert(TEntity entity)
        {
            long id = 0;
            using IDbConnection conn = Connection;
            var sqlResult = await conn.InsertAsync(entity);
            if (sqlResult != null)
                long.TryParse(sqlResult.ToString(), out id);
            return id;
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            using IDbConnection conn = Connection;
            return await conn.UpdateAsync(entity);
        }
    }
}
