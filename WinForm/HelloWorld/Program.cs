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
 * Thu 2024-09-19 File created & basic functionality implemented.                           Version: 00.01
 * -------------------------------------------------------------------------------------------------------*/
namespace HelloWorld
{
    /// <summary>
    /// The Program class serves as the heart of our application, orchestrating the initial setup and launch
    /// of the user interface. At its core is the Main method, the pivotal entry point that ensures our
    /// application starts smoothly and efficiently. By initializing essential configurations and launching
    /// the main form, this method guarantees that users experience the full power and simplicity of our
    /// software right from the start. This streamlined process not only highlights the robustness of our
    /// application but also underscores our commitment to delivering an intuitive and user-friendly
    /// experience. The Program class exemplifies our dedication to excellence, ensuring that every user
    /// interaction begins on a solid foundation.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// This is the main entry point for the application. It initializes essential configurations and
        /// launches the main form, ensuring that the application starts smoothly and is ready for user
        /// interaction.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}