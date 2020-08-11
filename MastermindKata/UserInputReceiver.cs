using System;

namespace MastermindKata
{
    public class UserInputReceiver
    {

        public string[] ReceiveUserInput()
        {
            PromptTheUser("\nPlease type in your 4 guesses, separated by a comma");
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
            var input= Console.ReadLine();
            return input.ToLower();
            //Find out if it's better to do this in a different method
        }
        
        public string[] PutUserGuessIntoArray(string userGuess)
        {
            string[] splitString = userGuess.Split(',');
            return splitString;
        }
    }
}