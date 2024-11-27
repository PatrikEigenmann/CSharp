using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


namespace Hangman
{
    public partial class Hangman : Form
    {
        private Panel panel;
        private Label wordLabel;
        private TextBox guessField;
        private Button guessButton;
        private Label messageLabel;
        private string word;
        private char[] guessedWord;
        private int maxAttempts = 6;
        private int attempts;
        private List<string> words;
        private HangmanPanel hangmanPanel;
        public Hangman()
        {
            InitializeComponent();
            LoadWords();
            StartGame();
        }

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
                        if(words == null) words = new List<string>();
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

        private void UpdateWordLabel()
        {
            wordLabel.Text = string.Join(" ", guessedWord);
        }

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
