using HungryPizza.Data.Models;
using HungryPizza.Data.Repositories.Base;
using HungryPizza.Data.Repositories.Interfaces;
using HungryPizza.Data.SqlGenerator;
using HungryPizza.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(IDatabase db, ISqlGenerator<Order, int> sqlGenerator) : base(db, sqlGenerator)
        {
        }

        public async Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId)
        {
            var orders = await Db.QueryAsync<Order>($"SELECT * FROM \"{SqlGenerator.Table}\" WHERE CustomerId = @CustomerId", new { CustomerId = customerId });
            return orders;
        }
    }
}
