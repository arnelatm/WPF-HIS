Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports AATM.Modules.Localization

Public Class FrmTranslationManager
    Implements ITranslationManagerView

    ' UI Controls
    Private WithEvents cmbLanguage As New ComboBox()
    Private WithEvents dgvTranslations As New DataGridView()
    Private WithEvents btnSave As New Button()


    ' Interface Events
    Public Event LoadView As EventHandler Implements ITranslationManagerView.LoadView
    Public Event SaveTranslation(originalString As String, localizedString As String) Implements ITranslationManagerView.SaveTranslation
    Public Event LanguageChanged(languageCode As String) Implements ITranslationManagerView.LanguageChanged

    ' Interface Methods
    Public Sub DisplayStrings(translations As List(Of (original As String, localized As String))) Implements ITranslationManagerView.DisplayStrings
        dgvTranslations.Rows.Clear()
        For Each translation In translations
            dgvTranslations.Rows.Add(translation.original, translation.localized)
        Next
    End Sub

    Public Sub DisplayLanguages(languages As List(Of (display As String, code As String))) Implements ITranslationManagerView.DisplayLanguages
        cmbLanguage.Items.Clear()
        For Each lang In languages
            cmbLanguage.Items.Add(New With {.Text = lang.display, .Value = lang.code})
        Next
        cmbLanguage.DisplayMember = "Text"
        cmbLanguage.ValueMember = "Value"
    End Sub

    Public Sub ShowSuccessMessage(message As String) Implements ITranslationManagerView.ShowSuccessMessage
        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub ShowErrorMessage(message As String) Implements ITranslationManagerView.ShowErrorMessage
        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ' Event Handlers
    Private Sub FrmTranslationManager_Load(sender As Object, e As EventArgs) Handles Me.Load
        RaiseEvent LoadView(Me, EventArgs.Empty)
    End Sub

    Private Sub cmbLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLanguage.SelectedIndexChanged
        If cmbLanguage.SelectedItem IsNot Nothing Then
            Dim languageCode As String = CType(cmbLanguage.SelectedItem, Object).Value
            RaiseEvent LanguageChanged(languageCode)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Iterate through the DataGridView and raise the save event for each row that has been modified.
        For Each row As DataGridViewRow In dgvTranslations.Rows
            If Not row.IsNewRow AndAlso Not row.Cells("LocalizedString").Value Is Nothing Then
                Dim originalString As String = row.Cells("OriginalString").Value.ToString()
                Dim localizedString As String = row.Cells("LocalizedString").Value.ToString()
                RaiseEvent SaveTranslation(originalString, localizedString)
            End If
        Next
        ShowSuccessMessage("Translations saved successfully!")
    End Sub

End Class
