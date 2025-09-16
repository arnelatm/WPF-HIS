using System.Windows.Forms;
using AATM.Contracts;

namespace AATM.Core
{
    /// <summary>
    /// A concrete implementation of IMessagingService that uses a standard WinForms MessageBox.
    /// This class is specific to the UI technology and can be easily swapped out.
    /// </summary>
    public class WinFormsMessageBoxService : IMessagingService
    {
        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInformation(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}