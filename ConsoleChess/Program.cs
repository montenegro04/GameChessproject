using System;
using board;
using chess;

namespace ConsoleChess
{
   public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.putPiece(new Tower(Color.White, board), new Position(0, 0));
                board.putPiece(new Tower(Color.Black, board), new Position(1, 3));
                board.putPiece(new King(Color.Black, board), new Position(4, 5));

                Screen.PrintBoard(board);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}