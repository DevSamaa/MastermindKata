using System;
using System.Collections.Generic;
using System.Linq;

namespace MastermindKata
{
    public class Mastermind
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly InputCentral _inputCentral;
        private readonly IInputReceiver _inputReceiver;
        private readonly KeyPegsCreator _keyPegsCreator;
        private readonly WinnerFinder _winnerFinder;
        private readonly PrintedMessages _printedMessages;
        public Mastermind()
        {
            _randomNumberGenerator = new RandomNumberGenerator();
            _inputReceiver = new InputReceiver();
            _inputCentral = new InputCentral(_inputReceiver);
            _keyPegsCreator = new KeyPegsCreator();
            _winnerFinder = new WinnerFinder();
            _printedMessages = new PrintedMessages();
        }

        public Mastermind(IRandomNumberGenerator randomNumberGenerator, IInputReceiver inputReceiver)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _inputReceiver = inputReceiver;
            _inputCentral = new InputCentral(_inputReceiver);
            _keyPegsCreator = new KeyPegsCreator();
            _winnerFinder = new WinnerFinder();
            _printedMessages = new PrintedMessages();
        }
        
        private int _maximumTries = 60;
        public bool Play()
        {
            //Part 1 set up the decoding board
            var codePegs = new CodePegsGenerator(_randomNumberGenerator).Generate();
            var decodingBoard = new DecodingBoard(codePegs);

            _printedMessages.WelcomeUser();
            
            while (decodingBoard.Tries < _maximumTries+1)
            {
                //Part 2 get the user input + increment tries
                var currentUserGuess = _inputCentral.GetValidUserInput();
                decodingBoard.UpdateUserPegs(currentUserGuess);

                //Part 3 check if any answers are correct + feedback to user
                var currentKeyPegs = _keyPegsCreator.Generate(decodingBoard.CodePegs, decodingBoard.UserPegs);
                decodingBoard.UpdateKeyPegs(currentKeyPegs);
                decodingBoard.PrintKeyPegs();

                // Part 4 check if game needs to end
                var userHasWon =_winnerFinder.UserHasWon(decodingBoard);
                
                //TODO think about separating out this bit for one round.
                //TODO think about what the value of writing a test for Play() is? - maybe just talk about why I'm not super happy with this solution.
                
                if (userHasWon)
                {
                    _printedMessages.UserWins();
                    return true;
                }

                if (decodingBoard.Tries == _maximumTries)
                {
                    _printedMessages.UserLoses();
                    return false;
                }
            }

            return false; 
        }
    }
}

//delete this later
// Console.WriteLine($"The correct answer is:");
// foreach (var peg in decodingBoard.CodePegs)
// {
//     Console.WriteLine($"[{peg}]");
// }
