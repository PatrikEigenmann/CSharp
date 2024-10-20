/* ---------------------------------------------------------------------------------------------------
 * Program.cs - Console Testing of the TicTacToe class and functionality.
 * ---------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * ---------------------------------------------------------------------------------------------------
 * Changelog
 * Tue 2024-02-27	File created														 Version 00.01
 * --------------------------------------------------------------------------------------------------- */

// Declare all usings
using System;
using System.Linq;


namespace TicTacToeTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            TicTacToe t = new TicTacToe();

            t.MakeMove(4, "X");
            Console.WriteLine(t.IsGameOver());

            t.MakeMove(0, "O");
            Console.WriteLine(t.IsGameOver());

            t.MakeMove(2, "X");
            Console.WriteLine(t.IsGameOver());

            t.MakeMove(6, "O");
            Console.WriteLine(t.IsGameOver());

            t.MakeMove(5, "X");
            Console.WriteLine(t.IsGameOver());

            t.MakeMove(3, "X");

            Console.WriteLine(t.IsGameOver());
            Console.WriteLine(t.Winner);
            Console.WriteLine(t.GameOverMessage);

            Console.WriteLine(t.ToString());

            Console.WriteLine(t.Version);
        }
    }
}