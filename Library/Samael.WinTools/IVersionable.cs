/* ------------------------------------------------------------------------------------------------------
 * The IVersionable interface is a crucial component for any software system that requires version control.
 * It standardizes how version information is retrieved across different objects, ensuring consistency
 * and reliability. By implementing this interface, any class can easily provide its version details,
 * which is essential for tracking updates and maintaining compatibility. This streamlined approach
 * simplifies version management, making it easier to handle software updates and ensure all components
 * are up-to-date. In essence, IVersionable is the backbone of efficient version control in our software
 * ecosystem.
 * ------------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * GitHub : www.github.com/PatrikEigenmann/CSharp
 * ------------------------------------------------------------------------------------------------------
 * Changelog
 * Wed 2025-01-16	File created & basic implementation created.                            Version 00.01
 * ------------------------------------------------------------------------------------------------------ */
using System;

namespace Samael.WinTools
{
    /// <summary>
    /// The IVersionable interface is a crucial component for any software system that requires version control.
    /// It standardizes how version information is retrieved across different objects, ensuring consistency and
    /// reliability. By implementing this interface, any class can easily provide its version details, which is
    /// essential for tracking updates and maintaining compatibility. This streamlined approach simplifies
    /// version management, making it easier to handle software updates and ensure all components are up-to-date.
    /// In essence, IVersionable is the backbone of efficient version control in our software ecosystem.
    /// </summary>
    internal interface IVersionable
    {
        /// <summary>
        /// The major # indicates significat changes or milestones, and stable builds in software packages. When
        /// the major # is incremented, it usually means that there are substantial updates, such as new features
        /// major improvements, or changes that might be not backward compatible. For example, moving from version
        /// 01.?? to 02.00 suggests a major overhaul or signigicant new functionality.
        /// </summary>
        int Major { get; }

        /// <summary>
        /// The minor # represents smaller updates or improvements that are backwards compatible. Incrementing the
        /// the minor # typically means bug fixes, minor enhancements, or incremental improvements. For instance
        /// going from version 01.02 to 01.03 indicating a minor ubdate that enhances the existing version without
        /// breaking the compatibility.
        /// </summary>
        int Minor { get; }


        /// <summary>
        /// 
        /// </summary>
        string Component { get; }

        /// <summary>
        /// The SetIVersion method is a vital feature for IVersionable interface. It provides a
        /// standardized way to retrieve version information, ensuring that every component can clearly
        /// communicate its version. This method is essential for maintaining consistency and reliability
        /// across the system, making it easier to manage updates and track changes. By implementing
        /// GetIVersion, we ensure that our software remains robust, up-to-date, and easy to maintain,
        /// ultimately enhancing the overall user experience.
        /// </summary>
        /// <returns>
        /// A formatted string where the name of the component is the class or object name, 
        /// and the version number consists of a major and a minor number, each formatted to two digits.
        /// </returns>
        void SetVersion();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}
