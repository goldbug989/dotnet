using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace MVCApp
{
    //TODO---   app does not use this class yet

    //add this to configure services and implement 
    //
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection(string connectionString);
    }

    public class SqlDbConnectionFactory : IDbConnectionFactory
    {
        IConfiguration _config;

        public SqlDbConnectionFactory(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection GetConnection(string connectionString)
        {
            var connection = new SqlConnection(_config.GetConnectionString(connectionString));
            connection.Open();
            return connection;
        }
    }
}
