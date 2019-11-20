using System;

namespace Opdracht1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }
        void Start()
        {
            PrintMaand(VraagMaand("Vul een nummer in a.u.b."));

        }

        void PrintMaand(Maand maand)
        {
            Console.WriteLine(String.Format("{0,3}. {1}", (int)maand, maand.ToString()));
        }

        void PrintMaanden()
        {
            for (int i = 1; i <= 12; i++)
            {
                Maand maandToPrint = (Maand)Enum.Parse(typeof(Maand), i.ToString());
                PrintMaand(maandToPrint);
            }
        }
        Maand VraagMaand(string vraag)
        {
            Console.Write(vraag);
            Maand inputMaand = (Maand)Enum.Parse(typeof(Maand), Console.ReadLine());
            bool inputValid = Enum.IsDefined(typeof(Maand), inputMaand);
            while (!inputValid)
            {
                Console.WriteLine("Invalid input, try again:");
                inputMaand = (Maand)Enum.Parse(typeof(Maand), Console.ReadLine());
                inputValid = Enum.IsDefined(typeof(Maand), inputMaand);
            }

            return inputMaand;

        }
    }
}
