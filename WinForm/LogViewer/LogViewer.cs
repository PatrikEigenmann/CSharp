/* -----------------------------------------------------------------------------------------------
 * LogViewer.cs - This class is a state-of-the-art log management tool crafted to revolutionize
 * the way you interact with log files. Designed with both efficiency and user experience in mind,
 * LogViewer offers an intuitive, powerful, and elegant solution for all your logging needs of 
 * Applications with the Samael-Framework.
 * 
 * Navigate through your logs with ease. The LogViewer class boasts a sleek design and clear
 * layout, ensuring that even the most extensive log files are presented in an easily digestible
 * format. Say goodbye to the days of endless scrolling and searching; find what you need, when you
 * need it.
 * 
 * Dynamic Filtering: LogViewer's powerful filtering capabilities allow you to zero in on the
 * information that matters most. Whether you're looking for specific log levels or entries from
 * particular modules, our advanced filtering system ensures you can quickly and effortlessly
 * extract valuable insights from your data.
 * -----------------------------------------------------------------------------------------------
 * Author:	Patrik Eigenmann
 * eMail:	p.eigenmann@gmx.net
 * -----------------------------------------------------------------------------------------------
 * Change Log:
 * Tue 2025-01-15 File created.													    Version: 00.01
 * ----------------------------------------------------------------------------------------------- */
using System.Data;
using System.Reflection;
using System.Windows.Forms;

using Samael.WinTools; 

namespace LogViewer
{
    /// <summary>
    /// The class LogViewer is a state-of-the-art log management tool crafted to revolutionize
    /// the way you interact with log files.Designed with both efficiency and user experience in
    /// mind, LogViewer offers an intuitive, powerful, and elegant solution for all your logging
    /// needs of Applications with the Samael-Framework.
    /// 
    /// Navigate through your logs with ease.The LogViewer class boasts a sleek design and clear
    /// layout, ensuring that even the most extensive log files are presented in an easily digestible
    /// format.Say goodbye to the days of endless scrolling and searching; find what you need,
    /// when you need it.
    /// 
    /// Dynamic Filtering: LogViewer's powerful filtering capabilities allow you to zero in on the
    /// information that matters most.Whether you're looking for specific log levels or entries from
    /// particular modules, our advanced filtering system ensures you can quickly and effortlessly
    /// extract valuable insights from your data.
    /// </summary>
    public partial class LogViewer : Form
    {
        /// <summary>
        /// Represents the major version number of the application.
        /// This property is used to track the major release version,
        /// which is incremented for significant updates or changes
        /// that may include new features, modifications, or potentially
        /// breaking changes.
        /// </summary>
        private int Major { get; set; } = 0;

        /// <summary>
        /// Represents the minor version number of the application.
        /// This property is used to track the minor release version,
        /// which is incremented for smaller updates, bug fixes, or
        /// incremental improvements that do not include major changes.
        /// </summary>
        private int Minor { get; set; } = 1;

        /// <summary>
        /// Gets the formatted version string of the application.
        /// The version is composed of the major and minor version
        /// numbers, formatted as "MM.mm" where MM is the two-digit
        /// major version and mm is the two-digit minor version.
        /// Example: "01.01" for Major = 1 and Minor = 1.
        /// </summary>
        private string Version
        {
            get
            {
                return $"{Major:D2}.{Minor:D2}";
            }
        }

        /// <summary>
        /// Gets or sets the directory path where log files are stored.
        /// This property is used to specify the location of log files
        /// for the application, allowing for easy access and management
        /// of log data.
        /// </summary>
        private string LogDir { get; set; }

        /// <summary>
        /// Initializes a new instance of the LogViewer class.
        /// Sets the title of the form to include the version number
        /// and initializes all the other components of the form.
        /// </summary>
        public LogViewer()
        {
            // Set the title of the form
            Text = $"Log Viewer {Version}";

            // Initialize all the other components
            InitializeComponent();

            string os = Environment.OSVersion.Platform.ToString().ToLower();
            if (os.Contains("win"))
            {
                LogDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "samael", "logs");
            }
            else
            {
                LogDir = "/usr/local/samael/logs";
            }

