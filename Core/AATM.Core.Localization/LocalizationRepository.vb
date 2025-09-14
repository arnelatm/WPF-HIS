Imports System.Collections.Generic
Imports System.Data.SqlClient

''' <summary>
''' A concrete implementation of ILocalizationRepository that retrieves
''' localized strings from a SQL Server database.
''' </summary>
Public Class LocalizationRepository
    Implements ILocalizationRepository

    Private ReadOnly _connectionString As String

    Public Sub New(connectionString As String)
        _connectionString = connectionString
    End Sub

    Public Function GetLocalizedStrings(languageCode As String) As List(Of TranslationDTO) Implements ILocalizationRepository.GetLocalizedStrings
        Dim localizedStrings As New List(Of TranslationDTO)()
        Using conn As New SqlConnection(_connectionString)
            Dim sql As String = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString FROM Localization WHERE LanguageCode = @languageCode"
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@languageCode", languageCode)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim dto As New TranslationDTO()
                        dto.ID = reader.GetInt32(reader.GetOrdinal("ID"))
                        dto.OriginalString = reader("OriginalString").ToString()
                        dto.ModuleName = reader("ModuleName").ToString()
                        dto.UIIdentifier = reader("UIIdentifier").ToString()
                        dto.LanguageCode = reader("LanguageCode").ToString()
                        dto.LocalizedString = reader("LocalizedString").ToString()
                        localizedStrings.Add(dto)
                    End While
                End Using
            End Using
        End Using
        Return localizedStrings
    End Function

    Public Sub AddOrUpdateLocalization(originalString As String, moduleName As String, uiIdentifier As String, languageCode As String, localizedString As String) Implements ILocalizationRepository.AddOrUpdateLocalization
        Using conn As New SqlConnection(_connectionString)
            Dim sql As String = "MERGE Localization AS target USING (SELECT @originalString, @moduleName, @uiIdentifier, @languageCode, @localizedString) AS source (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) ON (target.OriginalString = source.OriginalString AND target.UIIdentifier = source.UIIdentifier AND target.LanguageCode = source.LanguageCode) WHEN MATCHED THEN UPDATE SET LocalizedString = source.LocalizedString, ModuleName = source.ModuleName WHEN NOT MATCHED THEN INSERT (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString) VALUES (source.OriginalString, source.ModuleName, source.UIIdentifier, source.LanguageCode, source.LocalizedString);"
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@originalString", originalString)
                cmd.Parameters.AddWithValue("@moduleName", moduleName)
                cmd.Parameters.AddWithValue("@uiIdentifier", uiIdentifier)
                cmd.Parameters.AddWithValue("@languageCode", languageCode)
                cmd.Parameters.AddWithValue("@localizedString", localizedString)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
