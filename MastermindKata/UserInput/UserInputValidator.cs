using System;
using System.Linq;

namespace MastermindKata
{
    public class UserInputValidator
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
        
        //2 should check that the length of the array is 4
        public bool ArrayLengthIsCorrect(string[] userGuessArray)
        {
            const int correctLength = 4;
            return userGuessArray.Length == correctLength;
        }
        
        
        //3 should check that color names are correct
        public bool ColorNamesAreCorrect(string[] userGuessArray)
        {
            //TODO check if something like the line below oculd work
           // var test = PossibleColors.Colors.Contains<>(userGuessArray);
            foreach (var guess in userGuessArray)
            {
                var tempResult = PossibleColors.Options.Contains(guess);
                if (tempResult == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}