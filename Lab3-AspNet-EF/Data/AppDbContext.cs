using Microsoft.EntityFrameworkCore;
using Lab3_AspNet_EF.Models;

namespace Lab3_AspNet_EF.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Call> Calls { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Subscriber> Subscribers { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Call>(entity =>
        {
            entity.HasKey(e => e.CallId);
            // Additional configuration
        });
    }
}