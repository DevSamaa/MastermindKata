namespace MastermindKata
{
    public class InputProcessor
    {
        public string[] ProcessInput(string incomingString)
        { 
            var lowerCaseString =MakeInputLowerCase(incomingString);
            var stringWithoutWhiteSpace = RemoveWhiteSpace(lowerCaseString);
            var userGuessArray = PutUserGuessIntoArray(stringWithoutWhiteSpace);
            return userGuessArray;
        }

        public string MakeInputLowerCase(string incomingString)
        {
            return incomingString.ToLower();
        }

        public string RemoveWhiteSpace(string incomingString)
        {
           var newString = incomingString.Replace(" ", "");
            return newString;
        }
        public string[] PutUserGuessIntoArray(string userGuess)
        {
            string[] splitString = userGuess.Split(',');
            return splitString;
        }
    }
}