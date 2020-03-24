Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Translations

Public Class MessagingBox

    Private _newHeight As Int16
    Private _textDisplayLanguage As String
    Private _close As Boolean

    Public Shared SelectedButtons As MessagingButtons

    Public Event TextDisplayLanguageChanged()

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
        btnOk.Visible = True
        btnCancel.Visible = False
        btnYes.Visible = False
        btnNo.Visible = False
        btnOk.Left = (Me.Width - Me.btnOk.Width) / 2
        btnOk.Focus()
        SelectedButtons = MessagingButtons.Ok
    End Sub

    Protected Property TextDisplayLanguage As String
        Get
            Return _textDisplayLanguage
        End Get
        Set(value As String)
            If value <> _textDisplayLanguage Then
                _textDisplayLanguage = value
                SetCulture(_textDisplayLanguage)
                RaiseEvent TextDisplayLanguageChanged()
            End If
        End Set
    End Property

    Public Sub OkCancel()
        Dim spaceLength As Int16 = 0
        btnYes.Visible = False
        btnNo.Visible = False
        btnOk.Visible = True
        btnCancel.Visible = True
        spaceLength = (Me.Width - btnOk.Width - btnCancel.Width) / 3
        If spaceLength > 0 Then
            btnOk.Left = spaceLength
        Else
            btnOk.Left = 1
        End If
        btnCancel.Left = btnCancel.Right + spaceLength
        SelectedButtons = MessagingButtons.OkCancel
    End Sub

    Public Sub AbortRetryIgnore()
        Dim spaceLength As Int16 = 0
        btnOk.Visible = True
        btnOk.Text = "&Abort"
        btnCancel.Visible = True
        btnCancel.Text = "&Retry"
        btnYes.Visible = True
        btnYes.Text = "&Ignore"
        btnNo.Visible = False
        spaceLength = (Me.Width - btnOk.Width - btnCancel.Width - btnYes.Width) / 3
        If spaceLength > 0 Then
            btnOk.Left = spaceLength
        Else
            btnOk.Left = 1
        End If
        btnOk.Left = spaceLength
        btnCancel.Left = btnOk.Left + spaceLength
        btnYes.Left = btnCancel.Right + spaceLength
        SelectedButtons = MessagingButtons.AbortRetryIgnore
    End Sub

    Public Sub YesNoCancel()
        Dim spaceLength As Int16 = 0
        btnYes.Visible = True
        btnNo.Visible = True
        btnCancel.Visible = True
        btnOk.Visible = False
        spaceLength = (Me.Width - btnYes.Width - btnNo.Width - btnCancel.Width) / 3
        If spaceLength > 0 Then
            btnYes.Left = spaceLength
        Else
            btnYes.Left = 1
        End If
        btnNo.Left = btnYes.Right + spaceLength
        btnCancel.Left = btnNo.Right + spaceLength
        SelectedButtons = MessagingButtons.YesNoCancel
    End Sub

    Public Sub YesNo()
        Dim spaceLength As Int16 = 0
        btnOk.Visible = False
        btnCancel.Visible = False
        btnYes.Visible = True
        btnNo.Visible = True
        spaceLength = (Me.Width - btnYes.Width - btnNo.Width) / 3
        If spaceLength > 0 Then
            btnYes.Left = spaceLength
        Else
            btnYes.Left = 1
        End If
        btnNo.Left = btnYes.Right + spaceLength
        SelectedButtons = MessagingButtons.YesNo
    End Sub

    Public Sub RetryCancel()
        Dim spaceLength As Int16 = 0
        btnOk.Visible = True
        btnCancel.Visible = True
        btnYes.Visible = False
        btnNo.Visible = False
        spaceLength = (Me.Width - btnOk.Width - btnCancel.Width) / 3
        If spaceLength > 0 Then
            btnOk.Left = spaceLength
        Else
            btnOk.Left = 1
        End If
        btnCancel.Left = btnOk.Right + spaceLength
        SelectedButtons = MessagingButtons.RetryCancel
    End Sub

    Public Sub CustomOneButton(caption1 As String)
        btnOk.Visible = True
        btnOk.Text = caption1
        btnCancel.Visible = False
        btnYes.Visible = False
        btnNo.Visible = False
        btnOk.Left = (Me.Width - Me.btnOk.Width) / 2
        SelectedButtons = MessagingButtons.CustomOneButton
    End Sub

    Public Sub CustomTwoButtons(caption1 As String, caption2 As String)
        Dim spaceLength As Int16 = 0
        btnOk.Visible = True
        btnOk.Text = caption1
        btnCancel.Visible = True
        btnCancel.Text = caption2
        btnYes.Visible = False
        btnNo.Visible = False
        spaceLength = (Me.Width - btnOk.Width - btnCancel.Width) / 3
        If spaceLength > 0 Then
            btnOk.Left = spaceLength
        Else
            btnOk.Left = 1
        End If
        btnCancel.Left = btnCancel.Right + spaceLength
        SelectedButtons = MessagingButtons.CustomTwoButtons
    End Sub

    Public Sub CustomThreeButtons(caption1 As String, caption2 As String, caption3 As String)
        Dim spaceLength As Int16 = 0
        btnOk.Visible = True
        btnOk.Text = caption1
        btnCancel.Visible = True
        btnCancel.Text = caption2
        btnYes.Visible = True
        btnYes.Text = caption3
        btnNo.Visible = False
        spaceLength = (Me.Width - btnOk.Width - btnCancel.Width - btnYes.Width) / 4
        If spaceLength > 0 Then
            btnOk.Left = spaceLength
        Else
            btnOk.Left = 1
        End If
        btnOk.Left = spaceLength
        btnCancel.Left = btnOk.Left + spaceLength
        btnYes.Left = btnCancel.Right + spaceLength
        SelectedButtons = MessagingButtons.CustomThreeButtons
    End Sub

    Public Sub CustomFourButtons(caption1 As String, caption2 As String, caption3 As String, caption4 As String)
        Dim spaceLength As Int16 = 0
        btnOk.Visible = True
        btnOk.Text = caption1
        btnCancel.Visible = True
        btnCancel.Text = caption2
        btnYes.Visible = True
        btnYes.Text = caption3
        btnNo.Visible = True
        btnNo.Text = caption4
        spaceLength = (Me.Width - btnOk.Width - btnCancel.Width - btnYes.Width - btnNo.Width) / 5
        If spaceLength > 0 Then
            btnOk.Left = spaceLength
        Else
            btnOk.Left = 1
        End If
        btnOk.Left = spaceLength
        btnCancel.Left = btnOk.Left + spaceLength
        btnYes.Left = btnCancel.Right + spaceLength
        SelectedButtons = MessagingButtons.CustomFourButtons
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If SelectedButtons = MessagingButtons.Ok Or SelectedButtons = MessagingButtons.OkCancel Then
            Close()
            Me.DialogResult = DialogResult.OK
        ElseIf SelectedButtons = MessagingButtons.AbortRetryIgnore Then
            Close()
            Me.DialogResult = DialogResult.Abort
        ElseIf SelectedButtons = MessagingButtons.RetryCancel Then
            Close()
            Me.DialogResult = DialogResult.Retry
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        If SelectedButtons = MessagingButtons.OkCancel Or SelectedButtons = MessagingButtons.YesNoCancel Or MessagingButtons.RetryCancel Then
            _close = True
            Me.DialogResult = DialogResult.Cancel
        ElseIf SelectedButtons = MessagingButtons.AbortRetryIgnore Then
            _close = True
            Me.DialogResult = DialogResult.Retry
        End If
    End Sub

    Private Sub btnYes_Click(ByVal sender As Object, ByVal e As EventArgs)
        If SelectedButtons = MessagingButtons.YesNo Or SelectedButtons = MessagingButtons.YesNoCancel Then
            _close = True
            Me.DialogResult = DialogResult.Yes
        ElseIf SelectedButtons = MessagingButtons.AbortRetryIgnore Then
            _close = True
            Me.DialogResult = DialogResult.Ignore
        End If
    End Sub

    Private Sub btnNo_Click(ByVal sender As Object, ByVal e As EventArgs)
        If SelectedButtons = MessagingButtons.YesNo Or SelectedButtons = MessagingButtons.YesNoCancel Then
            _close = True
            Me.DialogResult = DialogResult.No
        End If
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
        CenterForm(Me)
        Refresh()
        Show()
    End Sub

    Public Shared Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
        '' Note: call this from frm's Load event!
        Dim r As Rectangle
        If parent IsNot Nothing Then
            r = parent.RectangleToScreen(parent.ClientRectangle)
        Else
            r = Screen.FromPoint(frm.Location).WorkingArea
        End If

        Dim x = r.Left + (r.Width - frm.Width) \ 2
        Dim y = r.Top + (r.Height - frm.Height) \ 2
        frm.Location = New Point(x, y)
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
            translatedText = TranslatorDac.ExecScalar(Of String)(cmd)
            If translatedText Is Nothing Then
                Dim languageBaseCode = Strings.Left(TextDisplayLanguage, TextDisplayLanguage.IndexOf("-", StringComparison.Ordinal))
                cmd = "SELECT Translated from TranslatedMessages_View where RTrim(MessageKey) = '" + RTrim(key) + "' and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
                translatedText = TranslatorDac.ExecScalar(Of String)(cmd)
                If translatedText IsNot Nothing Then
                    translatedText = message
                End If
            End If
        Else
            translatedText = message
        End If
        Return translatedText
    End Function

    Public Enum MessagingButtons
        Ok
        OkCancel
        AbortRetryIgnore
        YesNoCancel
        YesNo
        RetryCancel
        CustomOneButton
        CustomTwoButtons
        CustomThreeButtons
        CustomFourButtons
    End Enum

End Class