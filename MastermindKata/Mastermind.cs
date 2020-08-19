using System;
using System.Collections.Generic;
using System.Linq;
using MastermindKata.UserInput;

namespace MastermindKata
{
    public class Mastermind
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly InputCentral _inputCentral;
        private readonly KeyPegsCreator _keyPegsCreator;
        private readonly WinnerFinder _winnerFinder;

        private readonly CodePegsGenerator _codePegsGenerator;
        private readonly DecodingBoard _decodingBoard;
        public Mastermind()
        {
            _randomNumberGenerator = new RandomNumberGenerator();
            IInputReceiver inputReceiver = new InputReceiver();
            _inputCentral = new InputCentral(inputReceiver);
            _keyPegsCreator = new KeyPegsCreator();
            _winnerFinder = new WinnerFinder();
            _codePegsGenerator = new CodePegsGenerator(_randomNumberGenerator);
            var codePegs = _codePegsGenerator.Generate();
            _decodingBoard = new DecodingBoard(codePegs);
        }
        public Mastermind(IRandomNumberGenerator randomNumberGenerator, IInputReceiver inputReceiver)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _inputCentral = new InputCentral(inputReceiver);
            _keyPegsCreator = new KeyPegsCreator();
            _winnerFinder = new WinnerFinder();
             _codePegsGenerator = new CodePegsGenerator(_randomNumberGenerator);
             var codePegs = _codePegsGenerator.Generate();
            _decodingBoard = new DecodingBoard(codePegs);
        }

        private const int MaximumTries = 60;

        public void Run()
        {
            //Part 1 set up the decoding board
            // var codePegs = new CodePegsGenerator(_randomNumberGenerator).Generate();
            // var decodingBoard = new DecodingBoard(codePegs);

            MastermindMessages.WelcomeUser();

            while (_decodingBoard.Tries < MaximumTries+1)
            {
                // //Part 2 get the user input + increment tries
                // var currentUserGuess = _inputCentral.GetValidUserInput();
                // decodingBoard.UpdateUserPegs(currentUserGuess);
                //
                // //Part 3 check if any answers are correct + feedback to user
                // var currentKeyPegs = _keyPegsCreator.Generate(decodingBoard.CodePegs, decodingBoard.UserPegs);
                // decodingBoard.UpdateKeyPegs(currentKeyPegs);
                // decodingBoard.PrintKeyPegs();
                //
                // // Part 4 check if game needs to end
                // var userHasWon =_winnerFinder.UserHasWon(decodingBoard);

                var userHasWon = PlayARound();
                
                if (userHasWon)
                {
                    MastermindMessages.UserWins();
                    // return true;
                }

                if (_decodingBoard.Tries == MaximumTries)
                {
                    MastermindMessages.UserLoses();
                    // return false;
                }
            }
            // return false; 
        }

        public bool PlayARound()
        {
            //Part 2 get the user input + increment tries
            var currentUserGuess = _inputCentral.GetValidUserInput();
            _decodingBoard.UpdateUserPegs(currentUserGuess);

            //Part 3 check if any answers are correct + feedback to user
            var currentKeyPegs = _keyPegsCreator.Generate(_decodingBoard.CodePegs, _decodingBoard.UserPegs);
            _decodingBoard.UpdateKeyPegs(currentKeyPegs);
            _decodingBoard.PrintKeyPegs();

            // Part 4 check if game needs to end
            return _winnerFinder.UserHasWon(_decodingBoard);
        }
    }
}

//use for demonstration purposes
// Console.WriteLine($"The correct answer is:");
// foreach (var peg in decodingBoard.CodePegs)
// {
//     Console.WriteLine($"[{peg}]");
// }
