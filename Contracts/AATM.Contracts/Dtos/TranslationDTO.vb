''' <summary>
''' Data Transfer Object for a single localized string entry.
''' This DTO matches the columns in the Localization database table.
''' </summary>
Public Class TranslationDTO
    Public Property ID As Integer
    Public Property OriginalString As String
    Public Property ModuleName As String
    Public Property UIIdentifier As String
    Public Property LanguageCode As String
    Public Property LocalizedString As String
End Class