using System;

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
            RegularCandies[,] speelveld = new RegularCandies[9,9];
            InitCandies(speelveld);
            PrintCandies(speelveld);

            if (ScoreRijAanwezig(speelveld))
            {
                Console.WriteLine("Er is een valide rij aanwezig.");
            } else
            {
                Console.WriteLine("Nee.");
            }

            if (ScoreKolomAanwezig(speelveld))
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

        void PrintCandies(RegularCandies[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.ResetColor();
                    switch (matrix[i,j])
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

        bool ScoreRijAanwezig(RegularCandies[,] matrix)
        {

            RegularCandies currentCandy = RegularCandies.JellyBean;
            int counter=0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (currentCandy == matrix[i, j])
                    {
                        counter++;
                    } else
                    {
                        currentCandy = matrix[i, j];
                        counter = 1;
                    }

                    if (counter == 3)
                    {
                        return true;
                    }                
                    
                }
                counter = 0;
            }
            return false;                
        }

        bool ScoreKolomAanwezig(RegularCandies[,] matrix)
        {

            RegularCandies currentCandy = RegularCandies.JellyBean;
            int counter = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (currentCandy == matrix[j, i])
                    {
                        counter++;
                    }
                    else
                    {
                        currentCandy = matrix[j, i];
                        counter = 1;
                    }

                    if (counter == 3)
                    {
                        return true;
                    }

                }
                counter = 0;
            }
            return false;
        }
    }
}
