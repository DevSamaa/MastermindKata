using System;
using System.Collections.Generic;
using System.Linq;

namespace MastermindKata
{
    public class Mastermind
    {
        public void Play()
        {
            //Part 1 set up the decoding board
            var randomNumberGenerator = new RandomNumberGenerator();
            var codePegs = new CodePegsGenerator(randomNumberGenerator).Generate();
            var decodingBoard = new DecodingBoard(codePegs);

            var welcomeMessage = new WelcomeMessage();
            welcomeMessage.Print();
            
            while (decodingBoard.Tries < 61)
            {
                //Part 2 get the user input + increment tries
                var userInputCentral = new UserInputCentral();
                var currentUserGuess =userInputCentral.GetValidUserInput();
                decodingBoard.UpdateUserPegs(currentUserGuess);

                //Part 3 check if any answers are correct + feedback to user
                var keyPegsCreator = new KeyPegsCreator();
                var currentKeyPegs = keyPegsCreator.Generate(decodingBoard.CodePegs, decodingBoard.UserPegs);
                decodingBoard.UpdateKeyPegs(currentKeyPegs);
                decodingBoard.PrintKeyPegs();

                // Part 4 check if game needs to end
                var winnerFinder = new WinnerFinder();
                var userHasWon =winnerFinder.UserHasWon(decodingBoard);
                if (userHasWon)
                {
                    Console.WriteLine("Congratulations. You Win");
                    break;
                }

                if (decodingBoard.Tries ==60)
                {
                    Console.WriteLine("You've had 60 tries. Game Over.");
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

//TODO think of a better way to do this
// if (decodingBoard.KeyPegs.Count ==4)
// {
//     var allBlack = decodingBoard.KeyPegs.All(peg => peg.Equals("Black"));
//     if (allBlack)
//     {
//         Console.WriteLine("Congratulations. You Win");
//         break;
//     }
// }
