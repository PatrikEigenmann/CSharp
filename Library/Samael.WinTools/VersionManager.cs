/* ---------------------------------------------------------------------------------------------------
 * The VersionManager class is designed to manage and track different versions of software components.
 * It maintains a centralized list of versions, ensuring that each component’s version is easily
 * accessible. When a version is requested, the class checks if it already exists; if not, it creates
 * and stores a new version. This approach ensures consistency and reliability in version management,
 * making it easier to maintain and update software systems. Additionally, the class includes error
 * handling to manage any issues that might arise during version retrieval.
 * ---------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * GitHub : www.github.com/PatrikEigenmann/CSharp
 * ---------------------------------------------------------------------------------------------------
 * Changelog
 * Wed 2025-01-16 File created & basic implementation created.                          Version 00.01
 * Sun 2025-01-19 Class Deactivated for now.                                            Version 00.02
 * ---------------------------------------------------------------------------------------------------
 * To Do:
 * - Create a ComboBoxDialog Window.                                                    -> Done
 * - Singleton Pattern for VersionManager doesn't work in this version.                 -> Done
 *   Class deactivated for now. 
 * --------------------------------------------------------------------------------------------------- */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Samael.WinTools
{
    /// <summary>
    /// The VersionManager class is designed to manage and track different versions of software components.
    /// It maintains a centralized list of versions, ensuring that each component’s version is easily
    /// accessible. When a version is requested, the class checks if it already exists; if not, it creates
    /// and stores a new version. This approach ensures consistency and reliability in version management,
    /// making it easier to maintain and update software systems. Additionally, the class includes error
    /// handling to manage any issues that might arise during version retrieval.
    /// </summary>
    public class VersionManager // : IVersionable
    {
        /*
        #region Framework Version

        /// <summary>
        /// The major # indicates significat changes or milestones, and stable builds in software
        /// packages. When the major # is incremented, it usually means that there are substantial
        /// updates, such as new features major improvements, or changes that might be not backward
        /// compatible. For example, moving from version 01.?? to 02.00 suggests a major overhaul
        /// or signigicant new functionality.
        /// </summary>
        private static int _Major { get; } = 0;

        /// <summary>
        /// The minor # represents smaller updates or improvements that are backwards compatible.
        /// Incrementing the the minor # typically means bug fixes, minor enhancements, or incremental
        /// improvements. For instance going from version 01.02 to 01.03 indicating a minor ubdate that
        /// enhances the existing version without breaking the compatibility.
        /// </summary>
        private static int _Minor { get; } = 1;

        /// <summary>
        /// This represents the version string of the framework being used. It typically follows
        /// a specific format, such as "Framework/Software name major.minor" (e.g., "2.1.0"),
        /// and is used to identify the exact version of the framework in use. This information
        /// is crucial for compatibility checks, debugging, and ensuring that the correct version
        /// of the framework is being utilized in the application.
        /// </summary>
        private static string FrameworkVersion { get; } = $"Samael.WinTools Framework v.{_Major:D2}.{_Minor:D2}";

        #endregion

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
        public string Component { get; } = "VersionManager";

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
            VersionManager.Instance.RegisterVersion(Component, Major, Minor);
        }

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
            return string.Empty;
        }

        #endregion

        #region Singleton Pattern

        /// <summary>
        /// This static instance of the VersionManager class is a crucial component of the
        /// Singleton pattern, ensuring that only one instance of VersionManager exists
        /// throughout the application's lifecycle.
        /// </summary>
        private static VersionManager versionManager;

        /// <summary>
        /// Provides access to the single instance of the VersionManager class, following the
        /// Singleton pattern. To ensure only one instance is created, avoid using
        /// 'VersionManager vm = new VersionManager();'. Instead, access the instance with
        /// 'VersionManager.Instance'.
        /// </summary>
        public static VersionManager Instance
        {
            get
            {
                if (versionManager == null)
                {
                    versionManager = new VersionManager();
                }
                
                return versionManager;
            }
        }
        #endregion

        #region Version Management

        /// <summary>
        /// Initializes a new instance of the VersionManager class. This constructor sets up the
        /// initial version list and assigns the starting version number for the component. It
        /// ensures that the VersionManager is ready to track and manage version changes effectively
        /// from the outset.
        /// </summary>
        public VersionManager()
        {
            SetVersion();
        }

        /// <summary>
        /// A centralized dictionary that stores versions of different components, 
        /// ensuring easy access and management of component versions.
        /// </summary>
        private Dictionary<string, Version> versionList;

        /// <summary>
        /// This method should be called by every component that wants to register its version
        /// information. By inheriting the abstract method IVersionable.SetVersion(), the
        /// component can register itself by calling
        /// VersionManager.Instance.Register("Component", Major #, Minor #).
        /// </summary>
        /// <param name="component">The name of the component registering its version information.</param>
        /// <param name="major">The major version number of the component.</param>
        /// <param name="minor">The minor version number of the component.</param>
        public void RegisterVersion(string component, int major, int minor)
        {
            if(versionList == null)
            {
               versionList = new Dictionary<string, Version>();
            }

            if (!versionList.ContainsKey(component))
            {
                versionList.Add(component, new Version(component, major, minor));
            }
        }

        /// <summary>
        /// Generates a formatted string representing the current framework version and the versions
        /// of all components managed by the VersionManager. The string includes the framework
        /// version at the top, followed by each component's name and version number in a readable
        /// format.
        /// </summary>
        /// <returns>
        /// A string containing the framework version and the versions of all components.
        /// </returns>
        public string GetVersionString()
        {
            string versionString = FrameworkVersion + "\n";

            foreach (KeyValuePair<string, Version> version in versionList)
            {
                versionString += $"{version.Value.Component} v.{version.Value.Major:D2}.{version.Value.Minor:D2}\n";
            }
            
            return versionString;
        }
        #endregion
        */

        public static string GetVersionString()
        {
            string text = "Samael.WinTools Framework v 00.01\n";

            text += "\n";
            text += "- VersionManager v 00.02 Reduced functionality.\n";
            text += "- Version        v 00.01 Currently deactivated.\n";
            text += "- IVersionable   v 00.02 Reduced functionality.\n";
            text += "- ComboBoxDialog v 00.02\n";
            text += "- TextBoxDialog  v 00.01\n";
            text += "- InfoBoxDialog  v 00.01\n";
            text += "\n";

            return text;
        }

    }
}