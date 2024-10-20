/* -------------------------------------------------------------------------------------------------------
 * Engineered for unparalleled simplicity and efficiency, this cutting-edge tool empowers users to
 * seamlessly perform essential arithmetic operations. With an intuitive interface, users are guided to
 * input a number, select an operation—whether it’s addition, subtraction, multiplication, or division—and
 * then enter a second number. The calculator leverages advanced algorithms to deliver\precise results
 * instantaneously.
 * 
 * Elevate your computational capabilities with our state-of-the-art solution. Experience the next
 * generation of basic arithmetic with the Ultimate Console Calculator, where innovation meets precision.
 * -------------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------
 * Changelog
 * Fri 2023-12-22	File created														    Version 00.01
 * Tue 2024-09-24   Quick Fix CS8600 Null or possible null value to non-nullable type.      Version 00.02
 * ------------------------------------------------------------------------------------------------------- */
using System;

namespace Calculator;

/// <summary>
/// Engineered for unparalleled simplicity and efficiency, this cutting-edge tool empowers users to
/// seamlessly perform essential arithmetic operations.With an intuitive interface, users are guided
/// to input a number, select an operation—whether it’s addition, subtraction, multiplication, or
/// division—and then enter a second number.The calculator leverages advanced algorithms to
/// deliver\precise results instantaneously.
/// 
/// Elevate your computational capabilities with our state-of-the-art solution. Experience the next
/// generation of basic arithmetic with the Ultimate Console Calculator, where innovation meets precision.
/// </summary>
class Program
{
    /// <summary>
    /// This is the main entry point for the application. It initializes essential configurations and
    /// launches the main form, ensuring that the application starts smoothly and is ready for user
    /// interaction.
    /// </summary>
    /// <param name="args">
    /// Command-line arguments are like giving specific instructions to a program when you start it,
    /// so it knows exactly what to do.
    /// </param>
    static void Main(string[] args)
    {
        Console.Write("Enter the first number: ");				// Ask for the first user input
        double num1 = Convert.ToDouble(Console.ReadLine());		// Waiting for the user input

        Console.Write("Enter an operator (+, -, *, /): ");		// Asking for the operator
        #pragma warning disable CS8600                          // Converting null literal or possible null value to non-nullable type.
        string op = Console.ReadLine();							// Waiting for the user input
        #pragma warning restore CS8600                          // Converting null literal or possible null value to non-nullable type.

        Console.Write("Enter the second number: ");				// Asking for the second number from the user.
        double num2 = Convert.ToDouble(Console.ReadLine());     // Waiting for the user input

        // Switch case of the operator
        switch (op)
        {
            // Case of plus operator
            case "+":
                Console.WriteLine("The result is: " + (num1 + num2));
                break;

            // Case of minus operator
            case "-":
                Console.WriteLine("The result is: " + (num1 - num2));
                break;

            // Case of multiplication operator
            case "*":
                Console.WriteLine("The result is: " + (num1 * num2));
                break;

            // Case of divition operator
            case "/":
                if (num2 != 0)
                {
                    Console.WriteLine("The result is: " + (num1 / num2));
                }
                else
                {
                    // Careful divition by zero is not mathematically possible
                    Console.WriteLine("Error! Division by zero is not allowed.");
                }
                break;

            // If for some reason the user pressed another operator than the four
            // basic arithmetic funcions +, -, *, /
            default:
                Console.WriteLine("Invalid operator.");
                break;
        }
    }
}