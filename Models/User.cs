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
    public User(string ID, string userName, string passWord, Role role)
    {
        this.ID = ID;
        this.userName = userName;
        this.passWord = passWord;
        this.role = role;
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
    public User(string setID, string setUserName, string setPassWord, Role setRole)
    {
        ID = setID;
        userName = setUserName;
        passWord = setPassWord;
        role = setRole;
    }
    */
}
