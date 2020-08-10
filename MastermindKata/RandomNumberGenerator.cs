using System;

namespace MastermindKata
{
    public class RandomNumberGenerator: IRandomNumberGenerator
    {
        private const int MinValue = 0;
        private readonly int _maxValue = PossibleColors.Colors.Length;

        public int Generate()
        {
            var random = new Random();
            return random.Next(MinValue, _maxValue);
        }
    }
}