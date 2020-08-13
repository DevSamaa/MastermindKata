using System.Collections.Generic;
using System.Linq;

namespace MastermindKata
{
    public class KeyPegsCreator
    {
        public List<string> Generate(string[] codePegs, string[] userPegs)
        {
            var codePegsCopy = codePegs.ToList();
            var userPegsCopy = userPegs.ToList();
            var keyPegs= new List<string>();
            
            //get black pegs
            for (int i = 0; i < userPegsCopy.Count;)
            {
                if (userPegsCopy[i] == codePegsCopy[i])
                {
                    keyPegs.Add("Black");
                    userPegsCopy.RemoveAt(i);
                    codePegsCopy.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            //get white pegs
            for (int i = 0; i < userPegsCopy.Count;)
            {
                if (codePegsCopy.Contains(userPegsCopy[i]))
                {
                    keyPegs.Add("White");
                    codePegsCopy.Remove(userPegsCopy[i]);
                    userPegsCopy.RemoveAt(i);
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


