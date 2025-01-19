/* -------------------------------------------------------------------------------------------------------
 * Within the heart of your code lies the LogManager class, a vigilant guardian of warnings and errors.
 * This class, with its constants WARNING and ERROR, communicates through the showMessage method,
 * presenting messages in a clear dialog box.
 *
 * Its strength, however, lies in the writeMessage methods, recording messages into a centralized log file,
 * each entry stamped with a precise timestamp. Depending on the log type, messages are tagged as WRN for
 * warnings, ERR for errors, and INF for informational entries. Handle these messages carefully to avoid a
 * trail of lingering issues in your logs.
 * -------------------------------------------------------------------------------------------------------
 * Author:	Patrik Eigenmann
 * eMail:	p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------
 * Change Log:
 * 
 * Thu 2024-10-10 Class created and basic functionality implemented.					    Version: 00.01
 * Thu 2024-10-10 Changed the file extension from .log to .csv                              Version: 00.02
 * Thu 2024-10-10 Changed APP_NAME from ConfigManager.GetParameter("appName"); to           Version: 00.03
 *                  Process.GetCurrentProcess().ProcessName;
 * Fri 2024-10-11 Corrected the LogManager, process name and class name is now dynamically. Version: 00.04 
 * -------------------------------------------------------------------------------------------------------
 */
using System;
using System.IO;
using System.Diagnostics;

namespace Samael
{
    /// <summary>
    /// Within the heart of your code lies the LogManager class, a vigilant guardian of warnings and errors.
    /// This class, with its constants WARNING and ERROR, communicates through the showMessage method,
    /// presenting messages in a clear dialog box.
    /// 
    /// Its strength, however, lies in the writeMessage methods, recording messages into a centralized log file,
    /// each entry stamped with a precise timestamp. Depending on the log type, messages are tagged as WRN for
    /// warnings, ERR for errors, and INF for informational entries. Handle these messages carefully to avoid a
    /// trail of lingering issues in your logs.
    /// </summary>
    public class LogManager : IVersionable
    {
        /// <summary>
        /// Log level INFO
        /// </summary>
        public const int INFO = 1;      // 001

        /// <summary>
        /// Log level WARNING
        /// </summary>
        public const int WARNING = 2;   // 010

        /// <summary>
        /// Log level ERROR
        /// </summary>
        public const int ERROR = 4;     // 100

        /// <summary>
        /// 
        /// </summary>
        private static int internal_flag = 0;

        /// <summary>
        /// 
        /// </summary>
        public static int Flag {
            set { internal_flag = value; }              
        }

        /** Log directory based on OS */
        private static readonly string LOG_DIR;

        /// <summary>
        /// This block of code ensures that the configuration settings are loaded as soon as the class is
        /// accessed for the first time. It initialize the class with checking the operation system and
        /// sets the log path accordingly. After calling the construction of the class, the class is ready
        /// to write log files.
        /// </summary>
        static LogManager()
        {
            string os = Environment.OSVersion.Platform.ToString().ToLower();
            if (os.Contains("win"))
            {
                LOG_DIR = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "samael", "logs");
            }
            else
            {
                LOG_DIR = "/usr/local/samael/logs";
            }
            Directory.CreateDirectory(LOG_DIR); // Ensure directory exists
        }

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
            return VersionManager.GetInstance("LogManager", 0, 2).ToString();
        }

        /// <summary>
        /// Logs a message with a specified type, process, and component class.
        /// This method ensures comprehensive logging across both application and framework components,
        /// enabling precise tracking and troubleshooting. By capturing the process and component details,
        /// it provides a robust mechanism for monitoring and maintaining the health of your system.
        /// This approach ensures transparency and consistency, ultimately supporting informed decision-making
        /// and seamless operations.
        /// </summary>
        /// <param name="message">The log message to be recorded.</param>
        /// <param name="type">The type of log message (e.g., INFO, WARNING, ERROR).</param>
        /// <param name="processType">The class representing the process generating the log.</param>
        /// <param name="componentType">The class from which the log message originated.</param>
        public static void WriteMessage(string message, int type, Type processType, Type componentType)
        {
            if ((internal_flag & type) == type)
            {
                StreamWriter? outStream = null;
                try
                {
                    string logFile = Path.Combine(LOG_DIR, "samael.log");
                    outStream = new StreamWriter(new FileStream(logFile, FileMode.Append, FileAccess.Write));

                    string sDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string logType;
                    switch (type)
                    {
                        case WARNING:
                            logType = "WRN";
                            break;
                        case ERROR:
                            logType = "ERR";
                            break;
                        default:
                            logType = "INF";
                            break;
                    }
                    string processName = string.IsNullOrEmpty(processType.Namespace) ? processType.Name : processType.Namespace;
                    string componentName = componentType.Name;
                    string logEntry = $"{sDate},{processName},{componentName},{logType},{message}";
                    outStream.WriteLine(logEntry);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    outStream?.Close();
                }
            }
        }
    }
}