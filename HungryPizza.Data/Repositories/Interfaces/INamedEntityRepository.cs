using System.Threading.Tasks;

namespace HungryPizza.Data.Repositories.Interfaces
{
    public interface INamedEntityRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        Task<TEntity> GetByNameAsync(string name);
    }
}
