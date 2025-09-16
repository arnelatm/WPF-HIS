using AATM.Contracts.Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// A service class to manage database operations for translation data.
/// This version uses a SQL MERGE statement for atomic upsert functionality.
/// </summary>
public class TranslationDbService
{
    // IMPORTANT: Replace this with your actual database connection string.
    private readonly string _connectionString = "Data Source=YourServerName;Initial Catalog=YourDatabaseName;User ID=YourUsername;Password=YourPassword;";

    /// <summary>
    /// Inserts or updates a translation record atomically using a SQL MERGE statement.
    /// </summary>
    /// <param name="dto">The TranslationDto object to upsert.</param>
    /// <returns>The ID of the affected record.</returns>
    public async Task<int> UpsertTranslationAsync(TranslationDto dto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            // The MERGE statement intelligently handles both INSERT and UPDATE.
            // It finds a matching record based on the combination of OriginalString,
            // ModuleName, UIIdentifier, and LanguageCode.
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
                    OUTPUT inserted.ID;"; // This returns the ID of the affected row.

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
    /// Deletes a translation record from the database by its ID.
    /// </summary>
    /// <param name="id">The ID of the record to delete.</param>
    public async Task DeleteTranslationAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "DELETE FROM Localization WHERE ID = @ID";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                await command.ExecuteNonQueryAsync();
            }
        }
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

    ///// <summary>
    ///// Deletes a translation record from the database by its ID.
    ///// </summary>
    ///// <param name="id">The ID of the record to delete.</param>
    //public async Task DeleteTranslationAsync(int id)
    //{
    //    using (var connection = new SqlConnection(_connectionString))
    //    {
    //        await connection.OpenAsync();
    //        var query = "DELETE FROM Localization WHERE ID = @ID";
    //        using (var command = new SqlCommand(query, connection))
    //        {
    //            command.Parameters.AddWithValue("@ID", id);
    //            await command.ExecuteNonQueryAsync();
    //        }
    //    }
    //}

    ///// <summary>
    ///// Helper method to map a SqlDataReader row to a TranslationDto object.
    ///// </summary>
    //private TranslationDto MapToDto(SqlDataReader reader)
    //{
    //    return new TranslationDto
    //    {
    //        ID = reader.GetInt32(reader.GetOrdinal("ID")),
    //        OriginalString = reader.GetString(reader.GetOrdinal("OriginalString")),
    //        ModuleName = reader.GetString(reader.GetOrdinal("ModuleName")),
    //        UIIdentifier = reader.GetString(reader.GetOrdinal("UIIdentifier")),
    //        LanguageCode = reader.GetString(reader.GetOrdinal("LanguageCode")),
    //        LocalizedString = reader.GetString(reader.GetOrdinal("LocalizedString")),
    //        CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
    //    };
    //}
}
