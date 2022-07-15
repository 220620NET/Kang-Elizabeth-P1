using System.Data.SqlClient;
using System.Data;
using Models;
using CustomExceptions;

namespace DataAccess;

public class UserRepository : IUserDAO
{
    private readonly ConnectionFactory _connectionFactory;
    
    public UserRepository(ConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    public List<User> GetAllUsers()
    {
        List<User> users = new List<User>();
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM ers.Users", conn);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            User usr = new User();
            
            users.Add(new User
            {
                ID = (int)reader["user_ID"],
                username = (string)reader["username"],
                password = (string)reader["password"],
                role = usr.StringToRole((string)reader["role"])
            });
        }
        return users;
    }
    
    public User GetUserById(int userID)
    {
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM ers.Users WHERE user_ID = @ID;", conn);
        cmd.Parameters.AddWithValue("@ID", userID);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            User usr = new User();

            return new User
            {
                ID = (int)reader["user_ID"],
                username = (string)reader["username"],
                password = (string)reader["password"],
                role = usr.StringToRole((string)reader["role"])
            };
        }
        throw new ResourceNotFoundException("Could not find the user associated with the ID");
    }    
    
    public User GetUserByUsername(string username)
    {
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM ers.Users WHERE user_ID = @usr;", conn);
        cmd.Parameters.AddWithValue("@usr", username);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            User usr = new User();

            return new User
            {
                ID = (int)reader["user_ID"],
                username = (string)reader["username"],
                password = (string)reader["password"],
                role = usr.StringToRole((string)reader["role"])
            };
        }
        throw new ResourceNotFoundException("Could not find the user associated with the username");
    }
    
    public bool CreateUser(User NewUserToAdd)
    {
        DataSet userSet = new DataSet();

        SqlDataAdapter userAdapter = new SqlDataAdapter("SELECT * FROM ers.Users", _connectionFactory.GetConnection());

        userAdapter.Fill(userSet, "userTable");

        DataTable? userTable = userSet.Tables["userTable"];

        if(userTable != null)
        {
            DataRow newUser = userTable.NewRow();
            newUser["username"] = NewUserToAdd.username;
            newUser["password"] = NewUserToAdd.password;
            newUser["role"] = NewUserToAdd.role;
        
            userTable.Rows.Add(newUser);

            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(userAdapter);

            SqlCommand insertCommand = cmdbuilder.GetInsertCommand();
            userAdapter.InsertCommand = insertCommand;

            userAdapter.Update(userTable);
            return true;
        }

        return false;
    }
}