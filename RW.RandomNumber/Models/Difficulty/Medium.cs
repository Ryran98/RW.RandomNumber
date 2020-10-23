namespace RW.RandomNumber.Models.Difficulty
{
    public class Medium : Base
    {
        public Medium()
        {
            Name = "Medium";
            MaximumNumber = 100;
            NumberOfGuesses = 5;
        }
    }
}