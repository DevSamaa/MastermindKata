namespace MastermindKata
{
    //should generate the CodePegs that will then be used on the Decoding Board
    public class CodePegsGenerator
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly string[] PossibleColors = new[] {"Red", "Blue", "Green", "Orange", "Purple", "Yellow"};

        public CodePegsGenerator(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public string[] Generate()
        {
            var codePegs = new string[4];
            for (int i = 0; i < 4; i++)
            {
               
                codePegs[i] = PossibleColors[_randomNumberGenerator.Generate()];
            }

            return codePegs;

        }
    }
}

