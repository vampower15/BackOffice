using System.Data;
using System.Data.SqlClient;

namespace Test_Office.ConnectionContext
{
    public class SqlConnectionContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _sqlSqlConnectionSting;

        public SqlConnectionContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlSqlConnectionSting = _configuration.GetConnectionString("SqlConnectionString");
        }
        public IDbConnection CreateSqlconnection() => new SqlConnection(_sqlSqlConnectionSting);
    }
}
