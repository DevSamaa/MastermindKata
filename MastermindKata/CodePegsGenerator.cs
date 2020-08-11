using System;

namespace MastermindKata
{
    public class CodePegsGenerator
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public CodePegsGenerator(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public string[] Generate() 
        {
            var codePegs = new string[4];
            for (int i = 0; i < 4; i++)
            {
                codePegs[i] = PossibleColors.Options[_randomNumberGenerator.Generate()];
            }
            return codePegs;
        }

    }
}

