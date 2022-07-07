using Models;
using CustomExceptions;
using System.Text.RegularExpressions;

//USER TESTING
User user1 = new User("test", "test", "test", Role.Manager);
User user2 = new User("test", "test", "test", Role.Manager);

Console.WriteLine(user1); //ToString

Console.WriteLine();

Console.WriteLine(user1.Equals(user2)); //Equals Works

user2.ID = "new test";

Console.WriteLine(user1.Equals(user2)); //Equals Works

Console.WriteLine();

//TICKET TESTING
Ticket ticket1 = new Ticket("test", "test", "test", "test", Ticket.Status.Pending, 1);
Ticket ticket2 = new Ticket("test", "test", "test", "test", Ticket.Status.Pending, 1);
Ticket ticket3 = new Ticket("test", "test", "test", "test", Ticket.Status.Pending, 1);

ticket3 = ticket1;


Console.WriteLine(ticket1); //ToString Works

Console.WriteLine();

Console.WriteLine(ticket1.Equals(ticket2)); //Equals Works

ticket2.ID = "new test";

Console.WriteLine(ticket1.Equals(ticket2)); //Equals Works

Console.WriteLine(user1.ID.GetHashCode());
Console.WriteLine(user2.ID.GetHashCode());

Console.WriteLine(ticket1.GetHashCode());
Console.WriteLine(ticket3.GetHashCode());

Guid g = Guid.NewGuid();