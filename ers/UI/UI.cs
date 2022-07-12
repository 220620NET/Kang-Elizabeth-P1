using Models;
using Services;
using DataAccess;
using CustomExceptions;

namespace UI;

class test
{
    static void Main(string[] args)
    {
        
        User attempt = new User("firsttest", "passowrd", 0);
        Console.WriteLine(new UserRepository().GetUserById(1));
    }
}

