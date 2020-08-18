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
        public Mastermind()
        {
            _randomNumberGenerator = new RandomNumberGenerator();
            IInputReceiver inputReceiver = new InputReceiver();
            _inputCentral = new InputCentral(inputReceiver);
            _keyPegsCreator = new KeyPegsCreator();
            _winnerFinder = new WinnerFinder();
        }

        public Mastermind(IRandomNumberGenerator randomNumberGenerator, IInputReceiver inputReceiver)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _inputCentral = new InputCentral(inputReceiver);
            _keyPegsCreator = new KeyPegsCreator();
            _winnerFinder = new WinnerFinder();
        }
        
        private int _maximumTries = 60;
        public bool Play()
        {
            //Part 1 set up the decoding board
            var codePegs = new CodePegsGenerator(_randomNumberGenerator).Generate();
            var decodingBoard = new DecodingBoard(codePegs);

            MastermindMessages.WelcomeUser();

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
                    MastermindMessages.UserWins();
                    return true;
                }

                if (decodingBoard.Tries == _maximumTries)
                {
                    MastermindMessages.UserLoses();
                    return false;
                }
            }

            return false; 
        }
    }
}

//use for demonstration purposes
// Console.WriteLine($"The correct answer is:");
// foreach (var peg in decodingBoard.CodePegs)
// {
//     Console.WriteLine($"[{peg}]");
// }
