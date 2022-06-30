namespace Models;

public class Ticket
{
    public enum Status
    {
        Pending,
        Approved,
        Denied
    }

    public string ID { get; set;}
    public string author { get; set;}
    public string resolver { get; set;}
    public string description { get; set;}
    public Status status { get; set;}
    public decimal amount { get; set;}

    /// <summary>
    /// This is the constructor for the Ticket Object
    /// </summary>
    /// <param name="ID">A unique string associated with the Ticket</param>
    /// <param name="author">The ID of the user who authored the Ticket</param>
    /// <param name="resolver">The ID of the user who resolved of the Ticket</param>
    /// <param name="description">The description of the reason for the request</param>
    /// <param name="status">The status of the Ticket can be Pending, Approved, or Denied/</param>
    /// <param name="amount">The dollar amount stored on the Ticket/</param>
    public Ticket(string ID, string author, string resolver, string description, Status status, decimal amount)
    {
        this.ID = ID;
        this.author = author;
        this.resolver = resolver;
        this.description = description;
        this.status = status;
        this.amount = amount;
    }

    public override string ToString()
    {
        return "Ticket Object:\n" +
            "ID = " + ID + "\n" +
            "Author = " + author + "\n" +
            "Resolver = " + resolver + "\n" +
            "Description = " + description + "\n" +
            "Status = " + status + "\n" +
            "Amount = " + amount;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        else
        {
            Ticket ticket = (Ticket)obj;

            return ticket.ID == this.ID &&
                ticket.author == this.author &&
                ticket.resolver == this.resolver &&
                ticket.description ==  this.description &&
                ticket.status ==  this.status &&
                ticket.amount ==  this.amount;
        }
    }

    public override int GetHashCode() => (author, resolver, description, status, amount).GetHashCode();
}
