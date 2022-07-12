using System.Data.SqlClient;
using Models;

namespace DataAccess;

public class UserRepository : UserDAO
{
    string connectionString = "";

    public List<User> GetAllUsers()
    {
        List<User> users = new List<User>();
        
        string sql = "SELECT * FROM ers.Users";

        SqlConnection connection = new SqlConnection(connectionString);
        
        SqlCommand command = new SqlCommand(sql, connection);

        try
        {
            connection.Open();
            
            SqlDataReader reader = command.ExecuteReader();
            
            while(reader.Read())
            {
                users.Add(new User((int) reader[0], (string) reader[1], (string) reader[2], (Role) reader[3]));
            }
        }
        
        catch(Exception e) 
        {
            Console.WriteLine(e.Message);
            return new List<User>();
        }

        return users;
    }

    public User GetUserById(int userID)
    {
        string sql = "SELECT * FROM ers.Users WHERE user_ID = @i;";

        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@i", userID);

        User user = new User();

        try
        {
            connection.Open();
            
            SqlDataReader reader = command.ExecuteReader();
            
            while(reader.Read())
            {
                user = new User((int)reader[0], (string)reader[1], (string)reader[2], (Role)reader[3]);
            }
            
            reader.Close();
            
            connection.Close();
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new User();
        }

        return user;
    }
    
    public User GetUserbyUsername(string username)
    {
        string sql = "SELECT * FROM ers.Users WHERE username = @u;";
        
        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@u", username);

        User user = new User();

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                user = new User((int)reader[0], (string)reader[1], (string)reader[2], (Role)reader[3]);
            }
             reader.Close();
        
            connection.Close();
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            return new User();
        }

        return user;
    }
    
    public bool CreateUser(User newUser)
    {
        string sql = "INSERT INTO ers.Users(username, password, role) value (@u, @p, @r";

        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@u", newUser.username);
        command.Parameters.AddWithValue("@p", newUser.password);
        command.Parameters.AddWithValue("@r", newUser.role);

        try
        {
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if(rowsAffected != 0)
            {
                return true;
            }
        }

        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        return false;
    }
}