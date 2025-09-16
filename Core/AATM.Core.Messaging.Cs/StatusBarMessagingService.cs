// A concrete implementation of IMessagingService that displays messages
// in a StatusStrip control on a WinForms form.

using System;
using System.Drawing;
using System.Windows.Forms;
using AATM.Contracts;

namespace AATM.Core
{
    /// <summary>
    /// A concrete implementation of IMessagingService that displays messages
    /// in a StatusStrip control on a WinForms form.
    /// </summary>
    public class StatusBarMessagingService : IMessagingService
    {
        private readonly ToolStripStatusLabel _statusLabel;
        private readonly StatusStrip _statusStrip;

        /// <summary>
        /// Initializes a new instance of the StatusBarMessagingService.
        /// </summary>
        /// <param name="statusStrip">The StatusStrip control to use for displaying messages.</param>
        public StatusBarMessagingService(StatusStrip statusStrip)
        {
            if (statusStrip == null)
            {
                throw new ArgumentNullException(nameof(statusStrip), "StatusStrip cannot be null.");
            }

            // The Check for an existing ToolStripStatusLabel
            if (statusStrip.Items.Count == 0 || !(statusStrip.Items[0] is ToolStripStatusLabel))
            {
                throw new ArgumentException("The StatusStrip must contain at least one ToolStripStatusLabel.", nameof(statusStrip));
            }

            _statusStrip = statusStrip;
            _statusLabel = (ToolStripStatusLabel)statusStrip.Items[0];
        }

        /// <summary>
        /// Displays a success message in the status bar.
        /// </summary>
        public void ShowSuccess(string message)
        {
            _statusStrip.BeginInvoke((MethodInvoker)delegate
            {
                _statusLabel.Text = "Success: " + message;
                _statusLabel.ForeColor = Color.Green;
            });
        }

        /// <summary>
        /// Displays an error message in the status bar.
        /// </summary>
        public void ShowError(string message)
        {
            _statusStrip.BeginInvoke((MethodInvoker)delegate
            {
                _statusLabel.Text = "Error: " + message;
                _statusLabel.ForeColor = Color.Red;
            });
        }

        /// <summary>
        /// Displays an informational message in the status bar.
        /// </summary>
        public void ShowInformation(string message)
        {
            _statusStrip.BeginInvoke((MethodInvoker)delegate
            {
                _statusLabel.Text = "Info: " + message;
                _statusLabel.ForeColor = Color.Black;
            });
        }
    }
}

