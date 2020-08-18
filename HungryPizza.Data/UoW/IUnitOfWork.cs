using System;
using System.Data;

namespace HungryPizza.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        string ConnectionString { get; }

        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
