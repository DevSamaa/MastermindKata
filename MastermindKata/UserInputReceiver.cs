using System;

namespace MastermindKata
{
    public class UserInputReceiver
    {

        public string[] ReceiveUserInput()
        {
            PromptTheUser("Please type in your 4 guesses, separated by a comma");
            var userGuess = GetUserGuess();
            var userGuessInArray = PutUserGuessIntoArray(userGuess);
            return userGuessInArray;
        }
        
        private void PromptTheUser(string message)
        {
            Console.WriteLine(message);
        }
        
        private string GetUserGuess()
        {
            return Console.ReadLine();
        }
        
        //TODO maybe move this into a UserInputProcessor class and add a method that does .ToUpper for first and ToLower for remaining letters
        //1 should put incoming string into an array, separated by commas
        public string[] PutUserGuessIntoArray(string userGuess)
        {
            string[] splitString = userGuess.Split(',');
            return splitString;
        }
    }
}