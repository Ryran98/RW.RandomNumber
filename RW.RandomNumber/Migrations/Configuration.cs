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
            Highscore easy = new Highscore
            {
                Id = 1,
                DifficultyId = (int)Difficulties.Easy,
                Name = "Ryan Wilson",
                RemainingGuesses = 1
            };

            Highscore medium = new Highscore
            {
                Id = 2,
                DifficultyId = (int)Difficulties.Medium,
                Name = "Ryan Wilson",
                RemainingGuesses = 1
            };

            Highscore hard = new Highscore
            {
                Id = 3,
                DifficultyId = (int)Difficulties.Hard,
                Name = "Ryan Wilson",
                RemainingGuesses = 1
            };

            Highscore veryHard = new Highscore
            {
                Id = 4,
                DifficultyId = (int)Difficulties.VeryHard,
                Name = "Ryan Wilson",
                RemainingGuesses = 1
            };
        }
    }
}
