using AATM.Contracts.Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// A service class to manage database operations for translation data.
/// This version uses a SQL MERGE statement for atomic upsert functionality.
/// </summary>
public class TranslationDbService
{
    // IMPORTANT: Replace with a secure connection string source in production.
    // Quick fix for untrusted certs: TrustServerCertificate=True (keeps TLS, skips validation).
    private readonly string _connectionString =
        "Data Source=ibn-server;Initial Catalog=ispdata;User ID=IGroupAdmin;Password=igss@123;Encrypt=True;TrustServerCertificate=True;";

    public async Task<int> UpsertTranslationAsync(TranslationDto dto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var mergeCommand = @"
                MERGE INTO Localization AS T
                USING (VALUES (@OriginalString, @ModuleName, @UIIdentifier, @LanguageCode, @LocalizedString, GETDATE()))
                AS S (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate)
                ON T.OriginalString = S.OriginalString AND T.LanguageCode = S.LanguageCode AND T.ModuleName = S.ModuleName AND T.UIIdentifier = S.UIIdentifier
                WHEN MATCHED THEN
                    UPDATE SET T.LocalizedString = S.LocalizedString, T.CreationDate = S.CreationDate
                WHEN NOT MATCHED THEN
                    INSERT (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate)
                    VALUES (S.OriginalString, S.ModuleName, S.UIIdentifier, S.LanguageCode, S.LocalizedString, S.CreationDate)
                OUTPUT inserted.ID;";

            using (var command = new SqlCommand(mergeCommand, connection))
            {
                command.Parameters.AddWithValue("@OriginalString", dto.OriginalString);
                command.Parameters.AddWithValue("@ModuleName", dto.ModuleName);
                command.Parameters.AddWithValue("@UIIdentifier", dto.UIIdentifier);
                command.Parameters.AddWithValue("@LanguageCode", dto.LanguageCode);
                command.Parameters.AddWithValue("@LocalizedString", dto.LocalizedString);

                return Convert.ToInt32(await command.ExecuteScalarAsync());
            }
        }
    }


    /// <summary>
    /// Retrieves a single translation record by its unique ID.
    /// </summary>
    /// <param name="id">The unique ID of the translation record.</param>
    /// <returns>The TranslationDto object or null if not found.</returns>
    public async Task<TranslationDto> GetTranslationByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM Localization WHERE ID = @ID";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapToDto(reader);
                    }
                }
            }
        }
        return null;
    }

    /// <summary>
    /// Retrieves all translation records for a specific language code.
    /// </summary>
    /// <param name="languageCode">The BCP-47 language code (e.g., 'es-ES').</param>
    /// <returns>A list of TranslationDto objects.</returns>
    public async Task<List<TranslationDto>> GetTranslationsByLanguageCodeAsync(string languageCode)
    {
        var translations = new List<TranslationDto>();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM Localization WHERE LanguageCode = @LanguageCode";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LanguageCode", languageCode);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        translations.Add(MapToDto(reader));
                    }
                }
            }
        }
        return translations;
    }

    /// <summary>
    /// Fetches all translations from the database.
    /// </summary>
    /// <returns>A list of TranslationDto objects.</returns>
    public async Task<List<TranslationDto>> GetAllTranslationsAsync()
    {
        var translations = new List<TranslationDto>();
        string query = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate FROM Translations";

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            translations.Add(new TranslationDto
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                OriginalString = reader.GetString(reader.GetOrdinal("OriginalString")),
                                ModuleName = reader.GetString(reader.GetOrdinal("ModuleName")),
                                UIIdentifier = reader.GetString(reader.GetOrdinal("UIIdentifier")),
                                LanguageCode = reader.GetString(reader.GetOrdinal("LanguageCode")),
                                LocalizedString = reader.GetString(reader.GetOrdinal("LocalizedString")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                            });
                        }
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            // Log the exception or show an error message.
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Return an empty list on error.
            return new List<TranslationDto>();
        }

        return translations;
    }


    /// <summary>
    /// Deletes a translation record from the database.
    /// </summary>
    /// <returns>True if the record was deleted, false otherwise.</returns>
    public async Task<bool> DeleteTranslationAsync(int id)
    {
        string deleteSql = "DELETE FROM Translations WHERE ID = @ID";
        int rowsAffected = 0;

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(deleteSql, connection))
                {
                    // Add the parameter to prevent SQL injection.
                    command.Parameters.AddWithValue("@ID", id);
                    rowsAffected = await command.ExecuteNonQueryAsync();
                }
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Return true if at least one row was deleted.
        return rowsAffected > 0;
    }

    /// <summary>
    /// Helper method to map a SqlDataReader row to a TranslationDto object.
    /// </summary>
    private TranslationDto MapToDto(SqlDataReader reader)
    {
        return new TranslationDto
        {
            ID = reader.GetInt32(reader.GetOrdinal("ID")),
            OriginalString = reader.GetString(reader.GetOrdinal("OriginalString")),
            ModuleName = reader.GetString(reader.GetOrdinal("ModuleName")),
            UIIdentifier = reader.GetString(reader.GetOrdinal("UIIdentifier")),
            LanguageCode = reader.GetString(reader.GetOrdinal("LanguageCode")),
            LocalizedString = reader.GetString(reader.GetOrdinal("LocalizedString")),
            CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
        };
    }

}
