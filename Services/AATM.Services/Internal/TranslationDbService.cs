// --- 2. Data Access Service ---
// This service simulates your database layer (e.g., AATM.App.DbTranslate).
using AATM.Contracts.Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

public class TranslationDbService
{
    // WARNING: Replace this with your actual connection string.
    private const string ConnectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

    /// <summary>
    /// Inserts or updates a translation record in the database.
    /// </summary>
    public async Task<TranslationDto> UpsertTranslationAsync(TranslationDto dto)
    {
        string mergeSql = @"
MERGE INTO [dbo].[Translations] AS Target
USING (SELECT @OriginalString AS OriginalString, @ModuleName AS ModuleName, @UIIdentifier AS UIIdentifier, @LanguageCode AS LanguageCode, @LocalizedString AS LocalizedString) AS Source
ON (Target.OriginalString = Source.OriginalString AND Target.LanguageCode = Source.LanguageCode)
WHEN MATCHED THEN
    UPDATE SET
        ModuleName = Source.ModuleName,
        UIIdentifier = Source.UIIdentifier,
        LocalizedString = Source.LocalizedString
WHEN NOT MATCHED BY TARGET THEN
    INSERT (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString)
    VALUES (Source.OriginalString, Source.ModuleName, Source.UIIdentifier, Source.LanguageCode, Source.LocalizedString)
OUTPUT inserted.ID;";

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(mergeSql, connection))
                {
                    command.Parameters.AddWithValue("@OriginalString", dto.OriginalString);
                    command.Parameters.AddWithValue("@ModuleName", dto.ModuleName);
                    command.Parameters.AddWithValue("@UIIdentifier", dto.UIIdentifier);
                    command.Parameters.AddWithValue("@LanguageCode", dto.LanguageCode);
                    command.Parameters.AddWithValue("@LocalizedString", dto.LocalizedString);

                    // Execute the query and retrieve the ID of the affected row
                    object result = await command.ExecuteScalarAsync();
                    if (result != null)
                    {
                        dto.ID = Convert.ToInt32(result);
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return dto;
    }

    /// <summary>
    /// Fetches all translations from the database.
    /// </summary>
    public async Task<List<TranslationDto>> GetAllTranslationsAsync()
    {
        var translations = new List<TranslationDto>();
        string query = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate FROM Translations";

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<TranslationDto>();
        }
        return translations;
    }

    /// <summary>
    /// Deletes a translation record from the database.
    /// </summary>
    public async Task<bool> DeleteTranslationAsync(int id)
    {
        string deleteSql = "DELETE FROM Translations WHERE ID = @ID";
        int rowsAffected = 0;

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(deleteSql, connection))
                {
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
        return rowsAffected > 0;
    }
}