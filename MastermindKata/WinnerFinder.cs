using System;
using System.Linq;

namespace MastermindKata
{
    public class WinnerFinder
    {
        public bool UserHasWon(DecodingBoard decodingBoard)
        {
            if (decodingBoard.KeyPegs.Count != 4) return false;
            var allBlack = decodingBoard.KeyPegs.All(peg => peg.Equals("Black"));
            return allBlack;
        }
    }
}