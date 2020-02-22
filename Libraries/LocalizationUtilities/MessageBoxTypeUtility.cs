using System.Windows.Forms;

namespace AATM.Libraries.LocalizationUtilities
{
    /// <summary>
    ///     A utility for dealing with <c>MessageBoxType</c>.
    /// </summary>
    public static class MessageBoxTypeUtility
    {
        /// <summary>
        ///     Get the message box icon for the specified type.
        /// </summary>
        /// <param name="type">Message box type.</param>
        /// <returns>Corresponding message box icon.</returns>
        public static MessageBoxIcon GetIcon(MessageBoxType type)
        {
            switch (type)
            {
                case MessageBoxType.Info:
                    return MessageBoxIcon.Asterisk;

                case MessageBoxType.Warning:
                    return MessageBoxIcon.Exclamation;

                case MessageBoxType.Error:
                    return MessageBoxIcon.Hand;
            }

            return MessageBoxIcon.None;
        }
    }
}