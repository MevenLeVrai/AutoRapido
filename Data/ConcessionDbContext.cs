using Microsoft.EntityFrameworkCore;
using AutoRapido.Model;
using AutoRapido.Utils;
using Microsoft.Extensions.Configuration;
namespace AutoRapido.Data;

public class ConcessionDbContext : DbContext
{
    public DbSet<Concession> Concession { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Purchase> Purchases { get; set; } 

    public ConcessionDbContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(GlobalVariable.JsonPath)
            .Build();

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Purchase>()
            .HasKey(p => p.PurchaseId);

        modelBuilder.Entity<Purchase>()
            .HasOne<Car>()
            .WithMany()
            .HasForeignKey(p => p.CarId);

        modelBuilder.Entity<Purchase>()
            .HasOne<Client>()
            .WithMany()
            .HasForeignKey(p => p.ClientId);
    }
}
