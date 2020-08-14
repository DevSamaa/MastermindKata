using MastermindKata;
using NSubstitute;
using Xunit;

namespace MastermindTests
{
    public class InputCentralTests
    {
        [Fact]
        [Trait("Category","Integration")]
        public void GetValidUserInputShouldReturnStringArray()
        {
            var mockInputReceiver = Substitute.For<IInputReceiver>();
            mockInputReceiver.ReceiveUserInput().Returns("red, Orange, bLue, GREEN");
            
            var inputCentral = new InputCentral(mockInputReceiver);
            var actualResult = inputCentral.GetValidUserInput();

            var expectedResult = new string[] {"red","orange","blue","green"};
            
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

