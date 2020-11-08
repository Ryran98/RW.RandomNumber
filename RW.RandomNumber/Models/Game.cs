using RW.RandomNumber.Models.Difficulty;
using System;
using System.ComponentModel.DataAnnotations;

namespace RW.RandomNumber.Models
{
    public class Game
    {
        private int _RandomNumber { get; set; }
        public Base Difficulty { get; set; }

        [Display(Name = "Guesses Remaining")]
        public int RemainingGuesses { get; set; }
        public bool Win { get; set; }
        public string Message { get; set; }

        public Game(Difficulties difficulty)
        {
            Difficulty = Factory.Difficulty(difficulty);
            
            Random random = new Random();
            _RandomNumber = random.Next(1, Difficulty.MaximumNumber);

            RemainingGuesses = Difficulty.NumberOfGuesses;
        }

        public bool Guess(int guess)
        {
            if (!_ValidateGuess(guess))
                return false;

            if (guess == _RandomNumber)
            {
                Message = $"Congratulations! You guessed the random number of : {_RandomNumber}";
                return true;
            }

            RemainingGuesses -= 1;

            if (RemainingGuesses > 0)
                Message = guess > _RandomNumber ? "Your guess was too high" : "Your guess was too low";
            else
                Message = $"The Random Number was : {_RandomNumber}";

            return false;
        }

        private bool _ValidateGuess(int guess)
        {
            if (guess >= Difficulty.MinimumNumber && guess <= Difficulty.MaximumNumber)
                return true;

            Message = guess < Difficulty.MinimumNumber
                ? $"You must guess a number of {Difficulty.MinimumNumber} or higher"
                : $"You must guess a number of {Difficulty.MaximumNumber} or lower";

            return false;
        }
    }
}