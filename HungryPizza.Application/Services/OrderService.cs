using HungryPizza.Application.Services.Base;
using HungryPizza.Application.Services.Interfaces;
using HungryPizza.Data.DbContext.Interfaces;
using HungryPizza.Domain.Models;
using System.Threading.Tasks;

namespace HungryPizza.Application.Services
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            order.CalculatePrice();

            using var db = DbContextFactory.Create();
            db.BeginTransaction();

            order.Id = await db.Order.InsertAsync(order);

            foreach (var orderItem in order.OrderItems)
            {
                orderItem.OrderId = order.Id;
                orderItem.Id = await db.OrderItem.InsertAsync(orderItem);
            }

            db.Commit();

            return order;
        }
    }
}
