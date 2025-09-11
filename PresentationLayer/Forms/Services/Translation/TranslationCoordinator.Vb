Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Localization.Core
Imports AATM.Libraries.Localization.Services
Imports AATM.Libraries.Messaging
Imports AATM.Presentation.Events
Imports AATM.Presentation.Forms.Services.SystemView

Namespace Services.Translation
    Public Class TranslationCoordinator
        Private ReadOnly _form As Form
        Private ReadOnly _eventAggregator As EventAggregator
        Private ReadOnly _systemViewProvider As SystemViewIdProvider
        Private ReadOnly _ltrCulture As String
        Private ReadOnly _rtlCulture As String
        Private _repo As ITranslationRepository
        Private _cache As TranslationCache
        Private _translator As FormTranslationService
        Private _initialized As Boolean

        Public Sub New(form As Form,
                       ea As EventAggregator,
                       systemViewProvider As SystemViewIdProvider,
                       ltrCulture As String,
                       rtlCulture As String)
            _form = form
            _eventAggregator = ea
            _systemViewProvider = systemViewProvider
            _ltrCulture = ltrCulture
            _rtlCulture = rtlCulture
        End Sub

        Public Sub Initialize(translatorDac As Dac)
            If _initialized Then Return
            If translatorDac Is Nothing Then
                _repo = New NullTranslationRepository()
            Else
                _repo = New TranslationRepository(translatorDac)
                TranslatorAccessor.InitializeTranslator(translatorDac)
            End If
            _cache = New TranslationCache(_repo)
            _translator = New FormTranslationService(_form, _repo, _cache)
            Dim viewId = _systemViewProvider.GetId()
            If viewId > 0 Then
                _translator.Preload({_ltrCulture, _rtlCulture}, {viewId})
            End If
            _initialized = True
        End Sub

        Public Sub Invalidate()
            If _translator IsNot Nothing Then
                _translator.Invalidate()
            ElseIf _cache IsNot Nothing Then
                _cache.Clear()
            End If
        End Sub

        Public Sub TranslateCurrent(Optional allowFallback As Boolean = True)
            If Not _initialized Then Return
            _translator.TranslateCurrentForm(allowFallback)
        End Sub

        Public Sub SwitchUiLanguage(originalUi As Boolean, adjustButtons As Action)
            If Not _initialized Then Return
            Dim target = If(originalUi, _ltrCulture, _rtlCulture)
            If Not String.Equals(CultureInfo.CurrentCulture.Name, target, StringComparison.OrdinalIgnoreCase) Then
                GlobalFunctions.SetCulture(target)
                GlobalVariables.AppCurrentCultureInfo = CultureInfo.CurrentCulture
                GlobalVariables.RightToLeftLayout = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
            End If
            _translator.TranslateCurrentForm()
            adjustButtons?.Invoke()
            _eventAggregator?.PublishEvent(New LanguageChanged(_form))
        End Sub
    End Class
End Namespace