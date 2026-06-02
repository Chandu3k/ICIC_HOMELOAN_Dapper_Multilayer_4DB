using BussinessEntites.Interfaces;
using BussinessEntites.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection HotelsConnectionString()
        {
            string connectionString = _configuration.GetConnectionString(ConnectionStrings.HotelsSqlConnection);
            return new SqlConnection(connectionString);
        }

        public IDbConnection MidlandConnectionString()
        {
            string connectionString = _configuration.GetConnectionString(ConnectionStrings.MidlandSqlConnection);
            return new SqlConnection(connectionString);
        }

        public IDbConnection ProductConnectionString()
        {
            string connectionString = _configuration.GetConnectionString(ConnectionStrings.ProductsSqlConnection);
            return new SqlConnection(connectionString);
        }

        public IDbConnection RestaurantConnectionString()
        {
            string connectionString = _configuration.GetConnectionString(ConnectionStrings.RestaurantsSqlConnection);
            return new SqlConnection(connectionString);
        }
    }
}
