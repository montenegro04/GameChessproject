using System;
using board;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            boardPosition P;
            P = new boardPosition(3, 4);
            Console.WriteLine("Position: " + P);

            Console.ReadLine();

        }
    }
}