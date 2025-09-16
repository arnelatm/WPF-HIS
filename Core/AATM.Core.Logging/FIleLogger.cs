using System;
using System.IO;
using AATM.Contracts;

namespace AATM.Core.Logging
{

    /// <summary>
/// A simple file-based logger implementation.
/// </summary>
    public class FileLogger : ILogger
    {

        private readonly string _logFilePath;

        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        private void WriteToLog(string level, string message)
        {
            string logEntry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} [{level.ToUpper()}] - {message}";
            File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
        }

        public void LogInfo(string message)
        {
            WriteToLog("INFO", message);
        }

        public void LogWarning(string message)
        {
            WriteToLog("WARN", message);
        }

        public void LogError(string message)
        {
            WriteToLog("ERROR", message);
        }

        public void LogException(Exception ex)
        {
            WriteToLog("EXCEPTION", $"An exception occurred: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
        }

    }
}