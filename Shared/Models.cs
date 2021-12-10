namespace New2ndSemester.Shared;
public class User
{
    public int id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string? full_name { get; set; }
    public string? description { get; set; }
}

public class Role
{
    public int id { get; set; }
    public string name { get; set; }
}

public class UserRole
{
    public int id { get; set; }
    public int user_id { get; set; }
    public int role_id { get; set; }
}
