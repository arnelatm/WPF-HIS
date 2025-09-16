' AATM.Data.Sql Project
' This project is dedicated to providing concrete implementations for the data interfaces.

Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports AATM.Core.Data.Interfaces

''' <summary>
''' Provides localization data from a SQL Server database.
''' This class implements the ILocalizationRepository interface.
''' </summary>
Public Class SqlLocalizationRepository
    Implements ILocalizationRepository

    ' The connection string for the SQL Server database.
    Private ReadOnly _connectionString As String = "Server=localhost;Database=LocalizationDb;Integrated Security=SSPI;"

    ''' <summary>
    ''' Retrieves a single localized string by its unique ID.
    ''' </summary>
    ''' <param name="id">The unique identifier of the translation record.</param>
    ''' <returns>The TranslationDTO object, or Nothing if not found.</returns>
    Public Function GetLocalizationById(id As Integer) As TranslationDTO Implements ILocalizationRepository.GetLocalizationById
        Dim sql As String = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString " &
                            "FROM [dbo].[Localization] WHERE ID = @id"

        Dim parameters As New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@id", id))

        ' Define a function to map a data reader row to a TranslationDTO object.
        Dim mapFunction As Func(Of SqlDataReader, TranslationDTO) = Function(reader) New TranslationDTO With {
            .id = If(reader("ID") Is DBNull.Value, 0, CInt(reader("ID"))),
            .OriginalString = reader("OriginalString").ToString(),
            .ModuleName = reader("ModuleName").ToString(),
            .UIIdentifier = reader("UIIdentifier").ToString(),
            .LanguageCode = reader("LanguageCode").ToString(),
            .LocalizedString = reader("LocalizedString").ToString()
        }

        ' Use the generic helper to fetch the results.
        Dim results = ExecuteReaderGeneric(Of TranslationDTO)(sql, parameters.ToArray(), mapFunction)

        ' Return the first item if found, otherwise return Nothing.
        Return results.FirstOrDefault()
    End Function

    ''' <summary>
    ''' Retrieves all localized strings for a specific language from the SQL database.
    ''' This method now uses a private helper function to manage the connection.
    ''' </summary>
    ''' <param name="languageCode">The culture code for the language (e.g., "en-US", "ar-SA").</param>
    ''' <returns>A list of TranslationDTO objects.</returns>
    Public Function GetLocalizedStrings(languageCode As String) As List(Of TranslationDTO) Implements ILocalizationRepository.GetLocalizedStrings
        Dim sql As String = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString " &
                            "FROM [dbo].[Localization] WHERE LanguageCode = @languageCode"

        Dim parameters As New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@languageCode", languageCode))

        ' Define a function to map a data reader row to a TranslationDTO object.
        Dim mapFunction As Func(Of SqlDataReader, TranslationDTO) = Function(reader) New TranslationDTO With {
            .ID = If(reader("ID") Is DBNull.Value, 0, CInt(reader("ID"))),
            .OriginalString = reader("OriginalString").ToString(),
            .ModuleName = reader("ModuleName").ToString(),
            .UIIdentifier = reader("UIIdentifier").ToString(),
            .languageCode = reader("LanguageCode").ToString(),
            .LocalizedString = reader("LocalizedString").ToString()
        }

        ' Execute the generic command and return the list of translations.
        Return ExecuteReaderGeneric(Of TranslationDTO)(sql, parameters.ToArray(), mapFunction)
    End Function

    ''' <summary>
    ''' Adds a new localized string or updates an existing one using the SQL MERGE command.
    ''' This method now uses a private helper function to manage the connection.
    ''' </summary>
    Public Sub AddOrUpdateLocalization(originalString As String, moduleName As String, uiIdentifier As String, languageCode As String, localizedString As String) Implements ILocalizationRepository.AddOrUpdateLocalization
        Dim sql As String = "MERGE [dbo].[Localization] AS Target " &
                            "USING (VALUES (@originalString, @moduleName, @uiIdentifier, @languageCode, @localizedString)) " &
                            "AS Source (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) " &
                            "ON Target.OriginalString = Source.OriginalString " &
                            "AND Target.ModuleName = Source.ModuleName " &
                            "AND Target.UIIdentifier = Source.UIIdentifier " &
                            "AND Target.LanguageCode = Source.LanguageCode " &
                            "WHEN MATCHED THEN " &
                            "    UPDATE SET LocalizedString = Source.LocalizedString " &
                            "WHEN NOT MATCHED THEN " &
                            "    INSERT (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) " &
                            "    VALUES (Source.OriginalString, Source.ModuleName, Source.UIIdentifier, Source.LanguageCode, Source.LocalizedString);"

        Dim parameters As New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@originalString", originalString))
        parameters.Add(New SqlParameter("@moduleName", moduleName))
        parameters.Add(New SqlParameter("@uiIdentifier", uiIdentifier))
        parameters.Add(New SqlParameter("@languageCode", languageCode))
        parameters.Add(New SqlParameter("@localizedString", localizedString))

        ExecuteNonQueryCommand(sql, parameters.ToArray())
        Console.WriteLine("Localization record added or updated successfully.")
    End Sub

    ''' <summary>
    ''' Searches for localized strings across multiple fields.
    ''' </summary>
    ''' <param name="searchString">The string to search for. The search is case-insensitive.</param>
    ''' <returns>A list of TranslationDTO objects that match the search criteria.</returns>
    Public Function SearchLocalizations(searchString As String) As List(Of TranslationDTO)
        Dim sql As String = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString " &
                            "FROM [dbo].[Localization] WHERE OriginalString LIKE @searchString OR ModuleName LIKE @searchString OR UIIdentifier LIKE @searchString"

        Dim parameters As New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@searchString", "%" & searchString & "%"))

        ' Define a function to map a data reader row to a TranslationDTO object.
        Dim mapFunction As Func(Of SqlDataReader, TranslationDTO) = Function(reader) New TranslationDTO With {
            .ID = If(reader("ID") Is DBNull.Value, 0, CInt(reader("ID"))),
            .OriginalString = reader("OriginalString").ToString(),
            .ModuleName = reader("ModuleName").ToString(),
            .UIIdentifier = reader("UIIdentifier").ToString(),
            .LanguageCode = reader("LanguageCode").ToString(),
            .LocalizedString = reader("LocalizedString").ToString()
        }

        Return ExecuteReaderGeneric(Of TranslationDTO)(sql, parameters.ToArray(), mapFunction)
    End Function

    ''' <summary>
    ''' Deletes a specific localized string record by its unique ID.
    ''' </summary>
    ''' <param name="id">The unique identifier of the translation record to delete.</param>
    Public Sub DeleteLocalizationById(id As Integer)
        Dim sql As String = "DELETE FROM [dbo].[Localization] WHERE ID = @id"
        Dim parameters As New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@id", id))
        ExecuteNonQueryCommand(sql, parameters.ToArray())
        Console.WriteLine($"Localization record with ID {id} deleted successfully.")
    End Sub

    ''' <summary>
    ''' Deletes all localized string records for a specific language code.
    ''' </summary>
    ''' <param name="languageCode">The culture code for the language to delete.</param>
    Public Sub DeleteLocalizationByLanguageCode(languageCode As String)
        Dim sql As String = "DELETE FROM [dbo].[Localization] WHERE LanguageCode = @languageCode"
        Dim parameters As New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@languageCode", languageCode))
        ExecuteNonQueryCommand(sql, parameters.ToArray())
        Console.WriteLine($"All localization records for language code {languageCode} deleted successfully.")
    End Sub

    ''' <summary>
    ''' Executes a command that returns a list of generic objects.
    ''' This helper function encapsulates the connection and exception handling for read operations.
    ''' </summary>
    ''' <typeparam name="T">The type of object to return.</typeparam>
    ''' <param name="sql">The SQL query string.</param>
    ''' <param name="parameters">An array of SQL parameters.</param>
    ''' <param name="map">A function to map a SqlDataReader row to an object of type T.</param>
    ''' <returns>A list of objects of type T.</returns>
    Private Function ExecuteReaderGeneric(Of T)(sql As String, parameters As SqlParameter(), map As Func(Of SqlDataReader, T)) As List(Of T)
        Dim items As New List(Of T)()
        Try
            Using connection As New SqlConnection(_connectionString)
                connection.Open()
                Using command As New SqlCommand(sql, connection)
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            items.Add(map(reader))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"An error occurred while executing the SQL command: {ex.Message}")
        End Try
        Return items
    End Function

    ''' <summary>
    ''' Executes a command that does not return any rows (e.g., INSERT, UPDATE, MERGE).
    ''' This helper function encapsulates the connection and exception handling for write operations.
    ''' </summary>
    ''' <param name="sql">The SQL query string.</param>
    ''' <param name="parameters">An array of SQL parameters.</param>
    Private Sub ExecuteNonQueryCommand(sql As String, parameters As SqlParameter())
        Try
            Using connection As New SqlConnection(_connectionString)
                connection.Open()
                Using command As New SqlCommand(sql, connection)
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"An error occurred while executing the SQL command: {ex.Message}")
        End Try
    End Sub
End Class





'' AATM.Data.Sql Project
'' This project is dedicated to providing concrete implementations for the data interfaces.

'Imports System.Collections.Generic
'Imports System.Data.SqlClient
'Imports AATM.Core.Data.Interfaces

'''' <summary>
'''' Provides localization data from a SQL Server database.
'''' This class implements the ILocalizationRepository interface.
'''' </summary>
'Public Class SqlLocalizationRepository
'    Implements ILocalizationRepository

'    ' The connection string for the SQL Server database.
'    Private ReadOnly _connectionString As String = "Server=localhost;Database=LocalizationDb;Integrated Security=SSPI;"

'    ''' <summary>
'    ''' Retrieves all localized strings for a specific language from the SQL database.
'    ''' This method uses a parameterized query for security.
'    ''' </summary>
'    ''' <param name="languageCode">The culture code for the language (e.g., "en-US", "ar-SA").</param>
'    ''' <returns>A list of TranslationDTO objects.</returns>
'    Public Function GetLocalizedStrings(languageCode As String) As List(Of TranslationDTO) Implements ILocalizationRepository.GetLocalizedStrings
'        Dim translations As New List(Of TranslationDTO)()
'        Dim sql As String = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString " &
'                            "FROM [dbo].[Localization] WHERE LanguageCode = @languageCode"

