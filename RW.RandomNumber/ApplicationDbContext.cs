using System.Data.Entity;
using RW.RandomNumber.Models;

namespace RW.RandomNumber
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Highscore> Highscores { get; set; }
        public ApplicationDbContext() : base("rngEntities") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Highscore>()
                .HasIndex(h => h.DifficultyId)
                .IsUnique();
        }
    }
}