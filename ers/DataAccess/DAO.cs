using Models;

namespace DataAccess;


/// <summary>
/// Interface for TicketRepository class
/// </summary>
public interface ITicketDAO
{
    public List<Ticket> GetAllTickets();
    public List<Ticket> GetAllTicketsByAuthor(int authorID);
    public List<Ticket> GetAllTicketsByStatus (Status state);
    public Ticket GetTicketById(int ticketID);
    public Ticket CreateTicket(Ticket ticket);
    public Ticket UpdateTicket(Ticket ticket);

} 
/// <summary>
/// Interface for UserRepository class
/// </summary>
public interface IUserDAO
{
    public List<User> GetAllUsers();
    public User GetUserById(int userID);
    public User GetUserbyUsername(string username);
    public User CreateUser(User user);
    //public User UpdateTicket(Ticket ticket);
} 