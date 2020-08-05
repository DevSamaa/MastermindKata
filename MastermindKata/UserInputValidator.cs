using System.Linq;

namespace MastermindKata
{
    public class UserInputValidator
    {
        // "red,blue,yellow,orange"
        
        //1 should put incoming string into an array, separeated by commas
        public string[] PutUserGuessIntoArray(string userGuess)
        {
            string[] splitString = userGuess.Split(',');
            return splitString;
            
            //TODO what if there aren't any commas?
        }
        
        //2 should check that the length of the array is 4

        public bool ArrayLengthIsCorrect(string[] userGuessArray)
        {
            const int correctLength = 4;
            return userGuessArray.Length == correctLength;
        }
        
        //3 should check that color names are correct

        public bool ColorNamesAreCorrect(string[] userGuessArray)
        {
            //look into using enums maybe?!
            var possibleColors = new[] {"Red", "Blue", "Green", "Orange", "Purple", "Yellow"};
            
            foreach (var guess in userGuessArray)
            {
                var tempResult = possibleColors.Contains(guess);
                if (tempResult == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}