            loadLog();
        }

        /// <summary>
        /// Handles the event triggered to load the log data.
        /// This method is called when a specific event occurs (e.g., a button click)
        /// and it internally calls the loadLog method to process and display the log data.
        /// </summary>
        /// <param name="sender">The source of the event (typically a control).</param>
        /// <param name="e">An EventArgs object containing event data.</param>
        private void loadLog(object sender, EventArgs e)
        {
            loadLog();
        }

        /// <summary>
        /// Loads the log file created by applications based on the Samael framework
        /// from the specified log directory. This method processes and displays
        /// the log data within the application.
        /// </summary>
        private void loadLog()
        {
            string logFilePath = Path.Combine(LogDir, "samael.log");

            // Create a DataTable to hold the log data
            DataTable dataTable = new DataTable();

            // Define the columns based on the CSV structure
            dataTable.Columns.Add("Date", typeof(DateTime));
            dataTable.Columns.Add("Application", typeof(string));
            dataTable.Columns.Add("Module", typeof(string));
            dataTable.Columns.Add("Level", typeof(string));
            dataTable.Columns.Add("Message", typeof(string));

            // Read the log file
            using (StreamReader reader = new StreamReader(logFilePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line into fields based on the comma separator
                    string[] fields = line.Split(',');

                    // Create a new DataRow and populate it with the fields
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["Date"] = DateTime.Parse(fields[0]);
                    dataRow["Application"] = fields[1];
                    dataRow["Module"] = fields[2];
                    dataRow["Level"] = fields[3];
                    dataRow["Message"] = fields[4];

                    // Add the DataRow to the DataTable
                    dataTable.Rows.Add(dataRow);
                }
            }

            // Bind the DataTable to the DataGridView
            logData.DataSource = dataTable;
        }

        /// <summary>
        /// Handles the event triggered to filter the log data.
        /// This method is called when a specific event occurs (e.g., a filter action)
        /// and processes the log data to display only the relevant entries
        /// based on the specified filter criteria.
        /// </summary>
        /// <param name="sender">The source of the event (typically a control).</param>
        /// <param name="e">An EventArgs object containing event data.</param>
        private void filterLog(object sender, EventArgs e)
        {
            loadLog();

            string? filter = ShowFilterDialog();

            if (filter != null)
            {
                DataTable dataTable = (DataTable)logData.DataSource;

                if (dataTable != null)
                {
                    DataView dataView = new DataView(dataTable);
                    if (filter != "ALL")
                    {
                        dataView.RowFilter = $"Level = '{filter}'";
                    }
                    else
                    {
                        dataView.RowFilter = string.Empty;
                    }

                    logData.DataSource = dataView;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string? ShowFilterDialog()
        {
            string[] filters = new string[] { "ALL", "INF", "WRN", "ERR" };
            using (Samael.WinTools.ComboBoxDialog chooseFilterDialog = new Samael.WinTools.ComboBoxDialog("Choose Filter", "Choose your filter:", filters))
            {
                if (chooseFilterDialog.ShowDialog() == DialogResult.OK)
                {
                    return chooseFilterDialog.SelectedItem;
                }
            }

            return null;
        }

        /// <summary>
        /// Handles the event triggered to clear the log data.
        /// This method is called when a specific event occurs (e.g., a clear action)
        /// and removes all entries from the log display, effectively resetting it.
        /// </summary>
        /// <param name="sender">The source of the event (typically a control).</param>
        /// <param name="e">An EventArgs object containing event data.</param>
        private void clearLog(object sender, EventArgs e)
        {
            try
            {
                string logFilePath = Path.Combine(LogDir, "samael.log");

                // Overwrite the log file with an empty string
                File.WriteAllText(logFilePath, string.Empty);

                // Reload the log to reflect the changes
                loadLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while clearing the log: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Text Text Text\n";

            text += VersionManager.Instance.GetVersionString();

            MessageBox.Show(text, "About Log Viewer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
