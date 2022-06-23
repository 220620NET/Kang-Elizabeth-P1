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
    
    
    /// <summary>
    /// This is the constructor for the User object.
    /// </summary>
    /// <param name="ID">A unique associated with the User</param>
    /// <param name="userName">The username of the User</param>
    /// <param name="passWord">The password of the User</param>
    /// <param name="Role">The role of the User, either manager or employee</param>
    /// <returns></returns>
    public User(
        string ID, 
        string userName, 
        string passWord, 
        Role role)
    {
        this.ID = ID;
        this.Username = Username;
        this.Password = Password;
        this.role = role;
    }
}
