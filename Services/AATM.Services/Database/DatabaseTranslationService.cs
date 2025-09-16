using AATM.Contracts.Interfaces.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;


namespace AATM.Services.Database
{
    /// <summary>
    /// Implements the ITranslationService interface by first checking a SQL database
    /// and then falling back to an external API if a translation is not found.
    /// </summary>
    public class DatabaseTranslationService : ITranslationService
    {
        private readonly string _connectionString;
        private readonly ITranslationApi _translationApi;

        /// <summary>
        /// Initializes a new instance of the DatabaseTranslationService with a database connection string
        /// and a fallback translation API.
        /// </summary>
        /// <param name="connectionString">The connection string for the SQL database.</param>
        /// <param name="translationApi">The fallback API to use for translations not found in the database.</param>
        public DatabaseTranslationService(string connectionString, ITranslationApi translationApi)
        {
            _connectionString = connectionString;
            _translationApi = translationApi;
        }

        public async Task<string> TranslateAsync(string sourceText, string targetLanguage)
        {
            string translatedText = null;

            // 1. Attempt to retrieve the translation from the database.
            translatedText = await GetFromDatabaseAsync(sourceText, targetLanguage).ConfigureAwait(false);

            if (string.IsNullOrEmpty(translatedText))
            {
                // 2. If not found in the database, fall back to the external API.
                Console.WriteLine("Translation not found in database. Falling back to external API...");
                translatedText = await _translationApi.GetTranslationAsync(sourceText, targetLanguage).ConfigureAwait(false);

                if (!string.IsNullOrEmpty(translatedText))
                {
                    // 3. Save the new translation back to the database for future use (caching).
                    await SaveToDatabaseAsync(sourceText, targetLanguage, translatedText).ConfigureAwait(false);
                }
            }

            return translatedText;
        }

        private async Task<string> GetFromDatabaseAsync(string sourceText, string targetLanguage)
        {
            string sqlQuery = "SELECT TranslatedText FROM Translations WHERE [Key] = @Key AND [Language] = @Language;";
            string result = null;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    using (var command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Key", sourceText);
                        command.Parameters.AddWithValue("@Language", targetLanguage);
                        object queryResult = await command.ExecuteScalarAsync().ConfigureAwait(false);
                        if (queryResult != null && queryResult != DBNull.Value)
                        {
                            result = Convert.ToString(queryResult);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database lookup error: {ex.Message}");
            }
            return result;
        }

        private async Task SaveToDatabaseAsync(string sourceText, string targetLanguage, string translatedText)
        {
            // Use an UPSERT pattern (Update if exists, Insert if not) to avoid duplicate entries.
            string sqlQuery = @"
                MERGE Translations AS target
                USING (SELECT @Key AS [Key], @Language AS [Language], @TranslatedText AS TranslatedText) AS source
                ON target.[Key] = source.[Key] AND target.[Language] = source.[Language]
                WHEN MATCHED THEN
                    UPDATE SET TranslatedText = source.TranslatedText
                WHEN NOT MATCHED THEN
                    INSERT ([Key], [Language], TranslatedText)
                    VALUES (source.[Key], source.[Language], source.TranslatedText);";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    using (var command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Key", sourceText);
                        command.Parameters.AddWithValue("@Language", targetLanguage);
                        command.Parameters.AddWithValue("@TranslatedText", translatedText);
                        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                        Console.WriteLine("New translation saved to database.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database save error: {ex.Message}");
            }
        }
    }
}
