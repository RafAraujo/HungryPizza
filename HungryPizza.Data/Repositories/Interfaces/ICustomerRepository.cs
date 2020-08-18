using HungryPizza.Domain.Models;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repositories.Interfaces
{
    public interface ICustomerRepository : INamedEntityRepository<Customer, int>
    {
        Task<Customer> GetByIdentityDocumentAsync(string identityDocument);
    }
}
