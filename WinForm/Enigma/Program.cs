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
 * Sun 2024-10-20 LogManager implemented.                                                   Version: 00.02
 * ------------------------------------------------------------------------------------------------------- */
using Samael;

namespace Enigma
{
    /// <summary>
    /// The Program class serves as the heart of our application, orchestrating the initial setup and launch
    /// of the user interface. At its core is the Main method, the pivotal entry point that ensures our
    /// application starts smoothly and efficiently. By initializing essential configurations and launching
    /// the main form, this method guarantees that users experience the full power and simplicity of our
    /// software right from the start. This streamlined process not only highlights the robustness of our
    /// application but also underscores our commitment to delivering an intuitive and user-friendly
    /// experience. The Program class exemplifies our dedication to excellence, ensuring that every user
    /// interaction begins on a solid foundation.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// This is the main entry point for the application. It initializes essential configurations and
        /// launches the main form, ensuring that the application starts smoothly and is ready for user
        /// interaction.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set the LogManager with the flags to record.
            LogManager.Flag = LogManager.WARNING | LogManager.ERROR | LogManager.INFO;
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new EnigmaForm());
        }
    }
}