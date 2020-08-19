using System;
using System.Collections.Generic;
using MastermindKata;
using MastermindKata.UserInput;
using NSubstitute;
using Xunit;

namespace MastermindTests
{
    public class MastermindClassTests
    {
        public static IEnumerable<object[]> InputData()
        {
            yield return new object[]
            {
                "red,red,red,red",
                true
            };
            yield return new object[]
            {
                "blue,red,blue,red",
                false
            };
        }
        
        [Theory]
        [MemberData(nameof(InputData))]
        [Trait("Category","Integration")]
        public void PlayARound_GivenUserHasWon_ShouldReturnTrue(string userInput, bool expectedResult)
        {
            var mockRandomNumber = Substitute.For<IRandomNumberGenerator>();
            mockRandomNumber.Generate().Returns(0); //corresponds to all red
            
            var mockInputReceiver = Substitute.For<IInputReceiver>();
            mockInputReceiver.ReceiveUserInput().Returns(userInput);
            
            var mastermind = new Mastermind(mockRandomNumber, mockInputReceiver);
            var actualResult = mastermind.PlayARound();
            
            Assert.Equal(expectedResult,actualResult);
        }
    }
}