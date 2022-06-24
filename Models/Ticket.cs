namespace Models;

public class Ticket
{
    public string ID {get; set;}
    public string author {get; set;}
    public string resolver {get; set;}
    public string decription {get; set;}
    public string status {get; set;}
    public decimal amount {get; set;}


    /// <summary>
    /// This is the constructor for the Ticket Object
    /// </summary>
    /// <param name="ID">A unique string associated with the Ticket</param>
    /// <param name="author">The ID of the user who authored the Ticket</param>
    /// <param name="resolver">The ID of the user who resolved of the Ticket</param>
    /// <param name="description">The description of the reason for the request</param>
    /// <param name="status">The status of the Ticket can be Pending, Approved, or Denied/</param>
    /// <param name="amount">The dollar amount stored on the Ticket/</param>
    public Ticket(string ID, string author, string resolver, string description, string status, decimal amount)
    {
        this.ID = ID;
        this.author = author;
        this.resolver = resolver;
        this.decription = description;
        this.status = status;
        this.amount = amount;
    }
    
    /*

    this is the syntactic sugar that makes the variable, getter, and setter for ID
    public string ID {get; set;}

    

    this longer way of writing the getter and setter for ID
    private string ID;
    public string getID()
    {
        return ID;
    }
    public string setID(string setID)
    {
        ID = setID;
        return ID;
    }



    the way I typically make constructors in Java
    public Ticket(string setID, string setAuthor, string setResolver, string setDescription, string setStatus, decimal setAmount)
    {
        ID = setID;
        author = setAuthor;
        resolver = setResolver;
        decription = setDescription;
        status = setStatus;
        amount = setAmount;
    */
}
