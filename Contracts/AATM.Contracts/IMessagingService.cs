
namespace AATM.Contracts
{
    /// <summary>
/// Defines a contract for a service that provides user feedback and notifications.
/// This interface decouples the Presenter from specific UI implementations like MessageBox.
/// </summary>
    public interface IMessagingService
    {

        /// <summary>
    /// Displays a success message to the user.
    /// </summary>
    /// <param name="message">The message to display.</param>
        void ShowSuccess(string message);

        /// <summary>
    /// Displays an error message to the user.
    /// </summary>
    /// <param name="message">The message to display.</param>
        void ShowError(string message);

        /// <summary>
    /// Displays an informational message to the user.
    /// </summary>
    /// <param name="message">The message to display.</param>
        void ShowInformation(string message);

    }
}