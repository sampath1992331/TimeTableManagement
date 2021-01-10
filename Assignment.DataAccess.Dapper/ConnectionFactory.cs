using Core.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Dapper
{
    public class ConnectionFactory:IConnectionFactory
    {
        private readonly string connectionString;

        public ConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(this.connectionString);
        }
    }
}
