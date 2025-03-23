namespace Bidder;

partial class BidderForm
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
        btnNiche = new Button();
        SuspendLayout();
        // 
        // btnNiche
        // 
        btnNiche.Location = new Point(46, 37);
        btnNiche.Name = "btnNiche";
        btnNiche.Size = new Size(150, 46);
        btnNiche.TabIndex = 0;
        btnNiche.Text = "Niche";
        btnNiche.UseVisualStyleBackColor = true;
        btnNiche.Click += NicheClick;
        // 
        // BidderForm
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(932, 303);
        Controls.Add(btnNiche);
        Name = "BidderForm";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button btnNiche;
}
