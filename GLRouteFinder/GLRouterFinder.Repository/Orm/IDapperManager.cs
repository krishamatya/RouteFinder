using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLRouteFinder
{
    public interface IDapperManager
    {

        /// <summary>
        /// Executes a parametrized query, returning the data typed as T.
        /// Manages connection internally.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="buffered">Whether to buffer results in memory.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A sequence of data of the supplied type; if a basic type (int, string, etc) is
        /// queried then the data from the first column in assumed, otherwise an instance
        /// is created per row, and a direct column-name===member-name mapping is assumed
        /// (case insensitive).
        /// </returns>
        IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null);

        Task<dynamic> QueryAsync(string sql, object param = null, IDbTransaction transaction = null,
          int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes a parametrized query, returning the data typed as type.
        /// Works with externally managed connection
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="dbConnection">The connection to execute on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="buffered"> Whether to buffer results in memory.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A sequence of data of the supplied type; if a basic type (int, string, etc) is
        /// queried then the data from the first column in assumed, otherwise an instance
        /// is created per row, and a direct column-name===member-name mapping is assumed
        /// (case insensitive).
        /// </returns>
        IEnumerable<T> Query<T>(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes parametrized query, returning the data typed as type.
        /// Manages connection internally.
        /// </summary>
        /// <param name="type">The type to return</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="buffered"> Whether to buffer results in memory.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A sequence of data of the supplied type; if a basic type (int, string, etc) is
        /// queried then the data from the first column in assumed, otherwise an instance
        /// is created per row, and a direct column-name===member-name mapping is assumed
        /// (case insensitive).
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException:"
        /// type is null.
        /// </exception>
        IEnumerable<object> Query(Type type, string sql, object param = null,
            IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes a parametrized query, returning the data typed as type.
        /// Works with externally managed connection
        /// </summary>
        /// <param name="dbConnection">The connection to execute on.</param>
        /// <param name="type">The type to return</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="buffered"> Whether to buffer results in memory.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A sequence of data of the supplied type; if a basic type (int, string, etc) is
        /// queried then the data from the first column in assumed, otherwise an instance
        /// is created per row, and a direct column-name===member-name mapping is assumed
        /// (case insensitive).
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException:"
        /// type is null.
        /// </exception>
        IEnumerable<object> Query(IDbConnection dbConnection, Type type, string sql, object param = null, IDbTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// Execute parameterized SQL.
        /// Manages connection internally.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>The number of rows affected.</returns>
        int Execute(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Execute parameterized SQL.
        /// Works with externally managed connection
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>The number of rows affected.</returns>
        int Execute(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null);

        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null,
          int? commandTimeout = null, CommandType? commandType = null);

        Task<int> ExecuteAsyncBulk(string sql, object param = null, IDbTransaction transaction = null,
         int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes a single-row query, returning the data typed as type.
        /// Works with externally managed connection
        /// </summary>
        /// <param name="dbConnection">The connection to execute on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>An System.Data.IDataReader that can be used to iterate over the results of the SQL query.</returns>
        /// <remarks>
        /// This is typically used when the results of a query are not processed by Dapper,
        /// for example, used to fill a System.Data.DataTable or DataSet.
        /// </remarks>
        IDataReader ExecuteReader(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null);

        Task<IDataReader> ExecuteReaderAsync(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
       int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// Manages connection internally.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>The first cell returned, as T.</returns>
        T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null,
           int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// Works with externally managed connection
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="dbConnection">The connection to execute on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>The first cell returned, as T.</returns>
        T ExecuteScalar<T>(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// Manages connection internally.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A first instance of the supplied type; if a basic type (int, string,
        /// etc) is queried then the data from the first column in assumed, otherwise an
        /// instance is created per row, and a direct column-name===member-name mapping is
        /// assumed (case insensitive).
        /// </returns>
        T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// Works with externally managed connection
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="dbConnection">The connection to execute on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A first instance of the supplied type; if a basic type (int, string,
        /// etc) is queried then the data from the first column in assumed, otherwise an
        /// instance is created per row, and a direct column-name===member-name mapping is
        /// assumed (case insensitive).
        /// </returns>
        T QueryFirst<T>(IDbConnection dbConnection, string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
           int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// Manages connection internally.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A first instance or null of the supplied type; if a basic type (int, string,
        /// etc) is queried then the data from the first column in assumed, otherwise an
        /// instance is created per row, and a direct column-name===member-name mapping is
        /// assumed (case insensitive).
        /// </returns>
        T QueryFirstOrDefault<T>(string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null,
           IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// Works with externally managed connection
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="dbConnection">The connection to execute on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A first instance or null of the supplied type; if a basic type (int, string,
        /// etc) is queried then the data from the first column in assumed, otherwise an
        /// instance is created per row, and a direct column-name===member-name mapping is
        /// assumed (case insensitive).
        /// </returns>
        T QueryFirstOrDefault<T>(IDbConnection dbConnection, string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// Manages connection internally.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A single instance of the supplied type; if a basic type (int, string,
        /// etc) is queried then the data from the first column in assumed, otherwise an
        /// instance is created per row, and a direct column-name===member-name mapping is
        /// assumed (case insensitive).
        /// </returns>
        T QuerySingle<T>(string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// Works with externally managed connection
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="dbConnection">The connection to execute on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A single instance of the supplied type; if a basic type (int, string,
        /// etc) is queried then the data from the first column in assumed, otherwise an
        /// instance is created per row, and a direct column-name===member-name mapping is
        /// assumed (case insensitive).
        /// </returns>
        T QuerySingle<T>(IDbConnection dbConnection, string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
           int? commandTimeout = null, CommandType? commandType = null);
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// Manages connection internally.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A single instance of the supplied type; if a basic type (int, string,
        /// etc) is queried then the data from the first column in assumed, otherwise an
        /// instance is created per row, and a direct column-name===member-name mapping is
        /// assumed (case insensitive).
        /// </returns>
        T QuerySingleOrDefault<T>(string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null,
             IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// Works with externally managed connection
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="dbConnection">The connection to execute on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A single instance or null of the supplied type; if a basic type (int, string,
        /// etc) is queried then the data from the first column in assumed, otherwise an
        /// instance is created per row, and a direct column-name===member-name mapping is
        /// assumed (case insensitive).
        /// </returns>

        T QuerySingleOrDefault<T>(IDbConnection dbConnection, string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);


    }
}
