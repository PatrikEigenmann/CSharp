/* -------------------------------------------------------------------------------------------------
 * The VersionManager class is designed to manage and track different versions of software components.
 * It maintains a centralized list of versions, ensuring that each component’s version is easily
 * accessible. When a version is requested, the class checks if it already exists; if not, it creates
 * and stores a new version. This approach ensures consistency and reliability in version management,
 * making it easier to maintain and update software systems. Additionally, the class includes error
 * handling to manage any issues that might arise during version retrieval.
 * --------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * GitHub : www.github.com/PatrikEigenmann/CSharp
 * --------------------------------------------------------------------------------------------------
 * Changelog
 * Wed 2024-09-18	File created & basic implementation created.                        Version 00.01
 * Fri 2024-09-20   Version control implemented.                                        Version 00.02
 * Fri 2024-09-20   Version control changed to static.                                  Version 00.03
 * Mon 2024-09-23   Fixed a possible null reference to a non-nullable instance.         Version 00.04
 * Mon 2024-09-23   Implemented frameworkVersion as a const string.                     Version 00.05
 * Wed 2024-10-02   ConfigManager added.                                                Version 00.06
 * Thu 2024-10-10   LogManager added.                                                   Version 00.07
 * ---------------------------------------------------------------------------------------------------
 * To Do:
 * - Implementing a constant of the Samael framework version string.                            -> Done
 * - Adding the class ConfigManager to the framework, updating the version string.              -> Done
 * - Adding the class LogManager to the framework, updating the version string.                 -> Done
 * --------------------------------------------------------------------------------------------------- */
using System;
using System.Collections;

namespace Samael
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
        /// <summary>
        /// 
        /// </summary>
        private const string frameworkVersion = "Samael Framework v00.03";

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
            LogManager.WriteMessage("Version String created.", LogManager.INFO, typeof(VersionManager), typeof(VersionManager));
            return VersionManager.GetInstance("VersionManager", 0, 7).ToString();
        }

        /// <summary>
        /// A centralized dictionary that stores versions of different components, 
        /// ensuring easy access and management of component versions.
        /// </summary>
        private static Dictionary<string, Version> versionList = new Dictionary<string, Version>();

        /// <summary>
        /// Retrieves the version of a specified component. If the version does not exist, 
        /// it creates and stores a new version.
        /// </summary>
        /// <param name="component">The name of the component.</param>
        /// <param name="major">The major version number.</param>
        /// <param name="minor">The minor version number.</param>
        /// <returns>The version of the specified component.</returns>
        public static Version GetInstance(string component, int major, int minor)
        {
            Version version;

            try
            {
                /* ----- Part of Warning Fix v00.04 ------
                 * Change "version" to a nullable object. 
                 */
                if (!versionList.TryGetValue(component, out version!))
                {
                    version = new Version(component, major, minor);
                    versionList.Add(component, version);

                }
                return version;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                /* ----- Part of Warning Fix v00.04 ------
                 * It probably never goes here, but if it does,
                 * let's make sure that a new Version object is created.
                 */
                version = new Version(component, major, minor);
                versionList.Add(component, version);
                return version;
            }
        }

        /// <summary>
        /// The AddFramework method constructs a string message that includes the version
        /// information from various components. It starts with a the version # of the
        /// Samael Framework. Then, it appends the version details retrieved from four
        /// different sources: IVersionable, Utility, VersionManager, and Version. Each
        /// version detail is added on a new line. Finally, the complete message is returned.
        /// This method is useful for consolidating version information from multiple sources
        /// into a single string.
        /// </summary>
        /// <returns>
        /// A string that starts with a base message and includes version information from
        /// multiple sources, each on a new line. This provides a consolidated view of all
        /// relevant version details in one place.
        /// </returns>
        public static string AddFramework()
        {
            String message = VersionManager.frameworkVersion + ":\n------------------------------------------------\n";
            message += ConfigManager.GetVersion() + "\n";
            message += IVersionable.GetIVersion() + "\n";
            message += LogManager.GetVersion() + "\n";
            message += Utility.GetVersion() + "\n";
            message += VersionManager.GetVersion() + "\n";
            message += Version.GetVersion() + "\n";

            return message;
        }
    }
}