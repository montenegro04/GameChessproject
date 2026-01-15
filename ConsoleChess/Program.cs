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
                
                    try{
            
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.WriteLine();
                        Console.WriteLine("Enter the origin/destination starting with the letter(ex.:c2):");

                        Console.Write("Origin: ");
                        Position origin = Screen.readPositionChess().toPosition();
                        match.validadePositionOrigin(origin);

                        bool[,] possiblePosition = match.board.piece(origin).possibleMove();

                        Console.Clear();
                        Screen.printBoard(match.board, possiblePosition);

                        Console.WriteLine();
                    
                        Console.Write("Destination: ");
                        Position destination = Screen.readPositionChess().toPosition();
                        match.validadePositionDestination(origin, destination);

                        match.makeMove(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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