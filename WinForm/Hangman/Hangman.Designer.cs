using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Hangman
{
    partial class Hangman
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panel1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hangman));
            panel = new Panel();
            wordLabel = new Label();
            guessField = new TextBox();
            guessButton = new Button();
            messageLabel = new Label();
            hangmanPanel = new HangmanPanel();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(wordLabel);
            panel.Controls.Add(guessField);
            panel.Controls.Add(guessButton);
            panel.Controls.Add(messageLabel);
            panel.Controls.Add(hangmanPanel);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(640, 319);
            panel.TabIndex = 0;
            // 
            // wordLabel
            // 
            wordLabel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            wordLabel.Location = new Point(10, 10);
            wordLabel.Name = "wordLabel";
            wordLabel.Size = new Size(300, 30);
            wordLabel.TabIndex = 0;
            // 
            // guessField
            // 
            guessField.Font = new Font("Microsoft YaHei UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guessField.Location = new Point(10, 50);
            guessField.Name = "guessField";
            guessField.Size = new Size(141, 46);
            guessField.TabIndex = 1;
            guessField.KeyDown += GuessField_KeyDown;
            // 
            // guessButton
            // 
            guessButton.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guessButton.Location = new Point(157, 50);
            guessButton.Name = "guessButton";
            guessButton.Size = new Size(157, 46);
            guessButton.TabIndex = 2;
            guessButton.Text = "Guess";
            guessButton.Click += GuessButton_Click;
            // 
            // messageLabel
            // 
            messageLabel.Font = new Font("Segoe Script", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageLabel.Location = new Point(10, 114);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(300, 196);
            messageLabel.TabIndex = 3;
            // 
            // hangmanPanel
            // 
            hangmanPanel.Location = new Point(320, 10);
            hangmanPanel.Name = "hangmanPanel";
            hangmanPanel.Size = new Size(300, 300);
            hangmanPanel.TabIndex = 4;
            // 
            // Hangman
            // 
            ClientSize = new Size(640, 319);
            Controls.Add(panel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Hangman";
            Text = "Hangman Game";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
    }
}
