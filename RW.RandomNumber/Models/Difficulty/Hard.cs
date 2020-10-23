namespace RW.RandomNumber.Models.Difficulty
{
    public class Hard : Base
    {
        public Hard()
        {
            Name = "Hard";
            MaximumNumber = 1000;
            NumberOfGuesses = 4;
        }
    }
}