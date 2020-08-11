using System;

namespace MastermindKata
{
    public class UserInputCentral
    {
        public string[] GetValidUserInput()
        {
            var userInputReceiver = new UserInputReceiver();
            var userInputValidator = new UserInputValidator();
            string[] answer;
            
            while (true)
            {
                var userGuess = userInputReceiver.ReceiveUserInput();
                var everythingIsValid = userInputValidator.InputIsValid(userGuess);
                
                if (!everythingIsValid)
                {
                    Console.WriteLine(userInputValidator.ErrorMessage);
                   continue; 
                }
                answer= userGuess; 
                break;
            }
            return answer;
        }

    }
}

