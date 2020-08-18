using System.Linq;

namespace MastermindKata.UserInput
{
    public class InputValidator
    {
        public string ErrorMessage { get; private set; }
        
        public bool InputIsValid(string[] userGuess)
        {
            var lengthIsValid = ArrayLengthIsCorrect(userGuess);
            if (!lengthIsValid)
            {
                ErrorMessage = "You seem to not have entered 4 colors. or you forgot to place a comma between them";
                return false;
            }
            
            var colorsAreValid = ColorNamesAreCorrect(userGuess);
            if (!colorsAreValid )
            {
                ErrorMessage ="That color doesn't exist";
                return false;
            }

            return true;
        }
        
        public bool ArrayLengthIsCorrect(string[] userGuess)
        {
            const int correctLength = 4;
            return userGuess.Length == correctLength;
        }
        
        
        public bool ColorNamesAreCorrect(string[] userGuess)
        {
            return userGuess.All(color => PossibleColors.Options.Contains(color));
        }
    }
}