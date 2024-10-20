/* -------------------------------------------------------------------------------------------------------------------
 * The Enigma machine is a cipher device developed and used in the early- to mid-20th century to protect commercial,
 * diplomatic, and military communication. It was employed extensively by Nazi Germany during World War II, in all
 * branches of the German military. The Enigma machine was considered so secure that it was used to encipher the most
 * top-secret messages.
 * 
 * Around December 1932 Marian Rejewski, a Polish mathematician and cryptologist at the Polish Cipher Bureau, used the
 * theory of permutations,[8] and flaws in the German military-message encipherment procedures, to break message keys
 * of the plugboard Enigma machine.
 *
 * On 26 and 27 July 1939, in Pyry, just south of Warsaw, the Poles initiated French and British military intelligence
 * representatives into the Polish Enigma-decryption techniques and equipment, including Zygalski sheets and the
 * cryptologic bomb, and promised each delegation a Polish-reconstructed Enigma (the devices were soon delivered).
 *
 * In September 1939, British Military Mission 4, which included Colin Gubbins and Vera Atkins, went to Poland,
 * intending to evacuate cipher-breakers Marian Rejewski, Jerzy Różycki, and Zygalski from the country. The
 * cryptologists, however, had been evacuated by their own superiors into Romania, at the time a Polish-allied country.
 * On the way, for security reasons, the Polish Cipher Bureau personnel had deliberately destroyed their records and
 * equipment. From Romania they traveled on to France, where they resumed their cryptological work, collaborating by
 * teletype with the British, who began work on decrypting German Enigma messages, using the Polish equipment and
 * techniques.
 * -------------------------------------------------------------------------------------------------------------------
 * Author   : Patrik Eigenmann
 * eMail    : p.eigenmann@gmx.net
 * -------------------------------------------------------------------------------------------------------------------
 * Change Log:
 * Thu 2024-09-19 File created & basic functionality implemented.                                       Version: 00.01
 * Thu 2024-09-19 Bugfix: In encrypt and decrypt, fixed an issue with '\0'                              Version: 00.02
 * Thu 2024-09-19 Saving plain text & encrypted file in MyDocuments\enigma.                             version: 00.03
 * Thu 2024-09-19 About message corrected.                                                              Version: 00.04
 * Thu 2024-09-19 Comments got updated.                                                                 Version: 00.05
 * Thu 2024-09-19 Large rotor logic inplemented.                                                        Version: 00.06
 * Thu 2024-09-19 Loading plain text & encrypted files.                                                 Version: 00.07
 * Fri 2024-09-20 Changed Version Control to a static method.                                           Version: 00.08
 * Mon 2024-09-23 Menu "Reset" implemented.                                                             Version: 00.09
 * Mon 2024-09-23 Annoying DialogBoxed "File successfully loaded" removed.                              Version: 00.10
 * Sat 2024-09-28 Extended the alphanumeric characters with Capitol letters, small letters and Numbers. Version: 00.11
 * Mon 2024-09-30 Implemented the aplicationVersion like in Java.                                       Version: 00.12
 * Mon 2024-09-30 Got rid of some "un-used variable" warnings.                                          Version: 00.13
 * Thu 2024-10-03 Implemented the class ConfigManager. And Test it out.                                 Version: 00.14
 * Thu 2024-10-03 Changed how the application title and application version # is deployed.              Version: 00.15
 * Thu 2024-10-10 Implemented the class LogManager, and tested it out.                                  Version: 00.16
 * -------------------------------------------------------------------------------------------------------------------
 * To Do:
 * Implement the logic for the large rotor, 27 * 27 = 729 key's pressed.                                    -> Done
 * Implement loading plain text or encrypted text from files.                                               -> Done
 * Implement a reset button or menu.                                                                        -> Done
 * Implement a configuration system. Samael.ConfigManager is the class and the .\config.xml the file.       -> Done
 * Implement a LogManager and Logging INFO, WARNING, and ERROR message. Update app Version                  -> Done
 * ------------------------------------------------------------------------------------------------------------------- */
