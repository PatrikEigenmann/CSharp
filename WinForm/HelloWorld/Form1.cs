/* -------------------------------------------------------------------------------------------------------
 * This form is a modern Windows application of the classic “Hello World!” console app, which is often the
 * first program developers learn in almost every programming language. It showcases how powerful,
 * effective, easy, and logical C# can be in a WinForms environment. The Windows Form application, with
 * its features, significantly improves the user experience, making our application more intuitive and
 * user-friendly.
 * -------------------------------------------------------------------------------------------------------
 * Author   : Patrik Eigenmann
 * eMail    : p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------
 * Change Log:
 * Wed 2024-09-18 File created & basic functionality implemented.                           Version: 00.01
 * Wed 2024-09-18 Samael Version Control implemented.                                       Version: 00.02
 * Wed 2024-09-18 MessageBox & Help menu implemented.                                       Version: 00.03
 * -------------------------------------------------------------------------------------------------------*/
using Samael;

namespace HelloWorld
{
    /// <summary>
    /// This form is a modern Windows application of the classic “Hello World!” console app, which is often
    /// the first program developers learn in almost every programming language. It showcases how powerful,
    /// effective, easy, and logical C# can be in a WinForms environment. The Windows Form application,
    /// with its features, significantly improves the user experience, making our application more intuitive
    /// and user-friendly.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The GetVersion method is a vital feature for any class implementing the IVersionable interface.
        /// It provides a standardized way to retrieve version information, ensuring that every component
        /// can clearly communicate its version. This method is essential for maintaining consistency and
        /// reliability across the system, making it easier to manage updates and track changes. By
        /// implementing GetVersion, we ensure that our software remains robust, up-to-date, and easy to
        /// maintain, ultimately enhancing the overall user experience.
        /// </summary>
        /// <returns>
        /// A formatted string where the name of the component is the class or object name, 
        /// and the version number consists of a major and a minor number, each formatted to two digits.
        /// </returns>
        public string GetVersion()
        {
            return VersionManager.GetInstance(this.GetType().Name, 0, 3).ToString();
        }

        /// <summary>
        /// Initializes the form and sets up all the necessary components for the user interface.
        /// This ensures that the application is ready for user interaction as soon as it starts.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This event is triggered when the form is first loaded. It is used to perform any initial setup
        /// or configuration needed before the user starts interacting with the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This event is triggered when the Help menu item is clicked. It displays a message box
        /// showing the current version of the application, helping users to easily access version information.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void mnHelp_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show(GetVersion(),"HelloWorld Version 00.01");
        }
    }
}
