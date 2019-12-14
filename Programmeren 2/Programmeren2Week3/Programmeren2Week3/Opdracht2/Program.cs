using System;
using System.Collections.Generic;
using System.IO;

namespace Opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        void Start()
        {
            GalgjeSpel galgje = new GalgjeSpel();
            List<string> woordenLijst = WoordenLijst();

            galgje.Init(SelecteerWoord(woordenLijst)); 
            Console.Write("Het geheime woord is: ");
            ToonWoord(galgje.savedGeheimWoord);

            if (SpeelGalgje(galgje))
            {
                Console.WriteLine("Winst");
            } else
            {
                Console.WriteLine("Verlies..");
            }

            
        }

        bool SpeelGalgje(GalgjeSpel galgje)
        {
            List<char> ingevoerdeLetters = new List<char>();
            int aantalPogingen = 7;
            
            //main running loop, breakt pas als spel over is
            while (!galgje.IsGeraden() && aantalPogingen > 0)
            {
                Console.WriteLine("Voer een letter in:");
                char inputLetter = LeesLetter(ingevoerdeLetters);
                ingevoerdeLetters.Add(inputLetter);
                Console.Write("Ingevoerde letters: ");
                ToonLetters(ingevoerdeLetters);
                galgje.RaadLetter(inputLetter);
                Console.WriteLine("\nAantal pogingen over: " + (aantalPogingen -1));
                ToonWoord(galgje.geradenWoord);
                Console.WriteLine();
                aantalPogingen--;

            }
            if(galgje.IsGeraden())
            {
                return true;
            }
            return false;
        }
        //print alle al geraden letters
        void ToonLetters(List<char> letters)
        {
            foreach(char letter in letters)
            {
                Console.Write(letter + " ");
            }
        }
        //Vraag input letter op, als al geraden blijf loopen
        char LeesLetter(List<char> verbodenLetters)
        {
            char letter = char.Parse(Console.ReadLine());

            if (verbodenLetters.Contains(letter))
            {
                Console.WriteLine("Al geraden!");
                letter = LeesLetter(verbodenLetters);
            }

            return letter;
        }

        void ToonWoord(string woord)
        {
            
            Console.WriteLine(String.Join(" ", woord));
        }
        //vul lijst met woorden
        List<string> WoordenLijst()
        {

            string[] fileList = File.ReadAllLines("..\\..\\..\\woorden.txt");

            List<string> WoordenLijst = new List<string>();
            
            for (int i = 0; i < fileList.Length; i++)
            {
                WoordenLijst.Add(fileList[i]);                
            }

            return WoordenLijst;
        }
        //kies een random woord uit lijst van 20
        string SelecteerWoord(List<string> woorden)
        {
            Random random = new Random();
            string chosenWord = woorden[random.Next(0, woorden.Count + 1)];
            if (chosenWord.Length < 3)
            {
                return SelecteerWoord(woorden);
            }
            return chosenWord;
        }
    }
}
