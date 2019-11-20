using System;

namespace Opdracht2
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
            Persoon[] personenLijst = new Persoon[3];
            for(int i = 0; i <= 2; i++)
            {
                personenLijst[i] = LeesPersoon();
            }
            for(int i = 0; i <= 2; i++)
            {
                PrintPersoon(personenLijst[i]);
            }
            VierVerjaardag(personenLijst[0]);
            PrintPersoon(personenLijst[0]);
        }
        void VierVerjaardag(Persoon p)
        {
            Console.WriteLine("Het is een verjaardag, jaja.");
            p.Leeftijd++;

        }        
        Persoon LeesPersoon()
        {
            Persoon persoonToRead;
            persoonToRead.Voornaam = LeesString("Wat is de voornaam van uw persoon?: ");
            persoonToRead.Achternaam = LeesString("Wat is de achternaam van uw persoon?: ");
            persoonToRead.Leeftijd = LeesInt("Wat is de leeftjd van uw persoon?: ", 0, 130);
            persoonToRead.Woonplaats = LeesString("Wat is de woonplaats van uw persoon?: ");
            persoonToRead.Geslacht = LeesGeslacht("Wat is het geslacht van uw persoon? (Man, Vrouw): ");

            return persoonToRead;
        }

        void PrintPersoon(Persoon p)
        {
            Console.Write(String.Format("{0} {1}", p.Voornaam, p.Achternaam));
            PrintGeslacht(p.Geslacht);
            Console.WriteLine(String.Format("{0} jaar oud, {1}", p.Leeftijd, p.Woonplaats));
        }

        int LeesInt(string vraag)
        {
            Console.Write(vraag);
            int getalInput = int.Parse(Console.ReadLine());
            return getalInput;
        }

        GeslachtType LeesGeslacht(string vraag)
        {
            Console.Write(vraag);
            GeslachtType geslacht = (GeslachtType)Enum.Parse(typeof(GeslachtType), Console.ReadLine());
            return geslacht;
        }

        void PrintGeslacht(GeslachtType geslacht)
        {
            if (geslacht == GeslachtType.Man) {
                Console.WriteLine(" (m)");
            } else if (geslacht == GeslachtType.Vrouw)
            {
                Console.WriteLine(" (v)");
            } else
            {
                Console.WriteLine(" (?)");
            }
               
        }

        int LeesInt(string vraag, int min, int max)
        {
            Console.Write(vraag);
            int getalInput = int.Parse(Console.ReadLine());
            while (getalInput <= min || getalInput > max)
            {
                Console.Write(vraag);
                getalInput = int.Parse(Console.ReadLine());
            }

            return getalInput;
        }
        string LeesString(string vraag)
        {
            Console.Write(vraag);
            string naam = Console.ReadLine();
            return naam;
        }
    }
}
