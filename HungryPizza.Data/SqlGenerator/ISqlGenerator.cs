namespace HungryPizza.Data.SqlGenerator
{
    public interface ISqlGenerator<TEntity, TKey> where TEntity : class
    {
        string Table { get; }

        string CreateTable();

        string Insert();

        string Select();

        string Select(TKey id);

        string Update();

        string Delete();
    }
}
