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
            

            //Part 2 get the user input + increment tries
            var userGuess = new string[] {"Red", "Red", "Red", "Red"};
            decodingBoard.UserPegs = userGuess;

            //Part 3 check if any answers are correct + feedback to user
            //at this point you will have an array of 4 strings from the user, it's been saved into the decodingBoard.UserPegs
            //you will want to use that array, input it into a method and return a black/white/empty array.  
            //essentially you're creating the keyPegs here
            
            //loop over parts 2 &3 for as long as it's necessary

            //Part 4 end game if right conditions met (60 tries, or all black array)
        }
    }
}