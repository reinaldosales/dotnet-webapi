using DotnetWebAPI.ContextMappers;
using DotnetWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DotnetWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public DbSet<User> User { get; set; }

        public DbSet<Purchase> Purchase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DotnetWebAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserMap().Configure(modelBuilder.Entity<User>());
            new PurchaseMap().Configure(modelBuilder.Entity<Purchase>());
        }
    }
}
