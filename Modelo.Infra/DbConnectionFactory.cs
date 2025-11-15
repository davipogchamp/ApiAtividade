using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;   
namespace Modelo.Infra
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StringConexao");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
