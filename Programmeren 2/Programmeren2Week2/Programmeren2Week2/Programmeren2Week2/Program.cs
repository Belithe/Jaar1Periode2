using System;

namespace Programmeren2Week2
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
            int[,] matrix = new int[12, 10];
            InitMatrix2D(matrix);
            PrintMatrix(matrix);
        }

        void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0, 4} ", matrix[i, j].ToString()));
                }

                Console.WriteLine();
            }
        }
        void InitMatrix2D(int[,] matrix)
        {
            int counter=1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = counter;
                    counter++;
                }
            }
        }
    }
}
