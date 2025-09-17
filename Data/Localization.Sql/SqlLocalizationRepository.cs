using System;
// AATM.Data.Sql Project
// This project is dedicated to providing concrete implementations for the data interfaces.

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using AATM.Contracts;
using AATM.Contracts.Interfaces.Repositories;
using AATM.Contracts.Dtos;


namespace Localization.Sql
{

    /// <summary>
/// Provides localization data from a SQL Server database.
/// This class implements the ILocalizationRepository interface.
/// </summary>
    public class SqlLocalizationRepository : ILocalizationRepository
    {

        // The connection string for the SQL Server database.
        private readonly string _connectionString = "Server=Ibn-Server;Database=IspData;Integrated Security=SSPI;";

        /// <summary>
    /// Retrieves a single localized string by its unique ID.
    /// </summary>
    /// <param name="id">The unique identifier of the translation record.</param>
    /// <returns>The TranslationDto object, or Nothing if not found.</returns>
        public TranslationDto GetLocalizationById(int id)
        {
            string sql = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString " + "FROM [dbo].[Localization] WHERE ID = @id";

            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", id));

            // Define a function to map a data reader row to a TranslationDto object.
            Func<SqlDataReader, TranslationDto> mapFunction = reader => new TranslationDto()
            {
                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Conversions.ToInteger(reader["ID"]),
                OriginalString = reader["OriginalString"].ToString(),
                ModuleName = reader["ModuleName"].ToString(),
                UIIdentifier = reader["UIIdentifier"].ToString(),
                LanguageCode = reader["LanguageCode"].ToString(),
                LocalizedString = reader["LocalizedString"].ToString()
            };

            // Use the generic helper to fetch the results.
            var results = ExecuteReaderGeneric(sql, parameters.ToArray(), mapFunction);

            // Return the first item if found, otherwise return Nothing.
            return results.FirstOrDefault();
        }

        /// <summary>
    /// Retrieves all localized strings for a specific language from the SQL database.
    /// This method now uses a private helper function to manage the connection.
    /// </summary>
    /// <param name="languageCode">The culture code for the language (e.g., "en-US", "ar-SA").</param>
    /// <returns>A list of TranslationDto objects.</returns>
        public List<TranslationDto> GetLocalizedStrings(string languageCode)
        {
            string sql = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString " + "FROM [dbo].[Localization] WHERE LanguageCode = @languageCode";

            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@languageCode", languageCode));

            // Define a function to map a data reader row to a TranslationDto object.
            Func<SqlDataReader, TranslationDto> mapFunction = reader => new TranslationDto()
            {
                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Conversions.ToInteger(reader["ID"]),
                OriginalString = reader["OriginalString"].ToString(),
                ModuleName = reader["ModuleName"].ToString(),
                UIIdentifier = reader["UIIdentifier"].ToString(),
                LanguageCode = reader["LanguageCode"].ToString(),
                LocalizedString = reader["LocalizedString"].ToString()
            };

            // Execute the generic command and return the list of translations.
            return ExecuteReaderGeneric(sql, parameters.ToArray(), mapFunction);
        }

        /// <summary>
    /// Adds a new localized string or updates an existing one using the SQL MERGE command.
    /// This method now uses a private helper function to manage the connection.
    /// </summary>
        public void AddOrUpdateLocalization(string originalString, string moduleName, string uiIdentifier, string languageCode, string localizedString)
        {
            string sql = "MERGE [dbo].[Localization] AS Target " + "USING (VALUES (@originalString, @moduleName, @uiIdentifier, @languageCode, @localizedString)) " + "AS Source (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) " + "ON Target.OriginalString = Source.OriginalString " + "AND Target.ModuleName = Source.ModuleName " + "AND Target.UIIdentifier = Source.UIIdentifier " + "AND Target.LanguageCode = Source.LanguageCode " + "WHEN MATCHED THEN " + "    UPDATE SET LocalizedString = Source.LocalizedString " + "WHEN NOT MATCHED THEN " + "    INSERT (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) " + "    VALUES (Source.OriginalString, Source.ModuleName, Source.UIIdentifier, Source.LanguageCode, Source.LocalizedString);";

            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@originalString", originalString));
            parameters.Add(new SqlParameter("@moduleName", moduleName));
            parameters.Add(new SqlParameter("@uiIdentifier", uiIdentifier));
            parameters.Add(new SqlParameter("@languageCode", languageCode));
            parameters.Add(new SqlParameter("@localizedString", localizedString));

            ExecuteNonQueryCommand(sql, parameters.ToArray());
            Console.WriteLine("Localization record added or updated successfully.");
        }