'        Try
'            Using connection As New SqlConnection(_connectionString)
'                connection.Open()
'                Using command As New SqlCommand(sql, connection)
'                    command.Parameters.AddWithValue("@languageCode", languageCode)
'                    Using reader As SqlDataReader = command.ExecuteReader()
'                        While reader.Read()
'                            translations.Add(New TranslationDTO With {
'                                .ID = If(reader("ID") Is DBNull.Value, 0, CInt(reader("ID"))),
'                                .OriginalString = reader("OriginalString").ToString(),
'                                .ModuleName = reader("ModuleName").ToString(),
'                                .UIIdentifier = reader("UIIdentifier").ToString(),
'                                .languageCode = reader("LanguageCode").ToString(),
'                                .LocalizedString = reader("LocalizedString").ToString()
'                            })
'                        End While
'                    End Using
'                End Using
'            End Using
'        Catch ex As Exception
'            Console.WriteLine($"An error occurred while loading translations: {ex.Message}")
'        End Try
'        Return translations
'    End Function

'    ''' <summary>
'    ''' Adds a new localized string or updates an existing one using the SQL MERGE command.
'    ''' This is a more efficient, atomic approach to the "upsert" operation.
'    ''' </summary>
'    Public Sub AddOrUpdateLocalization(originalString As String, moduleName As String, uiIdentifier As String, languageCode As String, localizedString As String) Implements ILocalizationRepository.AddOrUpdateLocalization
'        Dim sql As String = "MERGE [dbo].[Localization] AS Target " &
'                            "USING (VALUES (@originalString, @moduleName, @uiIdentifier, @languageCode, @localizedString)) " &
'                            "AS Source (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) " &
'                            "ON Target.OriginalString = Source.OriginalString " &
'                            "AND Target.ModuleName = Source.ModuleName " &
'                            "AND Target.UIIdentifier = Source.UIIdentifier " &
'                            "AND Target.LanguageCode = Source.LanguageCode " &
'                            "WHEN MATCHED THEN " &
'                            "    UPDATE SET LocalizedString = Source.LocalizedString " &
'                            "WHEN NOT MATCHED THEN " &
'                            "    INSERT (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) " &
'                            "    VALUES (Source.OriginalString, Source.ModuleName, Source.UIIdentifier, Source.LanguageCode, Source.LocalizedString);"

