using System.Collections.Generic;
using MastermindKata;
using Xunit;

namespace MastermindTests
{
    public class WinnerFinderTests
    {
        private readonly DecodingBoard _decodingBoard;
        private readonly WinnerFinder _winnerFinder;
        
        public WinnerFinderTests()
        {
            var codePegs = new string[] {"orange", "orange", "orange", "orange"};
            _decodingBoard = new DecodingBoard(codePegs); 
            _winnerFinder = new WinnerFinder();

        }
        
         public static IEnumerable<object[]> InputData()
         {
             yield return new object[]
             {
                 new List<string>() {"Black", "Black", "Black", "Black"},
                 true
             };
             yield return new object[]
             {
                 new List<string>() {"Black", "Black", "Black", "White"},
                 false
             };
             yield return new object[]
             {
                 new List<string>() {"Black", "Black", "Black"},
                 false
             };
             yield return new object[]
             {
                 new List<string>() {"White", "White", "White", "White"},
                 false
             };
         }
         
         
        [Theory]
        [MemberData(nameof(InputData))]
        [Trait("Category", "Unit")]
        
        public void UserHasWon_Given4BlackPegs_ShouldReturnTrue(List<string>keyPegs, bool expectedResult)
        {
            _decodingBoard.UpdateKeyPegs(keyPegs);
            var actualResult = _winnerFinder.UserHasWon(_decodingBoard);
            
            Assert.Equal(expectedResult, actualResult);
        }
    }
}