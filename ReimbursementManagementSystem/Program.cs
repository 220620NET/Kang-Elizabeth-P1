using Models;
using CustomExceptions;

User user1 = new User("test", "test", "test", Role.Manager);

Console.WriteLine(user1);

Console.WriteLine();

Ticket ticket1 = new Ticket("test", "test", "test", "test", Ticket.Status.Pending, 1);

Console.WriteLine(ticket1);

Console.WriteLine();
