using System;
using AATM.Contracts;

namespace AATM.Core.Logging
{

    public class ConsoleLogger : ILogger
    {

        public void LogInfo(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"WARNING: {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }

        public void LogException(Exception ex)
        {
            Console.WriteLine($"EXCEPTION: An exception occurred: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

    }
}