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
               MatchChess match = new MatchChess();
               
               while (!match.finished){
            
                    Console.Clear();
                    Screen.PrintBoard(match.board);

                    Console.WriteLine();
                    Console.WriteLine("Enter the origin/destination starting with the letter(ex.:c2):");

                    Console.Write("Origin: ");
                    Position origin = Screen.readPositionChess().toPosition();

                    bool[,] possiblePosition = match.board.piece(origin).possibleMove();

                    Console.Clear();
                    Screen.PrintBoard(match.board, possiblePosition);

                    Console.WriteLine();
                   
                    Console.Write("Destination: ");
                    Position destination = Screen.readPositionChess().toPosition();

                    match.executeMove(origin, destination);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}