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
            this.panel = new System.Windows.Forms.Panel();
            this.wordLabel = new System.Windows.Forms.Label();
            this.guessField = new System.Windows.Forms.TextBox();
            this.guessButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.hangmanPanel = new HangmanPanel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.wordLabel);
            this.panel.Controls.Add(this.guessField);
            this.panel.Controls.Add(this.guessButton);
            this.panel.Controls.Add(this.messageLabel);
            this.panel.Controls.Add(this.hangmanPanel);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(640, 360);
            this.panel.TabIndex = 0;
            // 
            // wordLabel
            // 
            this.wordLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordLabel.Location = new System.Drawing.Point(10, 10);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(300, 30);
            this.wordLabel.TabIndex = 0;
            // 
            // guessField
            // 
            this.guessField.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guessField.Location = new System.Drawing.Point(10, 50);
            this.guessField.Name = "guessField";
            this.guessField.Size = new System.Drawing.Size(100, 27);
            this.guessField.TabIndex = 1;
            this.guessField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GuessField_KeyDown);
            // 
            // guessButton
            // 
            this.guessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guessButton.Location = new System.Drawing.Point(120, 50);
            this.guessButton.Name = "guessButton";
            this.guessButton.Size = new System.Drawing.Size(75, 30);
            this.guessButton.TabIndex = 2;
            this.guessButton.Text = "Guess";
            this.guessButton.Click += new System.EventHandler(this.GuessButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(10, 90);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(300, 30);
            this.messageLabel.TabIndex = 3;
            // 
            // hangmanPanel
            // 
            this.hangmanPanel.Location = new System.Drawing.Point(320, 10);
            this.hangmanPanel.Name = "hangmanPanel";
            this.hangmanPanel.Size = new System.Drawing.Size(300, 300);
            this.hangmanPanel.TabIndex = 4;
            // 
            // Hangman
            // 
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.Controls.Add(this.panel);
            this.Name = "Hangman";
            this.Text = "Hangman Game";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}

