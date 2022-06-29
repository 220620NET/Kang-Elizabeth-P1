using Models;
using CustomExceptions;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

User user1 = new User("test", "test", "test", Role.Manager);

Console.WriteLine(user1.userName);