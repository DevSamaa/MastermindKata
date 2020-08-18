namespace MastermindKata.UserInput
{
    public class InputProcessor
    {
        public string[] ProcessInput(string incomingString)
        { 
            var lowerCaseString = MakeInputLowerCase(incomingString);
            var stringWithoutWhiteSpace = RemoveWhiteSpace(lowerCaseString);
            var userGuessInArray = PutUserGuessIntoArray(stringWithoutWhiteSpace);
            return userGuessInArray;
        }

        private string MakeInputLowerCase(string userInput)
        {
            return userInput.ToLower();
        }

        public string RemoveWhiteSpace(string userInput)
        {
          return userInput.Replace(" ", "");
        }
        public string[] PutUserGuessIntoArray(string userGuess)
        {
            return userGuess.Split(',');
        }
    }
}