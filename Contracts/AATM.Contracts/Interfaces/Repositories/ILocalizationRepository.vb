Imports System.Collections.Generic

''' <summary>
''' Defines a contract for a data access layer responsible for retrieving localized strings.
''' This decouples the localization service from the specific data source (e.g., SQL Server, files).
''' </summary>
Public Interface ILocalizationRepository
    ''' <summary>
    ''' Gets a list of all localized strings for a given language.
    ''' </summary>
    ''' <param name="languageCode">The culture code for the language (e.g., "en-US", "ar-SA").</param>
    ''' <returns>A list of TranslationDTO objects.</returns>
    Function GetLocalizedStrings(languageCode As String) As List(Of TranslationDTO)

    ''' <summary>
    ''' Adds a new localized string to the data source.
    ''' </summary>
    Sub AddOrUpdateLocalization(originalString As String, moduleName As String, uiIdentifier As String, languageCode As String, localizedString As String)
    Function GetLocalizationById(id As Integer) As TranslationDTO
End Interface
