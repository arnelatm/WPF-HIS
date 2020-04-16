Imports System.Windows.Forms.VisualStyles

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

    Public Overloads Shared Function GetCaption(ByVal caption As String) As String
        Return DataAccessControl.GetMessageCaption(caption)
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
        'message = message.ReplaceValues(variables)
        message = ReplaceValues(message, variables)
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
        'message = message.ReplaceValues(variables)
        message = ReplaceValues(message, variables)
        Return MessagingForm.Show(message, "[" + MessageKey + "]")
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String) As DialogResult
        MessageKey = key
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]")
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String, ByVal variables As String())
        MessageKey = key
        message = GetMessage(translate, key, message, caption)
        message = ReplaceValues(message, variables)
        'message = message.ReplaceValues(variables)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]")
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------
    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String) As DialogResult
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function

    Public Overloads Shared Function Show(ByVal message As String, variables As String()) As DialogResult
        'message = message.ReplaceValues(variables)
        message = ReplaceValues(message, variables)
        Return MessagingForm.Show(message, " [" + MessageKey + "]", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function

    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, variables As String()) As DialogResult
        'message = message.ReplaceValues(variables)
        message = ReplaceValues(message, variables)
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
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        DataAccessControl.GetMessage(translate, key, message, caption)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, variables As String(), ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        message = GetMessage(translate, key, message, caption)
        'message = message.ReplaceValues(variables)
        message = ReplaceValues(message, variables)
        Return MessagingForm.Show(message, caption + " " + key, buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, variables As String(), ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        Dim caption As String = ""
        message = GetMessage(translate, key, message, caption)
        'message = message.ReplaceValues(variables)
        message = ReplaceValues(message, variables)
        Return MessagingForm.Show(message, caption + " " + key, buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal caption As String, variables As String(), ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        message = GetMessage(translate, key, message, caption)
        'message = message.ReplaceValues(variables)
        message = ReplaceValues(message, variables)
        Return MessagingForm.Show(message, caption + " " + key, buttons, icon, defaultButton)
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------
    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As DialogResult
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon)
    End Function

    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, variables As String(), ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        'message = message.ReplaceValues(variables)
        message = ReplaceValues(message, variables)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icon, defaultButton)
    End Function

    Public Shared Function TranslateCaption(cCaption As String)
        Return DataAccessControl.TranslateCaption(cCaption)
    End Function

    Public Shared Function ReplaceValues(ByVal message As String, variables As String()) As String
        Dim result As String = message
        Dim oldValue As String = ""
        Dim newValue As String = ""
        For i = 0 To variables.Count - 1 Step 2
            oldValue = "{" & variables(i) & "}"
            newValue = variables(i + 1)
            result = Replace(result, oldValue, newValue, 1, -1, CompareMethod.Text)
        Next
        Return result
    End Function

    Public Shared Function IsDateRangeValid(text As String, targetDate As Date, startDate As Date, endDate As Date) As DialogResult
        Dim retValue As DialogResult
        Dim dateField As String = Messaging.TranslateCaption(text)
        Dim startDateStr As String = startDate.ToShortDateString()
        Dim endDateStr As String = endDate.ToShortDateString()
        Dim variables = {"dateField", dateField, "startDate", startDateStr, "endDate", endDateStr}
        Dim message = Messaging.GetMessage(True, "MsgInvalidDate", "Invalid {dateField} Date entered, value must be between {startDate} And {endDate}!", "Invalid Date")
        Dim caption = Messaging.GetCaption("Invalid Date")
        If targetDate < startDate Or targetDate > endDate Then
            message = Messaging.ReplaceValues(message, variables)
            Messaging.Show(message, caption)
            retValue = DialogResult.No
        Else
            retValue = DialogResult.Yes
        End If
        Return retValue
    End Function

End Class