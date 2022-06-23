namespace Models;

public class Ticket
{
    public string ID {get; set;}
    public string author {get; set;}
    public string resolver {get; set;}
    public string status {get; set;}
    public decimal amount {get; set;}

    public Ticket(string ID, string author, string resolver, string status, decimal status)
    {
        this.ID = ID;
        this.author = author;
        this.resolver = resolver;
        this.status = status;
        this.amount = amount;
    }
}
