using System;

namespace MastermindKata
{
    public class UserInputCentral
    {
        public string[] Run()
        {
            var userInputValidator = new UserInputValidator();
            string[] answer;
            while (true)
            {
                PromptTheUser("please insert your guess");
                var userGuess = GetUserGuess();
                var userGuessArray =userInputValidator.PutUserGuessIntoArray(userGuess);
                //if no errors move on to next part --> write code for this

                    var validatedLength = userInputValidator.ArrayLengthIsCorrect(userGuessArray);
                    if (!validatedLength) continue;
                    var validatedColors = userInputValidator.ColorNamesAreCorrect(userGuessArray);
                    if (!validatedColors) continue;
                    answer= userGuessArray; 
                    break;

            }

            return answer;
        }
        
        //a method that displays a message to the user
        public void PromptTheUser(string message)
        {
            Console.WriteLine(message);
        }
        //a method that gets the user guess
        public string GetUserGuess()
        {
            return Console.ReadLine();
        }
        
        // a/ seeral methods that verify the string
        
        //return out the verified string to mastermind
        
    }
}

