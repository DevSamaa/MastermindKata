using System.Collections.Generic;
using MastermindKata.UserInput;
using Xunit;

namespace MastermindTests.UserInput
{
    public class InputValidatorTests
    {
        private readonly InputValidator _inputValidator;
        public InputValidatorTests()
        {
            _inputValidator = new InputValidator();
        }
        
        public static IEnumerable<object[]> InputIsValidData()
        {
            yield return new object[]
            {
                new string[] {"yellow", "blue", "yellow", "red"},
                true
            };
            yield return new object[]
            {
                new string[] {"purple", "purple", "purple", "purple"},
                true
            };
            yield return new object[]
            {
                new string[] {"orange", "green", "green", "green"},
                true
            };
            yield return new object[]
            {
                new string[] { "purple", "purple", "purple"},
                false
            };
            yield return new object[]
            {
                new string[] { "violet", "violet", "violet", "violet"},
                false
            };
        }
        
        [Theory]
        [Trait("Category","Unit")]
        [MemberData(nameof(InputIsValidData))]
        public void InputIsValid_GivenCorrectData_ShouldReturnTrue(string[] userGuess, bool expectedResult)
        {
            var actualResult = _inputValidator.InputIsValid(userGuess);
            Assert.Equal(expectedResult, actualResult);

        }
        
        public static IEnumerable<object[]> ArrayLengthData()
        {
            yield return new object[]
            {
                new string[] {"yellow", "blue", "yellow", "red"},
                true
            };
            yield return new object[]
            {
                new string[] {"any", "other", "color", "possible"},
                true
            };
            yield return new object[]
            {
                new string[] {".", ".", ".", "."},
                true
            };
            yield return new object[]
            {
                new string[] {"yellow", "red"},
                false
            };
            yield return new object[]
            {
                new string[] {"red", "red", "red"},
                false
            };
        }
        
        [Theory]
        [Trait("Category","Unit")]
        [MemberData(nameof(ArrayLengthData))]
        public void ArrayLengthIsCorrect_WhenPassed4Items_ShouldReturnTrue(string[] userGuess, bool expectedResult)
        {
            var actualResult = _inputValidator.ArrayLengthIsCorrect(userGuess);
            Assert.Equal(expectedResult, actualResult);
        }
        
        
        public static IEnumerable<object[]> ColorNamesData()
        {
            yield return new object[]
            {
                new string[] {"yellow", "blue", "yellow", "red"},
                true
            };
            yield return new object[]
            {
                new string[] {"red", "blue", "green", "orange", "purple", "yellow"},
                true
            };
            yield return new object[]
            {
                new string[] {"purple", "purple"},
                true
            };
            yield return new object[]
            {
                new string[] {"random", "colors", "that", "don't exist"},
                false
            };
            yield return new object[]
            {
                new string[] {"violet", "pink", "teal", "magenta"},
                false
            };
          
        }
        
        [Theory]
        [Trait("Category","Unit")]
        [MemberData(nameof(ColorNamesData))]
        public void ColorNamesAreCorrect_WhenCorrectColorsAreUsed_ShouldReturnTrue(string[] userGuess, bool expectedResult)
        {
            var actualResult = _inputValidator.ColorNamesAreCorrect(userGuess);
            Assert.Equal(expectedResult, actualResult);
        }
        
    }
}