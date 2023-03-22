using Microsoft.EntityFrameworkCore;
using BotaniFinder.Models;

namespace BotaniFinder.Context
{
    public class BotaniFinderDbContext : DbContext
    {
        public DbSet<PlantIdentificationResult> PlantIdentificationResults { get; set; }
        //public DbSet<Family> Families { get; set; }
        //public DbSet<Species> Species { get; set; }

        //public DbSet<Image> Images { get; set; }

        public BotaniFinderDbContext(DbContextOptions<BotaniFinderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>().HasKey(f => f.FamilyId);

            modelBuilder.Entity<Species>()
    .HasOne(s => s.Family)
    .WithOne(f => f.Species)
    .HasForeignKey<Family>(f => f.SpeciesId);

        //        modelBuilder.Entity<Family>()
        //.HasMany(Species)
        //.WithOne(s => s.Family)
        //.HasForeignKey(s => s.FamilyId);

            modelBuilder.Entity<PlantIdentificationResult>()
       .Property(p => p.ScorePercentage)
       .HasColumnName("ScorePercentage")
       .HasColumnType("FLOAT")
       .IsRequired();

            modelBuilder.Entity<PlantIdentificationResult>()
                .Property(p => p.SpeciesScientificNameWithoutAuthor)
                .HasColumnName("SpeciesScientificNameWithoutAuthor")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            modelBuilder.Entity<PlantIdentificationResult>()
                .Property(p => p.GenusScientificNameWithoutAuthor)
                .HasColumnName("GenusScientificNameWithoutAuthor")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            modelBuilder.Entity<PlantIdentificationResult>()
                .Property(p => p.FamilyScientificNameWithoutAuthor)
                .HasColumnName("FamilyScientificNameWithoutAuthor")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();


            modelBuilder.Entity<PlantIdentificationResult>()
                .Property(p => p.ImageDate)
                .HasColumnName("ImageDate")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();
            modelBuilder.Entity<PlantIdentificationResult>()
                .Ignore(p => p.Genus);
            modelBuilder.Entity<PlantIdentificationResult>()
                .Property(p => p.ImageUrl)
                .HasColumnName("ImageUrl")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            modelBuilder.Entity<PlantIdentificationResult>()
                .Property(p => p.CommonNames)
                .HasColumnName("CommonNames")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();
            modelBuilder.Entity<Species>().Ignore(s => s.CommonNames);

            //modelBuilder.Entity<List<string>>()
            //    .HasNoKey();
            //modelBuilder.Entity<Image>()
            //    .Ignore(i => i.ImageDate)
            //    .HasOne(i => i.PlantIdentificationResult)
            //    .WithMany(p => p.Image);
            //    //.HasForeignKey(i => i.ImageId);

            //modelBuilder.Entity<Species>()
            //    .HasOne(s => s.Family)
            //    .WithMany()
            //    .IsRequired();

            //modelBuilder.Entity<PlantIdentificationResult>()
            //    .HasOne(p => p.Species)
            //    .WithMany()
            //    //.HasForeignKey(p => p.SpeciesId)
            //    .IsRequired();

            ////modelBuilder.Entity<Family>()
            ////    .Property(f => f.Id)
            ////    .HasConversion(v => (int)v, v => v);

            //modelBuilder.Entity<Species>()
            //    .Ignore(s => s.CommonNames)
            //    .HasKey(s => s.SpeciesId);

            //modelBuilder.Entity<Url>()
            //    .Property(e => e.UrlId);


            //modelBuilder.Entity<List<string>>()
            //    .HasNoKey();

        }
    }
}


