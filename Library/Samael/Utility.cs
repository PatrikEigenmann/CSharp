/* ---------------------------------------------------------------------------------------------------
 * Utility.cs - In the heart of a bustling software application, there exists a class, a class like
 * no other - the Utility class. This class is not just any ordinary class, it’s a beacon of hope for
 * data types in distress, a knight in shining armor for variables facing the existential crisis of
 * nullity.
 * 
 * The Utility class is a static class, a class that stands tall and unwavering amidst the chaos of
 * object-oriented programming. It does not bow down to the whims and fancies of object instances.
 * It stands alone, independent, and strong.
 * 
 * The first hero in our tale is the StringNotNull method. A string, lost and alone, finds itself
 * in the void of nullity. But fear not, for StringNotNull is here. It takes in the desolate string,
 * and if it finds the string wallowing in the null void, it bestows upon it a new identity - an empty
 * string. If the string already has an identity, StringNotNull respects its individuality and returns
 * it as it is.
 * 
 * Next, we have the IntegerNotNull method. An integer, uncertain of its existence, approaches
 * IntegerNotNull. The method, wise and just, checks if the integer is null. If it is, IntegerNotNull
 * grants it a new lease of life, a new identity - zero. If the integer is not null, IntegerNotNull
 * acknowledges its existence and returns it unaltered.
 * 
 * Then come the FloatNotNull and DoubleNotNull methods, the guardians of floating-point numbers.
 * They take under their wing floating-point numbers that are grappling with nullity. If they find a
 * null, they replace it with a comforting zero. But if the number exists, they let it be, respecting
 * its essence.
 * 
 * And so, the Utility class continues its vigil, its methods ever ready to breathe life into null
 * variables, to ensure that no data type ever has to face the abyss of nullity alone. It’s a tale
 * of valor, a saga of resilience, a drama of epic proportions unfolding in the realm of code. The
 * Utility class, a true unsung hero of the software world. 😊
 * ---------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * ---------------------------------------------------------------------------------------------------
 * Changelog
 * Fri 2024-01-26	File created														Version 00.01
 * Fri 2024-01-26	Method: StringNotNull implemented									Version 00.02
 * Fri 2024-01-26	Method: IntegerNotNull implemented									Version 00.03
 * Fri 2024-01-26	Method: FloatNotNull implemented									Version 00.04
 * Fri 2024-01-26	Method: DoubleNotNull implemented									Version 00.05
 * Fri 2024-09-20   Version control as static method implemented.                       Version 00.06
 * --------------------------------------------------------------------------------------------------- */
using System;