'        Try
'            Using connection As New SqlConnection(_connectionString)
'                connection.Open()
'                Using command As New SqlCommand(sql, connection)
'                    command.Parameters.AddWithValue("@originalString", originalString)
'                    command.Parameters.AddWithValue("@moduleName", moduleName)
'                    command.Parameters.AddWithValue("@uiIdentifier", uiIdentifier)
'                    command.Parameters.AddWithValue("@languageCode", languageCode)
'                    command.Parameters.AddWithValue("@localizedString", localizedString)
'                    command.ExecuteNonQuery()
'                    Console.WriteLine("Localization record added or updated successfully.")
'                End Using
'            End Using
'        Catch ex As Exception
'            Console.WriteLine($"An error occurred while adding/updating the localization record: {ex.Message}")
'        End Try
'    End Sub
'End Class



'' AATM.Data.Sql Project
'' This project is dedicated to providing concrete implementations for the data interfaces.

'Imports System.Collections.Generic
'Imports System.Data.SqlClient
'Imports AATM.Core.Data.Interfaces

'''' <summary>
'''' Provides localization data from a SQL Server database.
'''' This class implements the ILocalizationRepository interface.
'''' </summary>
'Public Class SqlLocalizationRepository
'    Implements ILocalizationRepository

'    ' The connection string for the SQL Server database.
'    Private ReadOnly _connectionString As String = "Server=localhost;Database=LocalizationDb;Integrated Security=SSPI;"

