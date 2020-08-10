using System.Collections.Generic;
using System.Linq;

namespace MastermindKata
{
    public class KeyPegsCreator
    {
        public List<string> Generate(string[] codePegs, string[] userPegs)
        {
            var codePegsNew = codePegs.ToList();
            var userPegsNew = userPegs.ToList();
            var keyPegs= new List<string>();
            
            //get black pegs
            for (int i = 0; i < userPegsNew.Count;)
            {
                if (userPegsNew[i] == codePegsNew[i])
                {
                    keyPegs.Add("Black");
                    userPegsNew.RemoveAt(i);
                    codePegsNew.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            //get white pegs
            for (int i = 0; i < userPegsNew.Count;)
            {
                if (codePegsNew.Contains(userPegsNew[i]))
                {
                    keyPegs.Add("White");
                    codePegsNew.Remove(userPegsNew[i]);
                    userPegsNew.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            return keyPegs;
        }
        
    }
}


