using Models;

namespace DataAccess;

public interface TicketDAO
{
    public List<Ticket> GetAllTickets();
    public List<Ticket> GetAllTicketsByAuthor(int authorID);
    public List<Ticket> GetAllTicketsByStatus (Status state);
    public Ticket GetTicketsById(int ticketID);
    public bool CreateTicket(Ticket ticket);
    public bool UpdateTicket(Ticket ticket);

} 

public interface UserDAO
{
    public List<User> GetAllUsers();
    public User GetUserById(int userID);
    public User GetUserbyUsername(string username);
    public bool CreateUser(User user);
    
} 