namespace Models; 

public enum Role
{
    Manager,
    Employee
}
public class User
{
    public string ID {get; set;}
    public string userName {get; set;}
    public string passWord {get; set;}
    public Role role {get; set;}
    
    public User(string ID, string userName, string passWord, Role role)
    {
        this.ID = ID;
        this.Username = Username;
        this.Password = Password;
        this.role = role;
    }
}
