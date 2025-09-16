Public Interface ILocalizationService
    ReadOnly Property IsRightToLeft As Boolean
    Sub AddOrUpdateString(moduleName As String, uiIdentifier As String, originalString As String, languageCode As String, localizedString As String)
    ''' <summary>
    ''' Defines the contract for a translation service.
    ''' </summary>
    Function Translate(ByVal sourceLang As String, ByVal targetLang As String, ByVal textToTranslate As String) As String
    Function GetAvailableLanguages() As List(Of (display As String, code As String))
    Function GetString(uiIdentifier As String, originalString As String) As String
    Function GetLocalizedStrings() As IDictionary(Of String, String)
End Interface
