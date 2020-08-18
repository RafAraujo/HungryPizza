using HungryPizza.Application.Services.Base;
using HungryPizza.Application.Services.Interfaces;
using HungryPizza.Data.DbContext.Interfaces;
using HungryPizza.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Application.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<Customer> CreateIfNotExistsAsync(Customer customer)
        {
            using var db = DbContextFactory.Create();

            var dbCustomer = await db.Customer.GetByIdentityDocumentAsync(customer.IdentityDocument);

            if (dbCustomer == null)
            {
                customer.Id = await db.Customer.InsertAsync(customer);
            }

            return customer;
        }

        public async Task<IEnumerable<Order>> GetOrderHistoryAsync(int customerId)
        {
            using var db = DbContextFactory.Create();

            var orders = await db.Order.GetByCustomerIdAsync(customerId);

            return orders;
        }
    }
}
