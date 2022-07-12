using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class TicketService
{
    public bool SubmitReimbursement(Ticket ticket)
    {
        try
        {
            bool x =  new TicketRepository().CreateTicket(ticket);
            if(x)
            {
                return true;
            }
            else { return false; }
        }
        catch(Exception)
        {
            throw;

        }
    }
    public bool UpdateReimbursement(Ticket update)
    {
        try
        {
            return new TicketRepository().UpdateTicket(update);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Ticket GetReimbursementByID(int ticketID)
    {
        try
        {
            return new TicketRepository().GetTicketsById(ticketID);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Ticket> GetReimbursementByUserID(int userID)
    {
        try
        {
            return new TicketRepository().GetAllTicketsByAuthor(userID);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Ticket> GetReimbursementByStatus(Status state)
    {
        try
        {
            return new TicketRepository().GetAllTicketsByStatus(state);
        }
        catch (Exception)
        {
            throw;
        }
    }
}