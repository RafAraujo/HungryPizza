using HungryPizza.Data.DbContext.Interfaces;
using HungryPizza.Data.Models;
using HungryPizza.Data.Repositories.Interfaces;
using HungryPizza.Data.UoW;
using HungryPizza.Domain.Models;

namespace HungryPizza.Data.DbContext
{
    public class DbContext : IDbContext
    {
        private readonly IUnitOfWork _uow;

        public IDatabase Database { get; private set; }

        public IBaseRepository<Address, int> Address { get; private set; }

        public INamedEntityRepository<Category, int> Category { get; private set; }

        public ICustomerRepository Customer { get; private set; }

        public IBaseRepository<CustomerAddress, int> CustomerAddress { get; private set; }

        public INamedEntityRepository<Flavor, int> Flavor { get; private set; }

        public IOrderRepository Order { get; private set; }

        public IBaseRepository<OrderItem, int> OrderItem { get; private set; }

        public IBaseRepository<Pizza, int> Pizza { get; private set; }

        public IBaseRepository<PizzaFlavor, int> PizzaFlavor { get; private set; }

        public IBaseRepository<Product, int> Product { get; private set; }

        public DbContext(
            IUnitOfWork uow,
            IDatabase database,
            IBaseRepository<Address, int> addressRepository,
            INamedEntityRepository<Category, int> categoryRepository,
            ICustomerRepository customerRepository,
            IBaseRepository<CustomerAddress, int> customerAddressRepository,
            INamedEntityRepository<Flavor, int> flavorRepository,
            IOrderRepository orderRepository,
            IBaseRepository<OrderItem, int> orderItemRepository,
            IBaseRepository<Pizza, int> pizzaRepository,
            IBaseRepository<PizzaFlavor, int> pizzaFlavorRepository,
            IBaseRepository<Product, int> productRepository)
        {
            _uow = uow;

            Database = database;

            Address = addressRepository;
            Category = categoryRepository;
            Customer = customerRepository;
            CustomerAddress = customerAddressRepository;
            Flavor = flavorRepository;
            Order = orderRepository;
            OrderItem = orderItemRepository;
            Pizza = pizzaRepository;
            PizzaFlavor = pizzaFlavorRepository;
            Product = productRepository;
        }

        public void BeginTransaction() => _uow.BeginTransaction();

        public void Commit() => _uow.Commit();

        public void Rollback() => _uow.Rollback();

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}