Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Translations

Public Class Messaging

    Private Shared _dataAccessControl 

    Public Overloads Shared Function GetMessage(ByVal translate As Boolean, ByVal key As String) As String
        Dim message As String = ""
        Dim caption As String = ""
        CreateDataAccessControl()
        _dataAccessControl.GetMessage(translate, key, message, caption)
        Return message
    End Function

    Private Shared Sub CreateDataAccessControl()
        if _dataAccessControl Is Nothing Then
            _dataAccessControl = New Dac
        End If
    End Sub

    Public Overloads Shared Function GetMessage(ByVal translate As Boolean, ByVal key As String, ByRef message As String, ByRef caption As String) As String
        CreateDataAccessControl()
        _dataAccessControl.GetMessage(translate, key, message, caption)
        Return message
    End Function

    Public Overloads Shared Function AddMessage(ByVal key As String, ByRef message As String, ByRef caption As String) As String
        CreateDataAccessControl()
        _dataAccessControl.AddMessage(key, message, caption)
        Return message
    End Function


    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String) As DialogResult
        Dim message As String = ""
        Dim caption As String = ""
        CreateDataAccessControl()
        _dataAccessControl.GetMessage(translate, key, message, caption)
        Return Show(message, caption)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String) As DialogResult
        CreateDataAccessControl()
        _dataAccessControl.GetMessage(translate, key, message, caption)
        Dim p As MessagingBox = New MessagingBox()
        p.txtMessage.Text = message
        p.Visible = False
        p.Text = caption
        p.Ok()
        p.btnOk.Focus()
        p.SetInfoIcon()
        SetLayout(p)
        Return p.ShowDialog()
    End Function

    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String) As DialogResult
        Dim p As MessagingBox = New MessagingBox()
        p.txtMessage.Text = message
        p.Visible = False
        p.Text = caption
        p.Ok()
        p.btnOk.Focus()
        p.SetInfoIcon()
        SetLayout(p)
        Return p.ShowDialog()
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        CreateDataAccessControl()
        _dataAccessControl.GetMessage(translate, key, message, caption)
        Return Show(message, caption, buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Dim message As String = ""
        Dim caption As String = ""
        CreateDataAccessControl()
        _dataAccessControl.GetMessage(translate, key, message, caption)
        Return Show(message, caption, buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Dim p As MessagingBox = New MessagingBox()
        p.txtMessage.Text = message
        p.Text = caption
        SelectButton(p, buttons)
        SelectIcon(p, icon)
        SelectDefaultButton(p, defaultButton)
        SetLayout(p)
        Return p.ShowDialog()
    End Function

    Private Shared Sub SetLayout(p As MessagingBox)
        If GlobalVariables.RightToLeftLayout Then
            p.RightToLeftLayout = True
            p.RightToLeft = RightToLeft.Yes
        Else
            p.RightToLeftLayout = False
            p.RightToLeft = RightToLeft.No
        End If
    End Sub

    Private Shared Sub SelectButton(p As MessagingBox, buttons As MessageBoxButtons)
        Select Case buttons
            Case MessageBoxButtons.OK
                p.Ok()
            Case MessageBoxButtons.OKCancel
                p.OkCancel()
            Case MessageBoxButtons.AbortRetryIgnore
                p.AbortRetryIgnore()
            Case MessageBoxButtons.YesNo
                p.YesNo()
            Case MessageBoxButtons.YesNoCancel
                p.YesNoCancel()
            Case MessageBoxButtons.RetryCancel
                p.RetryCancel()
            Case Else
                p.Ok()
        End Select
    End Sub

    Private Shared Sub SelectDefaultButton(ByRef p As MessagingBox, defaultButton As MessageBoxDefaultButton)
        Select Case defaultButton
            Case MessageBoxDefaultButton.Button1
                p.btnYes.TabIndex = 0
            Case MessageBoxDefaultButton.Button2
                p.btnNo.TabIndex = 0
            Case MessageBoxDefaultButton.Button3
                p.btnCancel.TabIndex = 0
        End Select
    End Sub

    Private Shared Sub SelectIcon(p As MessagingBox, icon As MessageBoxIcon)
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

End Class