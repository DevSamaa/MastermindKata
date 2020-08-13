using System;

namespace MastermindKata
{
    public class InputReceiver
    {

        public string ReceiveUserInput()
        {
            PromptTheUser("\nPlease type in your 4 guesses, separated by a comma");
            var userGuess = GetUserGuess();
            return userGuess;
        }
        
        private void PromptTheUser(string message)
        {
            Console.WriteLine(message);
        }
        
        private string GetUserGuess()
        {
            return Console.ReadLine();
        }
        
    }
}