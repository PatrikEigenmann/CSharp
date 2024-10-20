/* ---------------------------------------------------------------------------------------------------
 * TicTacToe.cs - TicTacToe class represents the board game Tic Tac Toe on an abstract conseptual level.
 * ---------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * ---------------------------------------------------------------------------------------------------
 * Changelog
 * Tue 2024-02-27	File created														 Version 00.01
 * Thu 2024-03-28   Winner setter & getter implemented.                                  Version 00.02
 * Thu 2024-03-28   GameOverMessage setter & getter implemented.                         Version 00.03
 * Thu 2024-03-28   Moves setter & getter implemented.                                   Version 00.04
 * Thu 2024-03-28   Increment Moves by one after every move.                             Version 00.05
 * Thu 2024-03-28   Methode IsGameOver checks the status of the game.                    Version 00.06
 * Thu 2024-03-28   Version setter & getter implemented.                                 Version 00.07
 * --------------------------------------------------------------------------------------------------- */

// Declare all the libraries used in this programm.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Defining the namespace.
namespace TicTacToeTest
{

    /// <summary>
    /// TicTacToe class represents the board game Tic Tac Toe on an abstract level.
    /// </summary>
    class TicTacToe
    {
        /// <summary>
        /// How many fields does the board have.
        /// </summary>
        private const int FIELD_COUNT = 9;

        /// <summary>
        /// The board is an abstraction of a real playing board with 9 fields. Every field is indexed. That means, the field a1 is the index 0.
        /// And the index 4 is the field b2, and so on. I choose this abstraction to simplify the calculation methods in this class to operate
        /// properly on the board.
        /// 
        ///    a   b   c
        /// 1  0 | 1 | 2
        ///   ---+---+---
        /// 2  3 | 4 | 5
        ///   ---+---+---
        /// 3  6 | 7 | 8
        /// 
        /// </summary>
        public string[] Board { get; set; }

        /// <summary>
        /// Make the winner known.
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GameOverMessage { get; set; }

        /// <summary>
        /// How many moves were made since the start of the game.
        /// </summary>
        public int Moves { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Version Version { get; set; }

        /// <summary>
        /// This is the construction of the class. In here all the private members of the class will be initialized.
        /// </summary>
        public TicTacToe()
        {
            // Initializing all the variables.
            Board = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " "};
            Winner = " ";
            Moves = 0;
            GameOverMessage = "";

            Version = new Version(0,5);
        }

        /// <summary>
        /// The method IsMoveValid verifies the move of it's valitiy. If the field is not empty or the index is out of range,
        /// the method will return false.
        /// </summary>
        /// <param name="imdexIn">The index which should be checked.</param>
        /// <returns>Valitity of the move.</returns>
        public bool IsMoveValid( int indexIn)
        {
            // This is the checker as return value. If the internal condition is not correct,
            // checker stays on false.
            bool check = false;

            // First, let's check the range of the index.
            if (indexIn >= 0 && indexIn < FIELD_COUNT)
            {
                // If the field is empty " ", then it will
                // overwrite check with true. Else it will
                // overwrite check with false.
                check = Board[indexIn].Equals(" ");
            }

            // Returning the result of the check.
            return check;
        }

        /// <summary>
        /// If it is a valid move, the method MakeMove will make the actual move.
        /// </summary>
        /// <param name="indexIn">What index is used (0 .. 8)</param>
        /// <param name="playerIn">Who is making the move.</param>
        /// <returns>Returns if the move was a success or not!</returns>
        public bool MakeMove(int indexIn, string playerIn)
        {
            // This is the checker as return value. If the internal
            // condition is not correct, checker stays on false.
            bool check = false;

            // Verify if the move is valid.
            if(check = IsMoveValid(indexIn))
            {
                // Overwrite field @indexIn with
                // playerIn.
                Board[indexIn] = playerIn;
                Moves++;
            }

            // Return the checker.
            return check;
        }

        /// <summary>
        /// Mapping system from a column/row to a field index. As example, a1 would be index 0.
        /// 
        ///    a   b   c
        /// 1  0 | 1 | 2
        ///   ---+---+---
        /// 2  3 | 4 | 5
        ///   ---+---+---
        /// 3  6 | 7 | 8
        /// 
        /// </summary>
        /// <param name="columnIn">character 'a'/'b'/'c'</param>
        /// <param name="rowIn">character '1'/'2'/'3'</param>
        /// <returns>Index of the field as integer. As example col = 'a' and row = '2' index would be 3.</returns>
        public int MapColumnRowToIndex(char columnIn, char rowIn)
        {
            int colInt = columnIn - 'a';    // Convert column character to 0-based index (a -> 0, b -> 1, c -> 2) 
            int rowInt = rowIn - '1';       // Convert row character to 0-based index (1 -> 0, 2 -> 1, 3 -> 2)

            // Calculate the overall index
            return rowInt * 3 + colInt; 
        }

