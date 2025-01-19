/*
 * 
 *  */ 
using System;

namespace Samael.WinTools
{
    /// <summary>
    /// 
    /// </summary>
    internal class Version
    {
        /// <summary>
        /// 
        /// </summary>
        public int Major { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public int Minor { get; set; } = 1;


        /// <summary>
        /// 
        /// </summary>
        public string Component { get; set; } = "Version";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        public Version(string component, int major, int minor)
        {
            Component = component;
            Major = major;
            Minor = minor;

            SetVersion();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetVersion()
        {
            VersionManager.Instance.RegisterVersion(Component, Major, Minor);
        }
    }
}
