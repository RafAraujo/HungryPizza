using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Data.Models
{
    public interface IDatabase
    {
        Task<int> ExecuteAsync(string sql);

        Task<int> ExecuteAsync(string sql, object param);

        Task<IEnumerable<T>> QueryAsync<T>(string sql);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param);

        Task<T> QuerySingleOrDefaultAsync<T>(string sql);

        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param);
    }
}
