using System;

namespace MastermindKata
{
    public class InputCentral
    {
        public string[] GetValidUserInput()
        {
            var inputReceiver = new InputReceiver();
            var inputProcessor = new InputProcessor();
            var inputValidator = new InputValidator();
            string[] answer;
            
            while (true)
            {
                var userInput = inputReceiver.ReceiveUserInput();
                var processedInput = inputProcessor.ProcessInput(userInput);
                var inputIsValid = inputValidator.InputIsValid(processedInput);
                
                if (!inputIsValid)
                { 
                    Console.WriteLine(inputValidator.ErrorMessage);
                    continue;
                }
                answer = processedInput; 
                break;
            }
            return answer;
        }

    }
}

