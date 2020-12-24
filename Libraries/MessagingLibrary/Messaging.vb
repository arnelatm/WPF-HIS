Imports System.Globalization
Imports AATM.Libraries.GlobalFuncNSub

Public Class Messaging

    Private Shared ReadOnly DataAccessControl As New Dac

    ' ReSharper disable once UnusedMember.Local
    Private Shared _key As String = ""

    Public Shared Property MessageKey As String
    Public Shared Property MessageCaption As String

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
        MessageCaption = caption + " [" + MessageKey + "]"
        Return message
    End Function

    Public Overloads Shared Function GetMessageCaption(ByVal key As String) As String
        If key Is Nothing Then
            Return ""
        End If
        Return DataAccessControl.GetMessageCaption(key)
    End Function

    Public Overloads Shared Function GetMessage(ByVal translate As Boolean, ByVal key As String, ByRef message As String, ByRef caption As String) As String
        MessageKey = key
        ' caption is passed by reference and will be changed to the translated value
        DataAccessControl.GetMessage(translate, key, message, caption)
        MessageCaption = caption + " [" + MessageKey + "]"
        Return message
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------
    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String) As DialogResult
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        DataAccessControl.GetMessage(translate, key, message, caption)
        MessageCaption = caption + " [" + MessageKey + "]"
        Return MessagingForm.Show(message, MessageCaption)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal variables As String())
        MessageKey = key
        Dim caption = ""
        Dim message = ""
        message = GetMessage(translate, key, message, caption)
        message = ReplaceValues(message, variables)
        Return MessagingForm.Show(message, " [" + MessageKey + "]")
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String) As DialogResult
        MessageKey = key
        DataAccessControl.GetMessage(translate, key, message, "")
        Return MessagingForm.Show(message, " [" + MessageKey + "]")
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String, ByVal message As String, ByVal variables As String())
        MessageKey = key
        Dim caption = ""
        message = GetMessage(translate, key, message, caption)
        message = ReplaceValues(message, variables)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]")
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

    Public Overloads Shared Function Show(translate As Boolean, key As String, variables() As Object, buttons As MessageBoxButtons, icons As MessageBoxIcon, Optional defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        DataAccessControl.GetMessage(translate, key, message, caption)
        message = ReplaceValues(message, variables)
        Return MessagingForm.Show(message, caption + " [" + MessageKey + "]", buttons, icons, defaultButton)
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

    Public Shared Function TranslateCaption(cCaption As String) As String
        If cCaption Is Nothing Then
            Return ""
        End If
        Return DataAccessControl.TranslateCaption(cCaption)
    End Function

    Public Shared Function ReplaceValues(ByVal message As String, variables As String()) As String
        Dim result As String = message
        Dim oldValue As String
        Dim newValue As String
        For i = 0 To variables.Count - 1 Step 2
            oldValue = "{" & variables(i) & "}"
            newValue = variables(i + 1)
            result = Replace(result, oldValue, newValue, 1, -1, CompareMethod.Text)
        Next
        Return result
    End Function

    Public Overloads Shared Function ShowParametrizedMessage(ByVal translate As Boolean, ByVal key As String, ByVal variables As String(), ByVal parametrizedMessage As String, ByVal caption As String)
        Dim cMessage = Messaging.GetMessage(translate, key, parametrizedMessage, caption)
        Dim message = Messaging.ReplaceValues(cMessage, variables)
        ' caption now holds the translated value because GetMessage function above 'caption' parameter is by reference
        Messaging.Show(message, caption)
        Return message
    End Function

    Public Overloads Shared Function ShowParametrizedMessage(ByVal translate As Boolean, ByVal key As String, ByVal variables As String())
        Dim cMessage = Messaging.GetMessage(translate, key)
        Dim cCaption = Messaging.GetMessageCaption(key)
        Dim message = Messaging.ReplaceValues(cMessage, variables)
        Dim caption = Messaging.TranslateCaption(cCaption)
        'For Each value In variables
        '    Dim cvalue As String = "{" + value(0) + "}"
        '    If Not message.Contains(cvalue) Then
        '        Messaging.Show(True, "invalid translation for message " & key)
        '    End If
        'Next
        Messaging.Show(message, caption)
        Return message
    End Function

    Public Overloads Shared Function GetParametrizedMessage(ByVal translate As Boolean, ByVal key As String, ByVal variables As String())
        Dim cMessage = Messaging.GetMessage(translate, key)
        Return Messaging.ReplaceValues(cMessage, variables)
    End Function

    Public Shared Function SelectReportName(ByVal reportName As String, ByVal beginningDate As Date, ByVal endingDate As Date, ByVal FormCulture As Globalization.CultureInfo, Optional ByVal periodCode As String = "")
        Dim curCulture = CultureInfo.CurrentCulture

        If periodCode = "Y" Then
            Return Messaging.GetParametrizedMessage(True, "RptForTheYear", {"reportName", reportName, "year", GregorianYear(endingDate).ToString})
        ElseIf periodCode = "M" Then
            Dim monthName As String
            monthName = GlobalFunctions.GregorianMonthName(GregorianMonth(endingDate))
            Return Messaging.GetParametrizedMessage(True, "RptForTheMonth", {"reportName", reportName, "monthName", monthName})
        ElseIf periodCode = "Q" Then
            Dim nMonth = GregorianMonth(endingDate)
            Dim quarter = Int(nMonth / 3 + 0.8)
            Dim cYear = GregorianYear(endingDate).ToString
            Dim cQuarter As String
            If quarter = 1 Then
                cQuarter = TranslateCaption("First")
            ElseIf quarter = 2 Then
                cQuarter = TranslateCaption("Second")
            ElseIf quarter = 3 Then
                cQuarter = TranslateCaption("Third")
            Else
                cQuarter = TranslateCaption("Fourth")
            End If
            Return Messaging.GetParametrizedMessage(True, "RptForTheQuarter", {"reportName", reportName, "quarterName", cQuarter, "year", cYear})
        ElseIf periodCode = "S" Then
            Dim nMonth = GregorianMonth(endingDate)
            Dim semester = Int(nMonth / 6 + 0.9)
            Dim cYear = GregorianYear(endingDate).ToString
            Dim cSemester As String
            If semester = 1 Then
                cSemester = TranslateCaption("First")
            Else
                cSemester = TranslateCaption("Second")
            End If
            Return Messaging.GetParametrizedMessage(True, "RptForTheSemester", {"reportName", reportName, "semesterName", cSemester, "year", cYear})
        Else
            If GregorianDay(beginningDate) = 1 And GregorianDay(endingDate) = 31 And GregorianMonth(beginningDate) = 1 And GregorianMonth(endingDate) = 12 And GregorianYear(beginningDate) = GregorianYear(endingDate) Then
                Return Messaging.GetParametrizedMessage(True, "RptForTheYear", {"reportName", reportName, "year", GregorianYear(endingDate).ToString})
            ElseIf GregorianDay(beginningDate) = 1 And GregorianDay(DateAdd("d", 1, endingDate)) = 1 And GregorianMonth(beginningDate) = GregorianMonth(endingDate) And GregorianYear(beginningDate) = GregorianYear(endingDate) Then
                Dim monthName As String
                monthName = GlobalFunctions.GregorianMonthName(GregorianMonth(endingDate))
                Return Messaging.GetParametrizedMessage(True, "RptForTheMonth", {"reportName", reportName, "monthName", monthName})
            End If
        End If
        Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(beginningDate, CultureInfo.CreateSpecificCulture("en-GB"))
        Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(beginningDate, CultureInfo.CreateSpecificCulture("en-GB"))
        Return Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
    End Function

    'Public Shared Function IsDateRangeValid(text As String, targetDate As Date, startDate As Date, endDate As Date) As DialogResult
    '    Dim retValue As DialogResult
    '    Dim dateField As String = TranslateCaption(text)
    '    Dim startDateStr As String = startDate.ToShortDateString()
    '    Dim endDateStr As String = endDate.ToShortDateString()
    '    Dim variables = {"dateField", dateField, "startDate", startDateStr, "endDate", endDateStr}
    '    Dim message = GetMessage(True, "MsgInvalidDate", "Invalid {dateField} Date entered, value must be between {startDate} And {endDate}!", "Invalid Date")
    '    Dim caption = GetCaption("Invalid Date")
    '    If targetDate < startDate Or targetDate > endDate Then
    '        message = ReplaceValues(message, variables)
    '        Show(message, caption)
    '        retValue = DialogResult.No
    '    Else
    '        retValue = DialogResult.Yes
    '    End If
    '    Return retValue
    'End Function

End Class