'    ''' <summary>
'    ''' Retrieves all localized strings for a specific language from the SQL database.
'    ''' This method uses a parameterized query for security.
'    ''' </summary>
'    ''' <param name="languageCode">The culture code for the language (e.g., "en-US", "ar-SA").</param>
'    ''' <returns>A list of TranslationDTO objects.</returns>
'    Public Function GetLocalizedStrings(languageCode As String) As List(Of TranslationDTO) Implements ILocalizationRepository.GetLocalizedStrings
'        Dim translations As New List(Of TranslationDTO)()
'        Dim sql As String = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString " &
'                            "FROM [dbo].[Localization] WHERE LanguageCode = @languageCode"

'        Try
'            Using connection As New SqlConnection(_connectionString)
'                connection.Open()
'                Using command As New SqlCommand(sql, connection)
'                    command.Parameters.AddWithValue("@languageCode", languageCode)
'                    Using reader As SqlDataReader = command.ExecuteReader()
'                        While reader.Read()
'                            translations.Add(New TranslationDTO With {
'                                .ID = If(reader("ID") Is DBNull.Value, 0, CInt(reader("ID"))),
'                                .OriginalString = reader("OriginalString").ToString(),
'                                .ModuleName = reader("ModuleName").ToString(),
'                                .UIIdentifier = reader("UIIdentifier").ToString(),
'                                .languageCode = reader("LanguageCode").ToString(),
'                                .LocalizedString = reader("LocalizedString").ToString()
'                            })
'                        End While
'                    End Using
'                End Using
'            End Using
'        Catch ex As Exception
'            Console.WriteLine($"An error occurred while loading translations: {ex.Message}")
'        End Try
'        Return translations
'    End Function

