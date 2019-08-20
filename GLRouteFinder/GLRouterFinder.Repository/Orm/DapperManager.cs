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
   
    }
}






