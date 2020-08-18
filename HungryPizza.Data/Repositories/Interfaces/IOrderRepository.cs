using HungryPizza.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order, int>
    {
        Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId);
    }
}
