using HungryPizza.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateIfNotExistsAsync(Customer customer);

        Task<IEnumerable<Order>> GetOrderHistoryAsync(int customerId);
    }
}