using System.Windows.Forms;
using Samael;

namespace Enigma
{
    /// <summary>
    /// The EnigmaForm is the main form in the Windows application, designed to provide an intuitive and
    /// user-friendly interface for our modern remedy of the World War II Enigma encryption tool. This
    /// form exemplifies the power and flexibility of C# in a WinForms environment, making complex
    /// encryption tasks accessible and manageable for users. By implementing the IVersionable interface,
    /// it ensures that version information is easily retrievable, enhancing the maintainability and
    /// reliability of our software. The EnigmaForm class not only showcases our commitment to delivering
    /// high-quality, robust applications but also significantly improves the user experience, making
    /// encryption processes straightforward and efficient.
    /// </summary>
    public partial class EnigmaForm : Form, IVersionable
    {
        /// <summary>
        /// The major # indicates significat changes or milestones, and stable builds in software packages. When
        /// the major # is incremented, it usually means that there are substantial updates, such as new features
        /// major improvements, or changes that might be not backward compatible. For example, moving from version
        /// 01.?? to 02.00 suggests a major overhaul or signigicant new functionality.
        /// </summary>
        private static int appMajor = 0;

        /// <summary>
        /// The minor # represents smaller updates or improvements that are backwards compatible. Incrementing the
        /// the minor # typically means bug fixes, minor enhancements, or incremental improvements. For instance
        /// going from version 01.02 to 01.03 indicating a minor ubdate that enhances the existing version without
        /// breaking the compatibility.
        /// </summary>
        private static int appMinor = 4;


        /// <summary>
        /// Provides the name of the application as defined in the configuration, along with the current
        /// version number. This ensures consistency and transparency across our software deployments.
        /// It's a centralized source of truth for identifying the application and its version.
        /// This information is essential for tracking updates and maintaining version control.
        /// </summary>
        private static string AppInfo
        {
            get
            {
                /* Writing an info message into the log file. */
                LogManager.WriteMessage("Application Info created.", LogManager.INFO, typeof(EnigmaForm), typeof(EnigmaForm));
                return ConfigManager.GetParameter("appName") + " v" + string.Format("{0:D2}.{1:D2}", appMajor, appMinor);
            }
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
            /* Writing an info message into the log file. */
            LogManager.WriteMessage("Version string created.", LogManager.INFO, typeof(EnigmaForm), typeof(EnigmaForm));
            return VersionManager.GetInstance("EnigmaForm", 0, 15).ToString();
        }

        /// <summary>
        /// Represents a small rotor in an Enigma encryption machine. This rotor scrambles input letters
        /// through eletical contacts and internal wiring. It has 27 positions, changing the encryption
        /// pattern with each key press.
        /// 
        /// The small rotor works with other rotors and the reflector to produce the final encrypted output.
        /// </summary>
        private SmallRotor smrotor;

        /// <summary>
        /// Represents a medium rotor in an Enigma encryption machine. This rotor scrambles input letters
        /// through electrical contacts and internal wiring. It advances one position for every 27 key
        /// presses, altering the encryption pattern.
        /// 
        /// The medium rotor works with other rotors and the reflector to produce the final encrypted output.
        /// </summary>
        private MedRotor medrotor;

        /// <summary>
        /// Represents a large rotor in an Enigma encryption machine. This rotor scrambles input letters
        /// through electrical contacts and internal wiring. It advances one position for every 729 key
        /// presses, significantly altering the encryption pattern.
        /// 
        /// The large rotor works with other rotors and the reflector to produce the final encrypted output. 
        /// </summary>
        private LargeRotor lgrotor;

        /// <summary>
        /// Initializes the form and sets up all the necessary components for the user interface.
        /// This ensures that the application is ready for user interaction as soon as it starts.
        /// </summary>
        public EnigmaForm()
        {
            Text = AppInfo;

            InitializeComponent();

            /* Writing an info message into the log file. */
            LogManager.WriteMessage("EnigmaForm instance created.", LogManager.INFO, typeof(EnigmaForm), typeof(EnigmaForm));

            smrotor = new SmallRotor();
            medrotor = new MedRotor();
            lgrotor = new LargeRotor();
        }

