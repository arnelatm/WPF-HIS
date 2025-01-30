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
    Public Overloads Shared Function Show(ByVal key As String) As DialogResult
        Return Show(True, key)
    End Function

    Public Overloads Shared Function Show(ByVal translate As Boolean, ByVal key As String) As DialogResult
        MessageKey = key
        Dim message As String = ""
        Dim caption As String = ""
        DataAccessControl.GetMessage(translate, key, message, caption)
        MessageCaption = caption + " [" + MessageKey + "]"
        If message Is Nothing Or message = "" Then
            Return MessagingForm.Show(MessageCaption, MessageCaption)
        End If
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

    Public Overloads Shared Function Show(ByVal message As String, Optional messageBoxButton As MessageBoxButtons = MessageBoxButtons.OK, Optional messageBoxIcon As MessageBoxIcon = MessageBoxIcon.Information) As DialogResult
        Return MessagingForm.Show(message, MessageCaption, messageBoxButton, messageBoxIcon)
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

    Public Shared Function TranslateCaption(cCaption As String, Optional targetCulture As String = Nothing) As String
        If cCaption Is Nothing Then
            Return ""
        End If
        Return DataAccessControl.TranslateCaption(cCaption, targetCulture)
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

    Public Overloads Shared Function ShowPmMessage(ByVal translate As Boolean, ByVal key As String, ByVal variables As String(), ByVal parametrizedMessage As String, ByVal caption As String)
        Dim cMessage = Messaging.GetMessage(translate, key, parametrizedMessage, caption)
        Dim message = Messaging.ReplaceValues(cMessage, variables)
        ' caption now holds the translated value because GetMessage function above 'caption' parameter is by reference
        Messaging.Show(message, caption)
        Return message
    End Function

    Public Overloads Shared Function ShowPmMessage(ByVal translate As Boolean, ByVal key As String, ByVal variables As String())
        Dim cMessage = Messaging.GetMessage(translate, key)
        Dim cCaption = Messaging.GetMessageCaption(key)
        Dim message = Messaging.ReplaceValues(cMessage, variables)
        Dim caption = Messaging.TranslateCaption(cCaption)
        Messaging.Show(message, caption)
        Return message
    End Function

    Public Overloads Shared Function GetParametrizedMessage(ByVal translate As Boolean, ByVal key As String, ByVal variables As String())
        Dim cMessage = Messaging.GetMessage(translate, key)
        Return Messaging.ReplaceValues(cMessage, variables)
    End Function

    Public Shared Function SelectReportName(ByVal reportName As String, ByVal beginningDate As Date, ByVal endingDate As Date, ByVal formCulture As Globalization.CultureInfo, Optional ByVal periodCode As String = "")
        If periodCode = "Y" Then
            Return Messaging.GetParametrizedMessage(True, "RptForTheYear", {"reportName", reportName, "year", GregorianYear(endingDate).ToString})
        ElseIf periodCode = "M" Then
            Dim monthName As String
            If Left(formCulture.Name, 2) = "ar" Then
                monthName = GlobalFunctions.GregorianMonthNameArabic(GregorianMonth(endingDate))
            Else
                monthName = GlobalFunctions.GregorianMonthName(GregorianMonth(endingDate))
            End If
            Return Messaging.GetParametrizedMessage(True, "RptForTheMonth", {"reportName", reportName, "monthName", monthName, "year", Year(endingDate).ToString()})
        ElseIf periodCode = "Q" Then
            Dim nMonth = GregorianMonth(endingDate)
            Dim quarter As Integer = Int(nMonth / 3 + 0.8)
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
        ElseIf periodCode = "T" Then
            Dim bDateTime As String = GlobalFunctions.DateTimeToSpecificCultureShortDateTimeString(beginningDate, CultureInfo.CreateSpecificCulture("en-GB"))
            Dim eDateTime As String = GlobalFunctions.DateTimeToSpecificCultureShortDateTimeString(endingDate, CultureInfo.CreateSpecificCulture("en-GB"))
            Return Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDateTime, "endingDate", eDateTime})
        Else
            If beginningDate = endingDate Then
                Dim cDay As String
                cDay = beginningDate.ToString($"dd MMMMM yyyy")
                Return Messaging.GetParametrizedMessage(True, "RptForTheDay", {"reportName", reportName, "day", cDay})
            ElseIf GregorianDay(beginningDate) = 1 And GregorianDay(endingDate) = 31 And GregorianMonth(beginningDate) = 1 And GregorianMonth(endingDate) = 12 And GregorianYear(beginningDate) = GregorianYear(endingDate) Then
                Return Messaging.GetParametrizedMessage(True, "RptForTheYear", {"reportName", reportName, "year", GregorianYear(endingDate).ToString})
            ElseIf GregorianYear(beginningDate) = GregorianYear(endingDate) AndAlso
                   ((GregorianDay(beginningDate) = 1 AndAlso GregorianDay(endingDate) = 31 AndAlso GregorianMonth(beginningDate) = 1 AndAlso GregorianMonth(endingDate) = 3) Or
                    (GregorianDay(beginningDate) = 1 AndAlso GregorianDay(endingDate) = 30 AndAlso GregorianMonth(beginningDate) = 4 AndAlso GregorianMonth(endingDate) = 6) Or
                    (GregorianDay(beginningDate) = 1 AndAlso GregorianDay(endingDate) = 30 AndAlso GregorianMonth(beginningDate) = 7 AndAlso GregorianMonth(endingDate) = 9) Or
                    (GregorianDay(beginningDate) = 1 AndAlso GregorianDay(endingDate) = 31 AndAlso GregorianMonth(beginningDate) = 10 AndAlso GregorianMonth(endingDate) = 12)) Then
                Dim quarterName As String = ""
                Select Case GregorianMonth(beginningDate)
                    Case 1
                        quarterName = TranslateCaption("First")
                    Case 4
                        quarterName = TranslateCaption("Second")
                    Case 7
                        quarterName = TranslateCaption("Third")
                    Case 10
                        quarterName = TranslateCaption("Fourth")
                End Select
                Return Messaging.GetParametrizedMessage(True, "RptForTheQuarter", {"reportName", reportName, "quarterName", quarterName, "year", GregorianYear(endingDate).ToString})
            ElseIf GregorianYear(beginningDate) = GregorianYear(endingDate) AndAlso
                   ((GregorianDay(beginningDate) = 1 AndAlso GregorianDay(endingDate) = 30 AndAlso GregorianMonth(beginningDate) = 1 AndAlso GregorianMonth(endingDate) = 6) Or
                    (GregorianDay(beginningDate) = 1 AndAlso GregorianDay(endingDate) = 31 AndAlso GregorianMonth(beginningDate) = 7 AndAlso GregorianMonth(endingDate) = 12)) Then
                Dim semesterName As String = ""
                Select Case GregorianMonth(beginningDate)
                    Case 1
                        semesterName = TranslateCaption("First")
                    Case 7
                        semesterName = TranslateCaption("Second")
                End Select
                Return Messaging.GetParametrizedMessage(True, "RptForTheSemester", {"reportName", reportName, "semesterName", semesterName, "year", GregorianYear(endingDate).ToString})
            ElseIf GregorianDay(beginningDate) = 1 And GregorianDay(DateAdd("d", 1, endingDate)) = 1 And GregorianMonth(beginningDate) = GregorianMonth(endingDate) And GregorianYear(beginningDate) = GregorianYear(endingDate) Then
                Dim monthName As String
                Dim cYear = GregorianYear(endingDate).ToString
                If Left(formCulture.Name, 2) = "ar" Then
                    monthName = GlobalFunctions.GregorianMonthNameArabic(GregorianMonth(endingDate))
                Else
                    monthName = formCulture.DateTimeFormat.MonthGenitiveNames(GregorianMonth(endingDate) - 1)
                End If
                Return Messaging.GetParametrizedMessage(True, "RptForTheMonth", {"reportName", reportName, "monthName", monthName, "year", cYear})
            End If
        End If
        Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(beginningDate, CultureInfo.CreateSpecificCulture("en-GB"))
        Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(endingDate, CultureInfo.CreateSpecificCulture("en-GB"))
        Return Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
    End Function

    'Public Function MessageTimeOut(sMessage As String, sTitle As String, iSeconds As Integer) As Boolean
    '    Dim Shell = CreateObject("WScript.Shell")
    '    Shell.Run("mshta.exe vbscript:close(CreateObject(""WScript.shell"").Popup(""" & sMessage & """," & iSeconds & ",""" & sTitle & """))")
    '    MessageTimeOut = True
    'End Function

    Public Shared Sub MessageTimeOut(sMessage As String, sTitle As String, iSeconds As Integer)
        Dim Shell = CreateObject("WScript.Shell")
        Shell.Run("mshta.exe vbscript:close(CreateObject(""WScript.shell"").Popup(""" & sMessage & """," & iSeconds & ",""" & sTitle & """))")
    End Sub

    Public Shared Sub MessageTimeOutNowait(sMessage As String, sTitle As String, iSeconds As Integer)
        Dim t As New System.Threading.Thread(AddressOf ShowMSG)
        Dim messageParam As New WaitMessageParameters
        messageParam.Message = sMessage
        messageParam.Title = sTitle
        messageParam.Seconds = iSeconds
        t.Start(messageParam)
    End Sub

    Private Shared Sub ShowMSG(messageParam As WaitMessageParameters)
        Dim Shell = CreateObject("WScript.Shell")
        Shell.Run("mshta.exe vbscript:close(CreateObject(""WScript.shell"").Popup(""" & messageParam.Message & """," & messageParam.Seconds & ",""" & messageParam.Title & """))")
    End Sub


    Public Shared Sub MinimumDateError(dDate As Date)
        If dDate < dDate Then
            MessageBox.Show("Date can't be less than " + dDate.ToLongDateString())
            Beep()
        End If
    End Sub

    Public Shared Sub MaximumDateError(dDate As Date)
        If dDate < dDate Then
            MessageBox.Show("Date can't be more than " + dDate.ToLongDateString())
            Beep()
        End If
    End Sub

    'Public Shared Function SelectPeriodCaption(ByVal originalCaption As String, ByVal FormCulture As Globalization.CultureInfo, ByVal periodCode As String)
    '    Dim curCulture = CultureInfo.CurrentCulture
    '    If periodCode = "Y" Then
    '        Return Messaging.GetParametrizedMessage(True, "RptForTheYear", {"reportName", reportName, "year", GregorianYear(endingDate).ToString})
    '    ElseIf periodCode = "M" Then
    '        Dim monthName As String
    '        monthName = GlobalFunctions.GregorianMonthName(GregorianMonth(endingDate))
    '        Return Messaging.GetParametrizedMessage(True, "RptForTheMonth", {"reportName", reportName, "monthName", monthName, "year", Year(endingDate).ToString()})
    '    ElseIf periodCode = "Q" Then
    '        Dim nMonth = GregorianMonth(endingDate)
    '        Dim quarter = Int(nMonth / 3 + 0.8)
    '        Dim cYear = GregorianYear(endingDate).ToString
    '        Dim cQuarter As String
    '        If quarter = 1 Then
    '            cQuarter = TranslateCaption("First")
    '        ElseIf quarter = 2 Then
    '            cQuarter = TranslateCaption("Second")
    '        ElseIf quarter = 3 Then
    '            cQuarter = TranslateCaption("Third")
    '        Else
    '            cQuarter = TranslateCaption("Fourth")
    '        End If
    '        Return Messaging.GetParametrizedMessage(True, "RptForTheQuarter", {"reportName", reportName, "quarterName", cQuarter, "year", cYear})
    '    ElseIf periodCode = "S" Then
    '        Dim nMonth = GregorianMonth(endingDate)
    '        Dim semester = Int(nMonth / 6 + 0.9)
    '        Dim cYear = GregorianYear(endingDate).ToString
    '        Dim cSemester As String
    '        If semester = 1 Then
    '            cSemester = TranslateCaption("First")
    '        Else
    '            cSemester = TranslateCaption("Second")
    '        End If
    '        Return Messaging.GetParametrizedMessage(True, "RptForTheSemester", {"reportName", reportName, "semesterName", cSemester, "year", cYear})
    '    Else
    '        If GregorianDay(beginningDate) = 1 And GregorianDay(endingDate) = 31 And GregorianMonth(beginningDate) = 1 And GregorianMonth(endingDate) = 12 And GregorianYear(beginningDate) = GregorianYear(endingDate) Then
    '            Return Messaging.GetParametrizedMessage(True, "RptForTheYear", {"reportName", reportName, "year", GregorianYear(endingDate).ToString})
    '        ElseIf GregorianDay(beginningDate) = 1 And GregorianDay(DateAdd("d", 1, endingDate)) = 1 And GregorianMonth(beginningDate) = GregorianMonth(endingDate) And GregorianYear(beginningDate) = GregorianYear(endingDate) Then
    '            Dim monthName As String
    '            Dim cYear = GregorianYear(endingDate).ToString
    '            If Left(FormCulture.Name, 2) = "ar" Then
    '                monthName = GlobalFunctions.GregorianMonthNameArabic(GregorianMonth(endingDate))
    '            Else
    '                monthName = FormCulture.DateTimeFormat.MonthGenitiveNames(GregorianMonth(endingDate) - 1)
    '            End If
    '            Return Messaging.GetParametrizedMessage(True, "RptForTheMonth", {"reportName", reportName, "monthName", monthName, "year", cYear})
    '        End If
    '    End If
    '    Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(beginningDate, CultureInfo.CreateSpecificCulture("en-GB"))
    '    Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(beginningDate, CultureInfo.CreateSpecificCulture("en-GB"))
    '    Return Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
    'End Function

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

    Public Shared Function IsArabic()
        Dim textInformation As TextInfo = CultureInfo.CurrentCulture.TextInfo
        If textInformation.IsRightToLeft Then
            Return True
        End If
        Return False
    End Function


End Class

Public Class WaitMessageParameters
    Public Message As String
    Public Title As String
    Public Seconds As Integer
End Class