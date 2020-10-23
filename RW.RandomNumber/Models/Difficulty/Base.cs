using System.ComponentModel.DataAnnotations;

namespace RW.RandomNumber.Models.Difficulty
{
    public abstract class Base
    {
        public string Name { get; set; }
        [Display(Name = "Maximum Number")]
        public int MaximumNumber { get; set; }
        public int NumberOfGuesses { get; set; }
    }
}