'    ''' <summary>
'    ''' Adds a new localized string or updates an existing one.
'    ''' The method first checks for an existing record and then performs the appropriate operation.
'    ''' </summary>
'    Public Sub AddOrUpdateLocalization(originalString As String, moduleName As String, uiIdentifier As String, languageCode As String, localizedString As String) Implements ILocalizationRepository.AddOrUpdateLocalization
'        Dim recordExists As Boolean = False
'        Dim checkSql As String = "SELECT COUNT(*) FROM [dbo].[Localization] " &
'                                 "WHERE OriginalString = @originalString AND ModuleName = @moduleName AND UIIdentifier = @uiIdentifier AND LanguageCode = @languageCode"

'        Try
'            Using connection As New SqlConnection(_connectionString)
'                connection.Open()

'                ' First, check if the record already exists.
'                Using checkCommand As New SqlCommand(checkSql, connection)
'                    checkCommand.Parameters.AddWithValue("@originalString", originalString)
'                    checkCommand.Parameters.AddWithValue("@moduleName", moduleName)
'                    checkCommand.Parameters.AddWithValue("@uiIdentifier", uiIdentifier)
'                    checkCommand.Parameters.AddWithValue("@languageCode", languageCode)
'                    recordExists = CInt(checkCommand.ExecuteScalar()) > 0
'                End Using

'                If recordExists Then
'                    ' If the record exists, update the localized string.
'                    Dim updateSql As String = "UPDATE [dbo].[Localization] SET LocalizedString = @localizedString " &
'                                              "WHERE OriginalString = @originalString AND ModuleName = @moduleName AND UIIdentifier = @uiIdentifier AND LanguageCode = @languageCode"

'                    Using updateCommand As New SqlCommand(updateSql, connection)
'                        updateCommand.Parameters.AddWithValue("@localizedString", localizedString)
'                        updateCommand.Parameters.AddWithValue("@originalString", originalString)
'                        updateCommand.Parameters.AddWithValue("@moduleName", moduleName)
'                        updateCommand.Parameters.AddWithValue("@uiIdentifier", uiIdentifier)
'                        updateCommand.Parameters.AddWithValue("@languageCode", languageCode)
'                        updateCommand.ExecuteNonQuery()
'                        Console.WriteLine("Localization record updated successfully.")
'                    End Using
'                Else
'                    ' If the record does not exist, insert a new one.
'                    Dim insertSql As String = "INSERT INTO [dbo].[Localization] (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) " &
'                                              "VALUES (@originalString, @moduleName, @uiIdentifier, @languageCode, @localizedString)"

'                    Using insertCommand As New SqlCommand(insertSql, connection)
'                        insertCommand.Parameters.AddWithValue("@originalString", originalString)
'                        insertCommand.Parameters.AddWithValue("@moduleName", moduleName)
'                        insertCommand.Parameters.AddWithValue("@uiIdentifier", uiIdentifier)
'                        insertCommand.Parameters.AddWithValue("@languageCode", languageCode)
'                        insertCommand.Parameters.AddWithValue("@localizedString", localizedString)
'                        insertCommand.ExecuteNonQuery()
'                        Console.WriteLine("New localization record added successfully.")
'                    End Using
'                End If
'            End Using
'        Catch ex As Exception
'            Console.WriteLine($"An error occurred while adding/updating the localization record: {ex.Message}")
'        End Try
'    End Sub
'End Class
