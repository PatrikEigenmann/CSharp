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
        /// 
        /// </summary>
        private String? Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private String? Marker { get; set; } = "*";

        /// <summary>
        /// 
        /// </summary>
        private String? StartEnd { get; set; } = "|";

        /// <summary>
        /// 
        /// </summary>
        private int Full { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private int Steps { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        private int Divider { get; set; } = 60;

        /// <summary>
        /// 
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
            return VersionManager.GetInstance("Version", 0, 2).ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="full"></param>
        /// <param name="divider"></param>
        public ProgressBar(String title, int full, int divider = 60)
        {
            Initialize(title, full, divider);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="full"></param>
        /// <param name="marker"></param>
        /// <param name="startEnd"></param>
        /// <param name="divider"></param>
        public ProgressBar(String title, int full, String marker = "*", String startEnd = "|", int divider = 60)
        {
            Initialize(title, full, divider);

            Marker = marker;
            StartEnd = startEnd;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="full"></param>
        /// <param name="divider"></param>
        private void Initialize(String title, int full, int divider)
        {
            Title = title;
            Full = full;
            Divider = divider;
            Steps = Full / Divider;
        }

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