        /// <summary>
        /// Displays a message box with version information for the Enigma application and its components.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = AppInfo + ":\n------------------------------------------------\n";
            message += EnigmaForm.GetVersion() + "\n";
            message += Rotor.GetVersion() + "\n";
            message += LargeRotor.GetVersion() + "\n";
            message += MedRotor.GetVersion() + "\n";
            message += SmallRotor.GetVersion() + "\n";

            message += "\n\n" + VersionManager.AddFramework();

            /* Writing an info message into the log file. */
            LogManager.WriteMessage("About button in menu pressed.", LogManager.INFO, typeof(EnigmaForm), typeof(EnigmaForm));

            MessageBox.Show(message, ConfigManager.GetParameter("about.Title"));
        }

        /// <summary>
        /// Encrypts the text from the plainText control and displays the result in the encryptText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void encrypt_Click(object sender, EventArgs e)
        {

            String plain = plainText.Text;
            //plain = plain.ToUpper();
            String cypher = "";

            for (int i = 0; i < plain.Length; i++)
            {
                cypher += EncryptChar(plain.ElementAt(i));
            }

            encryptText.Text = cypher;

            /* Writing an info message into the log file. */
            LogManager.WriteMessage("Encrypt button @ plain text pressed.", LogManager.INFO, typeof(EnigmaForm), typeof(EnigmaForm));

            smrotor.Reset();
            medrotor.Reset();
            lgrotor.Reset();
        }

        /// <summary>
        /// Decrypts the text from the encryptText control and displays the result in the plainText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void decrypt_Click(object sender, EventArgs e)
        {
            String cypher = encryptText.Text;
            //cypher = cypher.ToUpper();
            String plaintxt = "";

            for (int i = 0; i < cypher.Length; i++)
            {
                plaintxt += DecryptChar(cypher.ElementAt(i));
            }

            plainText.Text = plaintxt;

            /* Writing an info message into the log file. */
            LogManager.WriteMessage("Decrypt button @ encrypted text pressed.", LogManager.INFO, typeof(EnigmaForm), typeof(EnigmaForm));

            smrotor.Reset();
            medrotor.Reset();
            lgrotor.Reset();
        }

        /// <summary>
        /// Encryption on character level.
        /// </summary>
        /// <param name="c">Character to encrypt.</param>
        /// <returns>Encrypted character.</returns>
        private char EncryptChar(char c)
        {
            char ch = (char)0;
            try
            {
                ch = lgrotor.CharAt((int)smrotor.IndexOf(c));
                ch = lgrotor.CharAt((int)medrotor.IndexOf(ch));
            }
            catch (Exception e)
            {
                /* Writing an info message error the log file. */
                LogManager.WriteMessage(e.Message, LogManager.ERROR, typeof(EnigmaForm), typeof(EnigmaForm));

                /*
                 * If the string contains '\0' it means that's the end of the string,
                 * and because the character initialization is with a '\0' a space
                 * will not be processed and the return value of ch was = '\0' 
                 * Old Code: if (c != '\n')
                 */
                ch = c;
                return ch;
            }

            /* Writing an info message into the log file. */
            LogManager.WriteMessage("Encrypt " + c + " into " + ch, LogManager.INFO, typeof(EnigmaForm), typeof(EnigmaForm));

            smrotor.Turn();

            // If the small rotor turned 27 times,
            // turn the medium rotor.
            if (smrotor.Turns() % Rotor.AlphabetLength == 0)
                medrotor.Turn();

            // if the medium rotor turned 27 times,
            // turn the large rotor.
            if (medrotor.Turns() % Rotor.AlphabetLength == 0)
                lgrotor.Turn();

            return ch;
        }

