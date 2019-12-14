using System;
using System.IO;
using CandyCrushLogic;

namespace Opdracht3
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
            Console.WriteLine("Voer als mogelijk bestandsnaam in zonder txt.");
            string input = Console.ReadLine();
            if (File.Exists(String.Format("{0}.txt", input)))
            {

                try
                {
                    RegularCandies[,] speelveld = LeesSpeelveld(String.Format("{0}.txt", input));

                    PrintCandies(speelveld);

                    if (CandyCrusher.ScoreRijAanwezig(speelveld))
                    {
                        Console.WriteLine("Er is een valide rij aanwezig.");
                    }
                    else
                    {
                        Console.WriteLine("Nee.");
                    }

                    if (CandyCrusher.ScoreKolomAanwezig(speelveld))
                    {
                        Console.WriteLine("Er is een valide kolom aanwezig.");
                    }
                    else
                    {
                        Console.WriteLine("Nee maar verticaal.");
                    }

                }
                catch
                {
                    NewGame(input);
                }
            }
            else
            {
                NewGame(input);
            }
        }

        void NewGame(string input)
        {
            RegularCandies[,] speelveld = new RegularCandies[9, 9];
            InitCandies(speelveld);
            PrintCandies(speelveld);

            SchrijfSpeelveld(speelveld, String.Format("{0}.txt", input));

            if (CandyCrusher.ScoreRijAanwezig(speelveld))
            {
                Console.WriteLine("Er is een valide rij aanwezig.");
            }
            else
            {
                Console.WriteLine("Nee.");
            }

            if (CandyCrusher.ScoreKolomAanwezig(speelveld))
            {
                Console.WriteLine("Er is een valide kolom aanwezig.");
            }
            else
            {
                Console.WriteLine("Nee maar verticaal.");
            }
        }

        void InitCandies(RegularCandies[,] matrix)
        {
            Random rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (RegularCandies)Enum.Parse(typeof(RegularCandies), rnd.Next(0, 6).ToString());
                }
            }
        }

        void SchrijfSpeelveld(RegularCandies[,] speelveld, string bestandsnaam)
        {
            StreamWriter fileToWrite = new StreamWriter(bestandsnaam, true);


            for (int i = 0; i < speelveld.GetLength(0); i++)
            {
                string rowToPrint = "";

                for (int j = 0; j < speelveld.GetLength(1); j++)
                {
                    rowToPrint = String.Format("{0} {1}", rowToPrint, (int)speelveld[i, j]);
                }
                fileToWrite.WriteLine(rowToPrint);
            }

            fileToWrite.Close();
        }

        RegularCandies[,] LeesSpeelveld(string bestandsnaam)
        {
            string[] inputFile = File.ReadAllLines(bestandsnaam);
            string[] getalStrings = inputFile[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            RegularCandies[,] speelveld = new RegularCandies[getalStrings.Length, inputFile.Length];

            for (int i = 0; i < inputFile.Length; i++)
            {
                getalStrings = inputFile[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < getalStrings.Length; j++)
                {
                    speelveld[i, j] = (RegularCandies)Enum.Parse(typeof(RegularCandies), (getalStrings[j]));
                }

            }

            return speelveld;

        }

        void PrintCandies(RegularCandies[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.ResetColor();
                    switch (matrix[i, j])
                    {
                        case RegularCandies.JellyBean:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case RegularCandies.Lozenge:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        case RegularCandies.LemonDrop:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case RegularCandies.GumSquare:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case RegularCandies.LollipopHead:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case RegularCandies.JujubeCluster:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                    }

                    Console.Write("$ ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ResetColor();
        }

        
    }
}
