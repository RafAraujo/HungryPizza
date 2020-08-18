using HungryPizza.Data.Models;
using HungryPizza.Data.Repositories.Interfaces;
using HungryPizza.Domain.Models;
using System;

namespace HungryPizza.Data.DbContext.Interfaces
{
    public interface IDbContext : IDisposable
    {
        IDatabase Database { get; }

        void BeginTransaction();

        void Commit();

        void Rollback();

        IBaseRepository<Address, int> Address { get; }

        INamedEntityRepository<Category, int> Category { get; }

        ICustomerRepository Customer { get; }

        IBaseRepository<CustomerAddress, int> CustomerAddress { get; }

        INamedEntityRepository<Flavor, int> Flavor { get; }

        IOrderRepository Order { get; }

        IBaseRepository<OrderItem, int> OrderItem { get; }

        IBaseRepository<Pizza, int> Pizza { get; }

        IBaseRepository<PizzaFlavor, int> PizzaFlavor { get; }

        IBaseRepository<Product, int> Product { get; }
    }
}
