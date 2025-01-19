/* ----------------------------------------------------------------------------------------
 * Introducing the ComboBoxDialog class, a versatile and user-friendly dialog box that
 * streamlines user input and enhances the overall experience. With its intuitive combo box
 * interface, this class provides a seamless way for users to make selections from a
 * predefined list, making it perfect for a wide range of applications. Whether you're
 * developing a sophisticated software suite or a simple utility tool, ComboBoxDialog ensures
 * a smooth and efficient user interaction, allowing you to capture user preferences
 * effortlessly. Its sleek design and easy integration make it a valuable addition to any
 * developer's toolkit. Experience the simplicity and elegance of ComboBoxDialog and elevate
 * your application's user experience to new heights.
 * ----------------------------------------------------------------------------------------
 * Author:  Patrik Eigenmann 
 * eMail:   p.eigenmann@gmx.net
 * GitHub:  www.github.com/PatrikEigenmann/CSharp
 * ----------------------------------------------------------------------------------------
 * ChangeLog:
 * 
 * Wed 2025-01-14 File created.                                             Version: 00.01
 * Sun 2025-01-19 Version control simplified because of incompatibility.    Version: 00.02
 * ---------------------------------------------------------------------------------------- */

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
    public partial class ComboBoxDialog : Form , IVersionable
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
        public int Minor { get; } = 2;

        /// <summary>
        /// The component name refers to the specific name of the class or object that implements the
        /// IVersionable interface. This name is used to uniquely identify the component within the
        /// system, ensuring that version control and management processes can accurately track changes
        /// and updates to the component over time.
        /// </summary>
        public string Component { get; } = "ComboBoxDialog";

        /*
        /// <summary>
        /// The SetVersion method is a vital feature for IVersionable interface. It provides a
        /// standardized way to retrieve version information, ensuring that every component can clearly
        /// communicate its version. This method is essential for maintaining consistency and reliability
        /// across the system, making it easier to manage updates and track changes. By implementing
        /// GetIVersion, we ensure that our software remains robust, up-to-date, and easy to maintain,
        /// ultimately enhancing the overall user experience.
        /// </summary>
        public void SetVersion()
        {
            //VersionManager.Instance.RegisterVersion(Component, Major, Minor);
        }
        */

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
        /// Retrieves the currently selected item from the combo box control. This method returns
        /// the value of the item that the user has selected from the drop-down list. It is commonly
        /// used to obtain user input or to trigger actions based on the selected item.
        /// </summary>
        public string SelectedItem { get; private set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxDialog"/> class. This constructor
        /// sets up the dialog window with a specified title, label text, and a list of options
        /// to populate the combo box. It prepares the ComboBoxDialog to display the options to
        /// the user and handle their selection.
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

            // SetVersion();
        }

        /// <summary>
        /// Handles the click event for the button. When the button is clicked, this method sets the
        /// selected item in the combo box and closes the dialog window with an OK result. This
        /// indicates that the user has made a selection and confirmed their choice.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button that was clicked.</param>
        /// <param name="e">An EventArgs that contains the event data, providing context for the event.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve the selected item from the combo box or the text if no item is selected
            this.SelectedItem = (comboBox1.SelectedItem != null) ? comboBox1.SelectedItem.ToString() : comboBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}