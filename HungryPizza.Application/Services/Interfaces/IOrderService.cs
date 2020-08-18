using HungryPizza.Domain.Models;
using System.Threading.Tasks;

namespace HungryPizza.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
