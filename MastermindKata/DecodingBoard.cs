using System;
using System.Collections.Generic;

namespace MastermindKata
{
    public class DecodingBoard
    {
        public string[] CodePegs;
        public string[] UserPegs { get; private set; }
        public List<string> KeyPegs { get; private set; }

        public int Tries { get; private set; }

        public DecodingBoard(string[] codePegs)
        {
           CodePegs = codePegs;
           UserPegs = new string[4];
           KeyPegs= new List<string>();
        }

        public void UpdateUserPegs(string[]currentUserGuess)
        {
            UserPegs = currentUserGuess;
            Tries++;
        }
        
        public void UpdateKeyPegs(List<string>currentKeyPegs)
        {
            KeyPegs = currentKeyPegs;
        }

        public void PrintKeyPegs()
        {
            foreach (var peg in KeyPegs)
            {
                Console.Write($"[{peg}]");
            }
        }
    }

    
}