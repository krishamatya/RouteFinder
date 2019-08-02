using Dapper;
using GLRouteFinder;
using GLRouteFinder.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLRouterFinder
{
    public class DapperManager : IDapperManager
    {
        private DbContextMain _context;
       
        public DapperManager(IDataBaseFactory databaseFactory)
        {
            
            DatabaseFactory = databaseFactory;
        }
        protected IDataBaseFactory DatabaseFactory
        {
            get;
            private set;
        }
        protected DbContextMain DbContext
        {
            get { return _context ?? (_context = DatabaseFactory.Get()); }
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return dbConnection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
           int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return await dbConnection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public async Task<dynamic> QueryAsync(string sql, object param = null, IDbTransaction transaction = null,
          int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return await dbConnection.QueryAsync(sql, param, transaction, commandTimeout, commandType);
            }
        }
        public IEnumerable<T> Query<T>(IDbConnection dbConnection, string sql, object param = null,
            IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return dbConnection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }

        public IEnumerable<object> Query(Type type, string sql, object param = null, IDbTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return dbConnection.Query(type, sql, param, transaction, buffered, commandTimeout, commandType);
            }
        }

        public IEnumerable<object> Query(IDbConnection dbConnection, Type type, string sql, object param = null,
            IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return dbConnection.Query(type, sql, param, transaction, buffered, commandTimeout, commandType);
        }

        public int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return dbConnection.Execute(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public int Execute(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            return dbConnection.Execute(sql, param, transaction, commandTimeout, commandType);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null,
          int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return await dbConnection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
            }

        }

        public async Task<int> ExecuteAsyncBulk(string sql, object param = null, IDbTransaction transaction = null,
         int? commandTimeout = null, CommandType? commandType = null)
        {
            var dbConnection = DbContext.OpenConnection();
            return await dbConnection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        }

        public IDataReader ExecuteReader(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            return dbConnection.ExecuteReader(sql, param, transaction, commandTimeout, commandType);
        }

        public async Task<IDataReader> ExecuteReaderAsync(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
        {
            return await dbConnection.ExecuteReaderAsync(sql, param, transaction, commandTimeout, commandType);
        }
        public T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return dbConnection.ExecuteScalar<T>(sql, param, transaction,
                    commandTimeout, commandType);
            }
        }

        public T ExecuteScalar<T>(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            return dbConnection.ExecuteScalar<T>(sql, param, transaction,
                commandTimeout, commandType);
        }

        public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return dbConnection.QueryFirst<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public async Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
           int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return await dbConnection.QueryFirstAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }


        public T QueryFirst<T>(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            return dbConnection.QueryFirst<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return dbConnection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
           int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return await dbConnection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }
        public T QueryFirstOrDefault<T>(IDbConnection dbConnection, string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return dbConnection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
        }
        public T QuerySingle<T>(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return dbConnection.QuerySingle<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
          int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return await dbConnection.QuerySingleAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public T QuerySingle<T>(IDbConnection dbConnection, string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return dbConnection.QuerySingle<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public T QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return dbConnection.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }
        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
           int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var dbConnection = DbContext.OpenConnection())
            {
                return await dbConnection.QuerySingleOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public T QuerySingleOrDefault<T>(IDbConnection dbConnection, string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return dbConnection.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
        }
    }
}






