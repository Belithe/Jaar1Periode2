using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Program chess = new Program();
            chess.Start();
        }

        void Start()
        {
            ChessPiece[,] chessboard = new ChessPiece[8, 8];

            InitChessboard(chessboard);
        }

        void InitChessboard(ChessPiece[,] chessboard)
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    chessboard[i, j] = null;
                }
            }
        }

        void DisplayChessboard(ChessPiece[,] chessboard)
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                if (i != 0)
                {
                    Console.Write(i);
                }    
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {


                }
            }
        }
    }
}