        /// <summary>
    /// Searches for localized strings across multiple fields.
    /// </summary>
    /// <param name="searchString">The string to search for. The search is case-insensitive.</param>
    /// <returns>A list of TranslationDto objects that match the search criteria.</returns>
        public List<TranslationDto> SearchLocalizations(string searchString)
        {
            string sql = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString " + "FROM [dbo].[Localization] WHERE OriginalString LIKE @searchString OR ModuleName LIKE @searchString OR UIIdentifier LIKE @searchString";

            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@searchString", "%" + searchString + "%"));

            // Define a function to map a data reader row to a TranslationDto object.
            Func<SqlDataReader, TranslationDto> mapFunction = reader => new TranslationDto()
            {
                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Conversions.ToInteger(reader["ID"]),
                OriginalString = reader["OriginalString"].ToString(),
                ModuleName = reader["ModuleName"].ToString(),
                UIIdentifier = reader["UIIdentifier"].ToString(),
                LanguageCode = reader["LanguageCode"].ToString(),
                LocalizedString = reader["LocalizedString"].ToString()
            };

            return ExecuteReaderGeneric(sql, parameters.ToArray(), mapFunction);
        }

        /// <summary>
    /// Deletes a specific localized string record by its unique ID.
    /// </summary>
    /// <param name="id">The unique identifier of the translation record to delete.</param>
        public void DeleteLocalizationById(int id)
        {
            string sql = "DELETE FROM [dbo].[Localization] WHERE ID = @id";
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", id));
            ExecuteNonQueryCommand(sql, parameters.ToArray());
            Console.WriteLine($"Localization record with ID {id} deleted successfully.");
        }

        /// <summary>
    /// Deletes all localized string records for a specific language code.
    /// </summary>
    /// <param name="languageCode">The culture code for the language to delete.</param>
        public void DeleteLocalizationByLanguageCode(string languageCode)
        {
            string sql = "DELETE FROM [dbo].[Localization] WHERE LanguageCode = @languageCode";
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@languageCode", languageCode));
            ExecuteNonQueryCommand(sql, parameters.ToArray());
            Console.WriteLine($"All localization records for language code {languageCode} deleted successfully.");
        }

