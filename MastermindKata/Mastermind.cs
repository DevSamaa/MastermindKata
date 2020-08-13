using System;
using System.Collections.Generic;
using System.Linq;

namespace MastermindKata
{
    public class Mastermind
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly InputCentral _inputCentral;
        private readonly KeyPegsCreator _keyPegsCreator;
        private readonly WinnerFinder _winnerFinder;
        private readonly PrintedMessages _printedMessages;
        public Mastermind()
        {
            _randomNumberGenerator = new RandomNumberGenerator();
            _inputCentral = new InputCentral();
            _keyPegsCreator = new KeyPegsCreator();
            _winnerFinder = new WinnerFinder();
            _printedMessages = new PrintedMessages();
        }
        private int _maximumTries = 60;
        public void Play()
        {
            //Part 1 set up the decoding board
            var codePegs = new CodePegsGenerator(_randomNumberGenerator).Generate();
            var decodingBoard = new DecodingBoard(codePegs);

            // var printedMessages = new PrintedMessages();
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
                if (userHasWon)
                {
                    _printedMessages.UserWins();
                    break;
                }

                if (decodingBoard.Tries == _maximumTries)
                {
                    _printedMessages.UserLoses();
                }
            }
        }
    }
}

//delete this later
// Console.WriteLine($"The correct answer is:");
// foreach (var peg in decodingBoard.CodePegs)
// {
//     Console.WriteLine($"[{peg}]");
// }
