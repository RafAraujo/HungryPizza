using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace HungryPizza.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public string ConnectionString { get; private set; }

        public IDbConnection Connection { get; private set; }

        public IDbTransaction Transaction { get; private set; }

        public UnitOfWork(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            ConnectionString = connectionString;
            Connect();
        }

        private void Connect()
        {
            if (Connection != null && Connection.State != ConnectionState.Closed)
            {
                throw new Exception("The connection is already open.");
            }

            Connection = new SqliteConnection(ConnectionString);
            Connection.Open();
        }

        public void BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new Exception("The transaction is already active.");
            }

            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            using var transaction = Transaction;
            transaction.Commit();
        }

        public void Rollback()
        {
            using var transaction = Transaction;
            transaction.Rollback();
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Connection?.Dispose();
        }
    }
}
