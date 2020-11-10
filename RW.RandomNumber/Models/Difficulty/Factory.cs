using System;

namespace RW.RandomNumber.Models.Difficulty
{
    public static class Factory
    {
        public static Base Difficulty(Difficulties difficulty)
        {
            switch (difficulty)
            {
                case Difficulties.Easy:
                    return new Easy((int)difficulty);
                case Difficulties.Medium:
                    return new Medium((int)difficulty);
                case Difficulties.Hard:
                    return new Hard((int)difficulty);
                case Difficulties.VeryHard:
                    return new VeryHard((int)difficulty);
                default:
                    throw new Exception($"No difficulty found for {difficulty}");
            }
        }
    }
}