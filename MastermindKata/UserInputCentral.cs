using System;

namespace MastermindKata
{
    public class UserInputCentral
    {
        // public string[] GetValidUserInput()
        // {
        //     var userInputReceiver = new UserInputReceiver();
        //     var userInputValidator = new UserInputValidator();
        //     string[] answer;
        //     
        //     while (true)
        //     {
        //         var userGuess = userInputReceiver.ReceiveUserInput();
        //
        //         var lengthIsValid = userInputValidator.ArrayLengthIsCorrect(userGuess);
        //         if (lengthIsValid == false)
        //         {
        //             Console.WriteLine("You seem to not have entered 4 colors. Or you forgot to put a comma , between them.");
        //             continue;
        //         }
        //         var colorsAreValid = userInputValidator.ColorNamesAreCorrect(userGuess);
        //             if (colorsAreValid == false)
        //             {
        //                 Console.WriteLine("That color doesn't exist");
        //                 continue;
        //             }
        //         answer= userGuess; 
        //         break;
        //     }
        //     return answer;
        // }
        
        public string[] GetValidUserInput()
        {
            var userInputReceiver = new UserInputReceiver();
            var userInputValidator = new UserInputValidator();
            string[] answer;
            
            while (true)
            {
                var userGuess = userInputReceiver.ReceiveUserInput();
                var everythingIsValid = userInputValidator.EverythingIsValid(userGuess);
                
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

