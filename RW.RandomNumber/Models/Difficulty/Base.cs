using System.ComponentModel.DataAnnotations;

namespace RW.RandomNumber.Models.Difficulty
{
    public abstract class Base
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Minimum Number")]
        public int MinimumNumber { get; set; }

        [Display(Name = "Maximum Number")]
        public int MaximumNumber { get; set; }
        public int NumberOfGuesses { get; set; }

        protected Base(int id, string name, int minimumNumber, int maximumNumber, int numberOfGuesses)
        {
            Id = id;
            Name = name;
            MinimumNumber = minimumNumber;
            MaximumNumber = maximumNumber;
            NumberOfGuesses = numberOfGuesses;
        }
    }
}