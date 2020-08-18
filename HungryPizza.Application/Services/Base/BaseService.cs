using HungryPizza.Data.DbContext.Interfaces;

namespace HungryPizza.Application.Services.Base
{
    public class BaseService
    {
        protected IDbContextFactory DbContextFactory { get; private set; }

        public BaseService(IDbContextFactory dbContextFactory) => DbContextFactory = dbContextFactory;
    }
}
