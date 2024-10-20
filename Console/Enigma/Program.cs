/* -------------------------------------------------------------------------------------------------------
 * The Enigma machine is a cipher device developed and used in the early- to mid-20th century to protect
 * commercial, diplomatic, and military communication. It was employed extensively by Nazi Germany during
 * World War II, in all branches of the German military. The Enigma machine was considered so secure that
 * it was used to encipher the most top-secret messages.
 * 
 * Around December 1932 Marian Rejewski, a Polish mathematician and cryptologist at the Polish Cipher Bureau,
 * used the theory of permutations,[8] and flaws in the German military-message encipherment procedures, to
 * break message keys of the plugboard Enigma machine.
 *
 * On 26 and 27 July 1939, in Pyry, just south of Warsaw, the Poles initiated French and British military
 * intelligence representatives into the Polish Enigma-decryption techniques and equipment, including
 * Zygalski sheets and the cryptologic bomb, and promised each delegation a Polish-reconstructed Enigma
 * (the devices were soon delivered).
 *
 * In September 1939, British Military Mission 4, which included Colin Gubbins and Vera Atkins, went to
 * Poland, intending to evacuate cipher-breakers Marian Rejewski, Jerzy Różycki, and  Zygalski from
 * the country. The cryptologists, however, had been evacuated by their own superiors into Romania, at the
 * time a Polish-allied country. On the way, for security reasons, the Polish Cipher Bureau personnel had
 * deliberately destroyed their records and equipment. From Romania they traveled on to France, where they
 * resumed their cryptological work, collaborating by teletype with the British, who began work on
 * decrypting German Enigma messages, using the Polish equipment and techniques.
 * -------------------------------------------------------------------------------------------------------
 * Author   : Patrik Eigenmann
 * eMail    : p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------
 * Change Log:
 * Thu 2024-09-19 File created & basic functionality implemented.                           Version: 00.01
 * Tue 2024-09-24 Complete overhaul with small-, med-, and large rotor implemented.         Version: 00.02
 * -------------------------------------------------------------------------------------------------------*/
using Enigma;
using System;

/// <summary>
/// The Program.cs class in the Enigma C# console application serves as the entry point for the program. It
/// initializes the Enigma machine, processes user input, and outputs the encrypted text. This class handles
/// the setup of the machine’s components, such as rotors, and manages the main execution flow to perform
/// the cipher operations.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        /*
         * Let's create all the variables and object we need to get the job done.
         */
        string input = "";
        string output = "";

        SmallRotor smallRotor = new SmallRotor();
        MedRotor medRotor = new MedRotor();
        LargeRotor largeRotor = new LargeRotor();

        /*
         * Now, a user input would be nice. Some sort of text that needs to be cyphered.
         */
        Console.Write("Enter a message to encrypt: ");
        input = Console.ReadLine();


        foreach (char c in input.ToUpper())
        {
            char ch = (char)0;
            try
            {
                ch = largeRotor.CharAt((int)smallRotor.IndexOf(c));
                ch = largeRotor.CharAt((int)medRotor.IndexOf(ch));
            }
            catch (Exception e)
            {
                /*
                 * If the string contains '\0' it means that's the end of the string,
                 * and because the character initialization is with a '\0' a space
                 * will not be processed and the return value of ch was = '\0' 
                 * Old Code: if (c != '\n')
                 */
                ch = c;
            }

            smallRotor.Turn();

            // If the small rotor turned 27 times,
            // turn the medium rotor.
            if (smallRotor.Turns() % 27 == 0)
                medRotor.Turn();

            // if the medium rotor turned 27 times,
            // turn the large rotor.
            if (medRotor.Turns() % 27 == 0)
                largeRotor.Turn();

            output += ch;
        }

        Console.WriteLine("Encrypted message: " + output);
    }
}