        /// <summary>
        /// Mapping an index into column/row signifier. Example: index 0 returns a1, or index 4 returns b2, etc.
        /// 
        ///    a   b   c
        /// 1  0 | 1 | 2
        ///   ---+---+---
        /// 2  3 | 4 | 5
        ///   ---+---+---
        /// 3  6 | 7 | 8
        /// 
        /// </summary>
        /// <param name="indexIn">The index of the field.</param>
        /// <returns>A string with the information of column and row.</returns>
        public string MapIndexToColumnRow(int indexIn)
        {
            
            string str = "";

            if(indexIn >= 0 && indexIn < FIELD_COUNT)
            {
                // Conversion of index into column row. So an index of 4 will be converted into b2.
                str = "" + (char)((indexIn % 3) + 'a') + (char)((indexIn / 3) + '1');
            }

            return str;
        }

        /// <summary>
        /// The method IsGameOver checks first if there is a winner,
        /// if not the method simply checks if there are any moves left.
        /// </summary>
        /// <returns>Is Game over or not!</returns>
        public bool IsGameOver()
        {
            bool check = false;

            if(Moves == FIELD_COUNT || CheckWin())
            {
                if (Moves == FIELD_COUNT)
                {
                    GameOverMessage = "Sorry, there are no more moves left. Stalemate. Good game though.";
                }

                if (CheckWin())
                {
                    GameOverMessage = "And the winner is: " + Winner + ". Thank you for the good game.";
                }
                check = true;
            }

            return check;
        }

        /// <summary>
        /// 
        ///    a   b   c
        /// 1  0 | 1 | 2
        ///   ---+---+---
        /// 2  3 | 4 | 5
        ///   ---+---+---
        /// 3  6 | 7 | 8
        /// 
        /// The method CheckWin() checks if there is a winner. In the board matrix, there are 8 possible wins to check.
        /// That is all tree columns, all three rows and the two diagnoals.
        /// </summary>
        /// <returns>Is there a winner or not!</returns>
        public bool CheckWin()
        {
            bool check = false;

            // Check all rows
            if ((!Board[0].Equals(" ") && Board[0].Equals(Board[1]) && Board[1].Equals(Board[2])))
            {
                check |= (!Board[0].Equals(" ") && Board[0].Equals(Board[1]) && Board[1].Equals(Board[2]));
                Winner = Board[0];
            }

            if (!Board[3].Equals(" ") && Board[3].Equals(Board[4]) && Board[4].Equals(Board[5]))
            {
                check |= (!Board[3].Equals(" ") && Board[3].Equals(Board[4]) && Board[4].Equals(Board[5]));
                Winner = Board[3];
            }
            
            if (!Board[6].Equals(" ") && Board[6].Equals(Board[7]) && Board[7].Equals(Board[8]))
            {
                check |= (!Board[6].Equals(" ") && Board[6].Equals(Board[7]) && Board[7].Equals(Board[8]));
                Winner = Board[6];
            }

            // Check all colums
            if (!Board[0].Equals(" ") && Board[0].Equals(Board[3]) && Board[3].Equals(Board[6]))
            {
                check |= (!Board[0].Equals(" ") && Board[0].Equals(Board[3]) && Board[3].Equals(Board[6]));
                Winner = Board[0];
            }

            if (!Board[1].Equals(" ") && Board[1].Equals(Board[4]) && Board[4].Equals(Board[7]))
            {
                check |= (!Board[1].Equals(" ") && Board[1].Equals(Board[4]) && Board[4].Equals(Board[7]));
                Winner = Board[1];
            }

            if (!Board[2].Equals(" ") && Board[2].Equals(Board[5]) && Board[5].Equals(Board[8]))
            {
                check |= (!Board[2].Equals(" ") && Board[2].Equals(Board[5]) && Board[5].Equals(Board[8]));
                Winner = Board[2];
            }

            // Check diagonals
            if (!Board[0].Equals(" ") && Board[0].Equals(Board[4]) && Board[4].Equals(Board[8]))
            {
                check |= (!Board[0].Equals(" ") && Board[0].Equals(Board[4]) && Board[4].Equals(Board[8]));
                Winner = Board[0];
            }

            if (!Board[2].Equals(" ") && Board[2].Equals(Board[4]) && Board[4].Equals(Board[6]))
            {
                check |= (!Board[2].Equals(" ") && Board[2].Equals(Board[4]) && Board[4].Equals(Board[6]));
                Winner = Board[2];
            }

            return check;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            string str = "   a   b   c\n" + (FIELD_COUNT - 8) + " ";
            
            for(int i = 0; i < FIELD_COUNT; ++i)
            {
                str += " " + Board[i] + " ";
                if((i % 3) == 2 && i < FIELD_COUNT - 1) str += "\n  ---+---+---\n" + (i / 3 + 1) + " ";
                else if (i % 3 != 2) str += "|";
            }
            str += "\n";
            return str;
        }
    }
}