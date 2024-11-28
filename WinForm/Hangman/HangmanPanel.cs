/* -------------------------------------------------------------------------------------------------------------------
 * The HangmanPanel class delivers an engaging visual dimension to the classic Hangman word game. This custom Java Swing
 * component expertly draws the gallows and the hanged man, updating dynamically with each incorrect guess. It enhances
 * the player experience by providing clear, real-time feedback on the game's progress. The panel starts with an empty
 * gallows and progressively adds parts of the hanged man, from the head to the legs, offering a tangible sense of the
 * stakes involved. Designed for clarity and impact, HangmanPanel makes the game visually intuitive and compelling,
 * turning each round of Hangman into an immersive experience that blends education with entertainment. This component
 * is essential for bringing the game's visual storytelling to life.
 * -------------------------------------------------------------------------------------------------------------------
 * Author:  Patrik Eigenmann
 * email:   p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------------------
 * Change Log:
 * Mon 2024-11-25 File created.                                                                         Version: 00.01
 * Tue 2024-11-26 Description and comments implemented.                                                 Version: 00.02
 * Wed 2024-11-27 Framework Samael implemented.                                                         Version: 00.03
 * -------------------------------------------------------------------------------------------------------------------
 * To Do:
 * Implement the basic classes and functionality from the Samael framework.
 * ------------------------------------------------------------------------------------------------------------------- */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

using Samael;

/// <summary>
/// The HangmanPanel class delivers an engaging visual dimension to the classic Hangman word
/// game. This custom Windows.Forms.Panel component expertly draws the gallows and the hanged
/// man, updating dynamically with each incorrect guess. It enhances the player experience by
/// providing clear, real-time feedback on the game's progress. The panel starts with an empty
/// gallows and progressively adds parts of the hanged man, from the head to the legs, offering
/// a tangible sense of the stakes involved. Designed for clarity and impact, HangmanPanel makes
/// the game visually intuitive and compelling, turning each round of Hangman into an immersive
/// experience that blends education with entertainment. This component is essential for
/// bringing the game's visual storytelling to life.
/// </summary>
public class HangmanPanel : Panel, IVersionable
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
        /* Writing an info message into the log file. */
        LogManager.WriteMessage("Version string created.", LogManager.INFO, typeof(HangmanPanel), typeof(HangmanPanel));
        return VersionManager.GetInstance("EnigmaForm", 0, 15).ToString();
    }

    /// <summary>
    /// The incorrectGuesses variable tracks the number of incorrect guesses made by the player
    /// in the Hangman game.It is used to update the visual representation of the hanged man on
    /// the HangmanPanel, progressively adding parts with each wrong guess.
    /// </summary>
    private int incorrectGuesses = 0;

    /// <summary>
    /// The incrementIncorrectGuesses() method is responsible for increasing the count of
    /// incorrect guesses by one and triggering a repaint of the HangmanPanel to visually update
    /// the state of the hanged man.Each call to this method advances the drawing, adding the
    /// next part of the hanged man to the gallows. It ensures that the visual representation
    /// remains accurate and responsive to the player's incorrect guesses, enhancing the
    /// interactivity and engagement of the game.
    /// </summary>
    public void IncrementIncorrectGuesses()
    {
        incorrectGuesses++;
        Invalidate(); // Trigger a repaint of the panel
    }

    /// <summary>
    /// The reset() method restores the initial state of the HangmanPanel by setting the count
    /// of incorrect guesses back to zero and triggering a repaint of the panel. This method
    /// ensures that the visual representation of the gallows and the hanged man is cleared,
    /// preparing the panel for a new game.It is called at the start of each new game to provide
    /// a clean slate for the gameplay experience.
    /// </summary>
    public void Reset()
    {
        incorrectGuesses = 0;
        Invalidate(); // Trigger a repaint of the panel
    }

    /// <summary>
    /// Paints the gallows and the hanged man based on the number of incorrect guesses. This
    /// method is called whenever the panel needs to be redrawn, such as after an incorrect
    /// guess or when the game is reset.
    /// </summary>
    /// <param name="e">Event arguments/parameters</param>
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        Pen blackPen = new Pen(Color.Black, 2);

        // Draw the gallows
        g.DrawLine(blackPen, 50, 250, 150, 250); // base
        g.DrawLine(blackPen, 100, 250, 100, 50); // pole
        g.DrawLine(blackPen, 100, 50, 200, 50); // horizontal beam
        g.DrawLine(blackPen, 200, 50, 200, 100); // rope

        // Draw the hanged man based on incorrect guesses
        if (incorrectGuesses > 0)
        { // head
            g.DrawEllipse(blackPen, 185, 100, 30, 30);
        }
        if (incorrectGuesses > 1)
        { // upper torso
            g.DrawLine(blackPen, 200, 130, 200, 150);
        }
        if (incorrectGuesses > 2)
        { // lower torso
            g.DrawLine(blackPen, 200, 150, 200, 170);
        }
        if (incorrectGuesses > 3)
        { // arms
            g.DrawLine(blackPen, 200, 130, 185, 140); // left arm
            g.DrawLine(blackPen, 200, 130, 215, 140); // right arm
        }
        if (incorrectGuesses > 4)
        { // legs
            g.DrawLine(blackPen, 200, 170, 185, 220); // left leg
            g.DrawLine(blackPen, 200, 170, 215, 220); // right leg
        }
    }
}