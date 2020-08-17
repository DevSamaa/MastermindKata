using MastermindKata;
using NSubstitute;
using Xunit;

namespace MastermindTests
{
    public class MastermindClassTests
    {
        [Fact]
        public void PlayShouldReturnTrueWhenUserWins()
        {
            var mockRandomNumber = Substitute.For<IRandomNumberGenerator>();
            mockRandomNumber.Generate().Returns(0);

            var mockInputReceiver = Substitute.For<IInputReceiver>();
            mockInputReceiver.ReceiveUserInput().Returns("red,red,red,red");
            
            var mastermind = new Mastermind(mockRandomNumber, mockInputReceiver);
            var result =mastermind.Play();
            
            Assert.True(result);
        }
    }
}