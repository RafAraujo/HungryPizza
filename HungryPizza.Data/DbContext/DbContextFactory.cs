using HungryPizza.Data.DbContext.Interfaces;
using HungryPizza.Data.Models;
using HungryPizza.Data.Repositories.Interfaces;
using HungryPizza.Data.UoW;
using HungryPizza.Domain.Models;

namespace HungryPizza.Data.DbContext
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IUnitOfWork _uow;
        private readonly IDatabase _database;
        private readonly IBaseRepository<Address, int> _addressRepository;
        private readonly INamedEntityRepository<Category, int> _categoryRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBaseRepository<CustomerAddress, int> _customerAddressRepository;
        private readonly INamedEntityRepository<Flavor, int> _flavorRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IBaseRepository<OrderItem, int> _orderItemRepository;
        private readonly IBaseRepository<Pizza, int> _pizzaRepository;
        private readonly IBaseRepository<PizzaFlavor, int> _pizzaFlavorRepository;
        private readonly IBaseRepository<Product, int> _productRepository;

        public DbContextFactory(
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
            _database = database;
            _addressRepository = addressRepository;
            _categoryRepository = categoryRepository;
            _customerRepository = customerRepository;
            _customerAddressRepository = customerAddressRepository;
            _flavorRepository = flavorRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _pizzaRepository = pizzaRepository;
            _pizzaFlavorRepository = pizzaFlavorRepository;
            _productRepository = productRepository;
        }

        public IDbContext Create()
        {
            return new DbContext(
                _uow,
                _database,
                _addressRepository,
                _categoryRepository,
                _customerRepository,
                _customerAddressRepository,
                _flavorRepository,
                _orderRepository,
                _orderItemRepository,
                _pizzaRepository,
                _pizzaFlavorRepository,
                _productRepository);
        }
    }
}
