Imports System.Data.SqlClient
Imports System.Collections.Generic

''' <summary>
''' Manages the retrieval of localized strings from the database with a caching layer.
''' </summary>
Public Class LocalizationManager
    ' A private dictionary to cache the translations in memory.
    ' The key is a composite string of the original string, module name, UI identifier, and language code.
    Private ReadOnly _translationCache As New Dictionary(Of String, String)()

    ' The connection string for the SQL Server database.
    Private ReadOnly _connectionString As String = "Server=Ibn-Server;Database=IspData;Integrated Security=SSPI;"

    ''' <summary>
    ''' Retrieves all translations from the database and populates the cache.
    ''' </summary>
    Private Sub LoadAllTranslations()
        Try
            Using connection As New SqlConnection(_connectionString)
                connection.Open()
                Dim sql As String = "SELECT [OriginalString], [ModuleName], [UIIdentifier], [LanguageCode], [LocalizedString] FROM [dbo].[Localization]"
                Using command As New SqlCommand(sql, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            ' Create a unique key for the dictionary cache.
                            Dim cacheKey As String = $"{reader("OriginalString")}|{reader("ModuleName")}|{reader("UIIdentifier")}|{reader("LanguageCode")}"
                            Dim localizedString As String = reader("LocalizedString").ToString()

                            ' Add the translation to the cache.
                            If Not _translationCache.ContainsKey(cacheKey) Then
                                _translationCache.Add(cacheKey, localizedString)
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' In a production environment, you would log this error.
            Console.WriteLine($"An error occurred while loading translations: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Gets the localized string for the specified key and language.
    ''' </summary>
    ''' <param name="originalString">The original string (e.g., "Welcome to the system").</param>
    ''' <param name="moduleName">The name of the module (e.g., "Login").</param>
    ''' <param name="uiIdentifier">The UI element identifier (e.g., "WelcomeHeader").</param>
    ''' <param name="languageCode">The language code (e.g., "en-US").</param>
    ''' <returns>The localized string or the original string if no translation is found.</returns>
    Public Function GetLocalizedString(ByVal originalString As String, ByVal moduleName As String, ByVal uiIdentifier As String, ByVal languageCode As String) As String
        ' First, check if the cache is empty. If so, load all translations.
        If _translationCache.Count = 0 Then
            LoadAllTranslations()
        End If

        ' Create the key for the cache lookup.
        Dim cacheKey As String = $"{originalString}|{moduleName}|{uiIdentifier}|{languageCode}"

        ' Look up the translation in the cache.
        If _translationCache.ContainsKey(cacheKey) Then
            Return _translationCache(cacheKey)
        Else
            ' If not found in the cache, return the original string as a fallback.
            Return originalString
        End If
    End Function
End Class

''' <summary>
''' A sample module to demonstrate how to use the LocalizationManager.
''' </summary>
Module Program
    Sub Main()
        ' Create an instance of the localization manager.
        Dim localizationManager As New LocalizationManager()

        ' Simulate an English user.
        Dim englishWelcome As String = localizationManager.GetLocalizedString("Welcome to the system", "Login", "WelcomeHeader", "en-US")
        Console.WriteLine($"English Welcome: {englishWelcome}")

        ' Simulate an Arabic user.
        Dim arabicWelcome As String = localizationManager.GetLocalizedString("Welcome to the system", "Login", "WelcomeHeader", "ar-SA")
        Console.WriteLine($"Arabic Welcome: {arabicWelcome}")

        Console.ReadKey()
    End Sub
End Module
