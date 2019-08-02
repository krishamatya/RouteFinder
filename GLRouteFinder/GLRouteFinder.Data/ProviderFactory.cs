using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace GLRouteFinder
{
    public class ProviderFactory
    {
        public IDbConnection CreateConnection()
        {
            return (IDbConnection)new SqlConnection();
        }
        public IDbConnection CreateConnection(string connectionString)
        {
            return (IDbConnection)new SqlConnection(connectionString);
        }
        public IDbCommand CreateCommand()
        {
            return (IDbCommand)new SqlCommand();
        }
        public IDbCommand CreateCommand(string cmdText, IDbConnection connection)
        {
            return (IDbCommand)new SqlCommand(cmdText, (SqlConnection)connection);
        }

        #region IDbDataAdapter methods
        /// <summary>
        /// Creates a Oracle Data Adapter. 
        /// </summary>
        /// <returns>IDbDataAdapter</returns>
        public IDbDataAdapter CreateDataAdapter()
        {
            return (IDbDataAdapter)new SqlDataAdapter();
        }
        /// <summary>
        /// Creates a Oracle Data Adapter
        /// </summary>
        /// <param name="selectCommand">Oracle Command</param>
        /// <returns>IDbDataAdapter</returns>
        public IDbDataAdapter CreateDataAdapter(SqlCommand selectCommand)
        {
            return (IDbDataAdapter)new SqlDataAdapter(selectCommand);
        }
        /// <summary>
        /// Creates a Oracle Data Adapter
        /// </summary>
        /// <param name="selectCommandText">Oracle Query</param>
        /// <param name="selectConnection">Oracle Connection</param>
        /// <returns>IDbDataAdapter</returns>
        public IDbDataAdapter CreateDataAdapter(string selectCommandText, SqlConnection selectConnection)
        {
            return (IDbDataAdapter)new SqlDataAdapter(selectCommandText, selectConnection);
        }
        /// <summary>
        /// Creates a Oracle Data Adapter
        /// </summary>
        /// <param name="selectCommandText">Oracle Query</param>
        /// <param name="selectConnectionString">Connection String</param>
        /// <returns></returns>
        public IDbDataAdapter CreateDataAdapter(string selectCommandText, string selectConnectionString)
        {
            return (IDbDataAdapter)new SqlDataAdapter(selectCommandText, selectConnectionString);
        }
        #endregion

       
        /// <summary>
        /// Creates Oracle Data Parameter
        /// </summary>
        /// <returns>IDbDataParameter</returns>
        public IDbDataParameter CreateDataParameter()
        {
            return (IDbDataParameter)new SqlParameter();
        }

        /// <summary>
        /// Creates Data Parameter
        /// </summary>
        /// <param name="parameterName">Parmater Name</param>
        /// <param name="dataType">Database Type</param>
        /// <returns>IDbDataParameter</returns>
        public IDbDataParameter CreateDataParameter(string parameterName, DbType dataType)
        {
            IDbDataParameter param = CreateDataParameter();

            if (param != null)
            {
                param.ParameterName = parameterName;
                param.DbType = dataType;
            }

            return param;
        }


        /// <summary>
        /// Creates Oracle Stored Procedure Parameter
        /// </summary>
        /// <param name="parameterName">Parameter</param>
        /// <param name="value">value</param>
        /// <returns>IDbDataParameter</returns>
        public IDbDataParameter CreateDataParameter(string parameterName, object value)
        {
            return (IDbDataParameter)new SqlParameter(parameterName, value);
        }

        /// <summary>
        /// Creates Data Parameter
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="dataType">Database Type</param>
        /// <param name="size">Size</param>
        /// <returns>IDbDataParameter</returns>
        public IDbDataParameter CreateDataParameter(string parameterName, DbType dataType, int size)
        {
            IDbDataParameter param = CreateDataParameter();

            if (param != null)
            {
                param.ParameterName = parameterName;
                param.DbType = dataType;
                param.Size = size;
            }

            return param;
        }

    }
}

