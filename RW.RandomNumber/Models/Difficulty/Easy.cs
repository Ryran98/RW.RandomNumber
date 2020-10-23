namespace RW.RandomNumber.Models.Difficulty
{
    public class Easy : Base
    {
        public Easy()
        {
            Name = "Easy";
            MaximumNumber = 10;
            NumberOfGuesses = 6;
        }
    }
}