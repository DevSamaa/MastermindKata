using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using MastermindKata;
using Xunit;

namespace MastermindTests
{
    public class KeyPegsCreatorTests
    {
        //TODo maybe take this one out later.
        //TODO find out why these tests are passing despite the fact that you're comparing a list to an array
        [Fact]
        public void GenerateShouldReturnExpectedArrayOld()
        {
            var codePegs = new string[] {"Red", "Blue", "Green", "Purple"};
            var userPegs = new string[] {"Yellow", "Blue", "Yellow", "Red"};
            var keyPegsCreator =new KeyPegsCreator();
            var expectedResult = new string[] {"Black", "White"};

            var actualResult =keyPegsCreator.Generate(codePegs,userPegs);
            
            Assert.Equal(expectedResult, actualResult);
        }
        
        public static IEnumerable<object[]> InputData()
            {
                yield return new object[] { 
                    new string[] {"Yellow", "Blue", "Yellow", "Red"},
                    new string[] {"Black", "White"} };
                yield return new object[] { 
                    new string[] {"Blue", "Red", "Purple","Green"},
                    new string[] {"White", "White", "White", "White"} };
                yield return new object[] { 
                    new string[] {"Red", "Blue", "Green", "Purple"},
                    new string[] {"Black", "Black", "Black", "Black"} };
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
        public void AllWrongAnswersShouldReturnEmptyArray()
        {
            var codePegs = new string[] {"Red", "Blue", "Green", "Purple"};
            var userPegs = new string[] {"Orange", "Orange", "Orange", "Orange"};
            // var expectedResult = new string[] {};

            var keyPegsCreator =new KeyPegsCreator();
            var actualResult =keyPegsCreator.Generate(codePegs,userPegs);
            
            //TODO find out which one of these is "better": IsNullOrEmpty(), or compare to expectedResult!?
            // Assert.Equal(expectedResult, actualResult);
            Assert.True(actualResult.IsNullOrEmpty());
            
        }
    }
}

