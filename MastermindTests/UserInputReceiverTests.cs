using MastermindKata;
using Xunit;

namespace MastermindTests
{
    public class UserInputReceiverTests
    {
        [Fact]
        public void PutUserGuessIntoArrayShouldReturnArrayOfStrings()
        {
            var inputReceiver = new UserInputReceiver();
            var result = inputReceiver.PutUserGuessIntoArray("Red,Blue,Green,Purple");

            Assert.Contains("Red", result);
            Assert.Contains("Blue", result);
            Assert.Contains("Green", result);
            Assert.Contains("Purple", result);
            
            //TODO maybe compare to an array
        }
    }
}