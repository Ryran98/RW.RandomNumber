using System.Collections.Generic;
using RW.RandomNumber.Models;
using System.Data.Entity.Migrations;

namespace RW.RandomNumber.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            List<Highscore> defaults = _DefaultHighscores();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                defaults.ForEach(h => db.Highscores.AddOrUpdate(h));
                db.SaveChanges();
            }
        }

        private List<Highscore> _DefaultHighscores()
        {
            return new List<Highscore>
            {
                new Highscore
                {
                    Id = 1,
                    DifficultyId = (int)Difficulties.Easy,
                    Name = "DEFAULT",
                    RemainingGuesses = 1
                },
                new Highscore
                {
                    Id = 2,
                    DifficultyId = (int)Difficulties.Medium,
                    Name = "DEFAULT",
                    RemainingGuesses = 1
                },
                new Highscore
                {
                    Id = 3,
                    DifficultyId = (int)Difficulties.Hard,
                    Name = "DEFAULT",
                    RemainingGuesses = 1
                },
                new Highscore
                {
                    Id = 4,
                    DifficultyId = (int)Difficulties.VeryHard,
                    Name = "DEFAULT",
                    RemainingGuesses = 1
                }
            };
        }
    }
}
