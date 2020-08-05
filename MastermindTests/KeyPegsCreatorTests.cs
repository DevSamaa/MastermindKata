using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using MastermindKata;
using Xunit;

namespace MastermindTests
{
    public class KeyPegsCreatorTests
    {
        
        //TODO change the keypegs to a list
        
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
                yield return new object[] { 
                    new string[] {"Red", "Orange", "Blue", "Blue"},
                    new string[] {"Black", "White"} };
            }
        
       
        
        [Theory]
        [MemberData(nameof(InputData))]
        public void GenerateShouldReturnExpectedArrays(string[] userPegs, string[] expectedResult)
        {
            var codePegs = new string[] {"Red", "Blue", "Green", "Purple"};
            var keyPegsCreator =new KeyPegsCreator();

            var actualResult =keyPegsCreator.Generate2(codePegs,userPegs);
            
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AllWrongAnswersShouldReturnEmptyArray()
        {
            var codePegs = new string[] {"Red", "Blue", "Green", "Purple"};
            var userPegs = new string[] {"Orange", "Orange", "Orange", "Orange"};

            var keyPegsCreator =new KeyPegsCreator();
            var actualResult =keyPegsCreator.Generate(codePegs,userPegs);
            
            //TODO find the assert.empty thing, also change workind. you're getting a list not an array
            Assert.True(actualResult.IsNullOrEmpty());
            
        }
    }
}

