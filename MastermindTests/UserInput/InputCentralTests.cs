using System.Collections.Generic;
using MastermindKata.UserInput;
using NSubstitute;
using Xunit;

namespace MastermindTests.UserInput
{
    public class InputCentralTests
    {
        public static IEnumerable<object[]> InputData()
        {
            yield return new object[]
            {
                "red, Orange, bLue, GREEN",
                new string[] {"red","orange","blue","green"}
            };
            yield return new object[]
            {
                "YELloW, yelLOW,    YELLOW,       YELLOW",
                new string[] {"yellow","yellow","yellow","yellow"}
            };
            yield return new object[]
            {
                "Purple, GrEEn,    Purple,                       rED",
                new string[] {"purple","green","purple","red"}
            };
        }

        [Theory]
        [MemberData(nameof(InputData))]
        [Trait("Category","Integration")]
        public void GetValidUserInput_GivenValidData_ShouldReturnStringArray(string receivedInput, string[] expectedResult)
        {
            var mockInputReceiver = Substitute.For<IInputReceiver>();
            mockInputReceiver.ReceiveUserInput().Returns(receivedInput);
            
            var inputCentral = new InputCentral(mockInputReceiver);
            var actualResult = inputCentral.GetValidUserInput();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}

