using Dapper;
using HungryPizza.Data.UoW;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HungryPizza.Data.Models
{
    public class Database : IDatabase
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public Database(IUnitOfWork uow)
        {
            _connection = uow.Connection;
            _transaction = uow.Transaction;
        }

        public async Task<int> ExecuteAsync(string sql) => await ExecuteAsync(sql, null);

        public async Task<int> ExecuteAsync(string sql, object param) => await _connection.ExecuteAsync(sql, param, _transaction);

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql) => await QueryAsync<T>(sql, null);

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param) => await _connection.QueryAsync<T>(sql, param, _transaction);

        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql) => await QuerySingleOrDefaultAsync<T>(sql, null);

        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param) => await _connection.QuerySingleOrDefaultAsync<T>(sql, param, _transaction);
    }
}
