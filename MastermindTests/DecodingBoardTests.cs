using System.Collections.Generic;
using System.Linq;
using MastermindKata;
using NSubstitute;
using Xunit;

namespace MastermindTests
{
    public class DecodingBoardTests
    {
        //TODO maybe move this test to the MastermindTests --really!??
        [Fact]
        [Trait("Category","Integration")]

        public void ADecodingBoardShouldHaveSpecifiedCodePegs()
        {
            var mockRandomNumber = Substitute.For<IRandomNumberGenerator>();
            mockRandomNumber.Generate().Returns(5,1,3,2);
            
            var codePegs = new CodePegsGenerator(mockRandomNumber).Generate();
            var decodingBoard = new DecodingBoard(codePegs);

            var expectedResult = new[] {"yellow", "blue", "orange", "green"};
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

        [Fact]
        public void UpdateUserPegsShouldWorkAndIncrementTries()
        {
            var testCodePegs = new string[] { "Red", "Blue", "Yellow", "Purple"};
            var decodingBoard = new DecodingBoard(testCodePegs);
            
            Assert.True(decodingBoard.Tries ==0);
            decodingBoard.UpdateUserPegs(testCodePegs);
            Assert.True(decodingBoard.Tries ==1);
            Assert.True(decodingBoard.UserPegs == testCodePegs);
        }
        
        [Fact]
        public void UpdateKeyPegsShouldWork()
        {
            var testCodePegs = new string[] { "Red", "Blue", "Yellow", "Purple"};
            var decodingBoard = new DecodingBoard(testCodePegs);
            var testKeyPegs = new List<string>(){"Black","Black","White","White"};
            
            //TODO think about changing this to Assert.Equal rather than Assert.True
            Assert.True(decodingBoard.KeyPegs.Count==0);
            decodingBoard.UpdateKeyPegs(testKeyPegs);
            Assert.True(decodingBoard.KeyPegs.Count==4);
            Assert.Equal(testKeyPegs, decodingBoard.KeyPegs);
        }
    }
}