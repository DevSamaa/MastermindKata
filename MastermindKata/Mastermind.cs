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
            

            //Part 3 check if any answers are correct + feedback to user

            //loop over parts 2 &3 for as long as it's necessary

            //Part 4 end game if right conditions met (60 tries, or all black array)
        }
    }
}