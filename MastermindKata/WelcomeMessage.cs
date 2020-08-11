using System;

namespace MastermindKata
{
    public class WelcomeMessage
    {
        public void Print()
        {
            Console.WriteLine("Welcome to Mastermind\n");
            Console.WriteLine("The game master was expecting you. The decoding board has already been set up.\n");
            Console.WriteLine("All that you have to do is guess the colors of the 4 pegs.");
            Console.WriteLine("The colors that you can chose from are: Red, Blue, Green, Orange, Purple, Yellow");
            Console.WriteLine("Here is an example of how you can type in your guess 'Red,Blue,Green,Yellow'.\n");
            Console.WriteLine("For every guess that is the right color in the right spot, you will receive a black peg, for every guess that is the right color in the wrong spot you will receive a white peg. For all incorrect guesses you won't receive anything.");
            Console.WriteLine("Let's begin...");
        }
        
    }
}