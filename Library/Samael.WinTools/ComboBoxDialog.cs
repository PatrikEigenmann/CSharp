/* --------------------------------------------------------------------------------------
 * Introducing the ComboBoxDialog class, a versatile and user-friendly dialog box
 * that streamlines user input and enhances the overall experience. With its intuitive
 * combo box interface, this class provides a seamless way for users to make selections
 * from a predefined list, making it perfect for a wide range of applications. Whether
 * you're developing a sophisticated software suite or a simple utility tool, ComboBoxDialog
 * ensures a smooth and efficient user interaction, allowing you to capture user
 * preferences effortlessly. Its sleek design and easy integration make it a valuable
 * addition to any developer's toolkit. Experience the simplicity and elegance of
 * ComboBoxDialog and elevate your application's user experience to new heights.
 * --------------------------------------------------------------------------------------
 * Author:  Patrik Eigenmann 
 * eMail:   p.eigenmann@gmx.net
 * GitHub:  www.github.com/PatrikEigenmann/CSharp
 * --------------------------------------------------------------------------------------
 * ChangeLog:
 * 
 * Wed 2025-01-14 File created.                                             Version: 00.01
 * -------------------------------------------------------------------------------------- */

using System;
using System.Drawing;
using System.Windows.Forms;

using Samael;

namespace Samael.WinTools
{
    /// <summary>
    /// Introducing the ComboBoxDialog class, a versatile and user-friendly dialog box
    /// that streamlines user input and enhances the overall experience. With its intuitive
    /// combo box interface, this class provides a seamless way for users to make selections
    /// from a predefined list, making it perfect for a wide range of applications. Whether
    /// you're developing a sophisticated software suite or a simple utility tool, ComboBoxDialog
    /// ensures a smooth and efficient user interaction, allowing you to capture user
    /// preferences effortlessly. Its sleek design and easy integration make it a valuable
    /// addition to any developer's toolkit. Experience the simplicity and elegance of
    /// ComboBoxDialog and elevate your application's user experience to new heights.
    /// </summary>

    public partial class ComboBoxDialog : Form, IVersionable
    {
        #region IVersionable Implementation

        /// <summary>
        /// 
        /// </summary>
        public int Major { get; } = 0;
        
        /// <summary>
        /// 
        /// </summary>
        public int Minor { get; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public string Component { get; } = "ComboBoxDialog";

        /// <summary>
        /// 
        /// </summary>
        public void SetVersion()
        {
            VersionManager.Instance.RegisterVersion(Component, Major, Minor);
        }
        #endregion

        /// <summary>
        /// Gets the selected item from the combo box.
        /// </summary>
        public string SelectedItem { get; private set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxDialog"/> class.
        /// </summary>
        /// <param name="title">The title of the dialog window.</param>
        /// <param name="lbltext">The text for the label displayed in the dialog.</param>
        /// <param name="options">The list of items to populate the combo box.</param>
        public ComboBoxDialog(string title, string lbltext, string[] options)
        {
            InitializeComponent();
            this.Text = title;
            label1.Text = lbltext;

            // Add items to the combo box and set the default selected item
            comboBox1.Items.AddRange(options);
            comboBox1.SelectedIndex = 0;

            SetVersion();
        }

        /// <summary>
        /// Handles the click event for the button.
        /// Sets the selected item and closes the dialog with an OK result.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve the selected item from the combo box or the text if no item is selected
            this.SelectedItem = (comboBox1.SelectedItem != null) ? comboBox1.SelectedItem.ToString() : comboBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
