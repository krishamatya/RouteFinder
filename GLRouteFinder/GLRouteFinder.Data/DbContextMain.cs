using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GLRouteFinder;
using Microsoft.Extensions.Options;

namespace GLRouteFinder
{
    public class DbContextMain : DbContext
    {
        string _connectionString;
        IDbConnection _connection;
        ProviderFactory _pf;
        IDbTransaction _transaction;
        IDataReader _reader;
        public  static IOptions<ConnectionStrings> _appSettings;
        public DbContextMain(DbContextOptions<DbContextMain> options)
            : base(options)

        {
           
        }
        public DbContextMain()
        {

            _connectionString = ConfigurationManager.AppSettings["ConnectionStrings:DefaultConnection"];
            _pf = new ProviderFactory();
        }
        public DbContextMain(string pConnectionString)
        {
            _connectionString = pConnectionString;
            _pf = new ProviderFactory();
        }
        public IDataReader DbReader { get { return _reader; } }

        public DbSet<airlines> airlines { get; set; }
        public DbSet<airports> airports { get; set; }
        public DbSet<routes> routes { get; set; }

        public void connect()
        {
            if (_connection == null)
            {
                _connection = _pf.CreateConnection(_connectionString);
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }
        public IDbConnection OpenConnection()
        {
            if (_connection == null)
            {
                _connection = _pf.CreateConnection(_connectionString);
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
            }
            return _connection;
        }
        public void beginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// End a transaction by committing to the database
        /// </summary>
        public void endTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }

        public void SaveTransaction(string savePointName)
        {
            if (_transaction != null)
            {
                ((SqlTransaction)_transaction).Save(savePointName);
            }
        }

        /// <summary>
        /// Roll back the transaction up to the save point
        /// </summary>
        /// <param name="savePointName">Name of the save point or transaction to rollback</param>
        public void rollback(string transactionName)
        {
            if (_transaction != null)
            {
                ((SqlTransaction)_transaction).Rollback(transactionName);
            }
        }


        /// <summary>
        /// Roll back the transaction done so far on the database
        /// </summary>
        public void rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }

    }
}




