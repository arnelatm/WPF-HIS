Imports AATM.Core.Localization


''' <summary>
''' Defines the contract for the Translation Manager View.
''' This decouples the Presenter from the specific WinForms UI implementation.
''' </summary>
Public Interface ITranslationManagerView

    ''' <summary>
    ''' Event raised when the user clicks the save button.
    ''' The presenter will subscribe to this event to save the translation.
    ''' </summary>
    Event SaveTranslation As Action(Of String, String, String, String, String)

    ''' <summary>
    ''' Event raised when the user selects a new language.
    ''' The presenter will handle this to load translations for the new language.
    ''' </summary>
    Event LanguageSelected As Action(Of String)

    ''' <summary>
    ''' Displays the list of available languages in the language dropdown.
    ''' </summary>
    Sub DisplayLanguages(languages As List(Of (display As String, code As String)))

    ''' <summary>
    ''' Displays translations in a DataGridView or similar control.
    ''' </summary>
    Sub DisplayTranslations(translations As List(Of TranslationDTO))

    ''' <summary>
    ''' Displays a message to the user, for example in a status bar or message box.
    ''' </summary>
    Sub ShowMessage(message As String)

    ''' <summary>
    ''' Gets the selected language code from the view.
    ''' </summary>
    Function GetSelectedLanguageCode() As String

    ''' <summary>
    ''' Gets the original string entered by the user.
    ''' </summary>
    Function GetOriginalString() As String

    ''' <summary>
    ''' Gets the translated string entered by the user.
    ''' </summary>
    Function GetLocalizedString() As String

End Interface




'Imports System.Collections.Generic

'Public Interface ITranslationManagerView
'    ' Events that the presenter will subscribe to
'    Event LoadView As EventHandler
'    Event SaveTranslation(originalString As String, localizedString As String)
'    Event LanguageChanged(languageCode As String)

'    ' Methods the presenter will call to update the view
'    Sub DisplayStrings(translations As List(Of (original As String, localized As String)))
'    Sub DisplayLanguages(languages As List(Of (display As String, code As String)))
'    Sub ShowSuccessMessage(message As String)
'    Sub ShowErrorMessage(message As String)
'End Interface
