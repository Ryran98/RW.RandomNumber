using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RW.RandomNumber.Models
{
    [Table("tb_Highscore")]
    public class Highscore
    {
        public int Id { get; set; }
        [Required]
        public int DifficultyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int RemainingGuesses { get; set; }

        public Highscore() { }
        public Highscore(int difficultyId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (!db.Highscores.Any(h => h.DifficultyId == difficultyId))
                    throw new Exception($"No highscore could be found for difficulty ID : {difficultyId}");

                Highscore highscore = db.Highscores.First(h => h.DifficultyId == difficultyId);

                Id = highscore.Id;
                DifficultyId = highscore.DifficultyId;
                Name = highscore.Name;
                RemainingGuesses = highscore.RemainingGuesses;
            }
        }

        public static bool Check(Game game)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (!db.Highscores.Any(h => h.DifficultyId == game.Difficulty.Id))
                    throw new Exception($"No highscore could be found for difficulty ID : {game.Difficulty.Id}");

                Highscore currentHighscore = db.Highscores.First(h => h.DifficultyId == game.Difficulty.Id);

                if (game.RemainingGuesses > currentHighscore.RemainingGuesses)
                    return true;
            }

            return false;
        }
    }
}