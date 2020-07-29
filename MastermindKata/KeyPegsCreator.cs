using System.Collections.Generic;
using System.Linq;

namespace MastermindKata
{
    public class KeyPegsCreator
    {
        public List<string> Generate(string[] codePegs, string[] userPegs)
        {
            var keyPegs= new List<string>();
            for (int i = 0; i < 4; i++)
            {
                if (userPegs[i] == codePegs[i])
                {
                    keyPegs.Add("Black");
                }
                else if (codePegs.Any(strings => strings == userPegs[i] ))
                {
                    keyPegs.Add("White");
                }
            }

            return keyPegs;
        }
        
        //TODO check if it's better to actually return an array rather than a list
        public string[] GenerateReturnArray2(string[] codePegs, string[] userPegs)
        {
            var keyPegs= new List<string>();
            for (int i = 0; i < 4; i++)
            {
                if (userPegs[i] == codePegs[i])
                {
                    keyPegs.Add("Black");
                }
                else if (codePegs.Any(strings => strings == userPegs[i] ))
                {
                    keyPegs.Add("White");
                }
            }

            return keyPegs.ToArray();
        }
    }
}


