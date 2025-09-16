''' <summary>
''' Defines the contract for a service that provides and manages localized strings.
''' </summary>
Public Interface ILocalizationService

    ''' <summary>
    ''' Retrieves a dictionary of all localized strings for the current language.
    ''' </summary>
    ''' <returns>A Dictionary where the key is the UI identifier and the value is the localized string.</returns>
    Function GetLocalizedStrings() As IDictionary(Of String, String)

    ''' <summary>
    ''' Gets a localized string for a specific UI element in the current language.
    ''' If the translation is not found, the original string is returned.
    ''' </summary>
    ''' <param name="uiIdentifier">The unique identifier of the UI element (e.g., "btnSave").</param>
    ''' <param name="originalString">The original, untranslated text (e.g., "Save").</param>
    ''' <returns>The localized string or the original string if not found.</returns>
    Function GetString(uiIdentifier As String, originalString As String) As String

    ''' <summary>
    ''' Adds a new localized string to the database or updates an existing one.
    ''' </summary>
    Sub AddOrUpdateString(moduleName As String, uiIdentifier As String, originalString As String, languageCode As String, localizedString As String)

    ''' <summary>
    ''' Gets a list of available languages for localization.
    ''' The result includes both the display name and the language code.
    ''' </summary>
    Function GetAvailableLanguages() As List(Of (display As String, code As String))

    ''' <summary>
    ''' Indicates whether the current language is a right-to-left language.
    ''' </summary>
    ReadOnly Property IsRightToLeft As Boolean

End Interface





'''' <summary>
'''' Defines a contract for a service that provides localized strings.
'''' </summary>
'Public Interface ILocalizationService

'    ''' <summary>
'    ''' Gets the localized string for a specified key.
'    ''' </summary>
'    ''' <param name="key">The key of the string to retrieve.</param>
'    ''' <returns>The localized string, or the key itself if not found.</returns>
'    Function GetString(key As String) As String

'    ''' <summary>
'    ''' Indicates whether the current language is a Right-to-Left language.
'    ''' </summary>
'    ReadOnly Property IsRightToLeft As Boolean

'    ''' <summary>
'    ''' Sets the current language for the application.
'    ''' </summary>
'    ''' <param name="languageCode">The code for the language to set (e.g., "en-US", "ar-SA").</param>
'    Sub SetLanguage(languageCode As String)

'    ''' <summary>
'    ''' Retrieves a dictionary of all localized strings for a specific module.
'    ''' </summary>
'    ''' <param name="moduleName">The name of the module to retrieve strings for.</param>
'    ''' <returns>A dictionary of localized strings.</returns>
'    Function GetLocalizedStrings(moduleName As String) As Dictionary(Of String, String)

'    ''' <summary>
'    ''' Retrieves a list of all available language codes and their display names.
'    ''' </summary>
'    ''' <returns>A list of tuples containing the language display name and code.</returns>
'    Function GetAvailableLanguages() As List(Of (display As String, code As String))

'    ''' <summary>
'    ''' Adds a dictionary of strings to the localization service.
'    ''' </summary>
'    Sub AddStrings(moduleName As String, languageCode As String, strings As Dictionary(Of String, String))

'    ''' <summary>
'    ''' Adds a string to the localization dictionary for a specific module and language.
'    ''' </summary>
'    ''' <param name="moduleName">The name of the module.</param>
'    ''' <param name="originalString">The original, non-localized string.</param>
'    ''' <param name="languageCode">The language culture code.</param>
'    Sub AddString(moduleName As String, originalString As String, languageCode As String)

'End Interface