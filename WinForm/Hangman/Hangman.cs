/* -------------------------------------------------------------------------------------------------------------------
 * The Hangman class brings the timeless Hangman word game to life with a sleek and engaging graphical user interface.
 * This class orchestrates the core game mechanics, seamlessly integrating word selection, user input, and game state
 * management. With intuitive design, it handles user guesses, updates the display of the word with each correct guess,
 * and progressively reveals parts of the hanged man for incorrect guesses. The game dynamically reads from a vast word
 * list, offering endless fun and challenge. The jHangman class ensures an interactive and enjoyable experience, complete
 * with real-time feedback and the ability to reset and play again seamlessly, making it a perfect blend of entertainment
 * and education.
 * -------------------------------------------------------------------------------------------------------------------
 * Author:  Patrik Eigenmann
 * email:   p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------------------
 * Change Log:
 * Mon 2024-11-25 File created.                                                                         Version: 00.01
 * Tue 2024-11-26 Description and comments implemented.                                                 Version: 00.02
 * -------------------------------------------------------------------------------------------------------------------
 * To Do:
 * Implement the basic classes from the Samael framework.
 * -------------------------------------------------------------------------------------------------------------------
 * Release Notes for Verion 01.00:
 * File created and basic functionality implemented.                                                    Version: 00.01
 * Added commentaries and descriptions to the code.                                                     Version: 00.02
 * Implemented the basic classes and functionality from the Samael framework.                           Version: 00.03
 * ------------------------------------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Collections;
using System.Security.Policy;
using System.Diagnostics;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

using System.Windows.Forms;

using Samael;

namespace Hangman
{
    /// <summary>
    /// The Hangman class brings the timeless Hangman word game to life with a sleek and engaging
    /// graphical user interface. This class orchestrates the core game mechanics, seamlessly
    /// integrating word selection, user input, and game state management.With intuitive design,
    /// it handles user guesses, updates the display of the word with each correct guess, and
    /// progressively reveals parts of the hanged man for incorrect guesses. The game dynamically
    /// reads from a vast word list, offering endless fun and challenge.The jHangman class ensures
    /// an interactive and enjoyable experience, complete with real-time feedback and the ability
    /// to reset and play again seamlessly, making it a perfect blend of entertainment and education.
    /// </summary>
    public partial class Hangman : Form, IVersionable
    {
        /// <summary>
        /// The major # indicates significat changes or milestones, and stable builds in software packages. When
        /// the major # is incremented, it usually means that there are substantial updates, such as new features
        /// major improvements, or changes that might be not backward compatible. For example, moving from version
        /// 01.?? to 02.00 suggests a major overhaul or signigicant new functionality.
        /// </summary>
        private static int appMajor = 0;

        /// <summary>
        /// The minor # represents smaller updates or improvements that are backwards compatible. Incrementing the
        /// the minor # typically means bug fixes, minor enhancements, or incremental improvements. For instance
        /// going from version 01.02 to 01.03 indicating a minor ubdate that enhances the existing version without
        /// breaking the compatibility.
        /// </summary>
        private static int appMinor = 5;


        /// <summary>
        /// Provides the name of the application as defined in the configuration, along with the current
        /// version number. This ensures consistency and transparency across our software deployments.
        /// It's a centralized source of truth for identifying the application and its version.
        /// This information is essential for tracking updates and maintaining version control.
        /// </summary>
        private static string AppInfo
        {
            get
            {
                /* Writing an info message into the log file. */
                LogManager.WriteMessage("Application Info created.", LogManager.INFO, typeof(Hangman), typeof(Hangman));
                return ConfigManager.GetParameter("appName") + " v" + string.Format("{0:D2}.{1:D2}", appMajor, appMinor);
            }
        }

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
            LogManager.WriteMessage("Version string created.", LogManager.INFO, typeof(Hangman), typeof(Hangman));
            return VersionManager.GetInstance("EnigmaForm", 0, 15).ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        private Panel panel;
        
        /// <summary>
        /// 
        /// </summary>
        private Label wordLabel;
        
        /// <summary>
        /// 
        /// </summary>
        private TextBox guessField;
        
        /// <summary>
        /// 
        /// </summary>
        private Button guessButton;
        
        /// <summary>
        /// 
        /// </summary>
        private Label messageLabel;
        
        /// <summary>
        /// 
        /// </summary>
        private string word;
        
        /// <summary>
        /// 
        /// </summary>
        private char[] guessedWord;
        
        /// <summary>
        /// 
        /// </summary>
        private int maxAttempts = 6;
        
        /// <summary>
        /// 
        /// </summary>
        private int attempts;
        
        /// <summary>
        /// 
        /// </summary>
        private List<string> words;
        
        /// <summary>
        /// 
        /// </summary>
        private HangmanPanel hangmanPanel;

        /// <summary>
        /// The Hangman() constructor initializes the Hangman game by setting up the main frame and
        /// its components. It configures the main panel with a BorderLayout and organizes the
        /// central game controls and the HangmanPanel using nested layouts. The constructor also
        /// loads the list of words, adds action listeners for the guess button and the text
        /// field, and starts the game by selecting a new word.This setup ensures the game is
        /// ready for interaction, providing a seamless and engaging user experience.The
        /// constructor's initial configuration is crucial for the accurate and smooth operation
        /// of the Hangman game.
        /// </summary>
        public Hangman()
        {
            InitializeComponent();
            LoadWords();
            StartGame();
        }

        /// <summary>
        /// The LoadWords method in the jHangman class reads a list of words from a
        /// comma-separated text file and stores them in the words ArrayList.This method ensures
        /// that the game has a variety of words for the player to guess.It handles file reading
        /// using a BufferedReader and splits the content by commas to populate the word list. If
        /// an error occurs while reading the file, such as an IOException, the method sets an
        /// error message to inform the player. This functionality is essential for setting up
        /// the game's word pool and providing a diverse range of words for each new game session.
        /// </summary>
        private void LoadWords()
        {
            try
            {
                string filePath = "words.txt";
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    string[] wordArray = content.Split(',');
                    foreach (var word in wordArray)
                    {
                        if (words == null) words = new List<string>();
                        words.Add(word.Trim().ToUpper()); // Convert to uppercase
                    }
                    messageLabel.Text = "Words loaded successfully!";
                }
                else
                {
                    messageLabel.Text = "File not found!";
                }
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Error loading words: " + ex.Message;
            }
        }

        /// <summary>
        /// The StartGame method in the jHangman class initializes a new game session by
        /// selecting a random word from the words list, resetting the game state, and updating
        /// the user interface. It populates the guessedWord array with underscores to represent
        /// the unguessed letters, sets the attempts counter to zero, and enables the guess
        /// input field and button.Additionally, it calls the reset method on the HangmanPanel
        /// to clear any previous drawings and ensures the guessField is focused for user input.
        /// This method is crucial for setting up each new game and providing a fresh and
        /// engaging experience for the player.
        /// </summary>
        private void StartGame()
        {
            Random rand = new Random();
            word = words[rand.Next(words.Count)];
            guessedWord = new char[word.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }
            attempts = 0;
            hangmanPanel.Reset();
            UpdateWordLabel();
            guessButton.Text = "Guess";
            guessButton.Enabled = true;
            guessField.Enabled = true;
            guessField.Focus();
            messageLabel.Text = "Start guessing!";
        }

        /// <summary>
        /// The UpdateWordLabel method in the jHangman class updates the display of the current
        /// state of the word being guessed.It constructs a StringBuilder representation of the
        /// guessedWord array, adding spaces between each character for better readability. This
        /// method is called whenever the player makes a guess, ensuring that the wordLabel
        /// accurately reflects the current progress of the game. It provides visual feedback to
        /// the player, showing the correctly guessed letters and underscores for the remaining
        /// letters yet to be guessed.
        /// </summary>
        private void UpdateWordLabel()
        {
            wordLabel.Text = string.Join(" ", guessedWord);
        }

        /// <summary>
        /// The UpdateWordLabel method in the jHangman class updates the display of the current
        /// state of the word being guessed.It constructs a StringBuilder representation of the
        /// guessedWord array, adding spaces between each character for better readability. This
        /// method is called whenever the player makes a guess, ensuring that the wordLabel
        /// accurately reflects the current progress of the game. It provides visual feedback to
        /// the player, showing the correctly guessed letters and underscores for the remaining
        /// letters yet to be guessed.
        /// </summary>
        /// <param name="guess">The letter guessed by the player.</param>
        private void CheckGuess(string guess)
        {
            if (guess.Length != 1)
            {
                messageLabel.Text = "Please enter a single letter.";
                return;
            }
            char guessedChar = char.ToUpper(guess[0]); // Convert to uppercase
            bool found = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == guessedChar && guessedWord[i] == '_')
                {
                    guessedWord[i] = guessedChar;
                    found = true;
                }
            }
            if (found)
            {
                messageLabel.Text = "Good guess!";
            }
            else
            {
                attempts++;
                hangmanPanel.IncrementIncorrectGuesses();
                messageLabel.Text = "Incorrect guess! Attempts left: " + (maxAttempts - attempts);
            }
            UpdateWordLabel();
            CheckGameOver();
        }

        /// <summary>
        /// The CheckGameOver method evaluates whether the game has ended by checking two
        /// conditions: if the player has exceeded the maximum allowed incorrect guesses
        /// (maxAttempts), or if the player has successfully guessed the entire word. If either
        /// condition is met, the method updates the messageLabel with an appropriate message
        /// ("Game over!" or "Congratulations!") and changes the guessButton text to "Play
        /// Again". This allows the player to start a new game, ensuring a smooth and enjoyable
        /// gameplay experience.
        /// </summary>
        private void CheckGameOver()
        {
            if (attempts >= maxAttempts)
            {
                messageLabel.Text = "Game over! The word was: " + word;
                guessButton.Text = "Play Again";
                guessButton.Enabled = true;
            }
            else if (new string(guessedWord).Equals(word))
            {
                messageLabel.Text = "Congratulations! You guessed the word: " + word;
                guessButton.Text = "Play Again";
                guessButton.Enabled = true;
            }
        }

        /// <summary>
        /// The GuessButton_Click event handler handles the action events triggered by the guess
        /// button.When the button is pressed, it checks if the button text is "Play Again" to
        /// restart the game or processes the player's guess by calling checkGuess(). It then
        /// clears the guessField for the next input, ensuring a smooth and responsive user
        /// experience.
        /// </summary>
        /// <param name="sender">The sender who triggered the event.</param>
        /// <param name="e">Event arguments/parameters.</param>
        private void GuessButton_Click(object sender, EventArgs e)
        {
            if (guessButton.Text == "Play Again")
            {
                StartGame();
            }
            else
            {
                string guess = guessField.Text.Trim().ToUpper();
                CheckGuess(guess);
                guessField.Text = "";
                guessField.Focus(); // Add this line to set focus to guessField
            }
        }

        /// <summary>
        /// The GuessButton_KeyDown event handler handles the action events triggered by the
        /// user enter key pressed. When the enter key is pressed, it checks if the button
        /// text is "Play Again" to restart the game or processes the player's guess by calling
        /// checkGuess(). It then clears the guessField for the next input, ensuring a smooth
        /// and responsive user experience.
        /// </summary>
        /// <param name="sender">The sender who triggered the event.</param>
        /// <param name="e">Event arguments/parameters.</param>
        private void GuessField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GuessButton_Click(this, new EventArgs());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}