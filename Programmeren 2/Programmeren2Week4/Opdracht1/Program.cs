using System;

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
            ToonPersoon(LeesPersoon());
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

        }
    }
}
