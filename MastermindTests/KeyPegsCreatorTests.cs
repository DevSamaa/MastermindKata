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
                    new string[] {"red", "blue", "green", "purple"},
                    new string[] {"yellow", "blue", "yellow", "red"},
                    new List<string>() {"Black", "White"} };
                
                yield return new object[] { 
                    new string[] {"red", "blue", "green", "purple"},
                    new string[] {"blue", "red", "purple","green"},
                    new List<string>(){"White", "White", "White", "White"} };
                
                yield return new object[] { 
                    new string[] {"red", "blue", "green", "purple"},
                    new string[] {"red", "blue", "green", "purple"},
                    new List<string>(){"Black", "Black", "Black", "Black"} };
                
                yield return new object[] { 
                    new string[] {"red", "blue", "green", "purple"},
                    new string[] {"red", "orange", "blue", "blue"},
                    new List<string>(){"Black", "White"} };
                
                yield return new object[] { 
                    new string[] {"purple", "orange", "blue", "green"},
                    new string[] {"orange", "purple", "blue","green"},
                    new List<string>(){"Black", "Black", "White", "White"} };
                
                yield return new object[] { 
                    new string[] {"red", "blue", "green", "purple"},
                    new string[] {"yellow", "orange", "blue", "blue"},
                    new List<string>(){ "White"} };
                
                yield return new object[] { 
                    new string[] {"red", "blue", "green", "purple"},
                    new string[] {"yellow", "yellow", "yellow", "yellow"},
                    new List<string>(){} };
                
                yield return new object[] { 
                    new string[] {"orange", "orange", "orange", "orange"},
                    new string[] {"blue", "green", "yellow", "purple"},
                    new List<string>(){} };
            }
        
        
        [Theory]
        [Trait("Category","Unit")]
        [MemberData(nameof(InputData))]
        public void Generate_ShouldReturnExpectedArray(string[]codePegs, string[] userPegs, string[] expectedResult)
        {
            var keyPegsCreator =new KeyPegsCreator();
            var actualResult =keyPegsCreator.Generate(codePegs,userPegs);
            
            Assert.Equal(expectedResult, actualResult);
        }
        
    }
}

