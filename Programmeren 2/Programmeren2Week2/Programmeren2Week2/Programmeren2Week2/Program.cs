using System;

namespace Opdracht1
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
            int[,] matrix = new int[10, 10];
            InitMatrixLineair(matrix);
            PrintMatrixWithCross(matrix);
        }

        void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0, 3} ", matrix[i, j].ToString()));
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

        void InitMatrixLineair(int[,] matrix)
        {
            int row = 0;
            int column = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[row,column] = i + 1;
                column++;
                if (column == matrix.GetLength(1))
                {
                    column = 0;
                    row++;
                }
            }
        }
        void PrintMatrixWithCross(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.ResetColor();

                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if(Math.Abs(j - matrix.GetLength(1)+1) == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }

                    Console.Write("{0, 3}", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }


    }
}
