using System.ComponentModel.DataAnnotations;

namespace RW.RandomNumber.Models.Difficulty
{
    public abstract class Base
    {
        public string Name { get; set; }

        [Display(Name = "Minimum Number")]
        public int MinimumNumber { get; set; }

        [Display(Name = "Maximum Number")]
        public int MaximumNumber { get; set; }
        public int NumberOfGuesses { get; set; }

        protected Base(string name, int minimumNumber, int maximumNumber, int numberOfGuesses)
        {
            Name = name;
            MinimumNumber = minimumNumber;
            MaximumNumber = maximumNumber;
            NumberOfGuesses = numberOfGuesses;
        }
    }
}