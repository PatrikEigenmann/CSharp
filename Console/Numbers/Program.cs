/* --------------------------------------------------------------------------
 * Prgram.cs - In this game, the program first generates a random number
 * between 1 and 100. Then it enters a loop where it asks the user to enter
 * their guess. If the user’s guess is too high or too low, it tells them so
 * and asks for another guess. If the user’s guess is correct, it congratulates
 * the user and ends the game. The game also counts the number of tries it took
 * for the user to guess the number correctly. If the user enters something
 * that’s not a number, the program will ask for a valid number.
 * --------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * --------------------------------------------------------------------------
 * Changelog
 * Sat 2023-12-23 File created					                Version 00.01
 * --------------------------------------------------------------------------
 * To Do:
 * - Create a template in Visual Studio 2022 for class files.
 * -------------------------------------------------------------------------- */

// Declare all the usings
using System;

// 
namespace Numbers;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int numberToGuess = random.Next(1, 101);
        int numberOfTries = 0;
        bool isCorrect = false;

        Console.WriteLine("Welcome to the Numbers Game! Guess a number between 1 and 100.");

        while (!isCorrect)
        {
            Console.Write("Enter your guess: ");
            string userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out int userGuess))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            numberOfTries++;

            if (userGuess > numberToGuess)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else if (userGuess < numberToGuess)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else
            {
                Console.WriteLine($"Congratulations! You've guessed the number correctly after {numberOfTries} attempts.");
                isCorrect = true;
            }
        }
    }
}