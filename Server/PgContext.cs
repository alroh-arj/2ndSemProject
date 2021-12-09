using New2ndSemester.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace New2ndSemester.Server;

public class PgContext : DbContext
{
    public virtual DbSet<User> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql("Host=tai.db.elephantsql.com;Database=zuzpanzz;Username=zuzpanzz;Password=ymi4kwhPV6qKLZ3ezJYDA9bNaoZGLlg1");
    }
}

public class Roles
{
    public int id { get; set; }
    public string name { get; set; }
}

public class UserRoles
{
    public int user_id { get; set; }
    public int role_id { get; set; }
}
