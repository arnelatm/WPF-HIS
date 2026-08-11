Imports System.Globalization
Imports System.Net.Mail
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms


Public Module GlobalFunctions
    Public Function FindControlRecursive(list As List(Of Control), parent As Control) As List(Of Control)
        If parent Is Nothing Then Return list
        list.Add(parent)
        For Each child As Control In parent.Controls
            FindControlRecursive(list, child)
        Next
        Return list
    End Function

    Public Function GetPropertyValue(obj As Object, propName As String) As Object
        Dim propValue As Object
        Try
            Dim objType As Type = obj.GetType()
            Dim pInfo As PropertyInfo = objType.GetProperty(propName,
                                                            BindingFlags.Public Or BindingFlags.Instance Or
                                                            BindingFlags.IgnoreCase)
            propValue = pInfo.GetValue(obj, BindingFlags.GetProperty Or BindingFlags.IgnoreCase, Nothing, Nothing,
                                       Nothing)
        Catch ex As Exception
            'MessageBox.Show("Invalid property " + PropName + " in object " + obj.GetType().ToString())
            'Throw ex
            propValue = Nothing
        End Try
        Return propValue
    End Function

    Public Function PropertyExists(queriedObject As Object, propertyName As String) As Boolean
        Dim objType As Type = queriedObject.GetType()
        If _
            objType.GetProperty(propertyName, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.IgnoreCase) Is
            Nothing Then
            Return False
        End If
        Return True
    End Function

    Public Function GetTranslatedField(propertyName As String) As String
        If GlobalVariables.RightToLeftLayout Then
            Return propertyName + "Ara"
        End If
        Return propertyName
        'Public Function GetTranslatedField(queriedObject As Object, propertyName As String) As String       
        'Dim translatedField = propertyName + "Ara"
        'if PropertyExists(queriedObject, translatedField) Then
        '    Return translatedField
        'end if
        'Return propertyName       
    End Function


    ''' <summary>
    '''     handles null or blank values for string type
    ''' </summary>
    ''' <param name="argStr">string value to handle</param>
    ''' <returns>returns string</returns>
    Public Function NullString(argStr As String) As String
        Dim strReturnString = ""
        If argStr.Equals(DBNull.Value) Then
            strReturnString = ""
        ElseIf Convert.ToString(argStr) = "" Then
            strReturnString = ""
        ElseIf Convert.ToString(argStr) = "&nbsp;" Then
            strReturnString = ""
        Else
            strReturnString = Convert.ToString(argStr)
        End If

        Return strReturnString
    End Function

    Public Function NullValue(argDbl As Double) As Double
        Dim dblReturnDouble = 0.0
        If argDbl.Equals(DBNull.Value) Then
            dblReturnDouble = 0.0
        ElseIf Convert.ToString(argDbl) = "" Then
            dblReturnDouble = 0.0
        ElseIf Convert.ToString(argDbl) = "&nbsp;" Then
            dblReturnDouble = 0.0
        Else
            dblReturnDouble = Convert.ToDouble(argDbl)
        End If

        Return dblReturnDouble
    End Function


    Public Function ObjectsCompare(ByVal fromObject As Object, ByVal toObject As Object)
        Dim objectsCompareResult = True
        Dim propList = fromObject.GetType().GetProperties()
        For Each t As PropertyInfo In propList
            For Each s As PropertyInfo In toObject.GetType.GetProperties()
                'For Each s As PropertyInfo In ToObject.GetType().GetProperties()
                'If s.Name.ToLower() = "payeetype" Then
                '    Debugger.Break()
                'End If
                If t.Name.ToLower() = s.Name.ToLower() Then
                    'If s.Name.ToLower() = "payeetype" Then
                    '    Debugger.Break()
                    'End If
                    ' check first for null values
                    Dim source = s.GetValue(toObject)
                    Dim target = t.GetValue(fromObject)
                    If target Is Nothing And source Is Nothing Then
                        '' objects compare
                    ElseIf target Is Nothing And TypeOf source Is String Then
                        If String.IsNullOrWhiteSpace(source) Then
                            '' objects compare
                        Else
                            objectsCompareResult = False
                        End If
                    ElseIf target Is Nothing And TypeOf source Is IEnumerable Then
                        'if source.Count() = 0 Then
                        '    '' object both empty 
                        'Else 
                        '    objectsCompareResult = False
                        'End If
                    ElseIf target Is Nothing And source IsNot Nothing Then
                        If String.IsNullOrWhiteSpace(source) Then
                            '' objects compare
                        Else
                            objectsCompareResult = False
                        End If
                    ElseIf source Is Nothing And target IsNot Nothing Then
                        If String.IsNullOrWhiteSpace(target) Then
                            '' objects compare
                        Else
                            objectsCompareResult = False
                        End If
                        'ElseIf TypeOf target Is IEnumerable AndAlso TypeOf source Is IEnumerable Then
                        '    If target.Count() <> source.Count()
                        '        objectsCompareResult = False
                        '    End If
                        '    For i = 0 To target.Count()-1
                        '        ObjectsCompare(target.item(1),source.item(1))
                        '    Next
                        'ElseIf target <> source Then
                    ElseIf Not target.Equals(source) Then
                        objectsCompareResult = False
                    End If
                    Exit For
                End If
            Next
            If Not objectsCompareResult Then
                Exit For
            End If
        Next
        Return objectsCompareResult
    End Function

    'Public Function GetAppLanguage()
    '    Dim rWriter As IResourceWriter
    '    Dim DefaultLanguage As String = ""
    '    If GlobalVariables.GAppLanguage = "" Then
    '        Try
    '            Dim reader As New ResourceReader("HIS.Language")
    '            Dim dEnum As IDictionaryEnumerator = reader.GetEnumerator()

    '            While dEnum.MoveNext()
    '                Select Case dEnum.Key
    '                    Case "DefaultLanguage"
    '                        DefaultLanguage = dEnum.Value
    '                        Exit Select
    '                    Case Else
    '                        DefaultLanguage = "English"
    '                End Select
    '            End While
    '            reader.Close()
    '        Catch
    '            rWriter = New ResourceWriter("HIS.Language")
    '            rWriter.AddResource("DefaultLanguage", "English")
    '            rWriter.Close()
    '            DefaultLanguage = "English"
    '        Finally
    '            If DefaultLanguage = "" Then
    '                DefaultLanguage = "English"
    '            End If
    '        End Try
    '        GlobalVariables.ChangeLanguage(DefaultLanguage)
    '    End If
    '    Return GlobalVariables.GAppLanguage
    'End Function

    'Public Function DateToInvCultureString(ByVal DateValue As Date?) As String
    '    ' convert a Date to string int a Invariant Culture Format
    '    If DateValue Is Nothing Then
    '        Return Nothing
    '    Else
    '        Try
    '            Dim myDate As DateTime = DateValue
    '            Return myDate.ToString(CultureInfo.InvariantCulture)
    '        Catch ex As Exception
    '            Return Nothing
    '        End Try
    '    End If
    'End Function

    'Public Function DateStringCurrentCultureToDate(ByVal DateString As String) As Date
    '    If DateString Is Nothing Then
    '        Return Nothing
    '    Else
    '        Try
    '            Dim dDate As DateTime? = Convert.ToDateTime(DateString)
    '            Return dDate
    '            'Return DateTime.ParseExact(DateString, CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern, CultureInfo.InvariantCulture)
    '        Catch ex As Exception
    '            Return Nothing
    '        End Try
    '    End If
    'End Function


    Public Function CalendarDateToShortDateString(dateValue As DateTime?, targetCulture As CultureInfo) As String
        If dateValue Is Nothing Then
            Return Nothing
        End If
        Dim givenDate As DateTime = dateValue
        Dim shortDateString As String
        Dim curCulture As CultureInfo = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = targetCulture
        Try
            shortDateString = givenDate.ToShortDateString()
        Catch ex As Exception
            shortDateString = Nothing
        Finally
            CultureInfo.CurrentCulture = curCulture
        End Try
        Return shortDateString
    End Function


    Public Function DateToSpecificCultureShortDateString(dateValue As DateTime?, targetCulture As CultureInfo) As String
        If dateValue Is Nothing Then
            Return Nothing
        End If
        Dim givenDate As DateTime = dateValue
        Dim shortDateString As String
        Dim curCulture As CultureInfo = CultureInfo.CurrentCulture
        If targetCulture IsNot Nothing Then
            CultureInfo.CurrentCulture = targetCulture
        End If
        Try
            shortDateString = givenDate.ToShortDateString()
        Catch ex As Exception
            shortDateString = Nothing
        Finally
            CultureInfo.CurrentCulture = curCulture
        End Try
        Return shortDateString
    End Function

    Public Function DateStringSpecificCultureToDate(dateString As String, targetCultureInfo As CultureInfo) As Date?
        Dim retDate As Date?
        Dim curCulture = CultureInfo.CurrentCulture
        Try
            CultureInfo.CurrentCulture = targetCultureInfo
            retDate = Convert.ToDateTime(dateString)

        Catch ex As Exception
            retDate = Nothing
        Finally
            CultureInfo.CurrentCulture = curCulture
        End Try
        Return retDate
    End Function

    Public Function IsDateValidForTargetCulture(strDate As String, ByRef targetCulture As CultureInfo) As Boolean
        ' checks if the strDate is a valid date in the
        ' targetculture format
        Dim curCulture = CultureInfo.CurrentCulture
        Dim retVal As Boolean
        CultureInfo.CurrentCulture = targetCulture
        If IsDate(strDate) Then
            retVal = True
        Else
            retVal = False
        End If
        CultureInfo.CurrentCulture = curCulture
        Return retVal
    End Function

    'Public Function CalendarDateStringSpecificCultureToDate(ByVal DateString As String, ByVal TargetCultureInfo As CultureInfo) As Date?
    '    Dim retDate As Date?
    '    Try
    '        retDate = Convert.ToDateTime(DateString, TargetCultureInfo)
    '    Catch ex As Exception
    '        retDate = Nothing
    '    End Try
    '    Return retDate
    '    'Dim retDate As Date?
    '    'Dim curCulture = CultureInfo.CurrentCulture
    '    'Try
    '    '    CultureInfo.CurrentCulture = TargetCultureInfo
    '    '    retDate = Convert.ToDateTime(DateString)
    '    'Catch ex As Exception
    '    '    retDate = Nothing
    '    'Finally
    '    '    CultureInfo.CurrentCulture = curCulture
    '    'End Try
    '    'Return retDate
    'End Function

    'Public Function DateStringToInvCultureDate(ByVal DateString As String) As Date?
    '    Dim retDate As Date?
    '    Try
    '        retDate = Date.Parse(DateString, System.Globalization.CultureInfo.InvariantCulture)
    '    Catch ex As Exception
    '        retDate = Nothing
    '    End Try
    '    Return retDate
    'End Function


    'Public Function DateICtoCurCulDateString(ByVal DateValue As Date?) As String
    '    Dim retDateString As String
    '    Dim curCulture As CultureInfo = CultureInfo.CurrentCulture
    '    Try
    '        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture
    '        retDateString = DateValue.ToString()
    '    Catch ex As Exception
    '        retDateString = Nothing
    '    Finally
    '        CultureInfo.CurrentCulture = curCulture
    '    End Try
    '    Return retDateString
    'End Function

    Public Function PadWithZeroSingleDigitDate(shortDate As String) As String
        ' appends zero to single digit no. say 1/1/200 will be changed to 01/01/2000
        Dim newShortDate As String
        If shortDate Is Nothing OrElse shortDate = "" Then
            newShortDate = Nothing
        Else
            newShortDate = Regex.Replace(shortDate, "\b\d\b", "0$&")
        End If
        Return newShortDate
    End Function

    'Public Function PadWithZeroSingleDigitDate(ByVal shortDate As String) As String
    '    ' appends zero to single digit no. say 1/1/200 will be changed to 01/01/2000
    '    Dim newShortDate As String
    '    If shortDate Is Nothing Or shortDate = "" Then
    '        newShortDate = Nothing
    '    Else
    '        newShortDate = Regex.Replace(shortDate, "\b\d\b", "0$&")
    '    End If
    '    Return newShortDate
    'End Function

    Public Function HijriMonthInEnglish(iMonth As Int16)
        Dim strMonth As String
        strMonth = ""
        Select Case iMonth
            Case 1
                strMonth = "Muḥarram"
            Case 2
                strMonth = "Ṣafar"
            Case 3
                strMonth = "Rabī' I"
            Case 4
                strMonth = "Rabī' II"
            Case 5
                strMonth = "Jumādā I"
            Case 6
                strMonth = "Jumādā II"
            Case 7
                strMonth = "Rajab"
            Case 8
                strMonth = "Sha'aban"
            Case 9
                strMonth = "Ramadan"
            Case 10
                strMonth = "Shawwal"
            Case 11
                strMonth = "Dhu al-Qi'dah"
            Case 12
                strMonth = "Dhu al-Hijjah"
            Case Else
                strMonth = "Invalid Month"
        End Select
        Return strMonth
    End Function


    Function CultureSupportUmAlQura(targetCulture As CultureInfo)
        Dim returnValue = False
        For Each optionalCalendar In targetCulture.OptionalCalendars
            If TypeOf optionalCalendar Is UmAlQuraCalendar Then
                returnValue = True
                Exit For
            End If
        Next
        Return returnValue
    End Function

    Function CultureSupportHijri(targetCulture As CultureInfo)
        Dim returnValue = False
        For Each optionalCalendar In targetCulture.OptionalCalendars
            If TypeOf optionalCalendar Is HijriCalendar Then
                returnValue = True
            End If
        Next
        Return returnValue
    End Function

    Function GetMonthNameInCulture(monthNumber As Integer, ByRef targetCulture As CultureInfo,
                                   ByRef currentCulture As CultureInfo)
        If Mid(currentCulture.Name, 1, 2).ToLower() = Mid(targetCulture.Name, 1, 2).ToLower() Then
            Return targetCulture.DateTimeFormat.MonthGenitiveNames(monthNumber - 1)
        Else
            If _
                Mid(currentCulture.Name, 1, 2).ToLower() = "en" And
                TypeOf targetCulture.DateTimeFormat.Calendar Is HijriCalendar Or
                TypeOf targetCulture.DateTimeFormat.Calendar Is UmAlQuraCalendar Then
                Return HijriMonthInEnglish(monthNumber)
            Else
                Return targetCulture.DateTimeFormat.MonthGenitiveNames(monthNumber - 1)
            End If
        End If
    End Function


    Function GetMonthNamesInCulture(monthNumber As Integer, ByRef targetCulture As CultureInfo,
                                    ByRef currentCulture As CultureInfo)
        Return targetCulture.DateTimeFormat.MonthGenitiveNames()
    End Function

    Function GetCalendarName(cal As Calendar) As String
        Return cal.ToString().Replace("System.Globalization.", "")
    End Function


    Public Function SendMail(strFrom As String, strTo As String, strSubject As String, strMsg As String) _
        As Boolean
        Try
            ' Create the mail message
            Dim objMailMsg = New MailMessage(strFrom, strTo)

            objMailMsg.BodyEncoding = Encoding.UTF8
            objMailMsg.Subject = strSubject
            objMailMsg.Body = strMsg
            objMailMsg.Priority = MailPriority.High
            objMailMsg.IsBodyHtml = True

            'prepare to send mail via SMTP transport
            Dim objSMTPClient = New SmtpClient()
            objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis
            objSMTPClient.Send(objMailMsg)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Module