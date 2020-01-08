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
            ChessPiece[,] chessboard = new ChessPiece[9, 9];

            InitChessboard(chessboard);
            DisplayChessboard(chessboard);
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

            PutChessPieces(chessboard);
        }

        void DisplayChessboard(ChessPiece[,] chessboard)
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    if(i == 0 || j == 0)
                    {
                        Console.ResetColor();
                    } else if ((j-i) % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    } else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }

                    Console.Write(" ");
                    if (i != 0 && j == 0)
                    {
                        Console.Write(i);
                    }
                    else if (j != 0 && i == 0)
                    {
                        Console.Write((char)(j + 64));
                    }
                    else
                    {
                        DisplayChessPieces(chessboard[i, j]);
                    }


                    Console.Write(" ");
                }
                Console.WriteLine();

                Console.ResetColor();
            }
            Console.ResetColor();
        }

        void PutChessPieces(ChessPiece[,] chessboard)
        {
            ChessPieceType[] order = {ChessPieceType.Pawn, ChessPieceType.Rook, ChessPieceType.Knight, ChessPieceType.Bishop, ChessPieceType.King, ChessPieceType.Queen, ChessPieceType.Bishop, ChessPieceType.Knight, ChessPieceType.Rook };
            
            for (int i = 1; i < chessboard.GetLength(0); i++)
            {
                for (int j = 1; j < chessboard.GetLength(1); j++)
                {
                    ChessPiece current = chessboard[i, j];
                    if (i == 1)
                    {
                        current = new ChessPiece();
                        current.type = order[j];
                        current.color = ChessPieceColor.White;
                    }else if(i == 2)
                    {
                        current = new ChessPiece();
                        current.type = ChessPieceType.Pawn;
                        current.color = ChessPieceColor.White;
                    }else if(i == 7)
                    {
                        current = new ChessPiece();
                        current.type = ChessPieceType.Pawn;
                        current.color = ChessPieceColor.Black;
                    } else if(i == 8)
                    {
                        current = new ChessPiece();
                        current.type = order[j];
                        current.color = ChessPieceColor.Black ;
                    }

                    chessboard[i, j] = current;
                }
            }
        }

        void DisplayChessPieces(ChessPiece chessPiece)
        {
            if (chessPiece == null)
            {
                Console.Write(" ");
            } else
            {
                switch(chessPiece.color)
                {
                    case ChessPieceColor.Black: 
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case ChessPieceColor.White:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                switch(chessPiece.type)
                {
                    case ChessPieceType.Pawn:
                        Console.Write("p");
                        break;
                    case ChessPieceType.Bishop:
                        Console.Write("b");
                        break;
                    case ChessPieceType.Knight:
                        Console.Write("k");
                        break;
                    case ChessPieceType.Rook:
                        Console.Write("r");
                        break;
                    case ChessPieceType.Queen:
                        Console.Write("Q");
                        break;
                    case ChessPieceType.King:
                        Console.Write("K");
                        break;
                }
            }
        }
    }
}
