using System;
using System.Linq;
using MastermindKata;
using NSubstitute;
using Xunit;

namespace MastermindTests
{
    public class CodePegsGeneratorTests
    {
        [Fact]
        public void TheGenerateMethodShouldReturnAnArrayWith4YellowStrings()
        {
            var mockRandomNumber = Substitute.For<IRandomNumberGenerator>();
            mockRandomNumber.Generate().Returns(5);
            var codePegsGenerator = new CodePegsGenerator(mockRandomNumber);
            
            var result =codePegsGenerator.Generate();
            var allStringsAreYellow = result.All(strings => strings.Equals("Yellow"));
            
            Assert.Equal(4,result.Length);
            Assert.True(allStringsAreYellow);
        }
    }
}

