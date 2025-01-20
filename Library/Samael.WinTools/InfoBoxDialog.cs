/*
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Samael.WinTools
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InfoBoxDialog : Form, IVersionable
    {
        #region IVersionable Implementation

        public int Major { get; } = 0;

        public int Minor { get; } = 1;

        public string Component { get; } = "InfoBoxDialog";

        public override string ToString()
        {
            return $"{Component} v{Major}.{Minor}";
        }

        #endregion

        private Font _Font { get; set; }



        public InfoBoxDialog(string title, string lblText)
        {
            InitializeComponent();

            InitInfoBox(title, lblText);
        }

        public InfoBoxDialog(string title, string lblText, Font font)
        {
            _Font = font;

            InitializeComponent();

            InitInfoBox(title, lblText);
        }

        private void InitInfoBox(string title, string lblText)
        {
            this.Text = title;
            this.label1.Text = lblText;
            this.label1.AutoSize = true;
            this.AutoSize = true;

            if (_Font != null)
            {
                this.label1.Font = _Font;
            }

            Image image = pictureBox1.Image;

            Bitmap bmp = new Bitmap(100, 100);

            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, 100, 100));
            }

            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
