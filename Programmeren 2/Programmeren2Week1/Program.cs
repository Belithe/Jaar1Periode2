using System;

namespace Opdracht0
{
    class Program
    {
        static void Main()
        {
            Program myProgram = new Program();
            myProgram.Start();
        }
        void Start()
        {
            int getal = LeesInt("tik een getal: ");
            Console.WriteLine("Je hebt {0} ingetikt.", getal);

            int leeftijd = LeesInt("hoe oud ben je? ", 0, 120);
            Console.WriteLine("Je bent {0} jaar oud.", leeftijd);

            string naam = LeesString("Hoe heet je? ");
            Console.WriteLine("Aangenaam kennis met je te maken, {0}.", naam);
            Console.ReadKey();
        }

        int LeesInt(string vraag)
        {
            Console.Write(vraag);
            int getalInput = int.Parse(Console.ReadLine());
            return getalInput;
        }

        int LeesInt(string vraag, int min, int max)
        {
            Console.Write(vraag);
            int leeftijd = int.Parse(Console.ReadLine());
            while(leeftijd <= min || leeftijd > max) {
                Console.Write(vraag);
                leeftijd = int.Parse(Console.ReadLine());
            }

            return leeftijd;
        }

        string LeesString(string vraag)
        {
            Console.Write(vraag);
            string naam = Console.ReadLine();
            return naam;
        }

    }
}
