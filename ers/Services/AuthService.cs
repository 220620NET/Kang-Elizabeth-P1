using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class AuthService
{
    public User Login(string username, string password)
    {
        User user;
        
        try
        {
            user = new UserService().GetUserByUserName(username);
            if(user.username == "")
            {
                throw new ResourceNotFoundException();
            }
            else if(user.password == password)
            {
                return user;
            }
            else
            {
                throw new InvalidCredentialsException();
            }
        }
        catch(ResourceNotFoundException)
        {
            throw;
        }
        catch(InvalidCredentialsException)
        {
            throw;
        }
    }

    public bool Register(User newUser)
    {
        try
        {
            User attempt = new UserService().GetUserByUserName(newUser.username);

            if(attempt.username == newUser.username)
            {
                throw new UsernameNotAvailableException();
            }
            else
            {
                return new UserRepository().CreateUser(newUser);
            }
        }
        catch(UsernameNotAvailableException)
        {
            throw;
        }
    }
}