/* -------------------------------------------------------------------------------------------------------------------
 * The LargeRotor class inherits all from its abstract parent Rotor. It representation of a rotor mechanism,
 * commonly used in encryption devices like the Enigma machine. It manages a rotor with a fixed alphabet
 * length, tracks the number of turns, and provides methods to manipulate and query the rotor’s state. The
 * class includes methods to rotate the rotor, reset it, and find the index of a character. The overwritten
 * setAlphabet method is specific for the SmallRotor.
 * -------------------------------------------------------------------------------------------------------------------
 * Author:	Patrik Eigenmann
 * eMail:	p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------------------
 * Change Log:
 * Sun 2024-09-01 File created.																            Version: 00.01
 * Sun 2024-09-01 Version control & getVersion implemented.									            Version: 00.02
 * Fri 2024-09-20 Version control changed into a static method.                                         Version: 00.03
 * Sat 2024-09-28 Extended the alphanumeric characters with Capitol letters, small letters and Numbers. Version: 00.04
 * Mon 2024-09-30 Same rotor array like in the Java version.                                            Version: 00.05
 * Sun 2024-10-20 LogManager implemented.                                                               Version: 00.06
 * -------------------------------------------------------------------------------------------------------------------*/
using System;
using Samael;

namespace Enigma
{
    /// <summary>
    /// The LargeRotor class inherits all from its abstract parent Rotor. It representation of a rotor mechanism,
    /// commonly used in encryption devices like the Enigma machine.It manages a rotor with a fixed alphabet
    /// length, tracks the number of turns, and provides methods to manipulate and query the rotor’s state. The
    /// class includes methods to rotate the rotor, reset it, and find the index of a character.The overwritten
    /// setAlphabet method is specific for the SmallRotor.
    /// </summary>
    internal class LargeRotor : Rotor, IVersionable
    {
        /// <summary>
        /// The GetVersion method is a vital feature for any class implementing the IVersionable interface.
        /// It provides a standardized way to retrieve version information, ensuring that every component
        /// can clearly communicate its version. This method is essential for maintaining consistency and
        /// reliability across the system, making it easier to manage updates and track changes. By
        /// implementing GetVersion, we ensure that our software remains robust, up-to-date, and easy to
        /// maintain, ultimately enhancing the overall user experience.
        /// </summary>
        /// <returns>
        /// A formatted string where the name of the component is the class or object name, 
        /// and the version number consists of a major and a minor number, each formatted to two digits.
        /// </returns>
        public static new string GetVersion()
        {
            /* Writing an info message into the log file. */
            LogManager.WriteMessage("Version string created.", LogManager.INFO, typeof(EnigmaForm), typeof(LargeRotor));
            return VersionManager.GetInstance("LargeRotor", 0, 6).ToString();
        }

        /// <summary>
        /// My dear Watson, this method is employed to initialize the rotor array with a particular sequence of
        /// characters.It begins with a space and continues with letters arranged in a unique and deliberate
        /// order.This custom alphabet is crucial for the proper functioning of the rotor within the Enigma machine.
        /// </summary>
        public override void SetAlphabet()
        {
            int i = 0;

            rotor[i++] = '0';
            rotor[i++] = '1';
            rotor[i++] = ' ';
            rotor[i++] = 'B';
            rotor[i++] = '2';
            rotor[i++] = 'b';
            rotor[i++] = 'd';
            rotor[i++] = 'f';
            rotor[i++] = 'h';
            rotor[i++] = '3';
            rotor[i++] = '4';
            rotor[i++] = 'A';
            rotor[i++] = 'C';
            rotor[i++] = 'E';
            rotor[i++] = 'G';
            rotor[i++] = '5';
            rotor[i++] = 'c';
            rotor[i++] = 'e';
            rotor[i++] = 'g';
            rotor[i++] = 'i';
            rotor[i++] = '6';
            rotor[i++] = 'U';
            rotor[i++] = 'W';
            rotor[i++] = 'Y';
            rotor[i++] = 'j';
            rotor[i++] = 'l';
            rotor[i++] = 'n';
            rotor[i++] = 'p';
            rotor[i++] = '7';
            rotor[i++] = '8';
            rotor[i++] = '9';
            rotor[i++] = 'D';
            rotor[i++] = 'F';
            rotor[i++] = 'H';
            rotor[i++] = 'J';
            rotor[i++] = 'L';
            rotor[i++] = 'N';
            rotor[i++] = 'P';
            rotor[i++] = 'R';
            rotor[i++] = 'T';
            rotor[i++] = 'V';
            rotor[i++] = 'X';
            rotor[i++] = 'Z';
            rotor[i++] = 'I';
            rotor[i++] = 'K';
            rotor[i++] = 'M';
            rotor[i++] = 'O';
            rotor[i++] = 'Q';
            rotor[i++] = 'S';
            rotor[i++] = 'r';
            rotor[i++] = 't';
            rotor[i++] = 'v';
            rotor[i++] = 'x';
            rotor[i++] = 'z';
            rotor[i++] = 'a';
            rotor[i++] = 'k';
            rotor[i++] = 'm';
            rotor[i++] = 'o';
            rotor[i++] = 'q';
            rotor[i++] = 's';
            rotor[i++] = 'u';
            rotor[i++] = 'w';
            rotor[i] = 'y';

            /* Writing an info message into the log file. */
            LogManager.WriteMessage("Large Rotor initialized.", LogManager.INFO, typeof(EnigmaForm), typeof(LargeRotor));
        }
    }
}
