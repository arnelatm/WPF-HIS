Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Translations

Public Class Messaging

    Private Shared ReadOnly DataAccessControl As New Dac
    Private Shared _key As String = ""

    Public Shared Property MessageKey As String

    'Private Shared Property Dac As New Dac

    Public Overloads Shared Function GetMessage(ByVal translate As Boolean, ByVal key As String) As String
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        ''CreateDataAccessControl()
        DataAccessControl.GetMessage(translate, key, message, caption)
        'dac.GetMessage(translate, key, message, caption)
        Return message
    End Function

    'Private Shared Sub 'CreateDataAccessControl()
    '    If _dataAccessControl Is Nothing Then
    '        _dataAccessControl = New Dac
    '    End If
    'End Sub

    Public Overloads Shared Function GetMessage(ByVal translate As Boolean, ByVal key As String, ByRef message As String, ByRef caption As String) As String
        MessageKey = key
        'CreateDataAccessControl()
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return message
    End Function

    Public Overloads Shared Function AddMessage(ByVal key As String, ByRef message As String, ByRef caption As String) As String
        MessageKey = key
        'CreateDataAccessControl()
        DataAccessControl.AddMessage(key, message, caption)
        Return message
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String) As DialogResult
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        'CreateDataAccessControl()
        DataAccessControl.GetMessage(translate, key, message, caption)
        'Return Show(message, caption)
        Return MessagingForm.Show(message, caption + " [" + key + "]")
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String) As DialogResult
        MessageKey = key
        'CreateDataAccessControl()
        DataAccessControl.GetMessage(translate, key, message, caption)
        'Dim p As MessagingBox = New MessagingBox()
        'p.txtMessage.Text = message
        'p.Visible = False
        'p.Text = caption
        'p.Ok()
        'p.btnOk.Focus()
        'p.SetInfoIcon()
        'p.MessageKey = MessageKey
        'SetLayout(p)
        ''Return p.ShowDialog()
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]" , MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Function

    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String) As DialogResult
        'Dim p As MessagingBox = New MessagingBox()
        'p.txtMessage.Text = message
        'p.Visible = False
        'p.Text = caption
        'p.Ok()
        'p.btnOk.Focus()
        'p.SetInfoIcon()
        'p.MessageKey = MessageKey
        'SetLayout(p)
        'Return p.ShowDialog()
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        'CreateDataAccessControl()
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]" , buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        'CreateDataAccessControl()
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        'Dim p As MessagingBox = New MessagingBox()
        'p.txtMessage.Text = message
        'p.Text = caption
        'p.MessageKey = MessageKey
        'SelectButton(p, buttons)
        'SelectIcon(p, icon)
        'SelectDefaultButton(p, defaultButton)
        'SetLayout(p)
        'Return p.ShowDialog()
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(translate As Boolean, key As String, message As String, caption As String, variables As String())
        MessageKey = key
        Dim oldValue As String = ""
        Dim newValue As String = ""
        message = GetMessage(translate, key, message, caption)
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]")
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, variables As String(), ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        message = GetMessage(translate, key, message, caption)
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, caption + " " + key, buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, variables As String(), ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        'Dim p As MessagingBox = New MessagingBox()
        message = message.ReplaceValues(variables)
        'p.txtMessage.Text = message
        'p.Text = caption
        'SelectButton(p, buttons)
        'SelectIcon(p, icon)
        'SelectDefaultButton(p, defaultButton)
        'SetLayout(p)
        'p.MessageKey = MessageKey
        'Return p.ShowDialog()
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon, defaultButton)
    End Function

    'Private Shared Sub SetLayout(p As MessagingBox)
    '    If GlobalVariables.RightToLeftLayout Then
    '        p.RightToLeftLayout = True
    '        p.RightToLeft = RightToLeft.Yes
    '    Else
    '        p.RightToLeftLayout = False
    '        p.RightToLeft = RightToLeft.No
    '    End If
    'End Sub

    'Private Shared Sub SelectButton(p As MessagingBox, buttons As MessageBoxButtons)
    '    Select Case buttons
    '        Case MessageBoxButtons.OK
    '            p.Ok()
    '        Case MessageBoxButtons.OKCancel
    '            p.OkCancel()
    '        Case MessageBoxButtons.AbortRetryIgnore
    '            p.AbortRetryIgnore()
    '        Case MessageBoxButtons.YesNo
    '            p.YesNo()
    '        Case MessageBoxButtons.YesNoCancel
    '            p.YesNoCancel()
    '        Case MessageBoxButtons.RetryCancel
    '            p.RetryCancel()
    '        Case Else
    '            p.Ok()
    '    End Select
    'End Sub

    'Private Shared Sub SelectDefaultButton(ByRef p As MessagingBox, defaultButton As MessageBoxDefaultButton)
    '    Select Case defaultButton
    '        Case MessageBoxDefaultButton.Button1
    '            p.btnYes.TabIndex = 0
    '        Case MessageBoxDefaultButton.Button2
    '            p.btnNo.TabIndex = 0
    '        Case MessageBoxDefaultButton.Button3
    '            p.btnCancel.TabIndex = 0
    '    End Select
    'End Sub

    'Private Shared Sub SelectIcon(p As MessagingBox, icon As MessageBoxIcon)
    '    Select Case icon
    '        Case MessageBoxIcon.Information
    '            p.SetInfoIcon()
    '        Case MessageBoxIcon.Question
    '            p.SetQuestionIcon()
    '        Case MessageBoxIcon.Exclamation
    '            p.SetWarningIcon()
    '        Case MessageBoxIcon.[Error]
    '            p.SetErrorIcon()
    '    End Select
    'End Sub

    Public Shared Function TranslateCaption(cCaption As String)
        'CreateDataAccessControl()
        Return DataAccessControl.TranslateCaption(cCaption)
    End Function

End Class