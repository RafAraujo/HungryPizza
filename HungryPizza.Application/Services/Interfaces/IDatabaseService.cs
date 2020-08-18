using System.Threading.Tasks;

namespace HungryPizza.Application.Services.Interfaces
{
    public interface IDatabaseService
    {
        Task ConfigureDatabase();
    }
}
