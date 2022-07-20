using Services;
using CustomExceptions;
using DataAccess;
using Models;

namespace WebAPI.Controller;

public class UserController
{
    private readonly UserServices _Services;
    public UserController(UserServices services)
    {
        _Services = services;
    }

    /// <summary>
    /// Controller for getting all users
    /// </summary>
    /// <returns>Status code 202 for success get all users</returns>
    public IResult GetAllUsers()
    {
        try
        {
            List<User> ListUsers = _Services.GetAllUsers();
            return Results.Accepted("/users", ListUsers);
        }
        catch(ResourceNotFoundException)
        {
            return Results.NotFound("There are no users");
        }
    }
}