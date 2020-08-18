using HungryPizza.Data.Models;
using HungryPizza.Data.Repositories.Base;
using HungryPizza.Data.Repositories.Interfaces;
using HungryPizza.Data.SqlGenerator;
using HungryPizza.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repositories
{
    public class CustomerRepository : NamedEntityRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(IDatabase db, ISqlGenerator<Customer, int> sqlGenerator) : base(db, sqlGenerator)
        {
        }

        public async Task<Customer> GetByIdentityDocumentAsync(string identityDocument)
        {
            var customer = await Db.QueryAsync<Customer>($"SELECT * FROM \"{SqlGenerator.Table}\" WHERE IdentityDocument = @IdentityDocument", new { IdentityDocument = identityDocument });
            return customer.FirstOrDefault();
        }
    }
}
