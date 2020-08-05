using System.Linq;
using MastermindKata;
using NSubstitute;
using Xunit;

namespace MastermindTests
{
    public class DecodingBoardTests
    {
        //TODO maybe move this test to the MastermindTests (integartion test)
        [Fact]
        public void ADecodingBoardShouldHaveSpecifiedCodePegs()
        {
            var mockRandomNumber = Substitute.For<IRandomNumberGenerator>();
            mockRandomNumber.Generate().Returns(5,1,3,2);
            var codePegs = new CodePegsGenerator(mockRandomNumber).Generate();
            var decodingBoard = new DecodingBoard(codePegs);

            var expectedResult = new[] {"Yellow", "Blue", "Orange", "Green"};

            var actualResult = decodingBoard.CodePegs;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void UserPegsShouldBeEditable()
        {
            var testCodePegs = new string[] { "Red", "Blue", "Yellow", "Purple"};
            var decodingBoard = new DecodingBoard(testCodePegs);

            Assert.True(string.IsNullOrEmpty(decodingBoard.UserPegs[0]));
            decodingBoard.UserPegs[0] = "ThisIsTheNewString";
            Assert.True(decodingBoard.UserPegs[0] == "ThisIsTheNewString");
        }
    }
}