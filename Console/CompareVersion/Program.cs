/* ---------------------------------------------------------------------------------------------------
 * Program.cs - This class is the entry point for console application. It contains the Main method with
 * its parameters, which is the first method that gets invoked when the application starts.
 * ---------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * ---------------------------------------------------------------------------------------------------
 * Changelog
 * Sat 2023-12-23	File created													Version 1.0.0.0.1
 * Sat 2023-12-23	Added various tests												Version 1.0.0.0.2
 * --------------------------------------------------------------------------------------------------- */

// Define the namespace
namespace CompareVersion
{
    /* ----------------------------------------------------------------------------------------------------
     * Class Program - The entry point for this console application. The class contains the Main method with
     * its parameters, which will be invoked on application start.
     * ---------------------------------------------------------------------------------------------------- */
    class Program
    {
        /* ------------------------------------------------------------------------------------------------
         * Main method with the string array of arguments
         * ------------------------------------------------------------------------------------------------ */
        public static void Main(string[] args)
        {
            int i = CompareVersion.VersionCompare("2.0.0", "2.0.0.1");  // integer i will contain the result of the compare
            Console.WriteLine($"Result :{i}");                          // Write the result i on the screen.

            i = CompareVersion.VersionCompare("2.0.0.5", "2.0.0.1");    // integer i will contain the result of the compare
            Console.WriteLine($"Result :{i}");                          // Write the result i on the screen.

            i = CompareVersion.VersionCompare("2", "2.0.0");            // integer i will contain the result of the compare
            Console.WriteLine($"Result :{i}");                          // Write the result i on the screen.
        }
    }
}