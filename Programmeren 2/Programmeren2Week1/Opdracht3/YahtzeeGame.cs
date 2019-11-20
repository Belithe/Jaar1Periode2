using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht3
{
    class YahtzeeGame
    {
        public Dobbelsteen[] dobbelsteenList = new Dobbelsteen[5];
        public void Init()
        {
            for (int i = 0; i < 5; i++)
            {
                dobbelsteenList[i] = new Dobbelsteen();

            }
        }

        public void Gooi()
        {
            for (int i = 0; i < dobbelsteenList.Length; i++)
            {
                dobbelsteenList[i].Gooi();
            }
            Console.WriteLine(); 
        }

        public void ToonWorp()
        {
            for (int i = 0; i < dobbelsteenList.Length; i++)
            {
                dobbelsteenList[i].ToonWaarde();
            }
        }

        public bool Yahtzee()
        {
            bool yahtzee = false;
            bool yahtzeePossible = true;

            for (int i = 0; i < dobbelsteenList.Length; i++)
            {
                if (i != 0)
                {
                    bool equalCheck = (dobbelsteenList[0].waarde == dobbelsteenList[i].waarde);

                    if (!equalCheck)
                    {
                        yahtzeePossible = false;
                    }
                    else if (i == dobbelsteenList.Length - 1 && yahtzeePossible == true)
                    {
                        yahtzee = true;
                    }
                }
            }

            return yahtzee;
        }
    }
}
