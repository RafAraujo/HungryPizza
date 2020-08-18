using HungryPizza.Data.Models;
using HungryPizza.Data.Repositories.Interfaces;
using HungryPizza.Data.SqlGenerator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repositories.Base
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        protected IDatabase Db { get; set; }

        protected ISqlGenerator<TEntity, TKey> SqlGenerator { get; private set; }

        public BaseRepository(IDatabase db, ISqlGenerator<TEntity, TKey> sqlGenerator)
        {
            Db = db;
            SqlGenerator = sqlGenerator;
        }

        public async virtual Task<int> CreateTable()
        {
            var sql = SqlGenerator.CreateTable();
            return await Db.ExecuteAsync(sql);
        }

        public async virtual Task<TKey> InsertAsync(TEntity entity)
        {
            var sql = SqlGenerator.Insert();
            await Db.ExecuteAsync(sql, entity);

            sql = $"SELECT Id FROM {SqlGenerator.Table} WHERE rowid = last_insert_rowid()";
            var id = await Db.QuerySingleOrDefaultAsync<TKey>(sql);

            return id;
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var sql = SqlGenerator.Select();
            return await Db.QueryAsync<TEntity>(sql);
        }

        public async virtual Task<TEntity> GetAsync(TKey id)
        {
            var sql = SqlGenerator.Select(id);
            return await Db.QuerySingleOrDefaultAsync<TEntity>(sql, id);
        }

        public async virtual Task<int> UpdateAsync(TEntity entity)
        {
            var sql = SqlGenerator.Update();
            return await Db.ExecuteAsync(sql, entity);
        }

        public async virtual Task<int> DeleteAsync(TKey id)
        {
            var sql = SqlGenerator.Delete();
            return await Db.ExecuteAsync(sql, id);
        }
    }
}
