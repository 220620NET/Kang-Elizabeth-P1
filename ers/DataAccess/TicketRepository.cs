using System.Data.SqlClient;
using System.Data;
using Models;
using CustomExceptions;

namespace DataAccess;

public class TicketRepository : ITicketDAO
{
    private readonly ConnectionFactory _connectionFactory;
    
    public TicketRepository(ConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public List<Ticket> GetAllTickets()
    {
        List<Ticket> tickets = new List<Ticket>();
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM ers.tickets", conn);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Ticket tick = new Ticket();
            
            tickets.Add(new Ticket
            {
                ID = (int)reader["ticket_ID"],
                authorID = (int)reader["author_fk"],
                resolverID = (int)reader["resolver_fk"],
                description = (string)reader["description"],
                status = tick.StringToStatus((string)reader["status"]),
                amount = (decimal)reader["amount"]
            });
        }
        return tickets;
    }

    public List<Ticket> GetAllTicketsByAuthor(int authorID)
    {
        List<Ticket> tickets = new List<Ticket>();
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM ers.Tickets WHERE author_fk = @a;", conn);
        cmd.Parameters.AddWithValue("@a", authorID);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Ticket tick = new Ticket();
            
            tickets.Add(new Ticket
            {
                ID = (int)reader["ticket_ID"],
                authorID = (int)reader["author_fk"],
                resolverID = (int)reader["resolver_fk"],
                description = (string)reader["description"],
                status = tick.StringToStatus((string)reader["status"]),
                amount = (decimal)reader["amount"]
            });
        }
        return tickets;
    }

    public List<Ticket> GetAllTicketsByStatus (Status status)
    {
        List<Ticket> tickets = new List<Ticket>();
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM ers.Tickets WHERE author_fk = @s;", conn);
        cmd.Parameters.AddWithValue("@s", status);

        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Ticket tick = new Ticket();
            
            tickets.Add(new Ticket
            {
                ID = (int)reader["ticket_ID"],
                authorID = (int)reader["author_fk"],
                resolverID = (int)reader["resolver_fk"],
                description = (string)reader["description"],
                status = tick.StringToStatus((string)reader["status"]),
                amount = (decimal)reader["amount"]
            });
        }
        return tickets;
    }
    
    public Ticket GetTicketById(int ticketID)
    {
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM ers.Tickets WHERE ticket_ID = @ID;", conn);
        cmd.Parameters.AddWithValue("@ID", ticketID);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Ticket tick = new Ticket();

            return new Ticket
            {
                ID = (int)reader["ticket_ID"],
                authorID = (int)reader["author_fk"],
                resolverID = (int)reader["resolver_fk"],
                description = (string)reader["description"],
                status = tick.StringToStatus((string)reader["status"]),
                amount = (decimal)reader["amount"]
            };
        }
        throw new ResourceNotFoundException("Could not find the ticket associated with the ID");
    }
    
    public bool CreateTicket(Ticket NewTicketToAdd)
    {
        DataSet ticketSet = new DataSet();

        SqlDataAdapter ticketAdapter = new SqlDataAdapter("SELECT * FROM ers.Tickets", _connectionFactory.GetConnection());

        ticketAdapter.Fill(ticketSet, "ticketTable");

        DataTable? ticketTable = ticketSet.Tables["ticketTable"];

        if(ticketTable != null)
        {
            DataRow newTicket = ticketTable.NewRow();
            newTicket["author_fk"] = NewTicketToAdd.authorID;
            newTicket["resolver_fk"] = NewTicketToAdd.resolverID;
            newTicket["description"] = NewTicketToAdd.description;
            newTicket["status"] = NewTicketToAdd.status;
            newTicket["amount"] = NewTicketToAdd.amount;
        
            ticketTable.Rows.Add(newTicket);

            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(ticketAdapter);

            SqlCommand insertCommand = cmdbuilder.GetInsertCommand();
            ticketAdapter.InsertCommand = insertCommand;

            ticketAdapter.Update(ticketTable);
            return true;
        }

        return false;
    }
    
    public bool UpdateTicket(Ticket UpdatedTicket)
    {
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("UPDATE ers.Tickets SET author_fk = @afk, resolver_fk = @rfk, description = @d, status = @s, amount = @amt WHERE ticket_ID = @ID;", conn);
        
        cmd.Parameters.AddWithValue("@ID", UpdatedTicket.ID);
        cmd.Parameters.AddWithValue("@afk", UpdatedTicket.authorID);
        cmd.Parameters.AddWithValue("@rfks", UpdatedTicket.resolverID);
        cmd.Parameters.AddWithValue("@d", UpdatedTicket.description);
        cmd.Parameters.AddWithValue("@s", UpdatedTicket.StatusToString(UpdatedTicket.status));
        cmd.Parameters.AddWithValue("@amt", UpdatedTicket.amount);

        try
        {
            cmd.ExecuteReader();

            int rowsAffected = cmd.ExecuteNonQuery();
        }
        catch(Exception)
        {
            return false;
        }

        return true;

        /// try 
        /// excute command queury 
        /// return true!

        /// catch return false or throw new Exception

        /// trypase --> trys to parse, gives false if it doesnt work
        /// parse ---> throws an exception
    }
}