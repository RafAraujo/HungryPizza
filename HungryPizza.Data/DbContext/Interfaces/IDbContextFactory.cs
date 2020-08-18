namespace HungryPizza.Data.DbContext.Interfaces
{
    public interface IDbContextFactory
    {
        IDbContext Create();
    }
}
