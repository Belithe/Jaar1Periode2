using System;
using System.IO;

namespace Opdracht1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prooooogram = new Program();
            prooooogram.Start();
        }

        void Start()
        {
            Console.WriteLine("Wat is uw naam?:");
            string inputFileNaam  = String.Format("{0}.txt", Console.ReadLine());
            

            if (File.Exists(inputFileNaam)) {  


                Console.WriteLine("Hallo bekende gebruiker.");
                ToonPersoon(LeesPersoon(inputFileNaam));

            } else
            {
                Console.WriteLine("Welkom nieuwe gebruiker.");
                SchrijfPersoon(LeesPersoon(), inputFileNaam);
            }
        }

        void ToonPersoon(Persoon p)
        {
            Console.WriteLine(String.Format("Naam: {0} Leeftijd: {1} Woonplaats: {2}", p.naam, p.leeftijd, p.woonplaats));
        }

        Persoon LeesPersoon()
        {
            Persoon persoonToRead = new Persoon();

            Console.WriteLine("Wat is de naam van uw persoon?");
            persoonToRead.naam = Console.ReadLine();
            Console.WriteLine("Wat is de woonplaats van uw persoon?");
            persoonToRead.woonplaats = Console.ReadLine();
            Console.WriteLine("Wat is de leeftijd van uw persoon?");
            persoonToRead.leeftijd = int.Parse(Console.ReadLine());

            return persoonToRead;
        }

        void SchrijfPersoon(Persoon p, string bestandsNaam)
        {
            StreamWriter fileToWrite = new StreamWriter(bestandsNaam, true);
            
            fileToWrite.WriteLine(p.naam);
            fileToWrite.WriteLine(p.leeftijd);
            fileToWrite.WriteLine(p.woonplaats);

            fileToWrite.Close();
        }

        Persoon LeesPersoon(string bestandsNaam)
        {
            Persoon persoonToRead = new Persoon();
            
            string[] infoToRead = File.ReadAllLines(bestandsNaam);

            persoonToRead.naam = infoToRead[0];
            persoonToRead.leeftijd = int.Parse(infoToRead[1]);
            persoonToRead.woonplaats = infoToRead[2];

            return persoonToRead;

        }
    }
}
