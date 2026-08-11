Imports System.Globalization
Imports System.Windows.Forms

Public Enum LanguageLayoutPolicy
    Fast
    FullInitialThenFast
    AlwaysFull
    Fixed
End Enum

Public Interface IFormCaptionTranslationService
    Sub Translate(form As BfMain, controls As List(Of Control), targetLanguage As String)
End Interface

Public Interface IFormLanguageLayoutService
    Sub Apply(form As BfMain, controls As List(Of Control))
End Interface

Public NotInheritable Class DefaultFormCaptionTranslationService
    Implements IFormCaptionTranslationService

    Public Sub Translate(form As BfMain,
                         controls As List(Of Control),
                         targetLanguage As String) Implements IFormCaptionTranslationService.Translate
        form.TranslateCaptionsFromService(controls, targetLanguage)
    End Sub
End Class

Public NotInheritable Class DefaultFormLanguageLayoutService
    Implements IFormLanguageLayoutService

    Public Sub Apply(form As BfMain,
                     controls As List(Of Control)) Implements IFormLanguageLayoutService.Apply
        form.ApplyLanguageLayoutFromService(controls)
    End Sub
End Class

Public NotInheritable Class LanguageSwitchContext
    Friend Sub New(originalUi As Boolean,
                   targetLanguage As String,
                   targetCulture As CultureInfo,
                   languageChanged As Boolean,
                   isInitialDisplay As Boolean,
                   controls As List(Of Control))
        Me.OriginalUi = originalUi
        Me.TargetLanguage = targetLanguage
        Me.TargetCulture = targetCulture
        Me.LanguageChanged = languageChanged
        Me.IsInitialDisplay = isInitialDisplay
        Me.Controls = controls
    End Sub

    Public ReadOnly Property OriginalUi As Boolean
    Public ReadOnly Property TargetLanguage As String
    Public ReadOnly Property TargetCulture As CultureInfo
    Public ReadOnly Property LanguageChanged As Boolean
    Public ReadOnly Property IsInitialDisplay As Boolean
    Public ReadOnly Property Controls As List(Of Control)

    Public ReadOnly Property IsRightToLeft As Boolean
        Get
            Return TargetCulture.TextInfo.IsRightToLeft
        End Get
    End Property
End Class
