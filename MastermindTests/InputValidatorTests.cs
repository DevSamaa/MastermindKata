using System.Collections.Generic;
using System.Linq;
using MastermindKata;
using Xunit;

namespace MastermindTests
{
    public class InputValidatorTests
    {
        
        public static IEnumerable<object[]> ArrayLengthData()
        {
            yield return new object[]
            {
                new string[] {"Yellow", "Blue", "Yellow", "Red"},
                true
            };
            yield return new object[]
            {
                new string[] {"skdhfksjdh", "trt45t", "Yeler43cerlow", "fkihw4icu3qucr"},
                true
            };
            yield return new object[]
            {
                new string[] {"Yellow", "Red"},
                false
            };
        }
        
        [Theory]
        [MemberData(nameof(ArrayLengthData))]
        public void ArrayLengthIsCorrectShouldReturnTrueWhen4ItemsPresent(string[] incomingArray, bool expectedResult)
        {
            var inputValidator = new InputValidator();

            var actualResult = inputValidator.ArrayLengthIsCorrect(incomingArray);
            
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
                new string[] {"skdhfksjdh", "trt45t", "Yeler43cerlow", "fkihw4icu3qucr"},
                false
            };
            yield return new object[]
            {
                new string[] {"purple", "purple"},
                true
            };
        }
        
        [Theory]
        [MemberData(nameof(ColorNamesData))]
        public void ColorNamesAreCorrectReturnsTrueWhenRightNamesAreUsed(string[] userGuessArray, bool expectedResult)
        {
            var inputValidator = new InputValidator();

            var actualResult = inputValidator.ColorNamesAreCorrect(userGuessArray);
            
            Assert.Equal(expectedResult, actualResult);
        }
        
    }
}