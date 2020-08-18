using System;
using System.Linq;
using MastermindKata;
using NSubstitute;
using Xunit;

namespace MastermindTests
{
    public class CodePegsGeneratorTests
    {
        [Theory]
        [InlineData(0,"red")]
        [InlineData(2,"green")]
        [InlineData(5,"yellow")]

        [Trait("Category","Unit")]
        public void Generate_GivenASpecificNumber_ShouldReturnAnArrayWith4TimesExpectedString(int number, string expectedResult)
        {
            var mockRandomNumber = Substitute.For<IRandomNumberGenerator>();
            mockRandomNumber.Generate().Returns(number); 
            var codePegsGenerator = new CodePegsGenerator(mockRandomNumber);
            
            var result =codePegsGenerator.Generate();
            
            Assert.Equal(4,result.Length);
            Assert.True(result.All(strings => strings.Equals(expectedResult)));
        }
    }
}

