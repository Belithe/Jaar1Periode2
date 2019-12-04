using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht2
{
    class GalgjeSpel
    {
        public string savedGeheimWoord = "";
        public string geradenWoord;
        
        public void Init(string geheimWoord)
        {
            savedGeheimWoord = geheimWoord;

            for (int i = 0; i < savedGeheimWoord.Length; i++)
            {
                geradenWoord = geradenWoord + ".";
            }
        }

        //check of geraden letter klopt, zo wel pas woord van geraden letters aan
        public bool RaadLetter(char letter)
        {
            if (savedGeheimWoord.Contains(letter))
            {
                for (int i = 0; i < savedGeheimWoord.Length; i++)
                {
                    if (savedGeheimWoord[i] == letter)
                    {
                        char[] tussenWoord = geradenWoord.ToCharArray();

                        tussenWoord[i] = letter;
                        geradenWoord = new string(tussenWoord);

                    }
                }
                return true;
            }
            return false;
            
        }

        public bool IsGeraden()
        {           
            return (savedGeheimWoord == geradenWoord);
        }
    }
}
