using System;
using System.Collections.Generic;
using board;
using chess;

namespace ConsoleChess
{
    public class Screen
    {

        public static void printMatch(MatchChess match)
        {
            printBoard(match.board);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);
            Console.WriteLine("Waiting for move: " + match.currentPlayer);
            Console.WriteLine();
            if (match.check)
            {
                Console.WriteLine("CHECK!");
            }
        }

        public static void printCapturedPieces(MatchChess match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            printSet(match.capturedPieces(Color.White));
            Console.WriteLine();
            Console.WriteLine("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(match.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();

        }

        public static void printSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void printBoard(Board board)
        {
            Console.WriteLine();
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
        }
        public static void printBoard(Board board, bool[,] possiblePosition)
        {
            ConsoleColor backOriginal = Console.BackgroundColor;
            ConsoleColor backAltered = ConsoleColor.DarkGray;

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possiblePosition[i, j])
                    {
                        Console.BackgroundColor = backAltered;
                    }
                    else
                    {
                        Console.BackgroundColor = backOriginal;
                    }
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = backOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
             Console.BackgroundColor = backOriginal;
        }

        public static PositionChess readPositionChess()
        {
            try
            {
                string s = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrEmpty(s) || s.Length < 2) throw new Exception("Invalid Position !");

                s = s.Replace(" ", "");
                char column;
                int line;

                if (char.IsDigit(s[0]) && char.IsLetter(s[1]))
                {
                    // format: 1c
                    line = int.Parse(s[0].ToString());
                    column = s[1];
                }
                else if (char.IsLetter(s[0]) && char.IsDigit(s[1]))
                {
                    // format: c1
                    column = s[0];
                    line = int.Parse(s[1].ToString());
                }
                else
                {
                    throw new Exception("Posição inválida!");
                }

                return new PositionChess(column, line);
            }
            catch
            {
                throw new Exception("Posição inválida!");
            }
        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece + " ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece + " ");
                    Console.ForegroundColor = aux;
                }
            }
        }
    }
}