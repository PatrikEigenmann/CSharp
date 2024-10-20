/* -------------------------------------------------------------------------------------------------------
 * The ConfigManager class is responsible for managing configuration parameters stored in an XML file. It
 * provides methods to load these parameters into a Config object and update the XML file with any changes
 * made to the configuration. The class uses the Config class to handle the key-value pairs of
 * configuration settings. It includes functionality to read from and write to the XML file, ensuring that
 * the application’s configuration can be easily maintained and modified.
 * -------------------------------------------------------------------------------------------------------
 * Author:	Patrik Eigenmann
 * eMail:	p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------
 * Change Log:
 * Sat 2024-09-14 File created.																Version: 00.01
 * Sat 2024-09-14 Samael.VersionControl implemented.										Version: 00.02
 * Wed 2024-09-18 Added the method public static String getParameter(String keyIn).			Version: 00.03
 * Thu 2024-10-03 Changed the parameter key to name.                                        Version: 00.04
 * -------------------------------------------------------------------------------------------------------
 * To Do:
 * 
 * -------------------------------------------------------------------------------------------------------*/
using System;
using System.Xml;

namespace Samael
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigManager : IVersionable
    {

        /// <summary>
        /// The CONFIG_FILE is a constant string that specifies the path to the XML configuration file.
        /// This file, named config.xml, is located in the current directory of the application.
        /// The CONFIG_FILE constant is used throughout the ConfigManager class to reference the
        /// configuration file for loading and updating configuration parameters.
        /// </summary>
        private const String CONFIG_FILE = ".\\config.xml";

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
            return VersionManager.GetInstance("ConfigManager", 0, 4).ToString();
        }

        /// <summary>
        /// This part of the program sets up a shared list of settings that the application will use.
        /// It ensures that there is only one instance of these settings, making them easily accessible
        /// whenever needed.
        /// </summary>
        private static Dictionary<string, string> configMap = new Dictionary<string, string>();

        /// <summary>
        /// This block of code ensures that the configuration settings are loaded as soon as the class is
        /// accessed for the first time. It calls the LoadConfig() method to initialize the settings,
        /// making them ready for use throughout the application.
        /// </summary>        
        static ConfigManager()
        {
            LoadConfig();
        }

        /// <summary>
        /// The LoadConfig method is a cornerstone of our configuration management strategy. It embodies
        /// our commitment to maintaining a seamless and dynamic configuration environment. By leveraging
        /// advanced XML processing techniques, this method ensures that our configuration parameters are
        /// not only stored efficiently but also updated with precision and clarity.
        ///
        /// At its core, LoadConfig transforms our in-memory configuration data into a well-structured
        /// XML document. It meticulously organizes the parameters, ensuring they are sorted and easily
        /// accessible. This method underscores our dedication to data integrity and accessibility,
        /// providing a robust framework for future enhancements and scalability.
        ///
        /// In essence, LoadConfig is more than just a method; it’s a testament to our forward-thinking
        /// approach in software development. It encapsulates our vision of creating adaptable, maintainable,
        /// and high-performing applications that can effortlessly evolve with changing requirements.
        /// </summary>
        public static void LoadConfig()
        {
            try
            {
                string configFile = ConfigManager.CONFIG_FILE;
                if (!File.Exists(configFile))
                {
                    return;
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(configFile);
                XmlNodeList nodeList = doc.GetElementsByTagName("parameter");

                foreach (XmlNode node in nodeList)
                {
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        XmlElement element = (XmlElement)node;
                        string key = element.GetAttribute("name");
                        string value = element.InnerText;
                        configMap[key] = value;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Retrieves the value of a configuration parameter based on the provided key.
        /// </summary>
        /// <param name="keyIn">The key for the desired configuration parameter.</param>
        /// <returns>The value associated with the provided key.</returns>
        public static string? GetParameter(string keyIn)
        {
            return configMap.TryGetValue(keyIn, out string? value) ? value : null;
        }
    }
}