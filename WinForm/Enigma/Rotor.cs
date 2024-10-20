/* -------------------------------------------------------------------------------------------------------
 * The Rotor class is an abstract representation of a rotor mechanism, commonly used in encryption devices
 * like the Enigma machine. It manages a rotor with a fixed alphabet length, tracks the number of turns,
 * and provides methods to manipulate and query the rotor’s state. The class includes methods to rotate
 * the rotor, reset it, and find the index of a character. The setAlphabet method is abstract, requiring
 * subclasses to define the specific alphabet used.
 * -------------------------------------------------------------------------------------------------------
 * Author:	Patrik Eigenmann
 * eMail:	p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------
 * Change Log:
 * Sun 2024-09-01 File created.																            Version: 00.01
 * Sun 2024-09-01 Version control & getVersion implemented.									            Version: 00.02
 * Fri 2024-09-20 Version control changed to a static method.                                           Version: 00.03
 * Sat 2024-09-28 Extended the alphanumeric characters with Capitol letters, small letters and Numbers. Version: 00.04
 * -------------------------------------------------------------------------------------------------------*/
using System;
using Samael;

namespace Enigma
{
    /// <summary>
    /// The Rotor class is an abstract representation of a rotor mechanism, commonly used in encryption devices
    /// like the Enigma machine.It manages a rotor with a fixed alphabet length, tracks the number of turns,
    /// and provides methods to manipulate and query the rotor’s state.The class includes methods to rotate
    /// the rotor, reset it, and find the index of a character.The setAlphabet method is abstract, requiring
    /// subclasses to define the specific alphabet used.
    /// </summary>
    internal abstract class Rotor : IVersionable
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
        public static string GetVersion()
        {
            return VersionManager.GetInstance("Rotor", 0, 4).ToString();
        }

        /// <summary>
        /// The western alphabet consists of 27 letters.
        /// </summary>
        public const int AlphabetLength = 63;



        /// <summary>
        /// Initialize the rotor and reserve space for each letter in the alphabet.
        /// </summary>
        protected char[] rotor = new char[AlphabetLength];

        /// <summary>
        /// Initialize how many turns were made.
        /// </summary>
        protected int turns = 0;

        /// <summary>
        /// The constructor of the Rotor class initializes the rotor’s state when an instance of the class is
        /// created.It sets the initial number of turns to zero and initializes the rotor’s alphabet by calling
        /// the setAlphabet method.This ensures that the rotor starts in a known state with a defined alphabet.
        /// </summary>
        public Rotor()
        {
            turns = 0;
            SetAlphabet();
        }

        /// <summary>
        /// The indexOf method is like a detective for your rotor’s alphabet.It hunts down the given character
        /// and returns its position.If the character is missing in action, it returns -1, signaling that the
        /// search came up empty.
        /// </summary>
        /// <param name="c">The character to search for in the rotor’s alphabet.</param>
        /// <returns>The index of the character c in the rotor’s alphabet, or -1 if the character is not found.</returns>
        public int IndexOf(char c)
        {
            for (int i = 0; i < AlphabetLength; i++)
            {
                if (rotor[i] == c)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// In the shadowy depths of the Rotor class, the turns method lurks, waiting to reveal the number of
        /// times the rotor has twisted and turned.Each call to this method brings forth the eerie count of
        /// rotations, a silent witness to the rotor’s relentless journey.
        /// </summary>
        /// <returns>The haunting number of turns the rotor has endured.</returns>
        public int Turns()
        {
            return turns;
        }

        /// <summary>
        /// In the delicate dance of the turn method, the rotor’s first character, c, is gently moved aside,
        /// making way for the others to follow.One by one, they shift, each taking the place of the one
        /// before, until c finds its new home at the end.With each turn, the rotor’s journey continues, and
        /// the count of turns, like the beats of a heart, increases by one, marking the passage of time in
        /// this mechanical romance.
        /// </summary>        
        public void Turn()
        {

            char c = rotor[0];
            for (int i = 1; i < AlphabetLength; i++)
            {
                rotor[i - 1] = rotor[i];
            }

            rotor[AlphabetLength - 1] = c;

            turns++;
        }

        /// <summary>
        /// Ah, the charAt method, a true connoisseur’s delight.This method, with all the grace of a well-aged
        /// scotch, retrieves the character at the specified index i from our esteemed rotor array.One might
        /// say it’s akin to selecting the finest cigar from a humidor—precise, deliberate, and oh-so-satisfying.
        /// </summary>
        /// <param name="i">The index at which to retrieve the character, much like choosing the perfect seat at the club.</param>
        /// <returns>The character residing at the distinguished position i in the rotor array.</returns>
        public char CharAt(int i)
        {
            return rotor[i];
        }

        /// <summary>
        /// Aye, the Reset method, it’s a proper grafter’s tool, innit? This method rolls up its sleeves and gets
        /// to work, setting the turns back to zero, like clocking out after a hard day’s graft.Then, it calls
        /// setAlphabet to get everything shipshape and Bristol fashion, ready for another round. No fuss, no
        /// muss, just good honest work.
        /// </summary>
        public void Reset()
        {
            turns = 0;
            SetAlphabet();
        }

        /// <summary>
        /// Ah, the setAlphabet method, a paragon of scholarly abstraction.This method, in its most erudite form,
        /// remains unimplemented, awaiting the intellectual prowess of a subclass to bestow upon it a concrete
        /// definition.It is the very essence of polymorphism, a testament to the flexibility and extensibility
        /// of our rotor mechanism.One might say it is the blank canvas upon which the subclasses shall paint their
        /// unique alphabets, thus contributing to the grand tapestry of our encryption endeavor.
        /// </summary>
        public abstract void SetAlphabet();
    }
}
