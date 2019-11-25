using System;

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
            int[,] matrix = new int[15, 10];
            int numberToSearch;
            Positie pos;

            InitMatrixRandom(matrix, 1, 100);
            PrintMatrix(matrix);

            Console.Write("\nGeef een int waarde: ");
            numberToSearch = int.Parse(Console.ReadLine());

            pos = ZoekGetal(matrix, numberToSearch);

            if (pos.found)
                Console.Write(String.Format("\nForwards: {0,2},{1}", pos.rij + 1, pos.kolom + 1));
            else
                Console.Write("\nGetal niet gevonden!");

            pos = ZoekGetalAchterwaards(matrix, numberToSearch);

            if (pos.found)
                Console.Write("\nBackwards: {0,2},{1}", pos.rij + 1, pos.kolom + 1);
            else
                Console.Write("\nGetal niet gevonden!");
        }

        void InitMatrixRandom(int[,] matrix, int min, int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(min, max);
                }
            }
        }
        void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0,2} ", matrix[i, j].ToString()));
                }

                Console.WriteLine();
            }
        }
        Positie ZoekGetal(int[,] matrix, int zoekGetal)
        {
            Positie search = new Positie();

            for (int i = 0; i < matrix.GetLength(0) && !search.found; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) && !search.found; j++)
                    if (matrix[i, j] == zoekGetal)
                    {
                        search.found = true;
                        search.rij = j;
                        search.kolom = i;
                    }
            }
            return search;
        }

        Positie ZoekGetalAchterwaards(int[,] matrix, int zoekGetal)
        {
            Positie search = new Positie();

            for (int i = matrix.GetLength(0) - 1; i >= 0 && !search.found; i--)
                for (int j = matrix.GetLength(1) - 1; j >= 0 && !search.found; j--)
                    if (matrix[i, j] == zoekGetal)
                    {
                        search.found = true;
                        search.rij = i;
                        search.kolom = j;
                    }

            return search;
        }

    }
}
