using System;
using System.Collections.Generic;
using System.Linq;

namespace MastermindKata
{
    public class Mastermind
    {
        public void Run()
        {
            //Think about creating just one class - CodePegsGenerator, the randomnumber could be created in there, and you can get rid of randomNumber generator.
            //That way if you increase the possible colors, you don't ahve to change the randomNumber and CodePegs creator class.
            //Part 1 set up the decoding board
            var randomNumberGenerator = new RandomNumberGenerator();
            var codePegs = new CodePegsGenerator(randomNumberGenerator).Generate();
            var decodingBoard = new DecodingBoard(codePegs);
            
            Console.WriteLine($"The correct answer is:");
            foreach (var peg in decodingBoard.CodePegs)
            {
                Console.WriteLine($"[{peg}]");
            }

            while (true)
            {
                
                
                //Part 2 get the user input + increment tries
                var userInputCentral = new UserInputCentral();
                var currentUserGuess =userInputCentral.Run();
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
                
                //loop over parts 2 &3 for as long as it's necessary  
            }

            // decodingBoard.KeyPegs.All(peg => peg.Equals("Black"))

            //Part 4 end game if right conditions met (60 tries, or all black array)
        }
    }
}