        /// <summary>
        /// Decryption on character level.
        /// </summary>
        /// <param name="c">Character to decrypt.</param>
        /// <returns>Decrypted character.</returns>
        private char DecryptChar(char c)
        {
            char ch = (char)0;
            try
            {
                ch = medrotor.CharAt((int)lgrotor.IndexOf(c));
                ch = smrotor.CharAt((int)lgrotor.IndexOf(ch));
            }
            catch (Exception e)
            {
                /* Writing an info message error the log file. */
                LogManager.WriteMessage(e.Message, LogManager.ERROR, typeof(EnigmaForm), typeof(EnigmaForm));

                /*
                 * If the string contains '\0' it means that's the end of the string,
                 * and because the character initialization is with a '\0' a space
                 * will not be processed and the return value of ch was = '\0' 
                 * Old Code: if (c != '\n')
                 */
                ch = c;
                return ch;
            }

            /* Writing an info message into the log file. */
            LogManager.WriteMessage("Decrypt " + c + " into " + ch, LogManager.INFO, typeof(EnigmaForm), typeof(EnigmaForm));

            smrotor.Turn();

            // If the small rotor turned 27 times,
            // turn the medium rotor.
            if (smrotor.Turns() % Rotor.AlphabetLength == 0)
                medrotor.Turn();

            // if the medium rotor turned 27 times,
            // turn the large rotor.
            if (medrotor.Turns() % Rotor.AlphabetLength == 0)
                lgrotor.Turn();

            return ch;
        }

