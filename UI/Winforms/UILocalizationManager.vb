Imports AATM.Core.Localization
Imports System.Windows.Forms
Imports System.Collections.Generic

''' <summary>
''' Manages the process of reading UI control text and registering it with the localization service.
''' This class is specific to Windows Forms and decouples the localization core from the UI.
''' </summary>
Public Class UILocalizationManager
    Implements IUiLocalizationManager

    Private ReadOnly _localizationService As ILocalizationService

    ''' <summary>
    ''' Initializes a new instance of the UILocalizationManager.
    ''' </summary>
    ''' <param name="localizationService">The localization service to use.</param>
    Public Sub New(localizationService As ILocalizationService)
        _localizationService = localizationService
    End Sub

    ''' <summary>
    ''' Recursively walks the controls on a form and registers their text with the localization service.
    ''' </summary>
    Public Sub RegisterFormStrings(form As Form, moduleName As String, languageCode As String)
        Dim strings As New Dictionary(Of String, String)
        CollectStrings(form.Controls, strings)

        ' Add the form's title manually
        If Not String.IsNullOrWhiteSpace(form.Text) Then
            strings.Add(form.Text, form.Text)
        End If

        ' The localization service now only needs to receive the strings.
        _localizationService.AddStrings(moduleName, languageCode, strings)
    End Sub

    Private Sub RegisterControlStrings(controls As Control.ControlCollection, moduleName As String, languageCode As String)
        For Each ctrl As Control In controls
            If Not String.IsNullOrWhiteSpace(ctrl.Text) Then
                _localizationService.AddString(moduleName, ctrl.Text, languageCode)
            End If

            If ctrl.Controls.Count > 0 Then
                RegisterControlStrings(ctrl.Controls, moduleName, languageCode)
            End If
        Next
    End Sub

    Private Sub CollectStrings(controls As Control.ControlCollection, ByRef strings As Dictionary(Of String, String))
        For Each control As Control In controls
            If Not String.IsNullOrWhiteSpace(control.Text) Then
                ' Use the control's text as the key
                If Not strings.ContainsKey(control.Text) Then
                    strings.Add(control.Text, control.Text)
                End If
            End If

            If control.HasChildren Then
                CollectStrings(control.Controls, strings)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Translates all controls on a form using a provided dictionary of localized strings.
    ''' </summary>
    Public Sub SetLocalizedText(form As Form, localizedStrings As Dictionary(Of String, String))
        SetText(form.Controls, localizedStrings)
        If localizedStrings.ContainsKey(form.Text) Then
            form.Text = localizedStrings(form.Text)
        End If
    End Sub

    Private Sub SetText(controls As Control.ControlCollection, localizedStrings As Dictionary(Of String, String))
        For Each control As Control In controls
            If localizedStrings.ContainsKey(control.Text) Then
                control.Text = localizedStrings(control.Text)
            End If

            If control.HasChildren Then
                SetText(control.Controls, localizedStrings)
            End If
        Next
    End Sub

    Private Sub IUiLocalizationManager_RegisterFormStrings(form As Form, moduleName As String, languageCode As String) Implements IUiLocalizationManager.RegisterFormStrings
        RegisterFormStrings(form, moduleName, languageCode)
    End Sub

    Private Sub IUiLocalizationManager_SetLocalizedText(form As Form, localizedStrings As Dictionary(Of String, String)) Implements IUiLocalizationManager.SetLocalizedText
        SetLocalizedText(form, localizedStrings)
    End Sub
End Class