        /// <summary>
    /// Executes a command that returns a list of generic objects.
    /// This helper function encapsulates the connection and exception handling for read operations.
    /// </summary>
    /// <typeparam name="T">The type of object to return.</typeparam>
    /// <param name="sql">The SQL query string.</param>
    /// <param name="parameters">An array of SQL parameters.</param>
    /// <param name="map">A function to map a SqlDataReader row to an object of type T.</param>
    /// <returns>A list of objects of type T.</returns>
        private List<T> ExecuteReaderGeneric<T>(string sql, SqlParameter[] parameters, Func<SqlDataReader, T> map)
        {
            var items = new List<T>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        if (parameters is not null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                items.Add(map(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while executing the SQL command: {ex.Message}");
            }
            return items;
        }

        /// <summary>
    /// Executes a command that does not return any rows (e.g., INSERT, UPDATE, MERGE).
    /// This helper function encapsulates the connection and exception handling for write operations.
    /// </summary>
    /// <param name="sql">The SQL query string.</param>
    /// <param name="parameters">An array of SQL parameters.</param>
        private void ExecuteNonQueryCommand(string sql, SqlParameter[] parameters)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        if (parameters is not null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while executing the SQL command: {ex.Message}");
            }
        }
    }
}





// ' AATM.Data.Sql Project
// ' This project is dedicated to providing concrete implementations for the data interfaces.

// Imports System.Collections.Generic
// Imports System.Data.SqlClient
// Imports AATM.Core.Data.Interfaces

// ''' <summary>
// ''' Provides localization data from a SQL Server database.
// ''' This class implements the ILocalizationRepository interface.
// ''' </summary>
// Public Class SqlLocalizationRepository
// Implements ILocalizationRepository

// ' The connection string for the SQL Server database.
// Private ReadOnly _connectionString As String = "Server=localhost;Database=LocalizationDb;Integrated Security=SSPI;"

// ''' <summary>
// ''' Retrieves all localized strings for a specific language from the SQL database.
// ''' This method uses a parameterized query for security.
// ''' </summary>
// ''' <param name="languageCode">The culture code for the language (e.g., "en-US", "ar-SA").</param>
// ''' <returns>A list of TranslationDto objects.</returns>
// Public Function GetLocalizedStrings(languageCode As String) As List(Of TranslationDto) Implements ILocalizationRepository.GetLocalizedStrings
// Dim translations As New List(Of TranslationDto)()
// Dim sql As String = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString " &
// "FROM [dbo].[Localization] WHERE LanguageCode = @languageCode"

// Try
// Using connection As New SqlConnection(_connectionString)
// connection.Open()
// Using command As New SqlCommand(sql, connection)
// command.Parameters.AddWithValue("@languageCode", languageCode)
// Using reader As SqlDataReader = command.ExecuteReader()
// While reader.Read()
// translations.Add(New TranslationDto With {
// .ID = If(reader("ID") Is DBNull.Value, 0, CInt(reader("ID"))),
// .OriginalString = reader("OriginalString").ToString(),
// .ModuleName = reader("ModuleName").ToString(),
// .UIIdentifier = reader("UIIdentifier").ToString(),
// .languageCode = reader("LanguageCode").ToString(),
// .LocalizedString = reader("LocalizedString").ToString()
// })
// End While
// End Using
// End Using
// End Using
// Catch ex As Exception
// Console.WriteLine($"An error occurred while loading translations: {ex.Message}")
// End Try
// Return translations
// End Function

// ''' <summary>
// ''' Adds a new localized string or updates an existing one using the SQL MERGE command.
// ''' This is a more efficient, atomic approach to the "upsert" operation.
// ''' </summary>
// Public Sub AddOrUpdateLocalization(originalString As String, moduleName As String, uiIdentifier As String, languageCode As String, localizedString As String) Implements ILocalizationRepository.AddOrUpdateLocalization
// Dim sql As String = "MERGE [dbo].[Localization] AS Target " &
// "USING (VALUES (@originalString, @moduleName, @uiIdentifier, @languageCode, @localizedString)) " &
// "AS Source (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) " &
// "ON Target.OriginalString = Source.OriginalString " &
// "AND Target.ModuleName = Source.ModuleName " &
// "AND Target.UIIdentifier = Source.UIIdentifier " &
// "AND Target.LanguageCode = Source.LanguageCode " &
// "WHEN MATCHED THEN " &
// "    UPDATE SET LocalizedString = Source.LocalizedString " &
// "WHEN NOT MATCHED THEN " &
// "    INSERT (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) " &
// "    VALUES (Source.OriginalString, Source.ModuleName, Source.UIIdentifier, Source.LanguageCode, Source.LocalizedString);"

// Try
// Using connection As New SqlConnection(_connectionString)
// connection.Open()
// Using command As New SqlCommand(sql, connection)
// command.Parameters.AddWithValue("@originalString", originalString)
// command.Parameters.AddWithValue("@moduleName", moduleName)
// command.Parameters.AddWithValue("@uiIdentifier", uiIdentifier)
// command.Parameters.AddWithValue("@languageCode", languageCode)
// command.Parameters.AddWithValue("@localizedString", localizedString)
// command.ExecuteNonQuery()
// Console.WriteLine("Localization record added or updated successfully.")
// End Using
// End Using
// Catch ex As Exception
// Console.WriteLine($"An error occurred while adding/updating the localization record: {ex.Message}")
// End Try
// End Sub
// End Class



// ' AATM.Data.Sql Project
// ' This project is dedicated to providing concrete implementations for the data interfaces.

// Imports System.Collections.Generic
// Imports System.Data.SqlClient
// Imports AATM.Core.Data.Interfaces

// ''' <summary>
// ''' Provides localization data from a SQL Server database.
// ''' This class implements the ILocalizationRepository interface.
// ''' </summary>
// Public Class SqlLocalizationRepository
// Implements ILocalizationRepository

// ' The connection string for the SQL Server database.
// Private ReadOnly _connectionString As String = "Server=localhost;Database=LocalizationDb;Integrated Security=SSPI;"

// ''' <summary>
// ''' Retrieves all localized strings for a specific language from the SQL database.
// ''' This method uses a parameterized query for security.
// ''' </summary>
// ''' <param name="languageCode">The culture code for the language (e.g., "en-US", "ar-SA").</param>
// ''' <returns>A list of TranslationDto objects.</returns>
// Public Function GetLocalizedStrings(languageCode As String) As List(Of TranslationDto) Implements ILocalizationRepository.GetLocalizedStrings
// Dim translations As New List(Of TranslationDto)()
// Dim sql As String = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString " &
// "FROM [dbo].[Localization] WHERE LanguageCode = @languageCode"

// Try
// Using connection As New SqlConnection(_connectionString)
// connection.Open()
// Using command As New SqlCommand(sql, connection)
// command.Parameters.AddWithValue("@languageCode", languageCode)
// Using reader As SqlDataReader = command.ExecuteReader()
// While reader.Read()
// translations.Add(New TranslationDto With {
// .ID = If(reader("ID") Is DBNull.Value, 0, CInt(reader("ID"))),
// .OriginalString = reader("OriginalString").ToString(),
// .ModuleName = reader("ModuleName").ToString(),
// .UIIdentifier = reader("UIIdentifier").ToString(),
// .languageCode = reader("LanguageCode").ToString(),
// .LocalizedString = reader("LocalizedString").ToString()
// })
// End While
// End Using
// End Using
// End Using
// Catch ex As Exception
// Console.WriteLine($"An error occurred while loading translations: {ex.Message}")
// End Try
// Return translations
// End Function

// ''' <summary>
// ''' Adds a new localized string or updates an existing one.
// ''' The method first checks for an existing record and then performs the appropriate operation.
// ''' </summary>
// Public Sub AddOrUpdateLocalization(originalString As String, moduleName As String, uiIdentifier As String, languageCode As String, localizedString As String) Implements ILocalizationRepository.AddOrUpdateLocalization
// Dim recordExists As Boolean = False
// Dim checkSql As String = "SELECT COUNT(*) FROM [dbo].[Localization] " &
// "WHERE OriginalString = @originalString AND ModuleName = @moduleName AND UIIdentifier = @uiIdentifier AND LanguageCode = @languageCode"

// Try
// Using connection As New SqlConnection(_connectionString)
// connection.Open()

// ' First, check if the record already exists.
// Using checkCommand As New SqlCommand(checkSql, connection)
// checkCommand.Parameters.AddWithValue("@originalString", originalString)
// checkCommand.Parameters.AddWithValue("@moduleName", moduleName)
// checkCommand.Parameters.AddWithValue("@uiIdentifier", uiIdentifier)
// checkCommand.Parameters.AddWithValue("@languageCode", languageCode)
// recordExists = CInt(checkCommand.ExecuteScalar()) > 0
// End Using

// If recordExists Then
// ' If the record exists, update the localized string.
// Dim updateSql As String = "UPDATE [dbo].[Localization] SET LocalizedString = @localizedString " &
// "WHERE OriginalString = @originalString AND ModuleName = @moduleName AND UIIdentifier = @uiIdentifier AND LanguageCode = @languageCode"

// Using updateCommand As New SqlCommand(updateSql, connection)
// updateCommand.Parameters.AddWithValue("@localizedString", localizedString)
// updateCommand.Parameters.AddWithValue("@originalString", originalString)
// updateCommand.Parameters.AddWithValue("@moduleName", moduleName)
// updateCommand.Parameters.AddWithValue("@uiIdentifier", uiIdentifier)
// updateCommand.Parameters.AddWithValue("@languageCode", languageCode)
// updateCommand.ExecuteNonQuery()
// Console.WriteLine("Localization record updated successfully.")
// End Using
// Else
// ' If the record does not exist, insert a new one.
// Dim insertSql As String = "INSERT INTO [dbo].[Localization] (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) " &
// "VALUES (@originalString, @moduleName, @uiIdentifier, @languageCode, @localizedString)"

// Using insertCommand As New SqlCommand(insertSql, connection)
// insertCommand.Parameters.AddWithValue("@originalString", originalString)
// insertCommand.Parameters.AddWithValue("@moduleName", moduleName)
// insertCommand.Parameters.AddWithValue("@uiIdentifier", uiIdentifier)
// insertCommand.Parameters.AddWithValue("@languageCode", languageCode)
// insertCommand.Parameters.AddWithValue("@localizedString", localizedString)
// insertCommand.ExecuteNonQuery()
// Console.WriteLine("New localization record added successfully.")
// End Using
// End If
// End Using
// Catch ex As Exception
// Console.WriteLine($"An error occurred while adding/updating the localization record: {ex.Message}")
// End Try
// End Sub
// End Class
