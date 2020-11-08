using RW.RandomNumber.Models.Difficulty;
using System;
using System.ComponentModel.DataAnnotations;

namespace RW.RandomNumber.Models
{
    public class Game
    {
        public Base Difficulty { get; set; }
        private int _RandomNumber { get; set; }
        [Display(Name = "Number of Guesses Remaining")]
        public int RemainingGuesses { get; set; }
        public bool Win { get; set; }
        public string Message { get; set; }

        public Game(Base difficulty, int randomNumber, int remainingGuesses)
        {
            Difficulty = difficulty;
            _RandomNumber = randomNumber;
            RemainingGuesses = remainingGuesses;
        }

        public Game(Difficulties difficulty)
        {
            Difficulty = Factory.Difficulty(difficulty);
            
            Random random = new Random();
            _RandomNumber = random.Next(1, Difficulty.MaximumNumber);

            RemainingGuesses = Difficulty.NumberOfGuesses;
        }

        public bool Guess(int guess)
        {
            if (guess == _RandomNumber)
                return true;

            RemainingGuesses -= 1;

            if (RemainingGuesses > 0)
                Message = guess > _RandomNumber ? "Your guess was too high" : "Your guess was too low";
            else
                Message = $"You have run out of guesses! The Random Number was : {_RandomNumber}";

            return false;
        }
    }
}