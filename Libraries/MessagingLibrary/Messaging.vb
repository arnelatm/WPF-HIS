Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Translations

Public Class Messaging

    Private Shared ReadOnly DataAccessControl As New Dac
' ReSharper disable once UnusedMember.Local
    Private Shared _key As String = ""

    Public Shared Property MessageKey As String

    '-------------------------------------------------------------------------------------------------------------------------------

    Public Overloads Shared Function AddMessage(ByVal key As String, ByRef message As String, ByRef caption As String) As String
        MessageKey = key
        DataAccessControl.AddMessage(key, message, caption)
        Return message
    End Function

    Public Overloads Shared Function GetMessage(ByVal translate As Boolean, ByVal key As String) As String
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return message
    End Function

    Public Overloads Shared Function GetMessage(ByVal translate As Boolean, ByVal key As String, ByRef message As String, ByRef caption As String) As String
        MessageKey = key
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return message
    End Function


    '-------------------------------------------------------------------------------------------------------------------------------
    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String) As DialogResult
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]")
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal variables As String())
        MessageKey = key
        Dim message = GetMessage(translate, key)
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, "[" + MessageKey + "]")
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String) As DialogResult
        MessageKey = key
        DataAccessControl.GetMessage(translate, key, message, "")
        Return MessagingForm.Show(message, " [" + MessageKey + "]")
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal variables As String())
        MessageKey = key
        message = GetMessage(translate, key, message, "")
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, "[" + MessageKey + "]")
    End Function
    
    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String) As DialogResult
        MessageKey = key
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]" )
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String, ByVal variables As String())
        MessageKey = key
        message = GetMessage(translate, key, message, caption)
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]")
    End Function


    '-------------------------------------------------------------------------------------------------------------------------------
    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String) As DialogResult
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function
        
    Public Overloads Shared Function Show(ByVal message As String, variables As String()) As DialogResult
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, " [" + MessageKey + "]", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function

    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, variables As String()) As DialogResult
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------
    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        Dim caption As String = ""
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]" , buttons, icon, defaultButton)
    End Function


    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]" , buttons, icon, defaultButton)
    End Function


    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, variables As String(), ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        message = GetMessage(translate, key, message, caption)
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, caption + " " + key, buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, byVal message As String, variables As String(), ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        Dim caption As String = ""
        message = GetMessage(translate, key, message, caption)
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, caption + " " + key, buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String,  variables As String(), ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        message = GetMessage(translate, key, message, caption)
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, caption + " " + key, buttons, icon, defaultButton)
    End Function
    
    '-------------------------------------------------------------------------------------------------------------------------------
    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, variables As String(), ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon, defaultButton)
    End Function
    
    Public Shared Function TranslateCaption(cCaption As String)
        Return DataAccessControl.TranslateCaption(cCaption)
    End Function

End Class