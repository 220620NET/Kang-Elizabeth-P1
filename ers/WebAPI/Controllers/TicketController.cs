using Services;
using CustomExceptions;
using DataAccess;
using Models;
namespace WebAPI.Controller;
public class TicketController
{
    private readonly TicketServices _Services;

    public TicketController(TicketServices services)
    {
        _Services = services;
    }

    /// <summary>
    /// Controller for creating a new ticket
    /// </summary>
    /// <param name="newTicket">The ticket object for the new ticket </param>
    /// <remarks>Status code 409 ticket was not correctly submitted or created<remarks>
    /// <returns>Status code 202 for successful creation</returns>
    public IResult Submit(Ticket newTicket)
    {
        try
        {
            bool all = _Services.SubmitReimbursement(newTicket);
            return Results.Accepted("/submit", _Services.GetReimbursementByUserID(newTicket.authorID));
        }
        catch(ResourceNotFoundException)
        {
            return Results.Conflict("The ticket could not be submitted");
        }
        catch(UsernameNotAvailableException)
        {
            return Results.Conflict("No user with that ID");
        }
    }
    

}