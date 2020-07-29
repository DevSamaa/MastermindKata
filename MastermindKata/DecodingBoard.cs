using System.Collections.Generic;

namespace MastermindKata
{
    public class DecodingBoard
    {
        public string[] CodePegs;
        public string[] UserPegs { get; set; }
        public List<string> KeyPegs { get; set; }

        public int Tries { get; set; }

        public DecodingBoard(string[] codePegs)
        {
           CodePegs = codePegs;
           UserPegs = new string[4];
           KeyPegs= new List<string>();
        }
    }

    
}