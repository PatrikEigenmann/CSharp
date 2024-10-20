/* -------------------------------------------------------------------------------------------------------
 * The MedRotor class inherits all from its abstract parent Rotor. It representation of a rotor mechanism,
 * commonly used in encryption devices like the Enigma machine. It manages a rotor with a fixed alphabet
 * length, tracks the number of turns, and provides methods to manipulate and query the rotor’s state. The
 * class includes methods to rotate the rotor, reset it, and find the index of a character. The overwritten
 * setAlphabet method is specific for the SmallRotor.
 * -------------------------------------------------------------------------------------------------------
 * Author:	Patrik Eigenmann
 * eMail:	p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------
 * Change Log:
 * Sun 2024-09-01 File created.																Version: 00.01
  * -------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    /// <summary>
    /// The MedRotor class inherits all from its abstract parent Rotor. It representation of a rotor mechanism,
    /// commonly used in encryption devices like the Enigma machine.It manages a rotor with a fixed alphabet
    /// length, tracks the number of turns, and provides methods to manipulate and query the rotor’s state. The
    /// class includes methods to rotate the rotor, reset it, and find the index of a character.The overwritten
    /// setAlphabet method is specific for the SmallRotor.
    /// </summary>
    internal class MedRotor : Rotor
    {
        /// <summary>
        /// My dear Watson, this method is employed to initialize the rotor array with a particular sequence of
        /// characters.It begins with a space and continues with letters arranged in a unique and deliberate
        /// order.This custom alphabet is crucial for the proper functioning of the rotor within the Enigma machine.
        /// </summary>
        public override void SetAlphabet()
        {
            int i = 0;

            rotor[i++] = ' ';
            rotor[i++] = 'E';
            rotor[i++] = 'J';
            rotor[i++] = 'O';
            rotor[i++] = 'T';
            rotor[i++] = 'Y';
            rotor[i++] = 'C';
            rotor[i++] = 'H';
            rotor[i++] = 'M';
            rotor[i++] = 'R';
            rotor[i++] = 'W';
            rotor[i++] = 'A';
            rotor[i++] = 'F';
            rotor[i++] = 'K';
            rotor[i++] = 'P';
            rotor[i++] = 'U';
            rotor[i++] = 'Z';
            rotor[i++] = 'D';
            rotor[i++] = 'I';
            rotor[i++] = 'N';
            rotor[i++] = 'S';
            rotor[i++] = 'X';
            rotor[i++] = 'B';
            rotor[i++] = 'G';
            rotor[i++] = 'L';
            rotor[i++] = 'Q';
            rotor[i] = 'V';
        }
    }
}