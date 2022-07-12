using System.Data.SqlClient;
using Models;

namespace DataAccess;

public class TicketRepository : TicketDAO
{
    string connectionString = "";

    public List<Ticket> GetAllTickets()
    {
        string sql = "SELECT * FROM ers.tickets;";

        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand(sql, connection);

        List<Ticket> tickets = new List<Ticket>();

        Ticket ticket = new Ticket();

        try
        {
            connection.Open();
            
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                tickets.Add(new Ticket((int)reader[0], (int) reader[1], (int)reader[2], (string)reader[3], (Status)reader[4], (decimal)reader[5]));
            }

            reader.Close();
            connection.Close();
        }

        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return new List<Ticket>();

        }
        return tickets;
    }
    public List<Ticket> GetAllTicketsByAuthor(int authorID)
    {
        string sql = "SELECT * FROM ers.Tickets WHERE author_fk = @a;";

        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@a", authorID);

        List<Ticket> tickets = new List<Ticket>();

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                tickets.Add(new Ticket((int)reader[0], (int)reader[1], (int)reader[2], (string)reader[3], (Status)reader[4], (decimal)reader[5]));
            }

            reader.Close();
            connection.Close();
        }

        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return new List<Ticket>();
        }
        return tickets;
    }
    public List<Ticket> GetAllTicketsByStatus (Status state)
    {
        string sql = "SELECT * FROM ers.Tickets WHERE status = @s;";

        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@s", state);

        List<Ticket> tickets = new List<Ticket>();

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                tickets.Add(new Ticket((int)reader[0], (int)reader[1], (int)reader[2], (string)reader[3], (Status)reader[4], (decimal)reader[5]));
            }

            reader.Close();
            connection.Close();
        }

        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return new List<Ticket>();
        }
        return tickets;
    }
    public Ticket GetTicketsById(int ticketID)
    {
        string sql = "SELECT * FROM ers.Tickets WHERE ticket_ID = @i;";

        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@i", ticketID);
        Ticket returnTicket = new Ticket();
        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Ticket ticket = new Ticket ((int)reader[0], (int)reader[1], (int)reader[2], (string)reader[3], (Status)reader[4], (decimal)reader[5]);
                returnTicket = ticket;
            }

            reader.Close();
            connection.Close();
        }

        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return new Ticket();
        }
        return returnTicket;
    }
    public bool CreateTicket(Ticket ticket)
    {
        string sql = "INSERT INTO ers.Tickets (author_fk, description, amount) VALUES (@at, @d, @am);";

        SqlConnection connection = new SqlConnection (connectionString);

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@at", ticket.authorID);
        command.Parameters.AddWithValue("@d", ticket.description);
        command.Parameters.AddWithValue("@am", ticket.amount);

        try
        {
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();
            
            connection.Close();

            if(rowsAffected != 0)
            {
                return true;
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return false;
    }
    public bool UpdateTicket(Ticket ticket)
    {
        string sql = "UPDATE ers.Tickets SET stauts = @s, resolver = @r WHERE ticket_ID = @id;";

        SqlConnection connection = new SqlConnection (connectionString);

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@id", ticket.ID);
        command.Parameters.AddWithValue("@r", ticket.resolverID);
        command.Parameters.AddWithValue("@s", ticket.status);

        try
        {
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();
            
            connection.Close();

            if(rowsAffected != 0)
            {
                return true;
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return false;
    }
}