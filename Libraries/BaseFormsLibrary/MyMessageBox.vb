Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class MyMessageBox

    Private _newHeight As Int16

    Private _close As Boolean

    Public Sub SetInfoIcon()
        Me.pctInfo.Visible = True
    End Sub

    Public Sub SetQuestionIcon()
        Me.pctQuestion.Visible = True
    End Sub

    Public Sub SetErrorIcon()
        Me.pctError.Visible = True
    End Sub

    Public Sub SetWarningIcon()
        Me.pctWarning.Visible = True
    End Sub

    Public Sub Ok()
        btnYes.Visible = False
        btnNo.Visible = False
        btnCancel.Visible = False
        btnOk.Visible = True
        btnOk.Left = (Me.Width - Me.btnOk.Width) / 2
        btnOk.Focus()
    End Sub

    Public Sub Yes()
        btnYes.Visible = True
        btnNo.Visible = False
        btnCancel.Visible = False
        btnYes.Left = (Me.Width - Me.btnYes.Width) / 2
    End Sub

    Public Sub YesNo()
        btnYes.Visible = True
        btnNo.Visible = True
        btnCancel.Visible = False
        btnYes.Left = Me.Width / 2 - btnYes.Width - 5
        btnNo.Left = btnYes.Right + 5
    End Sub

    Public Sub YesNoCancel()
        btnYes.Visible = True
        btnNo.Visible = True
        btnCancel.Visible = True
        btnYes.Left = Me.Width / 2 - btnYes.Width - (btnYes.Width / 2) - 10
        btnNo.Left = btnYes.Right + 5
        btnCancel.Left = btnNo.Right + 5
    End Sub

    Private Sub btnNo_Click(ByVal sender As Object, ByVal e As EventArgs)
        _close = True
        Me.DialogResult = DialogResult.No
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        _close = True
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnYes_Click(ByVal sender As Object, ByVal e As EventArgs)
        _close = True
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub MyMessageBox_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
        e.Cancel = Not _close
    End Sub

    Private Sub MyMessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMessage.BackColor = Me.BackColor
        Dim tSize = TextRenderer.MeasureText(
            txtMessage.Text,
            txtMessage.Font,
            New Size(txtMessage.Width, 1000),
            TextFormatFlags.WordBreak
            )
        txtMessage.Height = tSize.Height + 10
        _newHeight = tSize.Height + 85
        Me.Height = _newHeight
        Refresh()
        Hide()
        AutoSize = False
        Me.Height = _newHeight
        Refresh()
        Show()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Close()
    End Sub

    Public Function CreateMessage(key, message)
        StoreCaptions1.InsertMessage(key, message)
        Return GetTranslatedMessage(key, message)
    End Function

    Protected Function GetTranslatedMessage(ByVal key As String, ByVal message As String)
        Dim translatedText As String
        Dim cmd As String
        If NeedToTranslateText(TextDisplayLanguage) Then
            cmd = "SELECT Translated FROM TranslatedMessages_View where CultureInfoCode = '" + TextDisplayLanguage.TrimEnd + "'"
            translatedText = TranslatorDAC.ExecScalar(Of String)(cmd)
            If translatedText Is Nothing Then
                Dim languageBaseCode = Strings.Left(TextDisplayLanguage, TextDisplayLanguage.IndexOf("-", StringComparison.Ordinal))
                cmd = "SELECT Translated from TranslatedMessages_View where RTrim(MessageKey) = '" + RTrim(key) + "' and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
                translatedText = TranslatorDAC.ExecScalar(Of String)(cmd)
                If translatedText IsNot Nothing Then
                    translatedText = message
                End If
            End If
        Else
            translatedText = message
        End If
        Return translatedText
    End Function

End Class