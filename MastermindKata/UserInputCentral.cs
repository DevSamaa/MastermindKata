using System;

namespace MastermindKata
{
    public class UserInputCentral
    {
        public void Run()
        {
            PromptTheUser("please insert your guess");
            var userGuess = GetUserGuess();
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

// public string UserSelection()
// {
// while (true)
// {
//     var savedUserInput = UserPrompt();
//
//     var isValid = ValidateInput(savedUserInput);
//
//     if (isValid)
//     {
//         return savedUserInput;
//     }
//     else
//     {
//         Console.WriteLine("That is not a valid selection. Please try again.");
//     }
// }
//
// }
//
//
// private string UserPrompt()
// {
// Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
// return Console.ReadLine();
// }
//
//
// public bool ValidateInput(string incomingString)
// {
// if (incomingString == "1" || incomingString == "0")
// {
//     return true;
// }
// else
// {
//     return false;
// }
// }