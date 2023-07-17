using DotnetWebAPI.ContextMappers;
using DotnetWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotnetWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Purchase> Purchase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserMap().Configure(modelBuilder.Entity<User>());
            new PurchaseMap().Configure(modelBuilder.Entity<Purchase>());
        }
    }
}
