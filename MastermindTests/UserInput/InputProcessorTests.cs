using System.Collections.Generic;
using MastermindKata;
using MastermindKata.UserInput;
using Xunit;

namespace MastermindTests.UserInput
{
    public class InputProcessorTests
    {
        private readonly InputProcessor _inputProcessor;
        public InputProcessorTests()
        {
             _inputProcessor = new InputProcessor(); 
        }
        
        public static IEnumerable<object[]> InputData()
        {
            yield return new object[]
            {
                "Red,Blue,Green,Purple",
                new string[] {"Red", "Blue", "Green", "Purple"}
            };
            yield return new object[]
            {
                "ORANGE,YELLOW,GreEn,purple",
                new string[] {"ORANGE", "YELLOW", "GreEn", "purple"}
            };
            yield return new object[]
            {
                ".,.,.,.",
                new string[] {".", ".", ".", "."}
            };
            yield return new object[]
            {
                "Any,bunch,of,words,should,work",
                new string[] {"Any", "bunch", "of", "words", "should", "work"}
            };
            yield return new object[]
            {
                "1,2,6,8",
                new string[] {"1","2","6","8"}
            };
        }
        
        [Theory]
        [Trait("Category","Unit")]
        [MemberData(nameof(InputData))]
        public void PutUserGuessIntoArray_ShouldReturnStringArray(string userInput, string[] expectedResult)
        {
            var actualResult = _inputProcessor.PutUserGuessIntoArray(userInput);
            Assert.Equal(expectedResult,actualResult);
        }
        

        [Theory]
        [Trait("Category","Unit")]
        [InlineData("blue, red, green, orange",
            "blue,red,green,orange")]
        
        [InlineData("blue,  red,  green,  orange", 
            "blue,red,green,orange")]
        
        [InlineData("blue,  red,        green,      orange", 
            "blue,red,green,orange")]
        
        [InlineData("anything,              could,   go,    in, here", 
            "anything,could,go,in,here")]
        public void RemoveWhiteSpace_ShouldReturnStringWithoutWhiteSpace(string userInput, string expectedResult)
        {
            var actualResult = _inputProcessor.RemoveWhiteSpace(userInput);
            Assert.Equal(expectedResult, actualResult);
        }

        
        
        [Theory]
        [Trait("Category","Unit")]
        
        [InlineData("RED,blUe,green,yellOW")]
        [InlineData("RED    ,blUe,   green,  yellOW")]
        [InlineData("RED   ,BLUE,GREEN,  YELLOW")]

        public void ProcessInput_ShouldReturnLowerCaseStringArrayWithoutWhiteSpace(string userInput)
        {
            var actualResult = _inputProcessor.ProcessInput(userInput);
            var expectedResult = new string[]{"red", "blue", "green", "yellow"};
            Assert.Equal(expectedResult, actualResult);
        }
        
        }
}