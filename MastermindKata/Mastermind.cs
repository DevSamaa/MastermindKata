using System;
using System.Collections.Generic;
using System.Linq;

namespace MastermindKata
{
    public class Mastermind
    {
        public void Run()
        {
            //Part 1 set up the decoding board
            var randomNumberGenerator = new RandomNumberGenerator();
            var codePegs = new CodePegsGenerator(randomNumberGenerator).Generate();
            var decodingBoard = new DecodingBoard(codePegs);
            
            //delete this later
            Console.WriteLine($"The correct answer is:");
            foreach (var peg in decodingBoard.CodePegs)
            {
                Console.WriteLine($"[{peg}]");
            }

            while (true)
            {
                //Part 2 get the user input + increment tries
                var userInputCentral = new UserInputCentral();
                var currentUserGuess =userInputCentral.GetValidUserInput();
                //TODO, figure out of a UpdateTheBoardMethod would be useful.
                decodingBoard.UserPegs = currentUserGuess;
                decodingBoard.Tries++;

                //Part 3 check if any answers are correct + feedback to user
                var keyPegsCreator = new KeyPegsCreator();
                var currentKeyPegs = keyPegsCreator.Generate(decodingBoard.CodePegs, decodingBoard.UserPegs);
                decodingBoard.KeyPegs = currentKeyPegs;

                foreach (var peg in decodingBoard.KeyPegs)
                {
                    Console.WriteLine($"[{peg}]");
                }

                //TODO think of a better way to do this
                if (decodingBoard.KeyPegs.Count ==4)
                {
                    var allBlack = decodingBoard.KeyPegs.All(peg => peg.Equals("Black"));
                    if (allBlack)
                    {
                        Console.WriteLine("You Win");
                        break;
                    }
                }
                
            }

            //Part 4 end game if right conditions met (60 tries, or all black array)
        }
    }
}