using System.IO;
using System.Windows.Forms;

namespace AATM.Core.UI.Logging
{

    public partial class FrmLogViewer
    {
        public FrmLogViewer()
        {
            InitializeComponent();
        }

        public void LoadLogs(string logFilePath)
        {
            if (File.Exists(logFilePath))
            {
                string logContent = File.ReadAllText(logFilePath);
                // Assuming you have a TextBox or a RichTextBox named txtLogs
                txtLogs.Text = logContent;
            }
            else
            {
                // Assuming you have a Label or similar control to show a message
                MessageBox.Show("Log file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}