using Microsoft.EntityFrameworkCore;
using sprint_2.Models;

namespace sprint_2.Data;

public class AppDbContext : DbContext
{
    private string credentials { get; set; }
    
    public AppDbContext(string credentials)
    {
        this.credentials = credentials;
    }
    
    public DbSet<User> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql(
            credentials,
            new MySqlServerVersion(new Version(8, 0, 43)));
}