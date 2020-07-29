namespace MastermindKata
{
    public class CodePegsGenerator
    {
        private IRandomNumberGenerator _randomNumberGenerator;
        private string[] PossibleColors = new[] {"Red", "Blue", "Green", "Orange", "Purple", "Yellow"};

        public CodePegsGenerator(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        //should generate the CodePegs that will then be used on the Decoding Board
        public string[] Generate()
        {
            var codePegs = new string[4];
            for (int i = 0; i < 4; i++)
            {
                //TODO to be replaced with a random number
               
                codePegs[i] = PossibleColors[_randomNumberGenerator.Generate()];
            }

            return codePegs;

        }
    }
}

