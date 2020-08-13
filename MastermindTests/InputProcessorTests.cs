using MastermindKata;
using Xunit;

namespace MastermindTests
{
    public class InputProcessorTests
    {
        //TODO: turn this into a theory based test
        [Fact]
        public void PutUserGuessIntoArrayShouldReturnArrayOfStrings()
        {
            var inputProcessor = new InputProcessor();
            var actualResult = inputProcessor.PutUserGuessIntoArray("Red,Blue,Green,Purple");
            var expectedResult = new string[] {"Red", "Blue", "Green", "Purple"};
           
            Assert.Equal(expectedResult,actualResult);
        }
        

    [Theory]
    [InlineData("blue, red, green, orange",
        "blue,red,green,orange")]
    
    [InlineData("blue,  red,  green,  orange", 
        "blue,red,green,orange")]
    
    [InlineData("blue,  red,        green,      orange", 
        "blue,red,green,orange")]
    
    [InlineData("anything,              could,   go,    in, here", 
        "anything,could,go,in,here")]
    public void RemoveWhiteSpaceShouldReturnStringWithoutWhiteSpace(string incomingString, string expectedResult)
    {
        var inputProcessor = new InputProcessor();
        var actualResult = inputProcessor.RemoveWhiteSpace(incomingString);
        Assert.Equal(expectedResult, actualResult);
    }
    
    }
}