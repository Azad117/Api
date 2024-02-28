using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public interface IDb
{
    IDbConnection CreateConnection();
}

public class Db : IDb
{
    private readonly string _connectionString;

    public Db(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("SqlServerDb");
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
