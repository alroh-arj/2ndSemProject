using New2ndSemester.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace New2ndSemester.Server;

public class PgContext : DbContext
{
    public virtual DbSet<User> users { get; set; }
    public virtual DbSet<Role> roles { get; set; }
    public virtual DbSet<UserRole> user_roles { get; set; }
    public virtual DbSet<Shift> shifts { get; set; }
    public virtual DbSet<UserShift> user_shifts { get; set; }
    public virtual DbSet<Location> locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql("Host=tai.db.elephantsql.com;Database=zuzpanzz;Username=zuzpanzz;Password=ymi4kwhPV6qKLZ3ezJYDA9bNaoZGLlg1");
    }
}
