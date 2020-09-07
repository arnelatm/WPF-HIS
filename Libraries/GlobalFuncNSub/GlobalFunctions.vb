Imports System.ComponentModel
Imports System.Globalization
Imports System.Linq.Expressions
Imports System.Net.Mail
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Module GlobalFunctions

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

    Function CultureSupportHijri(targetCulture As CultureInfo)
        Dim returnValue = False
        For Each optionalCalendar In targetCulture.OptionalCalendars
            If TypeOf optionalCalendar Is HijriCalendar Then
                returnValue = True
            End If
        Next
        Return returnValue
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

    Public Function DtoS(ByVal dateValue As Date) As String
        Dim retValue As String
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        retValue = Year(dateValue).ToString() &
                Strings.Right("00" & Month(dateValue).ToString().TrimEnd().TrimStart(), 2) &
                Strings.Right("00" & DateAndTime.Day(dateValue).ToString().TrimStart().TrimEnd(), 2)
        CultureInfo.CurrentCulture = curCulture
        Return retValue
    End Function

    Public Function FindControlRecursive(list As List(Of Control), parent As Control) As List(Of Control)
        If parent Is Nothing Then Return list
        list.Add(parent)
        For Each child As Control In parent.Controls
            FindControlRecursive(list, child)
        Next
        Return list
    End Function

    Public Function FormatMoney(ByVal amount As Decimal) As String
        Return amount.ToString("N", GlobalVariables.DefaultCurrencyFormatInfo)
    End Function

    Public Function FormatDecimalNumber(ByVal number As Decimal) As String
        Return number.ToString("N", GlobalVariables.DefaultNumberFormatInfo)
    End Function

    Public Function GbDateSerial(ByVal year As Int16, ByVal month As Int16, ByVal day As Int16) As Date?
        Dim value As Date?
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = DateSerial(year, month, day)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    Function GetCalendarName(cal As Calendar) As String
        Return cal.ToString().Replace("System.Globalization.", "")
    End Function

    Public Function GetDescription(ByVal enumValue As Object, ByVal defDesc As String) As String
        If enumValue Is Nothing Then
            Return Nothing
        End If
        Dim fi As FieldInfo = enumValue.[GetType]().GetField(enumValue.ToString())

        If fi IsNot Nothing Then
            Dim attrs As Object() = fi.GetCustomAttributes(GetType(DescriptionAttribute), True)
            If attrs IsNot Nothing AndAlso attrs.Length > 0 Then Return (CType(attrs(0), DescriptionAttribute)).Description
        End If

        Return defDesc
    End Function

    Public Function GetEnumCode(ByVal enumValue As Object) As String
        If enumValue Is Nothing Then
            Return Nothing
        End If
        Dim fi As FieldInfo = enumValue.[GetType]().GetField(enumValue.ToString())

        If fi IsNot Nothing Then
            Dim attrs As Object() = fi.GetCustomAttributes(True)
            If attrs IsNot Nothing AndAlso attrs.Length > 0 Then Return (CType(attrs(0), EnumCode)).EnumCode
        End If
        Return Nothing
    End Function

    Public Function GetEnumCodeValue(Of T)(description As String) As T
        Dim type = GetType(T)
        If Not type.IsEnum Then
            Throw New InvalidOperationException()
        End If
        For Each fieldInfo In type.GetFields()
            Dim descriptionAttribute = Attribute.GetCustomAttribute(fieldInfo, GetType(EnumCode))
            If descriptionAttribute IsNot Nothing Then
                If DirectCast(descriptionAttribute, AATM.Libraries.GlobalFuncNSub.EnumCode).EnumCode <> description Then
                    Continue For
                End If
                Return DirectCast(fieldInfo.GetValue(Nothing), T)
            End If
            If fieldInfo.Name <> description Then
                Continue For
            End If
            Return DirectCast(fieldInfo.GetValue(Nothing), T)
        Next
        Return Nothing
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

    Public Function GetPropertyName(Of T)(expression As Expression(Of Func(Of T))) As String
        Return DirectCast(expression.Body, MemberExpression).Member.Name
    End Function

    Public Function GetPropertyValue(obj As Object, propName As String) As Object
        Dim propValue As Object = Nothing
        Try
            Dim objType As Type = obj.GetType()
            Dim pInfo As PropertyInfo = objType.GetProperty(propName,
                                                            BindingFlags.Public Or BindingFlags.Instance Or
                                                            BindingFlags.IgnoreCase)
            If pInfo IsNot Nothing Then
                propValue = pInfo.GetValue(obj, BindingFlags.GetProperty Or BindingFlags.IgnoreCase, Nothing, Nothing,
                                           Nothing)
            End If
        Catch ex As Exception
            'MessageBox.Show("Invalid property " + PropName + " in object " + obj.GetType().ToString())
            'Throw ex
            propValue = Nothing
        End Try
        Return propValue
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

    Public Function GetVatPercentage()
        Return 0.05D
    End Function

    Public Function GregorianDay(ByVal pDate As Date?) As Int16
        Dim value As Int16
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = Microsoft.VisualBasic.DateAndTime.Day(pDate)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    Public Function GregorianMonth(ByVal pDate As Date?) As Int16
        Dim value As Int16
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = Month(pDate)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    Public Function GregorianMonthName(ByVal pMonthNumber As Int16) As String
        Dim value As Int16
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = Microsoft.VisualBasic.DateAndTime.MonthName(pMonthNumber)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    Public Function GregorianYear(ByVal pDate As Date?) As Int16
        Dim value As Int16
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = Year(pDate)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    Public Function GregorianDateSerial(ByVal nYear As Integer, nMonth As Integer, nDay As Integer) As DateTime
        Dim value As DateTime
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = DateSerial(nYear, nMonth, nDay)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

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

    Public Function IsCultureOk(ByVal cultureCode As String) As Boolean
        Dim cultures As CultureInfo() = CultureInfo.GetCultures(CultureTypes.AllCultures And Not CultureTypes.NeutralCultures)
        Dim culture = cultures.FirstOrDefault(Function(c) c.Name.Equals(cultureCode, StringComparison.OrdinalIgnoreCase))
        If culture Is Nothing Then
            Return False
            'culture = cultures.FirstOrDefault(Function(c) c.Name.Equals(DefaultCultureCode, StringComparison.OrdinalIgnoreCase))
            'If culture Is Nothing Then culture = CultureInfo.CurrentCulture
        End If
        Return True
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

    Public Function IsEmpty(value) As Boolean
        If value Is Nothing Then
            Return True
        End If
        If TypeOf value Is String OrElse TypeOf value Is Char Then
            If value = "" Or value = vbNullChar Or value = vbNullString Then
                Return True
            End If
        ElseIf IsNumeric(value) Then
            If value = 0 Then
                Return True
            End If
            'ElseIf TypeOf value Is IntegerType OrElse TypeOf value Is SingleType OrElse value.DoubleType OrElse value.DecimalType OrElse
            '        value.LongType OrElse value.ShortType OrElse value.UIntegerType OrElse value.ULongType OrElse value.UShortType) Then
            '    If value = 0 Then
            '        Return True
            '    End If
        ElseIf TypeOf value Is Boolean Then
            If Not value Then
                Return True
            End If
        ElseIf TypeOf value Is DateTime Then
            Dim date1 As DateTime = CType(value, DateTime)
            'Dim date2 as New DateTime(Date1.Year, Date1.Month, Date1.Day, Date1.Hour, Date1.Minute, Date1.Second, 0)
            'date1 = Ctype(value,DateTime)
            'date1 =
            If date1.TrimMilliseconds() < Date.MinValue Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function IsRightToLeft(ByVal pCultureInfoString As String) As Boolean
        Dim isCultureRightToLeft As Boolean
        Dim curCulture = CultureInfo.CurrentCulture
        'If pCultureInfoString = GlobalVariables.OriginalAppTextLanguage THEN
        '    pCultureInfoString = GlobalVariables.OriginalAppLanguage
        'End If
        Try
            CultureInfo.CurrentCulture = New CultureInfo(pCultureInfoString, False)
            isCultureRightToLeft = Globalization.CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
            CultureInfo.CurrentCulture = curCulture
            If isCultureRightToLeft Then
                GlobalVariables.RightToLeftLayout = True
            Else
                GlobalVariables.RightToLeftLayout = False
            End If
        Catch ex As Exception
            ' missing culture info string? therefore assume that it is not right to left
            isCultureRightToLeft = False
            GlobalVariables.RightToLeftLayout = False
        End Try
        Return isCultureRightToLeft
    End Function

    Public Function NeedToTranslateText(textDisplayLanguage)
        If textDisplayLanguage = GlobalVariables.OriginalAppTextLanguage Or (Strings.Left(textDisplayLanguage, 2) = "en" And GlobalVariables.UseOriginalAppTextLanguageForEnglish) Then
            Return False
        Else
            Return True
        End If
    End Function

    'Public Function GetPropertyValue(ByRef obj As Object, ByVal propName As String) As Object
    '    Dim objType As Type = obj.GetType()
    '    Dim pInfo As PropertyInfo = objType.GetProperty("MainTableName")
    '    Dim pInfos As PropertyInfo() = objType.GetProperties()
    '    Dim propValue As Object = pInfo.GetValue(obj, BindingFlags.GetProperty, Nothing, Nothing, Nothing)
    '    Return propValue
    'End Function

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

    Public Function NumParser(Of T As Structure)(ByRef numString As String) As T
        Try
            Return Parser(Of T).Parser(numString)
        Catch ex As Exception
            Dim z As New T
            Dim x As Type = z.GetType()
            Dim u As Type = Nullable.GetUnderlyingType(x)
            Dim typeCode As TypeCode = Type.GetTypeCode(x)
            Dim underlyingTypeCode As TypeCode = Type.GetTypeCode(u)
            If u Is Nothing Then
                If NumTypeIsInteger(typeCode) Then
                    Dim num As Double
                    Dim isNumeric As Boolean = Decimal.TryParse(numString, num)
                    If Not isNumeric Then
                        Return Parser(Of T).Parser(0)
                    End If
                    If Math.Abs(num Mod 1) <= (Double.Epsilon * 100) Then
                        ' remove trailing zeroes
                        numString = Strings.Left(numString, numString.IndexOf(".", StringComparison.Ordinal))
                        Return Parser(Of T).Parser(numString)
                    End If
                End If
            Else
                If NumTypeIsInteger(underlyingTypeCode) Then
                    Dim num As Double
                    Dim isNumeric As Boolean = Decimal.TryParse(numString, num)
                    If Not isNumeric Then
                        Return Parser(Of T).Parser(0)
                    End If
                    If Math.Abs(num Mod 1) <= (Double.Epsilon * 100) Then
                        ' remove trailing zeroes
                        numString = Strings.Left(numString, numString.IndexOf(".", StringComparison.Ordinal) - 1)
                        Return Parser(Of T).Parser(numString)
                    End If
                End If
            End If
            Return Parser(Of T).Parser(0)
        End Try
    End Function

    Public Function ChangesMade(ByVal fromObject As Object, ByVal toObject As Object)
        If ObjectsCompare(fromObject, toObject) Then
            Return False
        End If
        Return True
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
                If t.Name.ToLower() = "errors" Then
                    ' skip checking this fields
                ElseIf t.Name.ToLower() = s.Name.ToLower() Then
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
                    ElseIf TypeOf target Is IList Then
                        'ElseIf TypeOf target Is IEnumerable AndAlso TypeOf source Is IEnumerable Then
                        '    If target.Count() <> source.Count()
                        '        objectsCompareResult = False
                        '    End If
                        '    For i = 0 To target.Count()-1
                        '        ObjectsCompare(target.item(1),source.item(1))
                        '    Next
                        'ElseIf target <> source Then
                    ElseIf Not target.Equals(source) Then
                        If t.Name.ToLower() = $"datecreated" Then
                            ' ignore these fields
                        Else
                            objectsCompareResult = False
                        End If
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

    Public Function PropertyExists(queriedObject As Object, propertyName As String) As Boolean
        Dim objType As Type = queriedObject.GetType()
        If _
            objType.GetProperty(propertyName, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.IgnoreCase) Is
            Nothing Then
            Return False
        End If
        Return True
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
    Public Sub SetCulture(ByVal cultureCode As String)
        If IsCultureOk(cultureCode) Then
            CultureInfo.CurrentCulture = New CultureInfo(cultureCode, False)
        Else
            cultureCode = "en-US"
            CultureInfo.CurrentCulture = New CultureInfo("en-US", False)
        End If
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            GlobalVariables.RightToLeftLayout = True
        Else
            GlobalVariables.RightToLeftLayout = False
        End If
        GlobalVariables.AppCurrentCultureInfo = CultureInfo.CurrentCulture
        If CultureInfo.CurrentUICulture.Name <> CultureInfo.CurrentCulture.Name Then
            CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture
        End If
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture
    End Sub

    Public Function GetMinMaxValue(typeCode As TypeCode, ByRef nMaxValue As Double) As Double
        Dim nMinValue As Double
        Select Case typeCode
            Case TypeCode.Byte
                nMinValue = Byte.MinValue
                nMaxValue = Byte.MaxValue
            Case TypeCode.Int16
                nMinValue = Int16.MinValue
                nMaxValue = Int16.MaxValue
            Case TypeCode.Int32
                nMinValue = Int32.MinValue
                nMaxValue = Int32.MaxValue
            Case TypeCode.Int64
                nMinValue = Int64.MinValue
                nMaxValue = Int64.MaxValue
            Case TypeCode.UInt16
                nMinValue = UInt16.MinValue
                nMaxValue = UInt16.MaxValue
            Case TypeCode.UInt32
                nMinValue = UInt32.MinValue
                nMaxValue = UInt32.MaxValue
            Case TypeCode.UInt64
                nMinValue = UInt64.MinValue
                nMaxValue = UInt64.MaxValue
            Case TypeCode.Single
                nMinValue = Single.MinValue
                nMaxValue = Single.MaxValue
            Case TypeCode.Double
                nMinValue = Double.MinValue
                nMaxValue = Double.MaxValue
            Case TypeCode.Decimal
                nMinValue = Decimal.MinValue
                nMaxValue = Decimal.MaxValue
            Case TypeCode.DBNull
                nMinValue = 0
                nMaxValue = 0
            Case Else
                nMinValue = Double.MinValue
                nMaxValue = Double.MaxValue
        End Select
        Return nMinValue
    End Function

    Public Function ConvertObjectToType(ByVal value As Object)
        Dim result
        Dim typeCode As TypeCode = value.GetTypeCode()
        Select Case typeCode
            Case TypeCode.String
                result = value.ToString()
            Case TypeCode.Boolean
                result = Convert.ToBoolean(value)
            Case TypeCode.Int32
                result = Convert.ToInt32(value)
            Case TypeCode.Decimal
                result = Convert.ToDecimal(value)
            Case TypeCode.Int16
                result = Convert.ToInt16(value)
            Case TypeCode.DateTime
                result = Convert.ToDateTime(value)
            Case TypeCode.Single
                result = Convert.ToSingle(value)
            Case TypeCode.Double
                result = Convert.ToDouble(value)
            Case TypeCode.Empty
                result = Nothing
            Case TypeCode.DBNull
                result = Nothing
            Case TypeCode.Char
                result = Convert.ToChar(value)
            Case TypeCode.Byte
                result = Convert.ToByte(value)
            Case TypeCode.Int64
                result = Convert.ToInt64(value)
            Case TypeCode.UInt16
                result = Convert.ToUInt16(value)
            Case TypeCode.UInt32
                result = Convert.ToUInt32(value)
            Case TypeCode.UInt64
                result = Convert.ToUInt64(value)
            Case TypeCode.SByte
                result = Convert.ToSByte(value)
            Case Else
                result = value
        End Select
        Return result
    End Function

    Public Function NumTypeIsInteger(ByVal typeCodeVal As TypeCode) As Boolean
        If typeCodeVal = TypeCode.Byte OrElse typeCodeVal = TypeCode.Int16 OrElse typeCodeVal = TypeCode.Int32 OrElse typeCodeVal = TypeCode.Int64 _
            OrElse typeCodeVal = TypeCode.UInt16 OrElse typeCodeVal = TypeCode.UInt32 OrElse typeCodeVal = TypeCode.UInt64 Then
            Return True
        End If
        Return False
    End Function

    'Public Function CompareValues(source, Target) As Boolean
    '    Dim retVal As Boolean = False
    '    Dim source1 As New List(Of String)
    '    Dim target1 = ""
    '    If source1 = target1 Then
    '        retVal = true
    '    End If
    '    'If Target.Equals(source) Then
    '    '    retVal = True
    '    'End If
    '    'If Target Is Nothing And source Is Nothing Then
    '    '    retVal = True
    '    'ElseIf Target Is Nothing And TypeOf source Is String Then
    '    '    If String.IsNullOrWhiteSpace(source) Then
    '    '        retVal = True
    '    '    End If
    '    'ElseIf Target Is Nothing And TypeOf source Is IEnumerable Then
    '    '    if source.Count() = 0 Then
    '    '        retVal = true
    '    '    End If
    '    'ElseIf Target Is Nothing And source IsNot Nothing Then
    '    '    If String.IsNullOrWhiteSpace(source) Then
    '    '        retVal = True
    '    '    End If
    '    'ElseIf source Is Nothing And Target IsNot Nothing Then
    '    '    If String.IsNullOrWhiteSpace(Target) Then
    '    '        retVal = True
    '    '    End If
    '    'ElseIf Target.Equals(source) Then
    '    '    retVal = True
    '    'End If
    '    Return retVal
    'End Function

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
    'Public Function GetEnumCode(ByVal enumValue As Type) As EnumCode
    '    If enumValue Is Nothing Then
    '        Return Nothing
    '    End If
    '    Dim myAtt As EnumCode
    '    myAtt = CType(Attribute.GetCustomAttribute(enumValue,GetType(EnumCode)), EnumCode)
    '    Return myAtt
    'End Function

    'Public Function GetEnumCode(T As Type)
    '    Dim myAttribute As EnumCode = CType(Attribute.GetCustomAttribute(t, GetType(EnumCode)), EnumCode)
    '    If myAttribute Is Nothing Then
    '        Return Nothing
    '    End If
    '    Return MyAttribute.EnumCode
    'End Function

    'Public Function GetEnumCode(Of T)(ByVal enumValue As Object, ByVal defDesc As String) As String

    '    Dim enumAtt As Attribute
    '    enumAtt = CType(tmpInfo.GetCustomAttributes(GetType(PositionAttribute), True)(0), PositionAttribute)

    '    If enumValue Is Nothing Then
    '        Return nothing
    '    End If
    '    Dim fi As FieldInfo = enumValue.[GetType]().GetField(enumValue.ToString())

    '    If fi IsNot Nothing Then
    '        Dim attrs As Object() = fi.GetCustomAttributes(GetType(T), True)
    '        If attrs IsNot Nothing AndAlso attrs.Length > 0 Then Return (CType(attrs(0), T)).EnumCode
    '    End If

    '    Return defDesc
    'End Function

    'Public Function EnumAttribute(Of T)(ByVal enumAttr As T, enumValue As Object, ByVal defDesc As String) As String
    '    If enumValue Is Nothing Then
    '        Return nothing
    '    End If
    '    Dim fi As FieldInfo = enumValue.[GetType]().GetField(enumValue.ToString())

    '    If fi IsNot Nothing Then
    '        Dim attrs As Object() = fi.GetCustomAttributes(GetType(T), True)
    '        If attrs IsNot Nothing AndAlso attrs.Length > 0 Then Return (CType(attrs(0), T)).Description
    '    End If

    '    Return defDesc
    'End Function
End Module