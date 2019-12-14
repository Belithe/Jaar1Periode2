using System;
using System.IO;

namespace Opdracht3week4
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pog = new Program();
            pog.Start();
        }

        void Start()
        {
            Console.WriteLine("Please enter your search term.");
            Console.WriteLine("\n\nAmount of lines including term: " + ZoekWoordInBestand("..\\..\\..\\tweets.txt", Console.ReadLine()));
        }

        bool ZitWoordInRegel(string regel, string woord)
        {
            return (regel.ToLower().Contains(woord.ToLower()));
        }

        int ZoekWoordInBestand(string bestandsnaam, string woord)
        {
            string[] tweet =  File.ReadAllLines(bestandsnaam);
            int woordCount = 0;

            for (int i = 0; i < tweet.Length; i++)
            {
                if(ZitWoordInRegel(tweet[i], woord))
                {
                    woordCount++;
                    ToonWoordInRegel(tweet[i], woord);
                }
            }

            return woordCount;
        }

        void ToonWoordInRegel(string regel, string woord)
        {
            int woordIndex = regel.ToLower().IndexOf(woord.ToLower());

            Console.Write(regel.Substring(0, woordIndex));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(regel.Substring(woordIndex, woord.Length));
            Console.ResetColor();
            Console.Write(regel.Substring(woordIndex + woord.Length));

            
                   
        }
    }
}
