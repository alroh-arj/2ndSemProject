using System.Text.Json.Nodes;

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
    public int? id { get; set; }
    public int user_id { get; set; }
    public int role_id { get; set; }
}

public class Shift
{
    public int? id { get; set; }
    public string title { get; set; }
    public string? description { get; set; }
    public int location_id { get; set; }
    public DateTime start { get; set; }
    public DateTime stop { get; set; }
    public int required_volunteers { get; set; }
}

public class ExtendedShift
{
    public Shift shift { get; set; }
    public Location location { get; set; }
    public User[] assigned_volunteers { get; set; }
}

public class UserShift
{
    public int id { get; set; }
    public int user_id { get; set; }
    public int shift_id { get; set; }
}

public class Location
{
    public int id { get; set; }
    public string name { get; set; }
    public string? description { get; set; }
    public double x { get; set; }
    public double y { get; set; }
}

public class Log
{
    public int id { get; set; }
    public DateTime tstamp { get; set; }
    public string schemaname { get; set; }    
    public string tabname { get; set; }    
    public string operation { get; set; }    
    public string? who { get; set; }    
    public string? old_val { get; set; }
    public string? new_val { get; set; }
    public int? by_user_id { get; set; }
}
