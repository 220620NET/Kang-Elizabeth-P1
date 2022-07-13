using System.Data.SqlClient;
using System.Data;
using Models;
using CustomExceptions;

namespace DataAccess;

public class TicketRepository : ITicketDAO
{
    private readonly ConnectionFactory _connectionFactory;
    
    public TicketRepository()
    {
        _connectionFactory = ConnectionFactory.GetInstance();
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
            Status state = (Status)tick.StringToNum((string)reader["status"]);
            
            tickets.Add(new Ticket
            {
                ID = (int)reader["ticket_ID"],
                authorID = (int)reader["author_fk"],
                resolverID = (int)reader["resolver_fk"],
                description = (string)reader["description"],
                status = state,
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
            Status state = (Status)tick.StringToNum((string)reader["status"]);
            
            tickets.Add(new Ticket
            {
                ID = (int)reader["ticket_ID"],
                authorID = (int)reader["author_fk"],
                resolverID = (int)reader["resolver_fk"],
                description = (string)reader["description"],
                status = state,
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
            Status state = (Status)tick.StringToNum((string)reader["status"]);
            
            tickets.Add(new Ticket
            {
                ID = (int)reader["ticket_ID"],
                authorID = (int)reader["author_fk"],
                resolverID = (int)reader["resolver_fk"],
                description = (string)reader["description"],
                status = state,
                amount = (decimal)reader["amount"]
            });
        }
        return tickets;
    }
    public Ticket GetTicketById(int ticketID)
    {
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM ers.Tickets WHERE author_fk = @ID;", conn);
        cmd.Parameters.AddWithValue("@ID", ticketID);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Ticket tick = new Ticket();
            Status state = (Status)tick.StringToNum((string)reader["status"]);

            return new Ticket
            {
                ID = (int)reader["ticket_ID"],
                authorID = (int)reader["author_fk"],
                resolverID = (int)reader["resolver_fk"],
                description = (string)reader["description"],
                status = state,
                amount = (decimal)reader["amount"]
            };
        }
        throw new ResourceNotFoundException("Could not find the ticket associated with the ID");
    }
    public Ticket CreateTicket(Ticket newTicketToAdd)
    {
        DataSet ticketSet = new DataSet();

        SqlDataAdapter ticketAdapter = new SqlDataAdapter("SELECT * FROM ers.Tickets", _connectionFactory.GetConnection());

        ticketAdapter.Fill(ticketSet, "ticketTable");

        DataTable? ticketTable = ticketSet.Tables["ticketTable"];

        if(ticketTable != null)
        {
            DataRow newTicket = ticketTable.NewRow();
            newTicket["author_fk"] = newTicketToAdd.authorID;
            newTicket["resolver_fk"] = newTicketToAdd.resolverID;
            newTicket["description"] = newTicketToAdd.description;
            newTicket["status"] = newTicketToAdd.status;
            newTicket["amount"] = newTicketToAdd.amount;
        
            ticketTable.Rows.Add(newTicket);

            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(ticketAdapter);

            SqlCommand insertCommand = cmdbuilder.GetInsertCommand();
            ticketAdapter.InsertCommand = insertCommand;

            ticketAdapter.Update(ticketTable);
        }

        return newTicketToAdd;
    }
    public Ticket UpdateTicket(Ticket UpdatedTicket)
    {
        DataSet ticketSet = new DataSet();

        SqlDataAdapter ticketAdapter = new SqlDataAdapter("SELECT * FROM ers.Tickets", _connectionFactory.GetConnection());

        ticketAdapter.Fill(ticketSet, "ticketTable");

        DataTable? ticketTable = ticketSet.Tables["ticketTable"];
        
        return new Ticket();
    }
}