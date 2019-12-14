using System;
using MyTools;

namespace Opdracht1
{
    class Program
    {
        static void Main() { Program myProgram = new Program(); myProgram.Start(); }
        void Start()
        {
            int getal = LeesTools.LeesInt("tik een getal: "); Console.WriteLine("Je hebt {0} ingetikt.", getal);
            int leeftijd = LeesTools.LeesInt("hoe oud ben je? ", 0, 120); Console.WriteLine("Je bent {0} jaar oud.", leeftijd);
            string naam = LeesTools.LeesString("Hoe heet je? "); Console.WriteLine("Aangenaam kennis met je te maken, {0}.", naam);
            Console.ReadKey();
        }
    }
}
