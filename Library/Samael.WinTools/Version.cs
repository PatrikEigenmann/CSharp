/* --------------------------------------------------------------------------------------------
 * The Version class encapsulates the version information for a software component. It includes
 * properties for the major,and minor, as well as the component name. This class is used to manage
 * and track the version history of components, ensuring accurate version control and facilitating
 * updates and compatibility checks.
 * --------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * GitHub : www.github.com/PatrikEigenmann/CSharp
 * --------------------------------------------------------------------------------------------
 * Sat 2025-01-18 File created.                                                  Version: 00.01
 * -------------------------------------------------------------------------------------------- */
using System;

namespace Samael.WinTools
{
    /// <summary>
    /// The Version class encapsulates the version information for a software component. It includes
    /// properties for the major,and minor, as well as the component name. This class is used to manage
    /// and track the version history of components, ensuring accurate version control and facilitating
    /// updates and compatibility checks.
    /// </summary>
    internal class Version
    {
 
        /// <summary>
        /// Major version number of the component.
        /// </summary>
        public int Major { get; set; } = 0;

        /// <summary>
        /// The minor # represents smaller updates or improvements that are backwards compatible.
        /// Incrementing the the minor # typically means bug fixes, minor enhancements, or incremental
        /// improvements. For instance going from version 01.02 to 01.03 indicating a minor ubdate that
        /// enhances the existing version without breaking the compatibility.
        /// </summary>
        public int Minor { get; set; } = 1;


        /// <summary>
        /// The component name refers to the specific name of the class or object that implements the
        /// IVersionable interface. This name is used to uniquely identify the component within the
        /// system, ensuring that version control and management processes can accurately track changes
        /// and updates to the component over time.
        /// </summary>
        public string Component { get; set; } = "Version";

        /// <summary>
        /// The SetVersion method is a vital feature for IVersionable interface. It provides a
        /// standardized way to retrieve version information, ensuring that every component can clearly
        /// communicate its version. This method is essential for maintaining consistency and reliability
        /// across the system, making it easier to manage updates and track changes. By implementing
        /// GetIVersion, we ensure that our software remains robust, up-to-date, and easy to maintain,
        /// ultimately enhancing the overall user experience.
        /// </summary>
        private void SetVersion()
        {
            //VersionManager.Instance.RegisterVersion(Component, Major, Minor);
        }

        /// <summary>
        /// Constructor for the Version class.
        /// </summary>
        /// <param name="component">Name of the component.</param>
        /// <param name="major">Major version number.</param>
        /// <param name="minor">Minor version number.</param>
        public Version(string component, int major, int minor)
        {
            Component = component;
            Major = major;
            Minor = minor;

            SetVersion();
        }
    }
}
