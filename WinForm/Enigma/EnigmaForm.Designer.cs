namespace Enigma
{
    partial class EnigmaForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem = new ToolStripMenuItem();
            plainText = new RichTextBox();
            encryptText = new RichTextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            btnSavePlain = new Button();
            btnSaveEncrypt = new Button();
            btnLoadPlain = new Button();
            btnLoadEncrypt = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, resetToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(47, 20);
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
            // 
            // plainText
            // 
            plainText.Location = new Point(12, 27);
            plainText.Name = "plainText";
            plainText.Size = new Size(619, 168);
            plainText.TabIndex = 2;
            plainText.Text = "";
            // 
            // encryptText
            // 
            encryptText.Location = new Point(12, 201);
            encryptText.Name = "encryptText";
            encryptText.Size = new Size(619, 187);
            encryptText.TabIndex = 3;
            encryptText.Text = "";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(637, 26);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(151, 23);
            btnEncrypt.TabIndex = 4;
            btnEncrypt.Text = "encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += encrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(637, 205);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(151, 23);
            btnDecrypt.TabIndex = 5;
            btnDecrypt.Text = "decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += decrypt_Click;
            // 
            // btnSavePlain
            // 
            btnSavePlain.Location = new Point(637, 56);
            btnSavePlain.Name = "btnSavePlain";
            btnSavePlain.Size = new Size(151, 23);
            btnSavePlain.TabIndex = 6;
            btnSavePlain.Text = "save plain txt";
            btnSavePlain.UseVisualStyleBackColor = true;
            btnSavePlain.Click += btnSavePlain_Click;
            // 
            // btnSaveEncrypt
            // 
            btnSaveEncrypt.Location = new Point(637, 235);
            btnSaveEncrypt.Name = "btnSaveEncrypt";
            btnSaveEncrypt.Size = new Size(151, 23);
            btnSaveEncrypt.TabIndex = 7;
            btnSaveEncrypt.Text = "save encrypted txt";
            btnSaveEncrypt.UseVisualStyleBackColor = true;
            btnSaveEncrypt.Click += btnSaveEncrypt_Click;
            // 
            // btnLoadPlain
            // 
            btnLoadPlain.Location = new Point(637, 85);
            btnLoadPlain.Name = "btnLoadPlain";
            btnLoadPlain.Size = new Size(151, 23);
            btnLoadPlain.TabIndex = 8;
            btnLoadPlain.Text = "load plain txt";
            btnLoadPlain.UseVisualStyleBackColor = true;
            btnLoadPlain.Click += btnLoadPlain_Click;
            // 
            // btnLoadEncrypt
            // 
            btnLoadEncrypt.Location = new Point(637, 266);
            btnLoadEncrypt.Name = "btnLoadEncrypt";
            btnLoadEncrypt.Size = new Size(151, 23);
            btnLoadEncrypt.TabIndex = 9;
            btnLoadEncrypt.Text = "load encrypted txt";
            btnLoadEncrypt.UseVisualStyleBackColor = true;
            btnLoadEncrypt.Click += btnLoadEncrypt_Click;
            // 
            // EnigmaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLoadEncrypt);
            Controls.Add(btnLoadPlain);
            Controls.Add(btnSaveEncrypt);
            Controls.Add(btnSavePlain);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(encryptText);
            Controls.Add(plainText);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "EnigmaForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private RichTextBox plainText;
        private RichTextBox encryptText;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Button btnSavePlain;
        private Button btnSaveEncrypt;
        private Button btnLoadPlain;
        private Button btnLoadEncrypt;
        private ToolStripMenuItem resetToolStripMenuItem;
    }
}
