Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Translations

Public Class MessagingBox

    Public Const SqlError = "Error connecting to server"
    Private _newHeight As Int16
    Private _textDisplayLanguage As String
    Private _close As Boolean
    Private Shared _dataAccessControl

    Public Shared SelectedButtons As MessagingButtons

    Public Event TextDisplayLanguageChanged()

    Private Shared Sub CreateDataAccessControl()
        If _dataAccessControl Is Nothing Then
            _dataAccessControl = New Dac
        End If
    End Sub

    Public Sub SetInfoIcon()
        pctInfo.Visible = True
    End Sub

    Public Sub SetQuestionIcon()
        pctQuestion.Visible = True
    End Sub

    Public Sub SetErrorIcon()
        pctError.Visible = True
    End Sub

    Public Sub SetWarningIcon()
        pctWarning.Visible = True
    End Sub

    Public Property MessageKey As String

    Public Sub Ok()
        btnOk.Visible = True
        btnCancel.Visible = False
        btnYes.Visible = False
        btnNo.Visible = False
        btnOk.Left = (Width - btnOk.Width) / 2
        btnOk.Focus()
        SelectedButtons = MessagingButtons.Ok
    End Sub

    Protected Property TextDisplayLanguage As String
        Get
            If _textDisplayLanguage Is Nothing Then
                _textDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name
            End If
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
        Dim spaceLength As Int16
        btnYes.Visible = False
        btnNo.Visible = False
        btnOk.Visible = True
        btnCancel.Visible = True
        spaceLength = (Width - btnOk.Width - btnCancel.Width) / 3
        If spaceLength > 0 Then
            btnOk.Left = spaceLength
        Else
            btnOk.Left = 1
        End If
        btnCancel.Left = btnCancel.Right + spaceLength
        SelectedButtons = MessagingButtons.OkCancel
    End Sub

    Public Sub AbortRetryIgnore()
        Dim spaceLength As Int16
        btnOk.Visible = True
        btnOk.Text = "&Abort"
        btnCancel.Visible = True
        btnCancel.Text = "&Retry"
        btnYes.Visible = True
        btnYes.Text = "&Ignore"
        btnNo.Visible = False
        spaceLength = (Width - btnOk.Width - btnCancel.Width - btnYes.Width) / 3
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
        Dim spaceLength As Int16
        btnYes.Visible = True
        btnNo.Visible = True
        btnCancel.Visible = True
        btnOk.Visible = False
        spaceLength = (Width - btnYes.Width - btnNo.Width - btnCancel.Width) / 3
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
        Dim spaceLength As Int16
        btnOk.Visible = False
        btnCancel.Visible = False
        btnYes.Visible = True
        btnNo.Visible = True
        spaceLength = (Width - btnYes.Width - btnNo.Width) / 3
        If spaceLength > 0 Then
            btnYes.Left = spaceLength
        Else
            btnYes.Left = 1
        End If
        btnNo.Left = btnYes.Right + spaceLength
        SelectedButtons = MessagingButtons.YesNo
    End Sub

    Public Sub RetryCancel()
        Dim spaceLength As Int16
        btnOk.Visible = True
        btnCancel.Visible = True
        btnYes.Visible = False
        btnNo.Visible = False
        spaceLength = (Width - btnOk.Width - btnCancel.Width) / 3
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
        btnOk.Left = (Width - btnOk.Width) / 2
        SelectedButtons = MessagingButtons.CustomOneButton
    End Sub

    Public Sub CustomTwoButtons(caption1 As String, caption2 As String)
        Dim spaceLength As Int16
        btnOk.Visible = True
        btnOk.Text = caption1
        btnCancel.Visible = True
        btnCancel.Text = caption2
        btnYes.Visible = False
        btnNo.Visible = False
        spaceLength = (Width - btnOk.Width - btnCancel.Width) / 3
        If spaceLength > 0 Then
            btnOk.Left = spaceLength
        Else
            btnOk.Left = 1
        End If
        btnCancel.Left = btnCancel.Right + spaceLength
        SelectedButtons = MessagingButtons.CustomTwoButtons
    End Sub

    Public Sub CustomThreeButtons(caption1 As String, caption2 As String, caption3 As String)
        Dim spaceLength As Int16
        btnOk.Visible = True
        btnOk.Text = caption1
        btnCancel.Visible = True
        btnCancel.Text = caption2
        btnYes.Visible = True
        btnYes.Text = caption3
        btnNo.Visible = False
        spaceLength = (Width - btnOk.Width - btnCancel.Width - btnYes.Width) / 4
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
        Dim spaceLength As Int16
        btnOk.Visible = True
        btnOk.Text = caption1
        btnCancel.Visible = True
        btnCancel.Text = caption2
        btnYes.Visible = True
        btnYes.Text = caption3
        btnNo.Visible = True
        btnNo.Text = caption4
        spaceLength = (Width - btnOk.Width - btnCancel.Width - btnYes.Width - btnNo.Width) / 5
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

    Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
        If SelectedButtons = MessagingButtons.Ok Or SelectedButtons = MessagingButtons.OkCancel Then
            Close()
            DialogResult = DialogResult.OK
        ElseIf SelectedButtons = MessagingButtons.AbortRetryIgnore Then
            Close()
            DialogResult = DialogResult.Abort
        ElseIf SelectedButtons = MessagingButtons.RetryCancel Then
            Close()
            DialogResult = DialogResult.Retry
        End If
    End Sub

    Private Sub btnCancel_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
        If SelectedButtons = MessagingButtons.OkCancel Or SelectedButtons = MessagingButtons.YesNoCancel Or MessagingButtons.RetryCancel Then
            _close = True
            DialogResult = DialogResult.Cancel
        ElseIf SelectedButtons = MessagingButtons.AbortRetryIgnore Then
            _close = True
            DialogResult = DialogResult.Retry
        End If
    End Sub

    Private Sub btnYes_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnYes.ClickButtonArea
        If SelectedButtons = MessagingButtons.YesNo Or SelectedButtons = MessagingButtons.YesNoCancel Then
            _close = True
            DialogResult = DialogResult.Yes
        ElseIf SelectedButtons = MessagingButtons.AbortRetryIgnore Then
            _close = True
            DialogResult = DialogResult.Ignore
        End If
    End Sub

    Private Sub btnNo_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnNo.ClickButtonArea
        If SelectedButtons = MessagingButtons.YesNo Or SelectedButtons = MessagingButtons.YesNoCancel Then
            _close = True
            DialogResult = DialogResult.No
        End If
    End Sub

    Private Sub MyMessageBox_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
        e.Cancel = Not _close
    End Sub

    Private Sub MyMessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMessage.BackColor = BackColor
        Dim tSize = TextRenderer.MeasureText(
            txtMessage.Text,
            txtMessage.Font,
            New Size(txtMessage.Width, 1000),
            TextFormatFlags.WordBreak
            )
        txtMessage.Height = tSize.Height + 10
        _newHeight = tSize.Height + 85
        Height = _newHeight
        CenterForm(Me)
        AutoSize = False
        Height = _newHeight
        Refresh()
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
        MessageKey = key
        StoreCaptions1.InsertMessage(key, message)
        Return GetTranslatedMessage(key, message)
    End Function

    Protected Function GetTranslatedMessage(ByVal key As String, ByVal message As String)
        Dim translatedText As String
        Dim cmd As String
        MessageKey = key
        If NeedToTranslateText(TextDisplayLanguage) Then
            CreateDataAccessControl()
            cmd = "SELECT Translated FROM TranslatedMessages_View where CultureInfoCode = '" + TextDisplayLanguage.TrimEnd + "'"
            translatedText = _dataAccessControl.ExecScalar(Of String)(cmd)
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

    Private Sub MessagingBox_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Text = Me.Text.Trim() & $" [{MessageKey}]"
        btnOk.Text = TranslateCaptions(btnOk.Text)
        btnCancel.Text = TranslateCaptions(btnCancel.Text)
        btnYes.Text = TranslateCaptions(btnYes.Text)
        btnNo.Text = TranslateCaptions(btnNo.Text)
    End Sub

    Private Function TranslateCaptions(textToTranslate As String)
        Dim translatedText = textToTranslate
        If NeedToTranslateText(TextDisplayLanguage) Then
            Dim cmd As String
            CreateDataAccessControl()
            cmd = "SELECT Concat(Coalesce(Translated,'') ,'~',Caption) FROM Captions_View where Caption = '" & textToTranslate.Trim() & "' and CultureInfoCode = '" + TextDisplayLanguage.TrimEnd + "'"
            translatedText = _dataAccessControl.ExecScalar(Of String)(cmd)
            If translatedText IsNot Nothing AndAlso Strings.Left(translatedText, 1) <> "~" Then
                If GlobalVariables.RightToLeftLayout Then
                    translatedText = Strings.Left(translatedText, translatedText.IndexOf("~", StringComparison.CurrentCulture))
                Else
                    translatedText = Strings.Mid(translatedText, translatedText.IndexOf("~", StringComparison.CurrentCulture)+1)
                End If
            Else
                AddCaption(textToTranslate)
                translatedText = textToTranslate
            End If
        End If
        Return translatedText
    End Function

    Sub ErrorMessage(ByVal e As Exception,
                     Optional ByVal s2 As String = "")
        Dim s As String = e.Message
        If Not e.InnerException Is Nothing Then _
            s += ControlChars.CrLf + e.InnerException.Message
        MessageBox.Show(s, $"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Function AddCaption(ByVal caption As String) As Boolean
        Dim cmd As String
        Dim status As Boolean = True
        Dim cs
        CreateDataAccessControl()
        cmd = "SELECT IdNo From OriginalCaptions where Caption = '" + caption + "'"
        Dim idNo As Int32 = _dataAccessControl.ExecScalar(Of Int32)(cmd)
        If idNo = 0 Then
            cs = _dataAccessControl.BuildConnString()
            Dim conn As SqlConnection = New SqlConnection(cs)
            Dim sqlCommand As New SqlCommand("INSERT INTO OriginalCaption (caption) values (@caption)", conn)
            Try
                conn.Open()
                sqlCommand.Parameters.Add("@caption", SqlDbType.VarChar).Value = caption
                sqlCommand.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                ErrorMessage(ex, SqlError)
                status = False
            Finally
                If conn.State = ConnectionState.Open Then conn.Close()
            End Try
        End If
        Return status
    End Function


End Class