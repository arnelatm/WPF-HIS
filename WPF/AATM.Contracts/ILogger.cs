using System;

namespace AATM.Contracts
{
    /// <summary>
/// Defines methods for logging messages and exceptions.
/// </summary>
    public interface ILogger
    {

        /// <summary>
    /// Logs a message with informational severity.
    /// </summary>
        void LogInfo(string message);

        /// <summary>
    /// Logs a message with a warning severity.
    /// </summary>
        void LogWarning(string message);

        /// <summary>
    /// Logs an error message.
    /// </summary>
        void LogError(string message);

        /// <summary>
    /// Logs an exception, including its full details.
    /// </summary>
        void LogException(Exception ex);

    }
}