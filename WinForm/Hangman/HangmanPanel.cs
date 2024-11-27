using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class HangmanPanel : Panel
{
    private int incorrectGuesses = 0;

    public void IncrementIncorrectGuesses()
    {
        incorrectGuesses++;
        Invalidate(); // Trigger a repaint of the panel
    }

    public void Reset()
    {
        incorrectGuesses = 0;
        Invalidate(); // Trigger a repaint of the panel
    }

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
