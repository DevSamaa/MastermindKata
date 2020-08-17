using System;

namespace MastermindKata
{
    public class PrintedMessages
    {
        public void WelcomeUser()
        {
            Console.WriteLine("Welcome to \n");
            Console.WriteLine("  __  __           _                      _           _ \n|  \\/  |         | |                    (_)         | |\n| \\  / | __ _ ___| |_ ___ _ __ _ __ ___  _ _ __   __| |\n| |\\/| |/ _` / __| __/ _ \\ '__| '_ ` _ \\| | '_ \\ / _` |\n| |  | | (_| \\__ \\ ||  __/ |  | | | | | | | | | | (_| |\n|_|  |_|\\__,_|___/\\__\\___|_|  |_| |_| |_|_|_| |_|\\__,_|\n                                                       \n                                                       \n");
            Console.WriteLine("The game master was expecting you. The decoding board has already been set up.\n");
            Console.WriteLine("All that you have to do is guess the colors of the 4 pegs.");
            Console.WriteLine("The colors that you can chose from are: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Blue");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Green");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Orange");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Purple");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Yellow");
            Console.ResetColor();
            Console.WriteLine("\nHere is an example of how you can type in your guess 'Red,Blue,Green,Yellow'.\n");
            Console.WriteLine("For every guess that is the right color in the right spot, you will receive a black peg, for every guess that is the right color in the wrong spot you will receive a white peg. For all incorrect guesses you won't receive anything.");
            Console.WriteLine("Let's begin...");
        }

        public void UserWins()
        {
            Console.WriteLine("Congratulations. You Win");
        }

        public void UserLoses()
        {
            Console.WriteLine("You've had 60 tries. Game Over.");
        }
    }
}