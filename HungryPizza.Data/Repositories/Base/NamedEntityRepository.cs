using HungryPizza.Data.Models;
using HungryPizza.Data.Repositories.Interfaces;
using HungryPizza.Data.SqlGenerator;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repositories.Base
{
    public class NamedEntityRepository<TEntity, TKey> : BaseRepository<TEntity, TKey>, INamedEntityRepository<TEntity, TKey>
        where TEntity : class
    {
        public NamedEntityRepository(IDatabase db, ISqlGenerator<TEntity, TKey> sqlGenerator) : base(db, sqlGenerator)
        {
        }

        public async Task<TEntity> GetByNameAsync(string name)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Name = @Name", SqlGenerator.Table);

            var entity = await Db.QueryAsync<TEntity>(sql, new { Name = name });

            return entity.FirstOrDefault();
        }
    }
}
