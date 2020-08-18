using System;

namespace MastermindKata.UserInput
{
    public class InputCentral
    {
        private readonly IInputReceiver _inputReceiver;
        private readonly InputProcessor _inputProcessor;
        private readonly InputValidator _inputValidator;
        
        public InputCentral(IInputReceiver inputReceiver)
        {
             _inputReceiver = inputReceiver;
             _inputProcessor = new InputProcessor();
             _inputValidator = new InputValidator();
        }
        public string[] GetValidUserInput()
        {
            string[] answer;
            
            while (true)
            {
                var userInput = _inputReceiver.ReceiveUserInput();
                var processedInput = _inputProcessor.ProcessInput(userInput);
                var inputIsValid = _inputValidator.InputIsValid(processedInput);
                
                if (!inputIsValid)
                { 
                    Console.WriteLine(_inputValidator.ErrorMessage);
                    continue;
                }
                answer = processedInput; 
                break;
            }
            return answer;
        }

    }
}

