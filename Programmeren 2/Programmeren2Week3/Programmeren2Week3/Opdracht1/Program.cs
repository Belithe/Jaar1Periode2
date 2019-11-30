using System;
using System.Collections.Generic;

namespace Opdracht1
{
//ak in de Start-methode een lijst met beoordelingen:
//List<Vak> rapport;
// Vul deze lijst met 3 vakken.Maak hiervoor methode List<Vak> LeesRapport(int aantalVakken).
// Toon het rapport op het scherm. Maak hiervoor methode void ToonRapport(List<Vak> rapport).


    class Program
    {
        static void Main(string[] args)
        {

            

            Program program = new Program();
            program.Start();
        }

        void Start()
        {
            //ToonVak(LeesVak("Van welk vak moet het resultaat worden gelezen?"));
            List<Vak> rapport = new List<Vak>();

            rapport = LeesRapport(3);
            ToonRapport(rapport);
        }

        List<Vak> LeesRapport(int aantalVakken)
        {
            List<Vak> vakList = new List<Vak>();
            for (int i = 0; i < 3; i++)
            {
                vakList.Add(LeesVak(String.Format("Voor vak nummer {0} in.", i+1)));
            }

            return vakList;
        }

        void ToonRapport(List<Vak> rapport)
        {
            bool geslaagd = true;
            bool cumLaude = true;
            int herkansingen = 0;

            //check of genoeg vakken geslaagd/cum laude en aantal herkansingen
            foreach (Vak vak in rapport)
            {
                ToonVak(vak);
            }
            foreach(Vak vak in rapport)
            {
                if(!vak.IsBehaald())
                {
                    cumLaude = false;
                    geslaagd = false;
                    herkansingen++;
                }
                if (!vak.IsCumLaude()) 
                {
                    cumLaude = false;
                }
               
            }
            //Print resultaten
            if(geslaagd == true)
            {
                Console.WriteLine("Student heeft alle vakken voldoende behaald.");
                if(cumLaude == true)
                {
                    Console.WriteLine("Student is Cum Laude geslaagd.");
                }
            } else
            {
                Console.WriteLine("Student is helaas gezakt");
                Console.WriteLine(String.Format("Student zal {0} herkansingen moeten maken.", herkansingen));
            }
            
        }

        PraktijkBeoordeling LeesPraktijkBeoordeling(string vraag)
        {
            Console.WriteLine(vraag);
            PraktijkBeoordeling beoordeling = (PraktijkBeoordeling)Enum.Parse(typeof(PraktijkBeoordeling),Console.ReadLine());
            return beoordeling;
        }
        void ToonPraktijkBeoordeling(PraktijkBeoordeling praktijkBeoordeling)
        {
            Console.WriteLine(praktijkBeoordeling.ToString());
        }
        Vak LeesVak(string vraag)
        {
            Vak vak = new Vak();

            Console.WriteLine(vraag);
            vak.vakNaam = Console.ReadLine();
            Console.WriteLine("Wat is het cijfer voor de theorietoets?");
            vak.cijferTheorie = int.Parse(Console.ReadLine());
            vak.praktijkBeoordeling = LeesPraktijkBeoordeling("Wat is het resultaat van de praktijk oefening?");

            return vak;
        }
        void ToonVak(Vak vak)
        {
            Console.WriteLine(String.Format("Resultaat voor {0}: Theorie: {1}, Praktijk: {2}", vak.vakNaam, vak.cijferTheorie.ToString(), vak.praktijkBeoordeling.ToString()));
        }


    }
}
