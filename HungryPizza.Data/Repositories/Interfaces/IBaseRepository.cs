using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        Task<int> CreateTable();

        Task<TKey> InsertAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(TKey id);

        Task<int> UpdateAsync(TEntity entity);

        Task<int> DeleteAsync(TKey id);
    }
}
