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
            PlayChess(chessboard);
        }

        void PlayChess(ChessPiece[,] chessboard)
        {
            while (true)
            {
                Position froPos = ReadPosition("Please input a position to move from:");
                Position toPos = ReadPosition("Please input a position to move to:");
                CheckMove(chessboard, froPos, toPos);
                DoMove(chessboard, froPos, toPos);
                DisplayChessboard(chessboard);
            }
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

        Position ReadPosition(string question)
        {
            Console.WriteLine(question);

            string userPos = Console.ReadLine();

            Position position = new Position();
            try
            {
                position.column = userPos[0] - 64;
                position.row = int.Parse(userPos[1].ToString());

                if (position.column < 1 || position.column > 8)
                {
                    Console.WriteLine("Incorrect column letter.");
                    return ReadPosition(question);
                }
                if (position.row > 8 || position.row < 1)
                {
                    Console.WriteLine("Incorrect row number.");
                    return ReadPosition(question);

                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ReadPosition(question);
            }
            return position;
        }

        void DoMove(ChessPiece[,] chessboard, Position from, Position to)
        {
            chessboard[to.row, to.column] = chessboard[from.row, from.column];
            chessboard[from.row, from.column] = null;

        }
        void CheckMove(ChessPiece[,] chessboard, Position from, Position to)
        {
            if (chessboard[to.row, to.column] != null)
            {
                Console.WriteLine("Position to go to is full.");
            }
            if (chessboard[from.row, from.column] == null)
            {
                Console.WriteLine("Position to go from is empty.");
            }
            if (!ValidMove(chessboard[from.row, from.column], from, to))
            {
                Console.WriteLine("Invalid move.");
            }
        }

        bool ValidMove(ChessPiece chessPiece, Position from, Position to)
        {
            bool isValid = false;

            int ver = Math.Abs(from.row - to.row);
            int hor = Math.Abs(from.column - to.column);

            switch(chessPiece.type) {

                case ChessPieceType.Pawn:
                    if(hor == 0 && ver == 1)
                    {
                        isValid = true;
                    }
                    break;
                case ChessPieceType.Bishop:
                    if(hor == ver)
                    {
                        isValid = true;
                    }
                    break;
                case ChessPieceType.Knight:
                    if(hor * ver == 2)
                    {
                        isValid = true;
                    }
                    break;
                case ChessPieceType.Rook:
                    if(hor * ver == 0)
                    {
                        isValid = true;
                    }
                    break;
                case ChessPieceType.Queen:
                    if(hor * ver == 0 || hor == ver)
                    {
                        isValid = true;
                    }
                    break;
                case ChessPieceType.King:
                    if(hor == 1 || ver == 1)
                    {
                        isValid = true;
                    }
                    break;
            }

            return isValid;
        }
    }
}
