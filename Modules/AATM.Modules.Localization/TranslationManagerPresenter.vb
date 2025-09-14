Imports AATM.Core.Localization
Imports AATM.Modules.Localization.AATM.Modules.Localization

''' <summary>
''' Presenter for the Translation Management user interface.
''' This class contains the business logic for loading and saving translations.
''' </summary>
Public Class TranslationManagerPresenter

    Private ReadOnly _localizationService As ILocalizationService
    Private ReadOnly _localizationRepository As ILocalizationRepository
    Private ReadOnly _view As ITranslationManagerView

    Public Sub New(view As ITranslationManagerView, localizationService As ILocalizationService, localizationRepository As ILocalizationRepository)
        _view = view
        _localizationService = localizationService
        _localizationRepository = localizationRepository
        AddHandler _view.SaveTranslation, AddressOf OnSaveTranslation
    End Sub

    ''' <summary>
    ''' Initializes the view by loading all available languages.
    ''' This should be called when the form is first displayed.
    ''' </summary>
    Public Sub Initialize()
        ' Get the list of languages and populate the view's language dropdown
        Dim languages As List(Of (display As String, code As String)) = _localizationService.GetAvailableLanguages()
        _view.DisplayLanguages(languages)
    End Sub

    ''' <summary>
    ''' Loads all translations for a selected language and populates the view.
    ''' </summary>
    Public Sub LoadTranslations(languageCode As String)
        Dim translations As List(Of TranslationDTO) = _localizationRepository.GetLocalizedStrings(languageCode)
        Dim viewTranslations As New List(Of (original As String, localized As String))
        For Each translation In translations
            viewTranslations.Add((translation.OriginalString, translation.LocalizedString))
        Next
        _view.DisplayStrings(viewTranslations)
    End Sub

    Private Sub OnSaveTranslation(originalString As String, localizedString As String)
        ' This is a placeholder. A full implementation would need more data,
        ' such as module name and language code.
        _localizationRepository.AddOrUpdateLocalization(
            originalString,
            "TranslationManager", ' ModuleName is hard-coded for now
            originalString, ' UIIdentifier is hard-coded for now
            "en-US", ' LanguageCode is hard-coded for now
            localizedString)

        _view.ShowSuccessMessage("Translation saved successfully!")

        ' After saving, reload the translations to refresh the grid
        LoadTranslations("en-US")
    End Sub
End Class

'Imports System.Collections.Generic
'Imports System.Linq
'Imports AATM.Core.Localization

'''' <summary>
'''' Presenter for the Translation Management user interface.
'''' This class contains the business logic for loading and saving translations.
'''' </summary>
'Public Class TranslationManagerPresenter

'    Private ReadOnly _localizationService As ILocalizationService
'    Private ReadOnly _localizationRepository As ILocalizationRepository
'    Private ReadOnly _view As ITranslationManagerView

'    Public Sub New(view As ITranslationManagerView, localizationService As ILocalizationService, localizationRepository As ILocalizationRepository)
'        _view = view
'        _localizationService = localizationService
'        _localizationRepository = localizationRepository
'        AddHandler _view.SaveTranslation, AddressOf OnSaveTranslation
'    End Sub

'    ''' <summary>
'    ''' Initializes the view by loading all available languages.
'    ''' This should be called when the form is first displayed.
'    ''' </summary>
'    Public Sub Initialize()
'        ' Get the list of languages and populate the view's language dropdown
'        Dim languages As List(Of (display As String, code As String)) = _localizationService.GetAvailableLanguages()
'        _view.DisplayLanguages(languages)
'    End Sub

'    ''' <summary>
'    ''' Loads all translations for a selected language and populates the view.
'    ''' </summary>
'    Public Sub LoadTranslations(languageCode As String)
'        Dim translations As List(Of TranslationDTO) = _localizationRepository.GetLocalizedStrings(languageCode)
'        Dim viewTranslations As New List(Of (original As String, localized As String))
'        For Each translation In translations
'            viewTranslations.Add((translation.OriginalString, translation.LocalizedString))
'        Next
'        _view.DisplayStrings(viewTranslations)
'    End Sub

'    Private Sub OnSaveTranslation(originalString As String, localizedString As String)
'        ' This is a placeholder. A full implementation would need more data,
'        ' such as module name and language code.
'        _localizationRepository.AddOrUpdateLocalization(
'            originalString,
'            "TranslationManager", ' ModuleName is hard-coded for now
'            originalString, ' UIIdentifier is hard-coded for now
'            "en-US", ' LanguageCode is hard-coded for now
'            localizedString)

'        _view.ShowSuccessMessage("Translation saved successfully!")

'        ' After saving, reload the translations to refresh the grid
'        LoadTranslations("en-US")
'    End Sub
'End Class


'Imports System.Collections.Generic
'Imports System.Linq
'Imports AATM.Core.Localization


'''' <summary>
'''' Presenter for the Translation Management user interface.
'''' This class contains the business logic for loading and saving translations.
'''' </summary>
'Public Class TranslationManagerPresenter

'    Private ReadOnly _localizationService As ILocalizationService
'    Private ReadOnly _localizationRepository As ILocalizationRepository
'    Private ReadOnly _view As ITranslationManagerView

'    Public Sub New(view As ITranslationManagerView, localizationService As ILocalizationService, localizationRepository As ILocalizationRepository)
'        _view = view
'        _localizationService = localizationService
'        _localizationRepository = localizationRepository
'        AddHandler _view.SaveTranslationClicked, AddressOf OnSaveTranslationClicked
'    End Sub

'    ''' <summary>
'    ''' Initializes the view by loading all available languages.
'    ''' This should be called when the form is first displayed.
'    ''' </summary>
'    Public Sub Initialize()
'        ' Get the list of languages and populate the view's language dropdown
'        Dim languages As List(Of (display As String, code As String)) = _localizationService.GetAvailableLanguages()
'        _view.DisplayLanguages(languages)
'    End Sub

'    ''' <summary>
'    ''' Loads all translations for a selected language and populates the view.
'    ''' </summary>
'    Public Sub LoadTranslations(languageCode As String)
'        Dim translations As List(Of TranslationDTO) = _localizationRepository.GetLocalizedStrings(languageCode)
'        _view.DisplayTranslations(translations)
'    End Sub

'    Private Sub OnSaveTranslationClicked(sender As Object, e As TranslationEventArgs)
'        _localizationRepository.AddOrUpdateLocalization(
'            e.OriginalString,
'            e.ModuleName,
'            e.UIIdentifier,
'            e.LanguageCode,
'            e.LocalizedString)

'        _view.ShowMessage("Translation saved successfully!")

'        ' After saving, reload the translations to refresh the grid
'        LoadTranslations(e.LanguageCode)
'    End Sub

'End Class

'''' <summary>
'''' Custom event arguments for the TranslationEventArgs event.
'''' </summary>
'Public Class TranslationEventArgs
'    Inherits EventArgs

'    Public Property OriginalString As String
'    Public Property ModuleName As String
'    Public Property UIIdentifier As String
'    Public Property LanguageCode As String
'    Public Property LocalizedString As String
'End Class


