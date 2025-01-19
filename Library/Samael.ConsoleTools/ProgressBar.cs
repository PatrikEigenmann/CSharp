/* --------------------------------------------------------------------------------------
 * ProgressBar.cs - This class represents a simple progress bar on console level
 * that can be used to show the progress of a task. It is a simple implementation
 * that uses the Console.Write() method to update the procentual progress of a task.
 * --------------------------------------------------------------------------------------
 * Author:  Patrik Eigenmann
 * eMail:   p.eigenmann@gmx.net
 * --------------------------------------------------------------------------------------
 * Change Log:
 * Fri 2025-01-10 File created & basic implementation created.              Version 00.01
 * -------------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Samael;

namespace Samael.ConsoleTools
{
    public class ProgressBar : IVersionable
    {
        /// <summary>
        /// The title of the progress bar.
        /// </summary>
        private String? Title { get; set; }

        /// <summary>
        /// The marker that is used to show the progress.
        /// </summary>
        private String? Marker { get; set; } = "*";

        /// <summary>
        /// StartEnd is the character that indicates the start
        /// and the end of the progress bar.
        /// </summary>
        private String? StartEnd { get; set; } = "|";

        /// <summary>
        /// Full is the full length of the progress bar.
        /// </summary>
        private int Full { get; set; }

        /// <summary>
        /// How many steps do this progress bar have.
        /// </summary>
        private int Steps { get; set; } = 0;

        /// <summary>
        /// Steps = Full / Divider. So the divider is how many
        /// Markers should be printed until the progress bar is full.
        /// </summary>
        private int Divider { get; set; } = 60;

        /// <summary>
        /// The counter is used to count the progress of the progress bar.
        /// </summary>
        private int Counter { get; set; } = 1;

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
        public static string GetVersion()
        {
            return VersionManager.GetInstance("ProgressBar", 0, 1).ToString();
        }

        /// <summary>
        /// ProgressBar construction, initializes all the parameter for the progress bar.
        /// </summary>
        /// <param name="title">The title of the progress bar.</param>
        /// <param name="full">Full represents 100% steps of the progress bar.</param>
        /// <param name="divider">Declare the divider.</param>
        public ProgressBar(String title, int full, int divider = 60)
        {
            Initialize(title, full, divider);
        }

        /// <summary>
        /// ProgressBar construction, initializes all the parameter for the progress bar.
        /// </summary>
        /// <param name="title">The title of the progress bar</param>
        /// <param name="full">Full represents 100% steps of the progress.</param>
        /// <param name="marker">Customized marker</param>
        /// <param name="startEnd">Customized StartEnd</param>
        /// <param name="divider">Declare the divider</param>
        public ProgressBar(String title, int full, String marker = "*", String startEnd = "|", int divider = 60)
        {
            Initialize(title, full, divider);

            Marker = marker;
            StartEnd = startEnd;

        }

        /// <summary>
        /// Standard initialization of the progress bar.
        /// </summary>
        /// <param name="title">Title of the progress bar</param>
        /// <param name="full">full steps of the progress bar</param>
        /// <param name="divider">divider of the progress bar</param>
        private void Initialize(String title, int full, int divider)
        {
            Title = title;
            Full = full;
            Divider = divider;
            Steps = Full / Divider;
        }

        /// <summary>
        /// Update() updatess the progress bar every step along the way.
        /// </summary>
        public void Update()
        {
            // When the counter is 0, we print the
            // title and the start of the progress bar.
            if (Counter == 1)
            {
                Console.Write(Title + " ");
                Console.Write(StartEnd);
            }

            // If the counter is a multiple of the steps.
            if (Counter > 1 && Counter % Steps == 0)
            {
                Console.Write(Marker);
            }

            // If the counter is the full length of the progress bar.
            if (Counter >= Full)
            {
                Console.WriteLine(StartEnd + " 100%" + Console.Out.NewLine);
            }

            // Increment the counter.
            Counter++;
        }
    }
}
