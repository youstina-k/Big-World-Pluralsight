using Globomantics.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Globomantics.Infrastructure.Data;

public class GlobomanticsDbContext : DbContext
{
    public DbSet<TodoTask> TodoTasks { get; set; }
    public DbSet<Bug> Bugs { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=DESKTOP-3O7CIT0\\MSSQLSERVER02;Database=TodoDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
