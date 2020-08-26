using System;
using System.Collections.Generic;
using System.Linq;
using MastermindKata.UserInput;

namespace MastermindKata
{
    public class Mastermind
    {
        private readonly InputCentral _inputCentral;
        private readonly KeyPegsCreator _keyPegsCreator;
        private readonly WinnerFinder _winnerFinder;
        private readonly DecodingBoard _decodingBoard;
        
        public Mastermind()
        {
            IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
            IInputReceiver inputReceiver = new InputReceiver();
            _inputCentral = new InputCentral(inputReceiver);
            _keyPegsCreator = new KeyPegsCreator();
            _winnerFinder = new WinnerFinder();
             var codePegs = new CodePegsGenerator(randomNumberGenerator).Generate();
            _decodingBoard = new DecodingBoard(codePegs);
        }
        public Mastermind(IRandomNumberGenerator randomNumberGenerator, IInputReceiver inputReceiver)
        {
            _inputCentral = new InputCentral(inputReceiver);
            _keyPegsCreator = new KeyPegsCreator();
            _winnerFinder = new WinnerFinder();
            var codePegs = new CodePegsGenerator(randomNumberGenerator).Generate();
            _decodingBoard = new DecodingBoard(codePegs);
        }

        public void Run()
        {
            MastermindMessages.WelcomeUser();

            do
            {
                var userHasWon = PlayARound();

                if (userHasWon)
                {
                    MastermindMessages.UserWins();
                    break;
                }

                if (_decodingBoard.MaximumTriesReached())
                {
                    MastermindMessages.UserLoses();
                    break;
                }
            } while (_decodingBoard.MaximumTriesReached());
        }

        public bool PlayARound()
        {
            var currentUserGuess = _inputCentral.GetValidUserInput();
            _decodingBoard.UpdateUserPegs(currentUserGuess);

            var currentKeyPegs = _keyPegsCreator.Generate(_decodingBoard.CodePegs, _decodingBoard.UserPegs);
            _decodingBoard.UpdateKeyPegs(currentKeyPegs);
            _decodingBoard.PrintKeyPegs();

            return _winnerFinder.UserHasWon(_decodingBoard);
        }
    }
}


//use for demonstration purposes
// Console.WriteLine($"The correct answer is:");
// foreach (var peg in _decodingBoard.CodePegs)
// {
// Console.WriteLine($"[{peg}]");
// }