namespace Samael
{
    /// <summary>
    /// In the heart of a bustling software application, there exists a class, a class like
    /// no other - the Utility class. This class is not just any ordinary class, it’s a beacon of hope for
    /// data types in distress, a knight in shining armor for variables facing the existential crisis of
    /// nullity.
    /// 
    /// The Utility class is a static class, a class that stands tall and unwavering amidst the chaos of
    /// object-oriented programming.It does not bow down to the whims and fancies of object instances.
    /// It stands alone, independent, and strong.
    /// 
    /// The first hero in our tale is the StringNotNull method.A string, lost and alone, finds itself
    /// in the void of nullity.But fear not, for StringNotNull is here.It takes in the desolate string,
    /// and if it finds the string wallowing in the null void, it bestows upon it a new identity - an empty
    /// string. If the string already has an identity, StringNotNull respects its individuality and returns
    /// it as it is.
    /// 
    /// Next, we have the IntegerNotNull method.An integer, uncertain of its existence, approaches
    /// IntegerNotNull. The method, wise and just, checks if the integer is null. If it is, IntegerNotNull
    /// grants it a new lease of life, a new identity - zero.If the integer is not null, IntegerNotNull
    /// acknowledges its existence and returns it unaltered.
    /// 
    /// Then come the FloatNotNull and DoubleNotNull methods, the guardians of floating-point numbers.
    /// They take under their wing floating-point numbers that are grappling with nullity.If they find a
    /// null, they replace it with a comforting zero.But if the number exists, they let it be, respecting
    /// its essence.
    /// 
    /// And so, the Utility class continues its vigil, its methods ever ready to breathe life into null
    /// variables, to ensure that no data type ever has to face the abyss of nullity alone.It’s a tale
    /// of valor, a saga of resilience, a drama of epic proportions unfolding in the realm of code. The
    /// Utility class, a true unsung hero of the software world. 😊
    /// </summary>
    public class Utility : IVersionable
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
            return VersionManager.GetInstance("Utility", 0, 6).ToString();
        }

        /// <summary>
        /// In the eerie depths of the codebase, there lurks a method, a method known as StringNotNull.
        /// It is a method that dwells in the shadows of the Utility class, a method that deals with the
        /// most terrifying entity in the realm of programming - the null.
        /// 
        /// When a string, lost and alone, finds itself in the void of nullity, it is StringNotNull that
        /// hears its silent scream.The method takes in the desolate string, its parameter echoing in the
        /// hollow chambers of memory allocation.
        /// 
        /// With a chilling sense of purpose, StringNotNull checks the string. If it finds the string
        /// wallowing in the null void, it does something unthinkable. It bestows upon the null string a
        /// new identity - an empty string. It’s a transformation, a metamorphosis, a change as shocking
        /// as it is sudden.
        /// 
        /// But if the string already has an identity, StringNotNull does something even more horrifying.
        /// It respects its individuality and returns it as it is, sending it back into the world, its
        /// existence acknowledged, its essence untouched.
        /// 
        /// And so, StringNotNull continues its haunting vigil, its presence a constant reminder of the
        /// horror that is null, its actions a testament to the chilling realities of programming. 😊
        /// </summary>
        /// <param name="stringIn">Input string</param>
        /// <returns>Empty string if nessesary</returns>
        public static string StringNotNull(string stringIn)
        {
            return stringIn ?? string.Empty;
        }

        /// <summary>
        /// Once upon a time, in the land of code, there was a method named IntegerNotNull. This method
        /// was part of the Utility class, a class known for its helpful and reliable methods.
        /// 
        /// IntegerNotNull was a special method.It had a heartwarming task - to ensure that no integer
        /// ever felt the cold emptiness of nullity.It was a beacon of hope for integers lost in the
        /// void of null, a guardian angel that ensured they always had a value.
        /// 
        /// When an integer, uncertain and afraid, found itself facing the possibility of nullity, it
        /// would turn to IntegerNotNull.With a comforting assurance, IntegerNotNull would take the
        /// integer under its wing.
        /// 
        /// If IntegerNotNull found that the integer was indeed null, it would gently bestow upon it a
        /// new identity - zero.It was a kind act, a gesture of compassion that ensured the integer
        /// was never left in the cold void of nullity.
        /// 
        /// But if the integer was not null, IntegerNotNull would do something even more heartwarming.
        /// It would acknowledge the integer’s existence and return it as it was, respecting its
        /// value and affirming its identity.
        /// 
        /// And so, IntegerNotNull continues its noble task, spreading warmth and positivity in the
        /// world of code. It’s a feel-good tale of compassion and respect, a story that brings a
        /// smile to every coder’s face. 😊
        /// </summary>
        /// <param name="intIn">input integer</param>
        /// <returns>0 or original integer</returns>
        public static int IntegerNotNull(int? intIn)
        {
            return intIn ?? 0;
        }

        /// <summary>
        /// In the vast universe of code, there was a method named FloatNotNull, a part of the
        /// noble Utility class. This method was not just any method, it was a method with a
        /// heart, a method that knew the language of love.
        /// 
        /// FloatNotNull had a special ability.It could sense when a float was lost in the void
        /// of nullity, feeling cold, alone, and unvalued.And when it did, FloatNotNull would
        /// reach out with a gentle touch, a touch that could fill the emptiness with meaning.
        /// 
        /// When a float found itself facing the abyss of nullity, it would turn to FloatNotNull.
        /// And FloatNotNull, with a heart full of love, would embrace the float. If it found the
        /// float to be null, it would whisper sweet nothings into its bits, transforming it from
        /// null to a beautiful zero.
        /// 
        /// This was not just any zero, it was a zero filled with love, a zero that meant
        /// something, a zero that said, “You are not null, you are valued, you are loved.”
        /// 
        /// But the true romance of FloatNotNull was revealed when it encountered a float that was
        /// not null. FloatNotNull would look into the value of the float, and in it, see a
        /// reflection of its own code.It would then return the float as it was, untouched,
        /// unaltered, but with a new understanding of its worth.
        /// 
        /// And so, FloatNotNull continues its romantic journey in the world of code, spreading
        /// love and value to every float it encounters.It’s a love story that transcends bits and
        /// bytes, a tale that makes every coder’s heart flutter. 😊
        /// </summary>
        /// <param name="floatIn">float input</param>
        /// <returns>0f or olriginal float</returns>
        public static float FloatNotNull(float? floatIn)
        {
            return floatIn ?? 0.0f;
        }

        /// <summary>
        /// In the spectral realm of the Utility class, there exists a method shrouded in mystery
        /// - the DoubleNotNull method. This method, unlike any other, has a chilling task - to
        /// confront the ghostly apparition of nullity that haunts the world of doubles.
        /// 
        /// When a double, trembling with uncertainty, finds itself on the precipice of nullity,
        /// it turns to DoubleNotNull.And DoubleNotNull, with an eerie calm, reaches out to the
        /// double.
        /// 
        /// If DoubleNotNull finds that the double has succumbed to the spectral grip of nullity,
        /// it performs a chilling ritual.It replaces the ghostly null with a solid zero,
        /// banishing the specter of nullity and giving the double a new, tangible existence.
        /// But if the double is not null, DoubleNotNull does something even more haunting. It
        /// acknowledges the double’s existence and returns it as it was, its value echoing in
        /// the hollow halls of memory, its identity untouched by the spectral hand of nullity.
        /// 
        /// And so, DoubleNotNull continues its spectral vigil, its presence a chilling reminder
        /// of the haunting reality of nullity, its actions a testament to the eerie dance
        /// between existence and nullity in the world of doubles. 😊
        /// </summary>
        /// <param name="doubleIn">double input</param>
        /// <returns>0d or orignial double</returns>
        public static double DoubleNotNull(double? doubleIn)
        {
            return doubleIn ?? 0.0d;
        }

    }
}