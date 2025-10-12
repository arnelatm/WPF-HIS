using System;
using Microsoft.Extensions.Configuration;

namespace AATM.Core.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        // Plan (pseudocode):
        // - Maintain a single lazy IConfigurationRoot instance.
        // - Load configuration from appsettings.json (optional) using the app base directory.
        // - GetSetting(key):
        //   - Return string.Empty if key is null/whitespace.
        //   - Try Microsoft.Extensions.Configuration:
        //       - cfg[key] (supports "Section:Key")
        //       - cfg.GetConnectionString(key)
        //   - Fallback to System.Configuration:
        //       - System.Configuration.ConfigurationManager.AppSettings[key]
        //       - System.Configuration.ConfigurationManager.ConnectionStrings[key]?.ConnectionString
        //   - Return string.Empty if nothing found.

        private static readonly Lazy<IConfigurationRoot> _config = new Lazy<IConfigurationRoot>(
            () =>
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                return config;
            },
            isThreadSafe: true
        );

        public string GetSetting(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return string.Empty;

            try
            {
                var cfg = _config.Value;

                var value = cfg[key];
                if (!string.IsNullOrEmpty(value))
                    return value;

                value = cfg.GetConnectionString(key);
                if (!string.IsNullOrEmpty(value))
                    return value;
            }
            catch
            {
                // Swallow configuration build/IO errors and continue to fallback.
            }

            try
            {
                var appSetting = System.Configuration.ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrEmpty(appSetting))
                    return appSetting;

                var connection = System.Configuration.ConfigurationManager.ConnectionStrings[key];
                if (connection != null && !string.IsNullOrWhiteSpace(connection.ConnectionString))
                    return connection.ConnectionString;
            }
            catch
            {
                // Ignore ConfigurationManager errors.
            }

            return string.Empty;
        }
    }
}