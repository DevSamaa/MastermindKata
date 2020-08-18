using System.Collections.Generic;
using System.Linq;
using MastermindKata;
using NSubstitute;
using Xunit;

namespace MastermindTests
{
    public class DecodingBoardTests
    {
        private readonly DecodingBoard _decodingBoard;
        public DecodingBoardTests()
        {
            var codePegs = new string[] { "red", "blue", "yellow", "purple"};
            _decodingBoard = new DecodingBoard(codePegs);
        }
        
        [Fact]
        [Trait("Category","Integration")]
        public void ADecodingBoard_ShouldHaveSpecifiedCodePegs()
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
        [Trait("Category","Unit")]
        public void UserPegs_ShouldBeEditable()
        {
            Assert.True(string.IsNullOrEmpty(_decodingBoard.UserPegs[0]));
            _decodingBoard.UserPegs[0] = "ThisIsTheNewString";
            var expectedResult = "ThisIsTheNewString";
            Assert.Equal(expectedResult,_decodingBoard.UserPegs[0]);
        }

        [Fact]
        [Trait("Category","Unit")]
        public void UpdateUserPegs_ShouldWorkAndIncrementTries()
        {
            var codePegs = new string[] { "blue", "red", "yellow", "green"};
            
            var expectedResultBeforeUpdate = 0;
            Assert.Equal(expectedResultBeforeUpdate, _decodingBoard.Tries);
            
            _decodingBoard.UpdateUserPegs(codePegs);
            
            var expectedResultAfterUpdate = 1;
            Assert.Equal(expectedResultAfterUpdate, _decodingBoard.Tries);
            
            Assert.Equal(codePegs, _decodingBoard.UserPegs);
        }
        
        [Fact]
        [Trait("Category","Unit")]
        public void UpdateKeyPegs_ShouldWork()
        {
            var keyPegs = new List<string>(){"Black","Black","White","White"};
            
            Assert.Empty(_decodingBoard.KeyPegs);
            _decodingBoard.UpdateKeyPegs(keyPegs);
            
            var expectedKeyPegsCount = 4;
            Assert.Equal(expectedKeyPegsCount,_decodingBoard.KeyPegs.Count);
            Assert.Equal(keyPegs, _decodingBoard.KeyPegs);
        }
    }
}