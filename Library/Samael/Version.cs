/* --------------------------------------------------------------------------------------------------
 * The Version class encapsulates the concept of versioning for a given class. It maintains a major
 * and minor version number, which are essential for tracking the evolution and updates of the class
 * over time. The class name is also stored to provide context to the version information.
 * 
 * The constructor initializes the class with a specific name and version numbers, ensuring that each
 * instance of Version is uniquely identifiable by its class name and version combination. The
 * toString method provides a formatted string representation of the version, making it easy to
 * display and interpret the version information in a human-readable format.
 * --------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * --------------------------------------------------------------------------------------------------
 * Change Log
 * Fri 2024-01-26	File created & basic implementation created.					    Version 00.01
 * Fri 2024-09-20   Version Control changed to static.                                  Version 00.02
 * Wed 2024-09-25   I do not need the setters/getters for the private properties.       Version 00.03
 * --------------------------------------------------------------------------------------------------
 * To Do:
 * -------------------------------------------------------------------------------------------------- */
using System;

namespace Samael
{
    /// <summary>
    /// The Version class encapsulates the concept of versioning for a given class. It maintains a major
    /// and minor version number, which are essential for tracking the evolution and updates of the class
    /// over time. The class name is also stored to provide context to the version information.
    /// </summary>
    public class Version : IVersionable
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
        public static string GetVersion()
        {
            return VersionManager.GetInstance("Version", 0, 2).ToString();
        }

        /// <summary>
        /// The component in the Version class represents the specific name of the component that the version
        /// information is associated with.It provides context to the version numbers, making it clear which
        /// component the version applies to.This is particularly useful in larger projects where multiple
        /// classes or components may have their own versions.
        /// </summary>
        private string sComponent = "";

        /// <summary>
        /// Setter/Getter for the component variable.
        /// Setter/Getter is obsolete, please don't use it no more.
        /// </summary>
        [Obsolete("Setter/Getter is obsolete, please don't use it no more.")]
        public string SComponent
        {
            get { return sComponent; }
            set { sComponent = value; }
        }

        /// <summary>
        /// The major number in versions typically signifies significant changes or milestones in the
        /// development of a component of the software.It is incremented when there are substantial
        /// updates that may include new features, architectural changes, or other modifications that
        /// could potentially break compatibility with previous versions.Essentially, the major number
        /// reflects the overall progress and evolution of the software in a way that users and developers
        /// can easily recognize the importance of the changes made.
        /// </summary>
        private int iMajor = 0;

        /// <summary>
        /// Getter and Setter for iMajor version number.
        /// Setter/Getter is obsolete, please don't use it no more.
        /// </summary>
        [Obsolete("Setter/Getter is obsolete, please don't use it no more.")]
        public int IMajor
        {
            get { return iMajor; }
            set { iMajor = value; }
        }

        /// <summary>
        /// The minor number in versions represents smaller, incremental updates or improvements to a
        /// class or software.These updates typically include bug fixes, performance enhancements, or
        /// minor feature additions that do not significantly alter the overall functionality or
        /// architecture.The minor number is incremented to indicate these less impactful changes,
        /// ensuring that users and developers can track and understand the progression of the software
        /// without expecting major shifts or compatibility issues.
        /// </summary>
        private int iMinor = 0;

        /// <summary>
        /// Getter and Setter for iMinor version number.
        /// Setter/Getter is obsolete, please don't use it no more.
        /// </summary>
        [Obsolete("Setter/Getter is obsolete, please don't use it no more.")]
        public int IMinor
        {
            get { return iMinor; }
            set { iMinor = value; }
        }

        /// <summary>
        /// The constructor initializes the class with a specific name and version numbers, ensuring that each
        /// instance of Version is uniquely identifiable by its class name and version combination.The
        /// toString method provides a formatted string representation of the version, making it easy to
        /// display and interpret the version information in a human-readable format.
        /// </summary>
        /// <param name="component">Class or component name.</param>
        /// <param name="major">Major version number.</param>
        /// <param name="minor">Minor version number.</param>
        public Version(string component, int major, int minor)
        {
            sComponent = component;
            iMajor = major;
            iMinor = minor;
        }

        /// <summary>
        /// The ToString method in the Version class provides a human-readable string representation of the
        /// version information.It combines the component name with the major and minor version numbers,
        /// formatting the version numbers to always display two digits. This method ensures that the version
        /// information is easily interpretable and can be conveniently displayed or logged.
        /// 
        /// For example, if the component name is “ExampleComponent” with a major version of 1 and a minor
        /// version of 5, the toString method would return the string “Component ExampleComponent: Version 01.05”.
        /// </summary>
        /// <returns>"Component" component: "Version" Major#.Minor#</returns>
        public override string ToString()
        {
            return $"Component: {sComponent}, Version: {iMajor:D2}.{iMinor:D2}";
        }
    }
}
