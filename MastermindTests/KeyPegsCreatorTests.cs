using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using MastermindKata;
using Xunit;

namespace MastermindTests
{
    public class KeyPegsCreatorTests
    {
        
        public static IEnumerable<object[]> InputData()
            {
                yield return new object[] { 
                    new string[] {"Yellow", "Blue", "Yellow", "Red"},
                    new List<string>() {"Black", "White"} };
                yield return new object[] { 
                    new string[] {"Blue", "Red", "Purple","Green"},
                    new List<string>(){"White", "White", "White", "White"} };
                yield return new object[] { 
                    new string[] {"Red", "Blue", "Green", "Purple"},
                    new List<string>(){"Black", "Black", "Black", "Black"} };
                yield return new object[] { 
                    new string[] {"Red", "Orange", "Blue", "Blue"},
                    new List<string>(){"Black", "White"} };
            }
        
        
        [Theory]
        [MemberData(nameof(InputData))]
        public void GenerateShouldReturnExpectedArrays(string[] userPegs, string[] expectedResult)
        {
            var codePegs = new string[] {"Red", "Blue", "Green", "Purple"};
            var keyPegsCreator =new KeyPegsCreator();

            var actualResult =keyPegsCreator.Generate(codePegs,userPegs);
            
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AllWrongAnswersShouldReturnEmptyList()
        {
            var codePegs = new string[] {"Red", "Blue", "Green", "Purple"};
            var userPegs = new string[] {"Orange", "Orange", "Orange", "Orange"};

            var keyPegsCreator =new KeyPegsCreator();
            var actualResult =keyPegsCreator.Generate(codePegs,userPegs);
            
            Assert.True(actualResult.IsNullOrEmpty());
            Assert.Empty(actualResult);
            
        }
    }
}

