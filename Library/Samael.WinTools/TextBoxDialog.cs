/* ----------------------------------------------------------------------------------------
 * Introducing the TexBoxDialog class, a versatile and user-friendly dialog box that
 * streamlines user input and enhances the overall experience. With its intuitive text box
 * interface, this class provides a seamless way for users to make input from a
 * predefined list, making it perfect for a wide range of applications. Whether you're
 * developing a sophisticated software suite or a simple utility tool, TexBoxDialog ensures
 * a smooth and efficient user interaction, allowing you to capture user preferences
 * effortlessly. Its sleek design and easy integration make it a valuable addition to any
 * developer's toolkit. Experience the simplicity and elegance of TexBoxDialog and elevate
 * your application's user experience to new heights.
 * ----------------------------------------------------------------------------------------
 * Author:  Patrik Eigenmann 
 * eMail:   p.eigenmann@gmx.net
 * GitHub:  www.github.com/PatrikEigenmann/CSharp
 * ----------------------------------------------------------------------------------------
 * ChangeLog:
 * 
 * Sun 2025-01-19 File created.                                             Version: 00.01
 * ---------------------------------------------------------------------------------------- */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Samael.WinTools
{
    /// <summary>
    /// The TextBoxDialog class provides a simple dialog window with a text box, allowing users
    /// to input text. This dialog includes a title and a label to guide the user, making it
    /// easy to collect user input in a structured manner.
    /// </summary>
    public partial class TextBoxDialog : Form, IVersionable
    {
        #region IVersionable Implementation

        /// <summary>
        /// The major # indicates significat changes or milestones, and stable builds in software
        /// packages. When the major # is incremented, it usually means that there are substantial
        /// updates, such as new features major improvements, or changes that might be not backward
        /// compatible. For example, moving from version 01.?? to 02.00 suggests a major overhaul
        /// or signigicant new functionality.
        /// </summary>
        public int Major { get; } = 0;

        /// <summary>
        /// The minor # represents smaller updates or improvements that are backwards compatible.
        /// Incrementing the the minor # typically means bug fixes, minor enhancements, or incremental
        /// improvements. For instance going from version 01.02 to 01.03 indicating a minor ubdate that
        /// enhances the existing version without breaking the compatibility.
        /// </summary>
        public int Minor { get; } = 1;

        /// <summary>
        /// The component name refers to the specific name of the class or object that implements the
        /// IVersionable interface. This name is used to uniquely identify the component within the
        /// system, ensuring that version control and management processes can accurately track changes
        /// and updates to the component over time.
        /// </summary>
        public string Component { get; } = "TexBoxDialog";

        /// <summary>
        /// The ToString method is a crucial part of the IVersionable interface. It allows components
        /// to provide a string representation of their version information. This method is typically
        /// used for debugging, logging, and displaying version details in a human-readable format.
        /// By implementing ToString, components can ensure consistent and clear version information
        /// across the system.
        /// </summary>
        /// <returns>A string containing the version information of the component.</returns>
        public override string ToString()
        {
            return $"{Component} v{Major}.{Minor}";
        }
        #endregion

        /// <summary>
        /// Retrieves the currently selected text from the text box control. This method returns
        /// the value of the item that the user has written in the text box. It is commonly
        /// used to obtain user input or to trigger actions based on the written item.
        /// </summary>
        public string SelectedText { get; private set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the TextBoxDialog class with the specified title and label
        /// text. This constructor sets up the dialog window with a given title and label, preparing
        /// it to display a text box for user input.
        /// </summary>
        /// <param name="title">The title of the dialog window.</param>
        /// <param name="lbltext">The text for the label displayed in the dialog.</param>
        public TextBoxDialog(string title, string lbltext)
        {
            InitializeComponent();

            Image image = pictureBox1.Image;

            Bitmap bmp = new Bitmap(100, 100);

            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, 100, 100));
            }

            pictureBox1.Image = bmp;

            this.Text = title;
            this.label1.Text = lbltext;
        }

        /// <summary>
        /// Handles the click event for the button. When the button is clicked, this method sets the
        /// selected item in the text box and closes the dialog window with an OK result. This
        /// indicates that the user has made an user input.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button that was clicked.</param>
        /// <param name="e">An EventArgs that contains the event data, providing context for the event.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve the selected item from the combo box or the text if no item is selected
            this.SelectedText = (textBox1.Text != null) ? textBox1.Text : string.Empty;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}