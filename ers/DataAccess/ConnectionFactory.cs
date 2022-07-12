using System.Data.SqlClient;

namespace DataAccess;

public class ConnectionFactory
{
    string connectionString = "";

    public SqlConnection GetConnection()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        return connection;
    }

    public bool EndConnection()
    {
        new SqlConnection(connectionString).Close();
        return true;
    }

    public SqlCommand GetInstance(string sql)
    {
        return new SqlCommand(sql, GetConnection());
    }


}