        /// <summary>
        /// Opens a SaveFileDialog to save the text from the plainText control to a file.
        /// Creates the "enigma" directory in the user's Documents folder if it doesn't exist.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnSavePlain_Click(object sender, EventArgs e)
        {
            string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string directoryPath = Path.Combine(userDocumentsPath, "enigma");

            try
            {
                // Create the directory if it doesn't exist
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Always open a SaveFileDialog
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = directoryPath;
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = saveFileDialog.FileName;

                        // Create a StreamWriter to write text to the file
                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            writer.Write(plainText.Text);
                        }
                        /*
                         * Replace this MessageBox with some sort of MessageHandler. A class that can write
                         * Log files. The Log files need to have four categories. INFO / WARNING / ERROR / DEBUG.
                         * For now, it's just commented out.
                         */
                        //MessageBox.Show("File saved successfully!");
                    }
                    else
                    {
                        /*
                         * Replace this MessageBox with some sort of MessageHandler. A class that can write
                         * Log files. The Log files need to have four categories. INFO / WARNING / ERROR / DEBUG.
                         * For now, it's just commented out.
                         */
                        //MessageBox.Show("Save operation was cancelled.");
                    }
                }
            }
            catch (Exception ex)
            {
                /* Writing an info message error the log file. */
                LogManager.WriteMessage(ex.Message, LogManager.INFO, typeof(EnigmaForm), typeof(EnigmaForm));
            }
        }

        /// <summary>
        /// Opens a SaveFileDialog to save the text from the encryptText control to a file with a .enigma extension.
        /// Creates the "enigma" directory in the user's Documents folder if it doesn't exist.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnSaveEncrypt_Click(object sender, EventArgs e)
        {
            string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string directoryPath = Path.Combine(userDocumentsPath, "enigma");

            try
            {
                // Create the directory if it doesn't exist
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Always open a SaveFileDialog
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = directoryPath;
                    saveFileDialog.Filter = "Enigma files (*.enigma)|*.enigma|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = "enigma";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = saveFileDialog.FileName;

                        // Create a StreamWriter to write text to the file
                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            writer.Write(encryptText.Text);
                        }
                        /*
                         * Replace this MessageBox with some sort of MessageHandler. A class that can write
                         * Log files. The Log files need to have four categories. INFO / WARNING / ERROR / DEBUG.
                         * For now, it's just commented out.
                         */
                        //MessageBox.Show("File saved successfully!");
                    }
                    else
                    {
                        /*
                         * Replace this MessageBox with some sort of MessageHandler. A class that can write
                         * Log files. The Log files need to have four categories. INFO / WARNING / ERROR / DEBUG.
                         * For now, it's just commented out.
                         */
                        //MessageBox.Show("Save operation was cancelled.");
                    }
                }
            }
            catch (Exception ex)
            {
                /* Writing an info message error the log file. */
                LogManager.WriteMessage(ex.Message, LogManager.ERROR, typeof(EnigmaForm), typeof(EnigmaForm));
            }
        }

        /// <summary>
        /// Opens an OpenFileDialog to load a plain text file into the richTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnLoadPlain_Click(object sender, EventArgs e)
        {
            string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string directoryPath = Path.Combine(userDocumentsPath, "enigma");

            try
            {
                // Create the directory if it doesn't exist
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Always open an OpenFileDialog
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = directoryPath;
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.DefaultExt = "txt";
                    openFileDialog.AddExtension = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openFileDialog.FileName;

                        // Load the file into the RichTextBox
                        plainText.LoadFile(fileName, RichTextBoxStreamType.PlainText);
                        /*
                         * Replace this MessageBox with some sort of MessageHandler. A class that can write
                         * Log files. The Log files need to have four categories. INFO / WARNING / ERROR / DEBUG.
                         * For now, it's just commented out.
                         */
                        //MessageBox.Show("File loaded successfully!");
                    }
                    else
                    {
                        /*
                         * Replace this MessageBox with some sort of MessageHandler. A class that can write
                         * Log files. The Log files need to have four categories. INFO / WARNING / ERROR / DEBUG.
                         * For now, it's just commented out.
                         */
                        //MessageBox.Show("Load operation was cancelled.");
                    }
                }
            }
            catch (Exception ex)
            {
                /*
                 * Replace this MessageBox with some sort of MessageHandler. A class that can write
                 * Log files. The Log files need to have four categories. INFO / WARNING / ERROR / DEBUG.
                 * For now, it's just commented out.
                 */
                //MessageBox.Show("An error occurred: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Opens an OpenFileDialog to load an .enigma file into the richTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnLoadEncrypt_Click(object sender, EventArgs e)
        {
            string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string directoryPath = Path.Combine(userDocumentsPath, "enigma");

            try
            {
                // Create the directory if it doesn't exist
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Always open an OpenFileDialog
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = directoryPath;
                    openFileDialog.Filter = "Enigma files (*.enigma)|*.enigma|All files (*.*)|*.*";
                    openFileDialog.DefaultExt = "enigma";
                    openFileDialog.AddExtension = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openFileDialog.FileName;

                        // Load the file into the RichTextBox
                        encryptText.LoadFile(fileName, RichTextBoxStreamType.PlainText);
                        /*
                         * Replace this MessageBox with some sort of MessageHandler. A class that can write
                         * Log files. The Log files need to have four categories. INFO / WARNING / ERROR / DEBUG.
                         * For now, it's just commented out.
                         */
                        //MessageBox.Show("File loaded successfully!");
                    }
                    else
                    {
                        /*
                         * Replace this MessageBox with some sort of MessageHandler. A class that can write
                         * Log files. The Log files need to have four categories. INFO / WARNING / ERROR / DEBUG.
                         * For now, it's just commented out.
                         */
                        //MessageBox.Show("Load operation was cancelled.");
                    }
                }
            }
            catch (Exception ex)
            {

                /*
                 * Replace this MessageBox with some sort of MessageHandler. A class that can write
                 * Log files. The Log files need to have four categories. INFO / WARNING / ERROR / DEBUG.
                 * For now, it's just commented out.
                 */
                //MessageBox.Show("An error occurred: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// In here is what happens when the menu "Reset" is pressed. Both text boxes will be clear,
        /// so the app is ready for new encryptions.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             * Both RichTextBoxes (plain & encrypted) are getting wiped clean.
             */
            plainText.Clear();
            encryptText.Clear();
        }
    }
}