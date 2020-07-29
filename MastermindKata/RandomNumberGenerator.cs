using System;

namespace MastermindKata
{
    public class RandomNumberGenerator: IRandomNumberGenerator
    {
        private const int MinValue = 0;
        private const int MaxValue = 6;

        public int Generate()
        {
            var random = new Random();
            return random.Next(MinValue, MaxValue);
        }
    }
}