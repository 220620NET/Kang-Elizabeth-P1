namespace Models;

public enum Status
{
    Pending,
    Approved,
    Denied
}
public class Ticket
{
    public int ID { get; set;}
    public int authorID { get; set;}
    public int resolverID { get; set;}
    public string description { get; set;}
    public Status status { get; set;}
    public decimal amount { get; set;}

    /// <summary>
    /// This is the constructor for the Ticket Object
    /// </summary>
    /// <param name="ID">The ID int associated with the Ticket</param>
    /// <param name="authorID">The ID of the user who authored the Ticket</param>
    /// <param name="resolverID">The ID of the user who resolved of the Ticket</param>
    /// <param name="description">The description of the reason for the request</param>
    /// <param name="status">The status of the Ticket can be Pending, Approved, or Denied/</param>
    /// <param name="amount">The dollar amount stored on the Ticket/</param>
    public Ticket(int ID, int authorID, int resolverID, string description, Status status, decimal amount)
    {
        this.ID = ID;
        this.authorID = authorID;
        this.resolverID = resolverID;
        this.description = description;
        this.status = status;
        this.amount = amount;
    }

    public Ticket() {}

    public string NumToString(int input)
    {
        switch(input)
        {
            case 1:
                return "Approved";
            case 2:
                return "Denied";
            default:
                return "Pending";
        }
    }
    public int StringToNum(string input)
    {
        switch(input)
        {
            case "Approved":
                return 1;
            case "Denied":
                return 2;
            default:
                return 0;
        }
    }
    
    public override string ToString()
    {
        return "Ticket Object:\n" +
            "ID = " + ID + "\n" +
            "Author = " + authorID + "\n" +
            "Resolver = " + resolverID + "\n" +
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
                ticket.authorID == this.authorID &&
                ticket.resolverID == this.resolverID &&
                ticket.description ==  this.description &&
                ticket.status ==  this.status &&
                ticket.amount ==  this.amount;
        }
    }

    // public override bool Equals(object other) =>
    //     other is Ticket tick &&
    //     (tick.ID, tick.author, tick.resolver, tick.description, tick.status, tick.amount).Equals((ID, author, resolver, description, status, amount));

    public override int GetHashCode()
    {
        int hashcode = 12;
        hashcode = hashcode * 2 ^ ID.GetHashCode();
        hashcode = hashcode * 2 ^ authorID.GetHashCode();
        hashcode = hashcode * 2 ^ resolverID.GetHashCode();
        hashcode = hashcode * 2 ^ description.GetHashCode();
        hashcode = hashcode * 2 ^ status.GetHashCode();
        hashcode = hashcode * 2 ^ amount.GetHashCode();
        return hashcode;
    }

    // public override int GetHashCode() => (author, resolver, description, status, amount).GetHashCode();
}
