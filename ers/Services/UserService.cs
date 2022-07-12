using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class UserService
{
    public User GetUserByUserName(string username)
    {
        try
        {
            return new UserRepository().GetUserbyUsername(username);
        }
        catch(UsernameNotAvailableException)
        {
            throw;
        }
    }

    public List<User> GetAllUsers()
    {
        try
        {
            return new UserRepository().GetAllUsers();
        }
        catch (ResourceNotFoundException)
        {
            throw;
        }
    }

    public User GetUserByuserId(int userId)
    {
        User users = new User();
        try
        {
            List<User> userList = GetAllUsers();
            if (userList.Count <userId)
            {
                throw new ResourceNotFoundException();
            }
            else
            {
                users =new UserRepository().GetUserById(userId);
            }
        }
        catch (ResourceNotFoundException)
        {
            throw;
        }
        return users;
    }
}
