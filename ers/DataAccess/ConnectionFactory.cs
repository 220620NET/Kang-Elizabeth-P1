using System.Data.SqlClient;

namespace DataAccess;

public class ConnectionFactory
{
    private static ConnectionFactory? _instance;
    private readonly static string _connectionString = File.ReadAllText("../DataAccess/connectionString.txt");
    private ConnectionFactory() {}
    public static ConnectionFactory GetInstance()
    {
        if(_instance == null)
        {
            _instance = new ConnectionFactory();
        }
        return _instance;
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}