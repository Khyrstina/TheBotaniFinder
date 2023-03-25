using Microsoft.EntityFrameworkCore;
using BotaniFinder.Models;

namespace BotaniFinder.Context
{
    public class BotaniFinderDbContext : DbContext
    {
        //BotaniFinderDbContext creates a DbSet of Urls, which is a table in the database.
        public DbSet<Url> Urls { get; set; }
        //The constructor takes in a DbContextOptions object, which is injected into the constructor using dependency injection.
        public BotaniFinderDbContext(DbContextOptions<BotaniFinderDbContext> options) : base(options)
        {
        }

        //OnModelCreating is used to configure the database to the model.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //The UrlId property is set as the primary key.
            modelBuilder.Entity<Url>()
                .HasKey(u => u.UrlId);  
            //The Urls table is created in the database.
            modelBuilder.Entity<Url>()
                .ToTable("Urls");
            //O is set as the column name in the database.
            modelBuilder.Entity<Url>()
                .Property(u => u.O);
            //M is set as another column name in the database.
            modelBuilder.Entity<Url>()
                .Property(u => u.M);
            //S is set as another column name in the database.
            modelBuilder.Entity<Url>()
                .Property(u => u.S);

        }
    }
}


