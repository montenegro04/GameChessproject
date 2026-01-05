using System;
using board;

namespace ConsoleChess
{
   public class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Screen.PrintBoard(board);

            Console.ReadLine();

        }
    }
}