using System;
using System.Configuration;

namespace AATM.Core.Configuration
{

    /// <summary>
/// Provides a concrete implementation of IConfigurationService
/// that reads settings from the application's App.config file.
/// </summary>
    public class ConfigurationService : IConfigurationService
    {

        private const string APP_CONFIG_FILE = "App.config";

        public string GetSetting(string key)
        {
            try
            {
                // We'll need to add a reference to System.Configuration to use ConfigurationManager.
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                // In a real-world app, you'd want to log this error.
                // For now, we'll just return an empty string.
                Console.WriteLine($"Error reading setting for key '{key}': {ex.Message}");
                return string.Empty;
            }
        }
    }
}