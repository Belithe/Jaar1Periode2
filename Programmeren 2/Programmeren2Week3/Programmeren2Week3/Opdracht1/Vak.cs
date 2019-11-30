using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht1
{
    class Vak
    {
        public string vakNaam;
        public int cijferTheorie;
        public PraktijkBeoordeling praktijkBeoordeling;
        public bool IsBehaald()
        {
            if (cijferTheorie < 55 || (int)praktijkBeoordeling < 3)
            {
                return false;
            } else
            {
                return true;
            }
        }
        public bool IsCumLaude()
        {
            if (cijferTheorie > 79 && praktijkBeoordeling == PraktijkBeoordeling.Goed)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
