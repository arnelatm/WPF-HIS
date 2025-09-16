using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AATM.Core.Localization
{

    /// <summary>
/// Manages the retrieval of localized strings from the database with a caching layer.
/// </summary>
    public class LocalizationManager
    {
        // A private dictionary to cache the translations in memory.
        // The key is a composite string of the original string, module name, UI identifier, and language code.
        private readonly Dictionary<string, string> _translationCache = new Dictionary<string, string>();

        // The connection string for the SQL Server database.
        private readonly string _connectionString = "Server=Ibn-Server;Database=IspData;Integrated Security=SSPI;";

        /// <summary>
    /// Retrieves all translations from the database and populates the cache.
    /// </summary>
        private void LoadAllTranslations()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "SELECT [OriginalString], [ModuleName], [UIIdentifier], [LanguageCode], [LocalizedString] FROM [dbo].[Localization]";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create a unique key for the dictionary cache.
                                string cacheKey = $"{reader["OriginalString"]}|{reader["ModuleName"]}|{reader["UIIdentifier"]}|{reader["LanguageCode"]}";
                                string localizedString = reader["LocalizedString"].ToString();

                                // Add the translation to the cache.
                                if (!_translationCache.ContainsKey(cacheKey))
                                {
                                    _translationCache.Add(cacheKey, localizedString);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // In a production environment, you would log this error.
                Console.WriteLine($"An error occurred while loading translations: {ex.Message}");
            }
        }

        /// <summary>
    /// Gets the localized string for the specified key and language.
    /// </summary>
    /// <param name="originalString">The original string (e.g., "Welcome to the system").</param>
    /// <param name="moduleName">The name of the module (e.g., "Login").</param>
    /// <param name="uiIdentifier">The UI element identifier (e.g., "WelcomeHeader").</param>
    /// <param name="languageCode">The language code (e.g., "en-US").</param>
    /// <returns>The localized string or the original string if no translation is found.</returns>
        public string GetLocalizedString(string originalString, string moduleName, string uiIdentifier, string languageCode)
        {
            // First, check if the cache is empty. If so, load all translations.
            if (_translationCache.Count == 0)
            {
                LoadAllTranslations();
            }

            // Create the key for the cache lookup.
            string cacheKey = $"{originalString}|{moduleName}|{uiIdentifier}|{languageCode}";

            // Look up the translation in the cache.
            if (_translationCache.ContainsKey(cacheKey))
            {
                return _translationCache[cacheKey];
            }
            else
            {
                // If not found in the cache, return the original string as a fallback.
                return originalString;
            }
        }
    }

    /// <summary>
/// A sample module to demonstrate how to use the LocalizationManager.
/// </summary>
    static class Program
    {
        public static void Main()
        {
            // Create an instance of the localization manager.
            var localizationManager = new LocalizationManager();

            // Simulate an English user.
            string englishWelcome = localizationManager.GetLocalizedString("Welcome to the system", "Login", "WelcomeHeader", "en-US");
            Console.WriteLine($"English Welcome: {englishWelcome}");

            // Simulate an Arabic user.
            string arabicWelcome = localizationManager.GetLocalizedString("Welcome to the system", "Login", "WelcomeHeader", "ar-SA");
            Console.WriteLine($"Arabic Welcome: {arabicWelcome}");

            Console.ReadKey();
        }
    }
}