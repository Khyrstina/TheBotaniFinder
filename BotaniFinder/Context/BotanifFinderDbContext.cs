using Microsoft.EntityFrameworkCore;
using BotaniFinder.Models;

namespace BotaniFinder.Context
{
    public class BotaniFinderDbContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }
        public BotaniFinderDbContext(DbContextOptions<BotaniFinderDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Url>()
                .HasKey(u => u.UrlId);  
            modelBuilder.Entity<Url>()
                .ToTable("Urls");
            modelBuilder.Entity<Url>()
                .Property(u => u.O);
            modelBuilder.Entity<Url>()
                .Property(u => u.M);
            modelBuilder.Entity<Url>()
                .Property(u => u.S);

        }
    }
}


