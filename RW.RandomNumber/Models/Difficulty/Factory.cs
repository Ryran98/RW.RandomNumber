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
                    return new Easy();
                case Difficulties.Medium:
                    return new Medium();
                case Difficulties.Hard:
                    return new Hard();
                default:
                    throw new Exception($"No difficulty found for {difficulty}");
            }
        }
    }
}