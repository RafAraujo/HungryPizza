using HungryPizza.Application.Services.Interfaces;
using HungryPizza.Data.DbContext.Interfaces;
using HungryPizza.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Application.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDbContextFactory _dbContextFactory;

        public DatabaseService(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task ConfigureDatabase()
        {
            using var db = _dbContextFactory.Create();
            db.BeginTransaction();

            if (!await TableExists(db))
            {
                await CreateTablesAsync(db);
                await SeedAsync(db);
            }

            db.Commit();
        }

        private async Task<bool> TableExists(IDbContext db)
        {
            var sql = "SELECT name FROM sqlite_master WHERE type = 'table' AND name = @Table";

            var result = await db.Database.QueryAsync<string>(sql, new { Table = "Pizza" });

            return !string.IsNullOrEmpty(result.FirstOrDefault());
        }

        private async Task CreateTablesAsync(IDbContext db)
        {
            await db.Address.CreateTable();
            await db.Category.CreateTable();
            await db.Customer.CreateTable();
            await db.CustomerAddress.CreateTable();
            await db.Flavor.CreateTable();
            await db.Product.CreateTable();
            await db.Order.CreateTable();
            await db.OrderItem.CreateTable();
            await db.Pizza.CreateTable();
            await db.PizzaFlavor.CreateTable();
        }

        private async Task SeedAsync(IDbContext db)
        {
            await InsertCategoriesAsync(db);
            await InsertFlavorsAsync(db);
            await InsertPizzasAsync(db);
        }

        private async Task InsertCategoriesAsync(IDbContext db)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Pizzas" }
            };

            foreach (var category in categories)
            {
                category.Id = await db.Category.InsertAsync(category);
            }
        }

        private async Task InsertFlavorsAsync(IDbContext db)
        {
            var flavors = new List<Flavor>
            {
                new Flavor { Name = "3 Cheese", Price = 50 },
                new Flavor { Name = "Chicken with Cream Cheese", Price = 59.9m },
                new Flavor { Name = "Mozzarella", Price = 42.5m },
                new Flavor { Name = "Calabresa", Price = 42.5m },
                new Flavor { Name = "Pepperoni", Price = 55 },
                new Flavor { Name = "Portuguese", Price = 45 },
                new Flavor { Name = "Veggie", Price = 59.9m }
            };

            foreach (var flavor in flavors)
            {
                flavor.Id = await db.Flavor.InsertAsync(flavor);
            }
        }

        private async Task InsertPizzasAsync(IDbContext db)
        {
            var flavors = new List<Flavor>();

            flavors.AddRange(await db.Flavor.GetAllAsync());

            for (int i = 0; i < flavors.Count; i++)
            {
                await CreatePizzaAsync(new Flavor[] { flavors[i] }, db);

                for (int j = i + 1; j < flavors.Count; j++)
                {
                    await CreatePizzaAsync(new Flavor[] { flavors[i], flavors[j] }, db);
                }
            }
        }

        public async Task<Pizza> CreatePizzaAsync(IEnumerable<Flavor> flavors, IDbContext db)
        {
            var category = await db.Category.GetByNameAsync("Pizzas");

            var pizza = new Pizza
            {
                Flavors = flavors.ToList()
            };

            pizza.Product = new Product
            {
                Name = pizza.GetName(),
                CategoryId = category.Id,
                Category = category,
                Price = pizza.CalculatePrice()
            };

            pizza.Product.Id = await db.Product.InsertAsync(pizza.Product);
            pizza.ProductId = pizza.Product.Id;

            pizza.Id = await db.Pizza.InsertAsync(pizza);

            var pizzaFlavors = pizza.Flavors.Select(f => new PizzaFlavor { PizzaId = pizza.Id, FlavorId = f.Id });
            foreach (var pizzaFlavor in pizzaFlavors)
            {
                pizzaFlavor.Id = await db.PizzaFlavor.InsertAsync(pizzaFlavor);
            }

            return pizza;
        }
    }
}
