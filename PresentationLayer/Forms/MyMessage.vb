Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Translations

Public Class MyMessage

    Public Shared Function Show(ByVal key As String, ByVal message As String, ByVal Optional caption As String = "") As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        CreateMessage(key, message, caption)
        p.txtMessage.Text = message
        p.Visible = False
        If caption Is Nothing Then
            p.Text = GetCaption(key)
        End If
        p.Ok()
        p.btnOk.Focus()
        p.SetInfoIcon()
        Return p.ShowDialog()
    End Function

    Public Shared Function Show(ByVal key As String, ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        CreateMessage(key, message, caption)
        p.txtMessage.Text = message
        If caption Is Nothing Then
            p.Text = GetCaption(key)
        End If
        SelectButton(p, buttons)
        SelectIcon(p, icon)
        SelectDefaultButton(p, defaultButton)
        Return p.ShowDialog()
    End Function

    Public Shared Function Show(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.txtMessage.Text = message
        p.Text = caption
        SelectButton(p, buttons)
        SelectIcon(p, icon)
        SelectDefaultButton(p, defaultButton)
        Return p.ShowDialog()
    End Function

    'Public Shared Function Show(ByVal interpolate As Boolean, ByVal key As String, ByVal message As String) As DialogResult
    '    Dim p As MyMessageBox = New MyMessageBox()
    '    p.txtMessage.Text = message.Interpolate(Function(x) )
    '    p.Visible = False
    '    p.Text = caption
    '    p.Ok()
    '    p.btnOk.Focus()
    '    p.SetInfoIcon()
    '    Return p.ShowDialog()
    'End Function

    Public Shared Function Display(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.txtMessage.Text = message
        p.Text = caption
        SelectButton(p, buttons)
        SelectIcon(p, icon)
        SelectDefaultButton(p, defaultButton)
        Return p.ShowDialog()
    End Function

    Private Shared Sub SelectButton(p As MyMessageBox, buttons As MessageBoxButtons)
        Select Case buttons
            Case MessageBoxButtons.OK
                p.Ok()
            Case MessageBoxButtons.YesNo
                p.YesNo()
            Case MessageBoxButtons.OKCancel
                p.YesNo()
            Case MessageBoxButtons.YesNoCancel
                p.YesNoCancel()
            Case Else
                p.Yes()
        End Select
    End Sub

    Private Shared Sub SelectDefaultButton(ByRef p As MyMessageBox, defaultButton As MessageBoxDefaultButton)
        Select Case defaultButton
            Case MessageBoxDefaultButton.Button1
                p.btnYes.TabIndex = 0
            Case MessageBoxDefaultButton.Button2
                p.btnNo.TabIndex = 0
            Case MessageBoxDefaultButton.Button3
                p.btnCancel.TabIndex = 0
        End Select
    End Sub

    Private Shared Sub SelectIcon(p As MyMessageBox, icon As MessageBoxIcon)

        Select Case icon
            Case MessageBoxIcon.Information
                p.SetInfoIcon()
            Case MessageBoxIcon.Question
                p.SetQuestionIcon()
            Case MessageBoxIcon.Exclamation
                p.SetWarningIcon()
            Case MessageBoxIcon.[Error]
                p.SetErrorIcon()
        End Select
    End Sub

    Public Shared Function Display(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.txtMessage.Text = message
        p.Text = caption

        Select Case buttons
            Case MessageBoxButtons.YesNo
                p.YesNo()
            Case MessageBoxButtons.OKCancel
                p.YesNo()
            Case MessageBoxButtons.YesNoCancel
                p.YesNoCancel()
            Case Else
                p.Yes()
        End Select

        Select Case icon
            Case MessageBoxIcon.Information
                p.SetInfoIcon()
            Case MessageBoxIcon.Question
                p.SetQuestionIcon()
            Case MessageBoxIcon.Exclamation
                p.SetWarningIcon()
            Case MessageBoxIcon.[Error]
                p.SetErrorIcon()
        End Select

        p.btnYes.Focus()
        Return p.ShowDialog()
    End Function

    Public Shared Function Display(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.txtMessage.Text = message
        p.Text = caption

        Select Case buttons
            Case MessageBoxButtons.YesNo
                p.YesNo()
            Case MessageBoxButtons.OKCancel
                p.YesNo()
            Case MessageBoxButtons.YesNoCancel
                p.YesNoCancel()
            Case MessageBoxButtons.OK
                p.Ok()
            Case Else
                p.Yes()
        End Select

        p.btnYes.Focus()
        Return p.ShowDialog()
    End Function

    Public Shared Function Display(ByVal message As String, ByVal caption As String) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.txtMessage.Text = message
        p.Text = caption
        p.Yes()
        p.btnYes.Focus()
        Return p.ShowDialog()
    End Function

    Public Shared Function Display(ByVal message As String) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.txtMessage.Text = message
        p.Ok()
        p.btnOk.Focus()
        Return p.ShowDialog()
    End Function

    Public Shared Function DisplayLocal(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton, ByVal yesButtonText As String, ByVal noButtonText As String, ByVal abortButtonText As String) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.btnYes.Text = yesButtonText
        p.btnNo.Text = noButtonText
        p.btnCancel.Text = abortButtonText
        p.txtMessage.Text = message
        p.Text = caption

        Select Case buttons
            Case MessageBoxButtons.YesNo
                p.YesNo()
            Case MessageBoxButtons.OKCancel
                p.YesNo()
            Case MessageBoxButtons.YesNoCancel
                p.YesNoCancel()
            Case Else
                p.Yes()
        End Select

        Select Case icon
            Case MessageBoxIcon.Information
                p.SetInfoIcon()
            Case MessageBoxIcon.Question
                p.SetQuestionIcon()
            Case MessageBoxIcon.Exclamation
                p.SetWarningIcon()
            Case MessageBoxIcon.[Error]
                p.SetErrorIcon()
        End Select

        Select Case defaultButton
            Case MessageBoxDefaultButton.Button1
                p.btnYes.TabIndex = 0
            Case MessageBoxDefaultButton.Button2
                p.btnNo.TabIndex = 0
            Case MessageBoxDefaultButton.Button3
                p.btnCancel.TabIndex = 0
        End Select

        Return p.ShowDialog()
    End Function

    Public Shared Function DisplayLocal(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal yesButtonText As String, ByVal noButtonText As String, ByVal abortButtonText As String) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.btnYes.Text = yesButtonText
        p.btnNo.Text = noButtonText
        p.btnCancel.Text = abortButtonText
        p.txtMessage.Text = message
        p.Text = caption

        Select Case buttons
            Case MessageBoxButtons.YesNo
                p.YesNo()
            Case MessageBoxButtons.OKCancel
                p.YesNo()
            Case MessageBoxButtons.YesNoCancel
                p.YesNoCancel()
            Case Else
                p.Yes()
        End Select

        Select Case icon
            Case MessageBoxIcon.Information
                p.SetInfoIcon()
            Case MessageBoxIcon.Question
                p.SetQuestionIcon()
            Case MessageBoxIcon.Exclamation
                p.SetWarningIcon()
            Case MessageBoxIcon.[Error]
                p.SetErrorIcon()
        End Select

        p.btnYes.Focus()
        Return p.ShowDialog()
    End Function

    Public Shared Function DisplayLocal(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal yesButtonText As String, ByVal noButtonText As String, ByVal abortButtonText As String) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.btnYes.Text = yesButtonText
        p.btnNo.Text = noButtonText
        p.btnCancel.Text = abortButtonText
        p.txtMessage.Text = message
        p.Text = caption

        Select Case buttons
            Case MessageBoxButtons.YesNo
                p.YesNo()
            Case MessageBoxButtons.OKCancel
                p.YesNo()
            Case MessageBoxButtons.YesNoCancel
                p.YesNoCancel()
            Case Else
                p.Yes()
        End Select

        p.btnYes.Focus()
        Return p.ShowDialog()
    End Function

    Public Shared Function DisplayLocal(ByVal message As String, ByVal caption As String, ByVal yesButtonText As String) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.btnYes.Text = yesButtonText
        p.txtMessage.Text = message
        p.Text = caption
        p.Yes()
        p.btnYes.Focus()
        Return p.ShowDialog()
    End Function

    Public Shared Function DisplayLocal(ByVal message As String, ByVal yesButtonText As String) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.btnYes.Text = yesButtonText
        p.txtMessage.Text = message
        p.Yes()
        p.btnYes.Focus()
        Return p.ShowDialog()
    End Function

    Public Shared Function DisplayLocal(ByVal message As String) As DialogResult
        Dim p As MyMessageBox = New MyMessageBox()
        p.txtMessage.Text = message
        p.Visible = False
        p.Ok()
        p.btnOk.Focus()
        p.SetInfoIcon()
        Return p.ShowDialog()
    End Function

    Public Shared Function CreateMessage(ByVal key As String, ByVal message As String, ByVal caption As String) As String()
        Dim storeCaptions1 As New StoreCaptions
        Dim textDisplayLanguage As String
        Dim translatorDac As New Dac
        Dim translatedMessage As String = message
        Dim translatedCaption As String = caption
        Dim cmd As String
        Dim activeForm = Form.ActiveForm
        textDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name
        cmd = "SELECT COUNT(*) FROM OriginalMessages where MessageKey='" + key + "'"
        Dim howMany As Int32 = translatorDac.ExecScalar(Of Int32)(cmd)
        If howMany = 0 Then
            cmd = "INSERT INTO OriginalMessages (messageKey,message,caption) values ( '" + key.Trim() + "','" + message.Trim() + "','" + caption.Trim() + "')"
            translatorDac.ExecCmd(cmd)
        End If
        If NeedToTranslateText(textDisplayLanguage) Then
            cmd = "SELECT TranslatedMessage, TranslatedCaption FROM TranslatedMessages_View where LTrim(RTrim(MessageKey)) = '" + key.Trim() + "' and CultureInfoCode = '" + textDisplayLanguage.TrimEnd + "'"
            Dim items = translatorDac.ExecReader(cmd)
            If items IsNot Nothing Then
                translatedMessage = items(1)
                translatedCaption = items(2)
            Else
                If translatedMessage Is Nothing Then
                    Dim languageBaseCode = Left(textDisplayLanguage, textDisplayLanguage.IndexOf("-", StringComparison.Ordinal))
                    cmd = "SELECT TranslatedMessage, TranslatedCaption from TranslatedMessages_View where LTrim(RTrim(MessageKey)) = '" + key.Trim() + "' and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
                    items = translatorDac.ExecReader(cmd)
                    If items IsNot Nothing Then
                        translatedMessage = items(1)
                        translatedCaption = items(2)
                    End If
                End If
            End If
        Else
            translatedMessage = message
            translatedCaption = caption
        End If
        Return {translatedMessage, translatedCaption}
    End Function

    Public Shared Function GetMessage(ByVal key As String, ByVal message As String, ByVal caption As String) As String
        Dim translatorDac As New Dac
        Return translatorDac.GetMessage(key, message, caption)
    End Function

    Public Shared Function GetCaption(ByVal key As String) As String
        Dim translatorDac As New Dac
        Return translatorDac.GetCaption(key)
    End Function

    'Protected Function GetTranslatedMessage(ByVal key As String, ByVal message As String, ByVal textDisplayLanguage As String) As String
    '    Dim translatorDac As New DAC
    '    Dim translatedText As String
    '    Dim cmd As String
    '    If GlobalFunctions.NeedToTranslateText(TextDisplayLanguage) Then
    '        cmd = "SELECT Translated FROM TranslatedMessages_View where CultureInfoCode = '" + TextDisplayLanguage.TrimEnd + "'"
    '        translatedText = TranslatorDAC.ExecScalar(Of String)(cmd)
    '        If translatedText Is Nothing Then
    '            Dim languageBaseCode = Strings.Left(TextDisplayLanguage, TextDisplayLanguage.IndexOf("-", StringComparison.Ordinal))
    '            cmd = "SELECT Translated from TranslatedMessages_View where RTrim(MessageKey) = '" + RTrim(key) + "' and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
    '            translatedText = TranslatorDAC.ExecScalar(Of String)(cmd)
    '            If translatedText IsNot Nothing Then
    '                translatedText = message
    '            End If
    '        End If
    '    Else
    '        translatedText = message
    '    End If
    '    Return translatedText
    'End Function

    Public Sub CreateAllMessages()

    End Sub

End Class