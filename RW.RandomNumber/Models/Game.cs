using RW.RandomNumber.Models.Difficulty;
using System;
using System.ComponentModel.DataAnnotations;

namespace RW.RandomNumber.Models
{
    public class Game
    {
        public Base Difficulty { get; set; }
        public int RandomNumber { get; set; }
        [Display(Name = "Number of Guesses Remaining")]
        public int RemainingGuesses { get; set; }
        public bool Win { get; set; }
        public string Hint { get; set; }

        public Game(Base difficulty, int randomNumber, int remainingGuesses)
        {
            Difficulty = difficulty;
            RandomNumber = randomNumber;
            RemainingGuesses = remainingGuesses;
        }

        public Game(Difficulties difficulty)
        {
            Difficulty = Factory.Difficulty(difficulty);
            
            Random random = new Random();
            RandomNumber = random.Next(1, Difficulty.MaximumNumber);

            RemainingGuesses = Difficulty.NumberOfGuesses;
        }

        public bool Guess(int guess)
        {
            if (guess == RandomNumber)
                return true;

            RemainingGuesses -= 1;
            Hint = guess > RandomNumber ? "Too High" : "Too Low";

            return false;
        }
    }
}