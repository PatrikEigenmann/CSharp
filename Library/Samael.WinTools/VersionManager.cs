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
 * Wed 2021-01-16	File created & basic implementation created.                        Version 00.01
 * ---------------------------------------------------------------------------------------------------
 * To Do:
 * - Implementing a constant of the Samael framework version string.                            -> Done
 * - Adding the class ConfigManager to the framework, updating the version string.              -> Done
 * - Adding the class LogManager to the framework, updating the version string.                 -> Done
 * --------------------------------------------------------------------------------------------------- */
using System;
using System.Collections;
using System.Collections.Generic;

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
    public class VersionManager : IVersionable
    {
        #region Framework Version
        
        /// <summary>
        /// Major version number of the framework.
        /// </summary>
        private static int _Major { get; } = 0;

        /// <summary>
        /// Minor version number of the framework.
        /// </summary>
        private static int _Minor { get; } = 1;

        /// <summary>
        /// Framework version string
        /// </summary>
        private static string FrameworkVersion { get; } = $"Samael.WinTools Framework v.{_Major:D2}.{_Minor:D2}";

        #endregion

        #region IVersionable Implementation

        /// <summary>
        /// Major version number of the component.
        /// </summary>
        public int Major { get; } = 0;

        /// <summary>
        /// Minor version number of the component.
        /// </summary>
        public int Minor { get; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public string Component { get; } = "VersionManager";

        /// <summary>
        /// 
        /// </summary>
        public void SetVersion()
        {
            VersionManager.Instance.RegisterVersion(Component, Major, Minor);
        }

        #endregion

        #region Singleton Pattern

        /// <summary>
        /// This static instance of the VersionManager class is a crucial component of the
        /// Singleton pattern, ensuring that only one instance of VersionManager exists
        /// throughout the application's lifecycle.
        /// </summary>
        private static readonly VersionManager versionManager = new VersionManager();

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
                return versionManager;
            }
        }
        #endregion

        #region Version Management

        public VersionManager()
        {
            SetVersion();
        }

        /// <summary>
        /// A centralized dictionary that stores versions of different components, 
        /// ensuring easy access and management of component versions.
        /// </summary>
        private Dictionary<string, Version> versionList = new Dictionary<string, Version>();

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
            if (!versionList.ContainsKey(component))
            {
                versionList.Add(component, new Version(component, major, minor));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

    }
}