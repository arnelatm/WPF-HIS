Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Dynamic
Imports System.Globalization
Imports System.IO
Imports System.Linq.Expressions
Imports System.Net.Mail
Imports System.Printing
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces

Public Module GlobalFunctions

    '''<summary>
    '''Converts a given date value to short date string in the requested targetculture
    '''</summary>
    Public Function CalendarDateToShortDateString(dateValue As DateTime?, targetCulture As CultureInfo) As String
        If dateValue Is Nothing Then
            Return Nothing
        End If
        Dim givenDate As DateTime = dateValue
        Dim shortDateString As String
        Dim curCulture As CultureInfo = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = targetCulture
        Try
            If TypeOf targetCulture.Calendar Is System.Globalization.UmAlQuraCalendar Or TypeOf targetCulture.Calendar Is System.Globalization.HijriCalendar Then
                targetCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            End If
            shortDateString = givenDate.ToShortDateString()
        Catch ex As Exception
            shortDateString = Nothing
        Finally
            CultureInfo.CurrentCulture = curCulture
        End Try
        Return shortDateString
    End Function

    '''<summary>
    '''Checks if the given CultureInfo supports the Hijri Calendar
    '''</summary>
    Function CultureSupportHijri(targetCulture As CultureInfo)
        Dim returnValue = False
        For Each optionalCalendar In targetCulture.OptionalCalendars
            If TypeOf optionalCalendar Is HijriCalendar Then
                returnValue = True
                Exit For
            End If
        Next
        Return returnValue
    End Function

    '''<summary>
    '''Checks if the given CultureInfo supports the Um-Al-Qura Calendar
    '''</summary>
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

    '''<summary>
    '''Converts the given Date String to the requested TargetCulture
    '''</summary>
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

    '''<summary>
    '''Converts a given Date Value to the desired shortDateString for the targetCulture
    '''</summary>
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

    '''<summary>
    '''Converts a string in the format 'yyyymmdd' to a gregorian date
    '''<para>minValue is returned and the MaxValue is passed by reference</para>
    '''</summary>
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

    Public Function GetFloorIntYearDifference(beginningDate As Date, endingDate As Date) As Int16
        Dim year1 As Int16 = Year(beginningDate) ' 1994/12/31 
        Dim year2 As Int16 = Year(endingDate)   ' 2024/01/01
        Dim yearDifference As Int16 = year2 - year1
        ' for accuracy check wee need to get actual values not just the year
        ' we can do it this way :
        ' years = DateAndTime.DateDiff(DateInterval.Year, CDate(View.StartDate), CDate(View.EndDate))
        ' but this would not result to an exact value where say for 2024/12/31 & 2025/01/01 would 
        ' give a result of 1 year for in fact there is only one day in between those days not a year
        ' the DateDiff function only considers the years of the date
        Dim testDate = DateAndTime.DateAdd(DateInterval.Year, yearDifference, beginningDate)
        Dim difference As Int16 = DateAndTime.DateDiff(DateInterval.Day, testDate, endingDate)
        Dim exactYearDifference As Int16
        If difference < -1 Then
            exactYearDifference = yearDifference - 1
        Else
            exactYearDifference = yearDifference
        End If
        Return exactYearDifference
    End Function

    Public Function GetDecimalYearDifference(startDate As Date?, endDate As Date?) As Decimal
        If startDate Is Nothing Then
            Return 0
        End If
        Dim NoOfYears As Int16 = GetFloorIntYearDifference(startDate, endDate)
        Dim tempDate As Date = DateAndTime.DateAdd(DateInterval.Year, NoOfYears, CDate(startDate))
        tempDate = DateAndTime.DateAdd(DateInterval.Year, -1, tempDate)
        Return NoOfYears - 1 + (DateDiff(DateInterval.Day, tempDate, CDate(endDate)) + 1) / 365
    End Function

    Public Function FindControlRecursive(list As List(Of Control), parent As Control) As List(Of Control)
        If parent Is Nothing Then Return list
        list.Add(parent)
        For Each child As Control In parent.Controls
            'If child.Name = "DataGridViewPcJournals" Then
            '    Debugger.Break()
            'End If
            FindControlRecursive(list, child)
        Next
        Return list
    End Function

    '''<summary>
    '''Converts a given Decimal Amount  into a string Currency format
    '''</summary>
    Public Function FormatMoney(ByVal amount As Decimal) As String
        Return amount.ToString("N", GlobalVariables.DefaultCurrencyFormatInfo)
    End Function

    '''<summary>
    '''Converts a given Decimal Amount  into a string Number format
    '''</summary>
    Public Function FormatDecimalNumber(ByVal number As Decimal) As String
        Return number.ToString("N", GlobalVariables.DefaultNumberFormatInfo)
    End Function

    '''<summary>
    '''Converts a given Decimal Amount into a string Decimal format with the desired decimal places
    '''</summary>
    Public Function FormatDecimalNumber(ByVal number As Decimal, ByVal decimalPlaces As Int16) As String
        Return number.ToString("F" + decimalPlaces.ToString().Trim)
    End Function

    '''<summary>
    '''Converts a given serial date (year,month,day) into a gregorian date regardless of current culture
    '''</summary>
    Public Function GbDateSerial(ByVal year As Int16, ByVal month As Int16, ByVal day As Int16) As Date?
        Dim value As Date?
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = DateSerial(year, month, day)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    '''<summary>
    '''Converts a given string to date (year,month,day) into a date regardless of current culture
    '''</summary>
    Public Function MakeDate(ByVal year As Int16, ByVal month As Int16, ByVal day As Int16) As Date?
        Dim value As Date?
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = DateSerial(year, month, day)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    '''<summary>
    '''Get the Calendar Name for a given Calendar
    '''</summary>
    Function GetCalendarName(cal As Calendar) As String
        Return cal.ToString().Replace("System.Globalization.", "")
    End Function

    '''<summary>
    '''Gets the description for a given enum
    '''</summary>
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

    '''<summary>
    '''Converts a given Enum Value to its Coded Value
    '''</summary>
    <System.Diagnostics.DebuggerStepThrough()>
    Public Function EnumToCode(ByVal enumValue As Object) As String
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

    '''<summary>
    '''Converts the Coded Value of an Enum to its Enum Value
    '''</summary>
    Public Function CodeToEnum(Of T)(description As String) As T
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

    '''<summary>
    '''Get the month name for the given culture
    '''</summary>
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

    '''<summary>
    '''Get the month names for the target Culture
    '''</summary>
    Function GetMonthNamesInCulture(ByRef targetCulture As CultureInfo)
        Return targetCulture.DateTimeFormat.MonthGenitiveNames()
    End Function

    '''<summary>
    '''Get the property name for the current expression
    '''</summary>
    Public Function GetPropertyName(Of T)(expression As Expression(Of Func(Of T))) As String
        Return DirectCast(expression.Body, MemberExpression).Member.Name
    End Function

    '''<summary>
    '''Get the value of a property in the target object
    '''</summary>
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

    '''<summary>
    '''Get the Arabic Translated property field name for the requested property
    '''</summary>
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

    '''<summary>
    ''' Returns the current Vat Percentage for sales
    '''</summary>
    Public Function GetVatPercentage()
        Return 0.15D
    End Function

    '''<summary>
    '''Returns the day number in a given date for the gregorian calendar
    '''</summary>
    Public Function GregorianDay(ByVal pDate As Date?) As Int16
        Dim value As Int16
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = Microsoft.VisualBasic.DateAndTime.Day(pDate)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    '''<summary>
    '''Returns the month number for the gregorian calendar for a given date
    '''</summary>
    Public Function GregorianMonth(ByVal pDate As Date?) As Int16
        Dim value As Int16
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = Month(pDate)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    '''<summary>
    '''Returns the month name for the gregorian calendar for a given month number
    '''</summary>
    Public Function GregorianMonthName(ByVal pMonthNumber As Int16) As String
        Dim value As String
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = Microsoft.VisualBasic.DateAndTime.MonthName(pMonthNumber)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    '''<summary>
    '''Returns the month name for the gregorian calendar for a given month number
    '''</summary>
    Public Function GregorianMonthNameArabic(ByVal pMonthNumber As Int16) As String
        Dim value As String
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("ar-AE", False)
        value = Microsoft.VisualBasic.DateAndTime.MonthName(pMonthNumber)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    '''<summary>
    '''Returns the year in the gregorian calendar for a given date
    '''</summary>
    Public Function GregorianYear(ByVal pDate As Date?) As Int16
        Dim value As Int16
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = Year(pDate)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    Public Function GregorianLongDate(ByVal dateToConvert As Date?, ByVal targetCulture As CultureInfo)
        If Strings.Left(targetCulture.Name, 2) = "ar" Then
            Return GregorianMonthNameArabic(GregorianMonth(dateToConvert)) + " " + GregorianDay(dateToConvert).ToString() + ", " + GregorianYear(dateToConvert).ToString()
        Else
            Return GregorianMonthName(GregorianMonth(dateToConvert)) + " " + GregorianDay(dateToConvert).ToString() + ", " + GregorianYear(dateToConvert).ToString()
        End If
    End Function

    '''<summary>
    '''Converts a Date to Gregorian Date given the year,month,and day.
    '''</summary>
    Public Function GregorianDateSerial(ByVal nYear As Integer, nMonth As Integer, nDay As Integer) As DateTime
        Dim value As DateTime
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        value = DateSerial(nYear, nMonth, nDay)
        CultureInfo.CurrentCulture = curCulture
        Return value
    End Function

    '''<summary>
    '''Returns the Hijri month (in English) for the given month number.
    '''</summary>
    Public Function HijriMonthInEnglish(iMonth As Int16) As String
        Dim strMonth As String
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

    '''<summary>
    '''Checks if a given culture code is a valid culture
    '''</summary>
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

    '''<summary>
    '''Checks if a given date (in string format) is valid for the given target culture
    '''</summary>
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

    '''<summary>
    '''Checks if a given value is empty
    '''</summary>
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

    '''<summary>
    '''Checks if a given culture string is a Right To Left Culture
    '''</summary>
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

    ''' <summary>
    ''' Checks if there is a need to translate a given text
    ''' </summary>
    Public Function NeedToTranslateText(ByVal textDisplayLanguage As String, Optional pTargetCulture As String = Nothing) As Boolean
        Dim targetCulture As String
        If pTargetCulture Is Nothing Then
            targetCulture = textDisplayLanguage
        Else
            targetCulture = pTargetCulture
        End If
        If targetCulture = GlobalVariables.OriginalAppTextLanguage Or (Strings.Left(textDisplayLanguage, 2) = "en" And GlobalVariables.UseOriginalAppTextLanguageForEnglish) Then
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    '''     handles null or blank values for string type
    ''' </summary>
    ''' <param name="argStr">string value to handle</param>
    ''' <returns>returns string</returns>
    Public Function NullString(argStr As String) As String
        Dim strReturnString As String
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

    '''<summary>
    '''Converts a Double number to zero if null
    '''</summary>
    Public Function NullValue(argDbl As Double) As Double
        Dim dblReturnDouble As Double
        If argDbl.Equals(DBNull.Value) Then
            dblReturnDouble = 0D
        ElseIf Convert.ToString(argDbl) = "" Then
            dblReturnDouble = 0D
        ElseIf Convert.ToString(argDbl) = "&nbsp;" Then
            dblReturnDouble = 0D
        Else
            dblReturnDouble = Convert.ToDouble(argDbl)
        End If
        Return dblReturnDouble
    End Function

    '''<summary>
    '''Converts a given number in string format to the desired number format.
    '''<para>returns zero(0) if not convertible to number.</para>
    '''</summary>
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
                ElseIf typeCode = TypeCode.Decimal Then
                    Return Parser(Of T).Parser(0)
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

    '''<summary>
    '''Converts a given date in string format to the desired date format.
    '''<para>returns zero(0) if not convertible to number.</para>
    '''</summary>
    Public Function DateParser(Of T As Structure)(ByRef dateString As String) As T
        Try
            Return Parser(Of T).Parser(dateString)
        Catch ex As Exception
            Dim z As New T
            Dim x As Type = z.GetType()
            Dim u As Type = Nullable.GetUnderlyingType(x)
            Dim typeCode As TypeCode = Type.GetTypeCode(x)
            Dim underlyingTypeCode As TypeCode = Type.GetTypeCode(u)
            If u Is Nothing Then
                Return Nothing
            End If
            Return Parser(Of T).Parser(DateTime.MinValue)
        End Try
    End Function

    '''<summary>
    '''Converts a given Boolean in string format to the desired Bool format.
    '''<para>returns false (0) if not convertible to boolean.</para>
    '''</summary>
    Public Function BoolParser(Of T As Structure)(ByRef boolString As String) As T
        Try
            Return Parser(Of T).Parser(boolString)
        Catch ex As Exception
            Dim z As New T
            Dim x As Type = z.GetType()
            Dim u As Type = Nullable.GetUnderlyingType(x)
            Dim typeCode As TypeCode = Type.GetTypeCode(x)
            Dim underlyingTypeCode As TypeCode = Type.GetTypeCode(u)
            If u Is Nothing Then
                Return Nothing
            End If
            Return Parser(Of T).Parser(False)
        End Try
    End Function

    ''''<summary>
    ''''Checks two objects if they are the same (no changes)
    ''''</summary>
    'Public Function ChangesMade(ByVal fromObject As Object, ByVal toObject As Object)
    '    If ObjectsCompare(fromObject, toObject) Then
    '        Return False
    '    End If
    '    Return True
    'End Function

    '''<summary>
    '''Compares two objects if the same
    '''</summary>
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

    '''<summary>
    '''converts a date string to double digits say 1/1/2012 -> 01/01/2012
    '''</summary>
    Public Function PadWithZeroSingleDigitDate(shortDate As String) As String
        ' appends zero to single digit no. say 1/1/2000 will be changed to 01/01/2000
        Dim newShortDate As String
        If shortDate Is Nothing OrElse shortDate = "" Then
            newShortDate = Nothing
        Else
            newShortDate = Regex.Replace(shortDate, "\b\d\b", "0$&")
            ' \b - boundary non , \d - digit
            ' replacement $& - include the rest of the string
            ' 0 - add 0 to the matched string
        End If
        Return newShortDate
    End Function

    '''<summary>
    '''Checks if a given property exists in the queried object
    '''</summary>
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
            Dim objMailMsg = New MailMessage(strFrom, strTo) With {
                .BodyEncoding = Encoding.UTF8,
                .Subject = strSubject,
                .Body = strMsg,
                .Priority = MailPriority.High,
                .IsBodyHtml = True
            }

            'prepare to send mail via SMTP transport
            Dim objSMTPClient = New SmtpClient With {
                .DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis
            }
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

    '''<summary>
    '''Sets the current culture to the given culture Code
    '''</summary>
    Public Sub SetCulture(ByVal cultureCode As String)
        If IsCultureOk(cultureCode) Then
            CultureInfo.CurrentCulture = New CultureInfo(cultureCode, False)
        Else
            'cultureCode = "en-US"
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

    '''<summary>
    '''Returns the minimum and maximum value for a given typecode
    '''<para>minValue is returned and the MaxValue is passed by reference</para>
    '''</summary>
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

    '''<summary>
    '''Converts an object to its type
    '''</summary>
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

    Public Function GetObjectDataType(dataObject As Object) As IFindableControl.DataTypeEnum
        Dim dataTypeEnum As IFindableControl.DataTypeEnum
        If dataObject = GetType(Date?) Or dataObject = GetType(Date) Or dataObject = GetType(DateTime) Then
            dataTypeEnum = IFindableControl.DataTypeEnum.Date
        ElseIf dataObject = GetType(String) Or dataObject = GetType(Char) Then
            dataTypeEnum = IFindableControl.DataTypeEnum.String
        ElseIf dataObject = GetType(Short) Or dataObject = GetType(Integer) Or dataObject = GetType(Long) _
               Or dataObject = GetType(ULong) Or dataObject = GetType(UShort) Or dataObject = GetType(UInteger) _
               Or dataObject = GetType(SByte) Or dataObject = GetType(Byte) Then
            dataTypeEnum = IFindableControl.DataTypeEnum.Integer
        ElseIf dataObject = GetType(Decimal) Or dataObject = GetType(Single) Or dataObject = GetType(Double) Then
            dataTypeEnum = IFindableControl.DataTypeEnum.Decimal
        ElseIf dataObject = GetType(Boolean) Then
            dataTypeEnum = IFindableControl.DataTypeEnum.Boolean
        End If
        Return dataTypeEnum
    End Function

    '''<summary>
    '''Checks if the given typeCodeValue is an integer
    '''</summary>
    Public Function NumTypeIsInteger(ByVal typeCodeVal As TypeCode) As Boolean
        If typeCodeVal = TypeCode.Byte OrElse typeCodeVal = TypeCode.Int16 OrElse typeCodeVal = TypeCode.Int32 OrElse typeCodeVal = TypeCode.Int64 _
            OrElse typeCodeVal = TypeCode.UInt16 OrElse typeCodeVal = TypeCode.UInt32 OrElse typeCodeVal = TypeCode.UInt64 Then
            Return True
        End If
        Return False
    End Function

    Public Function NumTypeIsDecimal(ByVal typeCodeVal As TypeCode) As Boolean
        If typeCodeVal = TypeCode.Decimal Then
            Return True
        End If
        Return False
    End Function

    Public Sub AdjustBeginningEndDates(ByVal periodCode As String, ByRef beginningDate As Date?, ByRef endingDate As Date?)
        If periodCode IsNot Nothing Then
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Select Case periodCode
                Case "Y"
                    If endingDate Is Nothing Then
                        endingDate = DateAdd("yyyy", -1, Now())
                    End If
                    beginningDate = GlobalFunctions.GregorianDateSerial(Year(endingDate), 1, 1)
                    endingDate = GlobalFunctions.GregorianDateSerial(Year(endingDate), 12, 31)
                Case "M"
                    If endingDate Is Nothing Then
                        endingDate = DateAdd("m", -1, Now())
                    End If
                    beginningDate = GlobalFunctions.GregorianDateSerial(Year(endingDate), Month(endingDate), 1)
                    endingDate = GlobalFunctions.GregorianDateSerial(Year(endingDate), Month(endingDate) + 1, 0)
                Case "Q"
                    If endingDate Is Nothing Then
                        endingDate = DateAdd("m", -3, Now())
                    End If
                    Dim nMonth = Month(endingDate)
                    Dim quarter = Int(nMonth / 3 + 0.8)
                    beginningDate = GlobalFunctions.GregorianDateSerial(Year(endingDate), quarter * 3 - 2, 1)
                    Dim quarterEndDate = GlobalFunctions.GregorianDateSerial(Year(endingDate), quarter * 3, 1)
                    quarterEndDate = GregorianDateSerial(Year(quarterEndDate), Month(quarterEndDate), DateTime.DaysInMonth(Year(quarterEndDate), Month(quarterEndDate)))
                    endingDate = quarterEndDate
                Case "S"
                    If endingDate Is Nothing Then
                        endingDate = DateAdd("m", -6, Now())
                    End If
                    Dim nMonth = Month(endingDate)
                    Dim semester = Int(nMonth / 6 + 0.9)
                    beginningDate = GlobalFunctions.GregorianDateSerial(Year(endingDate), semester * 6 - 5, 1)
                    Dim semesterEndDate = GlobalFunctions.GregorianDateSerial(Year(endingDate), semester * 6, 1)
                    semesterEndDate = DateSerial(Year(semesterEndDate), Month(semesterEndDate), DateTime.DaysInMonth(Year(semesterEndDate), Month(semesterEndDate)))
                    endingDate = semesterEndDate
                Case "C"
                    If beginningDate Is Nothing Then
                        beginningDate = Now()
                    End If
                    If endingDate Is Nothing Then
                        endingDate = Now()
                    End If
            End Select
        End If
    End Sub

    Public Sub MoveToGridView(ByVal dgv As DataGridView, ByVal columnName As String)
        If dgv IsNot Nothing AndAlso dgv.Visible Then
            With dgv
                .Focus()
                If .CurrentCell Is Nothing Then
                    If .CurrentCell Is Nothing Then
                        If .Columns(columnName) IsNot Nothing And .Rows.Count() > 0 Then
                            .CurrentCell = dgv(.Columns(columnName).Index(), 0)
                        End If
                    End If
                Else
                    If .Columns(columnName) IsNot Nothing Then
                        If .Columns(columnName) IsNot Nothing And .Rows.Count() > 0 Then
                            .CurrentCell = dgv(.Columns(columnName).Index(), 0)
                        End If
                    End If
                End If
            End With
        End If

    End Sub

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
    'Public Function EnumToCode(ByVal enumValue As Type) As EnumCode
    '    If enumValue Is Nothing Then
    '        Return Nothing
    '    End If
    '    Dim myAtt As EnumCode
    '    myAtt = CType(Attribute.GetCustomAttribute(enumValue,GetType(EnumCode)), EnumCode)
    '    Return myAtt
    'End Function

    'Public Function EnumToCode(T As Type)
    '    Dim myAttribute As EnumCode = CType(Attribute.GetCustomAttribute(t, GetType(EnumCode)), EnumCode)
    '    If myAttribute Is Nothing Then
    '        Return Nothing
    '    End If
    '    Return MyAttribute.EnumCode
    'End Function

    'Public Function EnumToCode(Of T)(ByVal enumValue As Object, ByVal defDesc As String) As String

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

    Public Function CreateTextImage(cText As String, pFontSize As Int16?, pBgColor As Color?, pFgColor As Color?, pLength As Int16?, pWidth As Int16?)
        Dim img As Image
        If pFontSize Is Nothing Then
            pFontSize = 30
        End If
        If pBgColor Is Nothing Then
            pBgColor = Color.AntiqueWhite
        End If
        If pFgColor Is Nothing Then
            pFgColor = Color.Black
        End If
        If pLength Is Nothing Then
            pLength = 300
        End If
        If pWidth Is Nothing Then
            pWidth = 200
        End If
        img = ConvertTextToImage(cText, "Courier", pFontSize, pBgColor, pFgColor, pWidth, pLength)
        Return img
        'img = ConvertTextToImage(
        '    "Click" & Environment.NewLine & "to Change" & Environment.NewLine & "Photo",
        '    "Courier", 30,
        '    Color.AntiqueWhite, Color.Black,
        '    300, 200)
        'Return img
    End Function

    ''' <summary>
    ''' Responsive for creating a error image
    ''' </summary>
    ''' <param name="pMessageText"></param>
    ''' <param name="pFontName"></param>
    ''' <param name="pFontSize"></param>
    ''' <param name="pBackColor"></param>
    ''' <param name="pForeColor"></param>
    ''' <param name="pWidth"></param>
    ''' <param name="pHeight"></param>
    ''' <returns></returns>
    Private Function ConvertTextToImage(pMessageText As String,
                                        pFontName As String, pFontSize As Integer,
                                        pBackColor As Color,
                                        pForeColor As Color,
                                        pWidth As Integer,
                                        pHeight As Integer) As Bitmap

        Dim bmp As New Bitmap(pWidth, pHeight)

        Using graphics As Graphics = Graphics.FromImage(bmp)
            Dim font As New Font(pFontName, pFontSize)
            graphics.FillRectangle(New SolidBrush(pBackColor), 0, 0, bmp.Width, bmp.Height)
            graphics.DrawString(pMessageText, font, New SolidBrush(pForeColor), 0, 0)
            graphics.Flush()
            font.Dispose()
            graphics.Dispose()
        End Using

        Return bmp

    End Function

    Public Function GetTempFileName(ByVal extension As String) As String
        Dim fileName As String = Nothing
        Dim attempt As Integer = 0
        While True
            fileName = Path.GetRandomFileName()
            fileName = Path.ChangeExtension(fileName, extension)
            fileName = Path.Combine(Path.GetTempPath(), fileName)
            Try
                Using New FileStream(fileName, FileMode.CreateNew)
                End Using
                Return fileName
            Catch ex As IOException
                If System.Threading.Interlocked.Increment(attempt) = 10 Then Throw New IOException("No unique temporary file name is available.", ex)
            End Try
        End While
        Return Nothing
    End Function

    Public Function AsMonthEndDate(dDate As DateTime) As Date
        Dim firstDayOfMonth As New DateTime(dDate.Year, dDate.Month, 1)
        Return firstDayOfMonth.AddMonths(1).AddDays(-1)
    End Function

    Public Function UserIsASuperAdmin()
        If GlobalVariables.UserName IsNot Nothing Then
            If GlobalVariables.UserName.ToLower() = $"arnel" Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function UserIsADeveloper()
        If GlobalVariables.UserName.ToLower() = $"arnel" Then
            Return True
        End If
        Return False
    End Function

    Public Function GetPrinterPaperSources()
        Dim paperSources As New Collection
        Dim printDoc As New PrintDocument
        Dim pkSource As Drawing.Printing.PaperSource
        For i = 0 To printDoc.PrinterSettings.PaperSources.Count - 1
            pkSource = printDoc.PrinterSettings.PaperSources.Item(i)
            paperSources.Add(pkSource)
        Next
        Return paperSources
    End Function

    Public Function GetInstalledPrinters() As ArrayList
        Dim installedPrinters As New ArrayList
        For Each Printer In PrinterSettings.InstalledPrinters
            installedPrinters.Add(Printer)
        Next
        Return installedPrinters
    End Function

    Public Function GetNetworkPrinters() As PrintQueueCollection
        Dim server = New PrintServer()
        'Console.WriteLine("Listing Shared Printers")

        Dim queues = server.GetPrintQueues() '; {EnumeratedPrintQueueTypes. , EnumeratedPrintQueueTypes.Connections})

        'For Each item In queues
        '    Console.WriteLine(item.FullName)
        'Next

        'Console.WriteLine(vbLf & "Listing Local Printers Now")
        'queues = server.GetPrintQueues({EnumeratedPrintQueueTypes.Shared})

        'For Each item In queues
        '    Console.WriteLine(item.FullName)
        'Next

        Return queues
        'Console.ReadLine()
    End Function

    'Public Function AsGMonthEndDate(dDate As DateTime) As Date
    '    ' return the gregorian month end date
    '    Dim gregorianDate As Date = dDate
    '    Dim firstDayOfMonth As New DateTime(dDate.Year, dDate.Month, 1)
    '    Return firstDayOfMonth.AddMonths(1).AddDays(-1)
    'End Function

    Public Function GetPrinterPageInfo(ByVal printerName As String) As PageSettings
        Dim settings As PrinterSettings

        'If Not String.IsNullOrEmpty(printerName) Then

        '    For Each printer In PrinterSettings.InstalledPrinters
        '        settings = New PrinterSettings()
        '        settings.PrinterName = printer.ToString()
        '        If settings.IsDefaultPrinter Then Return settings.DefaultPageSettings
        '    Next

        '    Return Nothing
        'End If

        settings = New PrinterSettings()
        settings.PrinterName = printerName
        Return settings.DefaultPageSettings

    End Function

    Public Function IsPrinterValid(pPrinterName As String) As Boolean
        Dim data = GetPrinterPageInfo(pPrinterName)
        If data.PrinterSettings.IsValid() Then
            Return True
        End If
        Return False
    End Function

    'Public Function GetPrinterPageInfo(ByVal printerName As String) As PageSettings
    '    Dim settings As PrinterSettings

    '    If Not String.IsNullOrEmpty(printerName) Then

    '        For Each printer In PrinterSettings.InstalledPrinters
    '            settings = New PrinterSettings()
    '            settings.PrinterName = printer.ToString()
    '            If settings.IsDefaultPrinter Then Return settings.DefaultPageSettings
    '        Next

    '        Return Nothing
    '    End If

    '    settings = New PrinterSettings()
    '    settings.PrinterName = printerName
    '    Return settings.DefaultPageSettings

    'End Function

    Public Sub ProcessQrCode(cQrCodeText As String, ByRef gTin As String, ByRef batchNo As String, ByRef expiry As String, ByRef serializationNo As String, ByRef manufacture As String)
        Dim dataLength = Len(cQrCodeText)
        Dim i As Int16 = 0
        Dim ai As String = Mid(cQrCodeText, 1, 2)
        Dim lastPosition As Int16 = 2
        gTin = Nothing
        serializationNo = Nothing
        batchNo = Nothing
        expiry = Nothing
        manufacture = Nothing
        While lastPosition < dataLength
            Select Case ai
                Case "01" 'GTin
                    gTin = Mid(cQrCodeText, lastPosition + 1, 14)
                    lastPosition += 14
                Case "17" 'Expiry Date
                    expiry = Mid(cQrCodeText, lastPosition + 1, 6)
                    If expiry.Right(2) = "00" Then
                        expiry = Mid(expiry, 1, 4) + "01"
                    End If
                    lastPosition += 6
                Case "11" 'manufacture date
                    manufacture = Mid(cQrCodeText, lastPosition + 1, 6)
                    lastPosition += 6
                Case "10" ' Batch Number
                    For i = lastPosition + 1 To dataLength
                        If Mid(cQrCodeText, i, 4) = "<GS>" Or Mid(cQrCodeText, i, 1) = ChrW(13) Or i >= dataLength Then ' separator
                            If i >= dataLength Then
                                batchNo = Mid(cQrCodeText, lastPosition + 1)
                            Else
                                batchNo = Mid(cQrCodeText, lastPosition + 1, i - lastPosition - 1)
                            End If
                            lastPosition = i + 3
                            Exit For
                        End If
                    Next
                    'MessageBox.Show("Batch No = " + batchNo)
                Case "21" ' Serialization No.
                    For i = lastPosition + 1 To dataLength
                        If Mid(cQrCodeText, i, 4) = "<GS>" Or Mid(cQrCodeText, i, 1) = ChrW(13) Or i >= dataLength Then
                            If i >= dataLength Then
                                serializationNo = Mid(cQrCodeText, lastPosition + 1)
                            Else
                                serializationNo = Mid(cQrCodeText, lastPosition + 1, i - lastPosition - 1)
                            End If
                            lastPosition = i + 3
                            Exit For
                        End If
                    Next
                    'MessageBox.Show("Serialization No = " + serializationNo)
            End Select
            If lastPosition >= dataLength Then
                Exit While
            Else
                ai = Mid(cQrCodeText, lastPosition + 1, 2)
                If ai = vbLf Or ai = vbCrLf Or ai = vbLf & vbCr Then
                    Exit While
                End If
                lastPosition += 2
            End If
        End While
    End Sub

    ''' <summary>
    '''     handles null or blank values for string type
    ''' </summary>
    ''' <param name="argObj">string value to handle</param>
    ''' <returns>returns string</returns>
    Public Function NoDbNull(argObj As Object) As Object
        If argObj Is Nothing OrElse argObj.Equals(DBNull.Value) Then
            Return Nothing
        End If
        Return argObj
    End Function

    Public Function DateIsBetween(dateToCheck As Object, begDate As Object, endDate As Object)
        If Not (TypeOf dateToCheck Is Date Or TypeOf dateToCheck Is Date?) And (TypeOf begDate Is Date Or TypeOf begDate Is Date?) And (TypeOf endDate Is Date Or TypeOf endDate Is Date?) Then
            MessageBox.Show("One of the passed date is not a valid date type.")
            Debugger.Break()
            Return False
        End If
        If TypeOf dateToCheck Is Date And TypeOf begDate Is Date And TypeOf endDate Is Date Then
            Dim dC As Date = dateToCheck
            Dim dB As Date = begDate
            Dim dE As Date = endDate
            If dC.ToString("yyyyMMdd") >= dB.ToString("yyyyMMdd") And dC.ToString("yyyyMMdd") <= dE.ToString("yyyyMMdd") Then
                Return True
            Else
                Return False
            End If
        ElseIf TypeOf dateToCheck Is Date? And TypeOf begDate Is Date? And TypeOf endDate Is Date? Then
            If dateToCheck Is Nothing And begDate Is Nothing And endDate Is Nothing Then
                Return True
            End If
            If dateToCheck Is Nothing Then
                If begDate IsNot Nothing And endDate IsNot Nothing Then
                    Return False
                Else
                    Return True
                End If
            Else
                If begDate Is Nothing Or endDate Is Nothing Then
                    Return True
                Else
                    Dim dDateToCheck As Date = dateToCheck
                    Dim dEndDate As Date = endDate
                    Dim dBegDate As Date = begDate
                    If dDateToCheck.ToString("yyyyMMdd") >= dBegDate.ToString("yyyyMMdd") And dDateToCheck.ToString("yyyyMMdd") <= dEndDate.ToString("yyyyMMdd") Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        End If
        Return False
    End Function

    Public Function CreateDynamicObj(fieldsList As String, values As Object)
        Dim fields = fieldsList.Split(",")
        Dim obj As New ExpandoObject
        Dim i As Int16 = 0
        For Each item In fields
            CreateDynamicField(obj, item, values(i))
            i = i + 1
        Next
        Return obj
    End Function


    Public Function CreateDynamicField(ByRef obj As ExpandoObject, ByVal propertyName As String, ByVal propertyValue As Object)
        Dim name As String = propertyName.Replace(" ", "")
        name = name.Replace("[", "")
        name = name.Replace("]", "")
        CType(obj, IDictionary(Of String, Object))(name) = propertyValue
        Return obj
    End Function

    Public Function DecimalToFraction(ByVal decimalNumber As Double, Optional den As Integer = 32) As String

        Dim fracString As String

        Dim dp As Decimal = decimalNumber Mod 1 'determine decimal portion

        Dim wn As Integer = CInt(Fix(decimalNumber)) 'determine whole number portion

        Dim num As Integer = CInt(Math.Floor(dp * den + 0.5)) 'determine numerator

        If num = 0 Then 'decimal rounds down to next whole number

            fracString = wn.ToString

        ElseIf num = den Then 'decimal rounds up to next whole number

            fracString = (wn + 1).ToString

        Else 'somewhere between

            Do Until num Mod 2 = 1

                num = CInt(num / 2)

                den = CInt(den / 2)

            Loop

            If wn > 0 Then

                fracString = wn.ToString & " " & num.ToString & "/" & den.ToString

            Else

                fracString = num.ToString & "/" & den.ToString

            End If

        End If

        Return fracString 'return string

    End Function

    Function Num2Fraction(dblSource As Decimal) As Fraction
        Dim lp As Long
        Dim strNumber As String
        Dim strDecimals As String
        Dim lngN As Double
        Dim lngD As Double

        ' Slight rework of JohnYingling's example to get
        ' numerator and denominator as numerics rather than
        ' string
        strNumber = CStr(dblSource)
        strDecimals = Right(strNumber, Len(strNumber) - InStr(strNumber, "."))
        If Len(strDecimals) > 0 Then
            lngN = CLng(strDecimals)
            lngD = 10 ^ (Len(strDecimals))
        End If

        ' Given a numerator and denominator, reduce to
        ' lowest terms by checking for common factors, stating with the highest
        For lp = lngN To 2 Step -1 ' No need to check 1
            If lngN Mod lp = 0 Then
                If lngD Mod lp = 0 Then
                    lngN = lngN / lp
                    lngD = lngD / lp
                    lp = lngN ' reduce search space
                End If
            End If
        Next
        Return New Fraction(lngN, lngD)
    End Function


    ''' <summary>
    ''' Return a fraction string from a double.
    ''' </summary>
    ''' <param name="d">The double to convert.</param>
    ''' <returns>The converted string.</returns>
    ''' <remarks>Code written by Troy Lundin on May 3, 2007</remarks>
    Function GetFraction(ByVal d As Double) As String
        ' Get the initial denominator: 1 * (10 ^ decimal portion length)
        Dim tb1 = d.ToString()
        Dim Denom As Int32 = CInt(1 * (10 ^ tb1.Split("."c)(1).Length))

        ' Get the initial numerator: integer portion of the number
        Dim Numer As Int32 = CInt(tb1.Split("."c)(1))

        ' Use the Euclidean algorithm to find the gcd
        Dim a As Int32 = Numer
        Dim b As Int32 = Denom
        Dim t As Int32 = 0 ' t is a value holder

        ' Euclidean algorithm
        While b <> 0
            t = b
            b = a Mod b
            a = t
        End While

        ' Return our answer
        Return CInt(d) & " " & (Numer / a) & "/" & (Denom / a)
    End Function

    Public Function GetDecimalToFraction(ByVal dNumber As Double, ByVal iDenominator As Integer, sMethod As String) As String
        Dim dRes As Double
        Dim dPrec As Double
        Dim iIn As Long, iParts As Integer
        dPrec = 1 / iDenominator        'decimal precision
        dRes = 0 : iIn = 0 : iParts = 0
        dRes = Round(dNumber, dPrec, sMethod)
        iIn = Int(dRes)
        iParts = CInt((dRes - iIn) * iDenominator)
        If iParts = iDenominator Then
            GetDecimalToFraction = CStr(iIn + 1)
        ElseIf iParts > 0 Then
            Do While (iParts Mod 2) = 0 And (iDenominator Mod 2) = 0
                iParts = iParts / 2
                iDenominator = iDenominator / 2
            Loop
            If iIn > 0 Then
                GetDecimalToFraction = CStr(iIn) & " " & CStr(iParts) & "/" & CStr(iDenominator)
            Else
                GetDecimalToFraction = CStr(iParts) & "/" & CStr(iDenominator)
            End If
        Else    'parts=0
            GetDecimalToFraction = CStr(iIn)
        End If
    End Function

    Public Function Round(dNumber As Double, dIncrement As Double, sMethod As String) As Double
        If sMethod Like "U" Then
            Round = CLng((dNumber + dIncrement / 2) / dIncrement) * dIncrement
        ElseIf sMethod Like "D" Then
            Round = CLng((dNumber - dIncrement / 2) / dIncrement) * dIncrement
        Else    'assume nearest
            Round = CLng(dNumber / dIncrement) * dIncrement
        End If
    End Function

    Public Function RealToFraction(ByVal value As Double, Optional ByVal accuracy As Double = 0.01) As String
        If accuracy <= 0.0 OrElse accuracy >= 1.0 Then
            Throw New ArgumentOutOfRangeException("accuracy", "Must be > 0 and < 1.")
        End If

        Dim sign As Integer = Math.Sign(value)

        If sign = -1 Then
            value = Math.Abs(value)
        End If
        Dim fraction As Fraction
        Dim maxError As Double = If(sign = 0, accuracy, value * accuracy)
        Dim n As Integer = CInt(Math.Floor(value))
        value -= n

        If value < maxError Then
            fraction = New Fraction(sign * n, 1)
            Return FractionToString(fraction)
        End If

        If 1 - maxError < value Then
            fraction = New Fraction(sign * (n + 1), 1)
            Return FractionToString(fraction)
        End If

        Dim lower_n As Integer = 0
        Dim lower_d As Integer = 1
        Dim upper_n As Integer = 1
        Dim upper_d As Integer = 1

        While True
            Dim middle_n As Integer = lower_n + upper_n
            Dim middle_d As Integer = lower_d + upper_d

            If middle_d * (value + maxError) < middle_n Then
                upper_n = middle_n
                upper_d = middle_d
            ElseIf middle_n < (value - maxError) * middle_d Then
                lower_n = middle_n
                lower_d = middle_d
            Else
                fraction = New Fraction((n * middle_d + middle_n) * sign, middle_d)
                Return FractionToString(fraction)
            End If
        End While
    End Function

    Public Function Real2Fraction(ByVal value As Double, Optional ByVal accuracy As Double = 0.01) As Fraction
        If accuracy <= 0.0 OrElse accuracy >= 1.0 Then
            Throw New ArgumentOutOfRangeException("accuracy", "Must be > 0 and < 1.")
        End If

        Dim sign As Integer = Math.Sign(value)

        If sign = -1 Then
            value = Math.Abs(value)
        End If
        Dim fraction As Fraction
        Dim maxError As Double = If(sign = 0, accuracy, value * accuracy)
        Dim n As Integer = CInt(Math.Floor(value))
        value -= n

        If value < maxError Then
            fraction = New Fraction(sign * n, 1)
            Return fraction
        End If

        If 1 - maxError < value Then
            fraction = New Fraction(sign * (n + 1), 1)
            Return fraction
        End If

        Dim lower_n As Integer = 0
        Dim lower_d As Integer = 1
        Dim upper_n As Integer = 1
        Dim upper_d As Integer = 1

        While True
            Dim middle_n As Integer = lower_n + upper_n
            Dim middle_d As Integer = lower_d + upper_d

            If middle_d * (value + maxError) < middle_n Then
                upper_n = middle_n
                upper_d = middle_d
            ElseIf middle_n < (value - maxError) * middle_d Then
                lower_n = middle_n
                lower_d = middle_d
            Else
                fraction = New Fraction((n * middle_d + middle_n) * sign, middle_d)
                Return fraction
            End If
        End While
    End Function

    Public Structure Fraction
        Public Sub New(ByVal nP As Integer, ByVal dP As Integer)
            N = nP
            D = dP
        End Sub

        Public Property N As Integer
        Public Property D As Integer
    End Structure

    Public Function FractionToString(fraction As Fraction) As String
        Dim fractionString As String = ""
        If fraction.N = 0 Then
            Return ""
        Else

        End If
        Return fraction.N.ToString() + "/" + fraction.D.ToString()
    End Function


    ''' <summary>
    ''' Convert stored number to words using selected currency
    ''' </summary>
    ''' <returns></returns>
    Public Function NumberToWordEnglish(number As Decimal, Optional money As Boolean = True) As String
        Dim tempNumber As [Decimal] = number
        Dim retVal As String = ""
        If tempNumber = 0 Then
            Return "Zero"
        End If
        Dim _decimalValue As Int64
        Dim _integerValue As Int64
        Dim splits As [String]() = number.ToString().Split("."c)
        _integerValue = Convert.ToInt64(splits(0))
        If splits.Length > 1 Then
            _decimalValue = Convert.ToInt64(splits(1))
        End If
        retVal = ConvertWholeNumberToWord(_integerValue)
        If _decimalValue > 0 Then
            Dim fraction As Fraction = Real2Fraction(number - _integerValue)
            retVal = IIf(retVal = "", "", retVal + " and ") + ConvertWholeNumberToWord(fraction.N) + "- " + ConvertWholeNumberToWord(fraction.D, True)
        End If
        Return retVal
    End Function


#Region "English Number To Word"

#Region "Variables"

    Private _englishOnes As String() = New String() {"Zero", "One", "Two", "Three", "Four", "Five",
     "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
     "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
     "Eighteen", "Nineteen"}


    Private _englishFractionOnes As String() = New String() {"", "one", "half", "third", "fourth", "fifth",
     "sixth", "seventh", "eighth", "ninth", "tenth", "eleventh",
     "twelfth", "thirteenth", "Fourteenth", "Fifteenth", "Sixteenth", "Seventeenth",
     "eighteenth", "nineteenth"}

    Private _englishTens As String() = New String() {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
     "Eighty", "Ninety"}


    Private _englishFractionTens As String() = New String() {"twentieth", "thirtieth", "Fortieth", "Fiftieth", "Sixtieth", "Seventieth",
     "Eightieth", "Ninetieth"}

    Private _englishGroup As String() = New String() {"Hundred", "Thousand", "Million", "Billion", "Trillion", "Quadrillion",
     "Quintillion", "Sextillian", "Septillion", "Octillion", "Nonillion", "Decillion",
     "Undecillion", "Duodecillion", "Tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion",
     "Septendecillion", "Octodecillion", "Novemdecillion", "Vigintillion", "Unvigintillion", "Duovigintillion",
     "10^72", "10^75", "10^78", "10^81", "10^84", "10^87",
     "Vigintinonillion", "10^93", "10^96", "Duotrigintillion", "Trestrigintillion"}

    Private _englishFractionGroup As String() = New String() {"Hundredth", "Thousandth", "Millionth", "Billionth", "Trillionth", "Quadrillionth",
     "Quintillionth", "Sextillianth", "Septillionth", "Octillionth", "Nonillionth", "Decillionth",
     "Undecillionth", "Duodecillionth", "Tredecillionth", "Quattuordecillionth", "Quindecillionth", "Sexdecillionth",
     "Septendecillionth", "Octodecillionth", "Novemdecillionth", "Vigintillionth", "Unvigintillionth", "Duovigintillionth",
     "10^72", "10^75th", "10^78th", "10^81th", "10^84th", "10^87th",
     "Vigintinonillionth", "10^93th", "10^96th", "Duotrigintillionth", "Trestrigintillionth"}

#End Region

    ''' <summary>
    ''' Process a group of 3 digits
    ''' </summary>
    ''' <param name="groupNumber">The group number to process</param>
    ''' <returns></returns>
    Private Function ProcessGroup(ByVal groupNumber As Integer, Optional ByVal fractonalPart As Boolean = False) As String
        Dim tens As Integer = groupNumber Mod 100

        Dim hundreds As Integer = groupNumber \ 100

        Dim retVal As String = [String].Empty

        If hundreds > 0 Then
            retVal = [String].Format("{0} {1}", IIf(fractonalPart, _englishFractionOnes(hundreds), _englishOnes(hundreds)), IIf(fractonalPart, _englishFractionGroup(0), _englishGroup(0)))
        End If
        If tens > 0 Then
            If tens < 20 Then
                retVal += (If((retVal <> [String].Empty), " ", [String].Empty)) & IIf(fractonalPart, _englishFractionOnes(tens), _englishOnes(tens))
            Else
                Dim ones As Integer = tens Mod 10

                tens = (tens \ 10) - 2
                ' 20's offset
                retVal += (If((retVal <> [String].Empty), " ", [String].Empty)) & IIf(fractonalPart, _englishFractionTens(tens), _englishTens(tens))

                If ones > 0 Then
                    retVal += (If((retVal <> [String].Empty), " ", [String].Empty)) & IIf(fractonalPart, _englishFractionOnes(ones), _englishOnes(ones))
                End If
            End If
        End If

        Return retVal
    End Function


    Public Function ConvertWholeNumberToWord(ByRef wholeNumber As Int64, Optional fractionalPart As Boolean = False) As String
        Dim retVal As String = [String].Empty
        Dim group As Integer = 0
        Dim tempNumber As Int64 = wholeNumber
        If wholeNumber < 1 Then
            retVal = IIf(fractionalPart, _englishOnes(0), _englishFractionOnes(0))
        Else
            While tempNumber >= 1
                Dim numberToProcess As Integer = CInt(Math.Truncate(tempNumber Mod 1000))

                tempNumber = tempNumber / 1000

                Dim groupDescription As String = ProcessGroup(numberToProcess, fractionalPart)

                If groupDescription <> [String].Empty Then
                    If group > 0 Then
                        retVal = [String].Format("{0} {1}", IIf(fractionalPart, _englishGroup(group), _englishFractionGroup), retVal)
                    End If

                    retVal = [String].Format("{0} {1}", groupDescription, retVal)
                End If

                group += 1
            End While
        End If
        Return retVal
    End Function

    Private _arabicOnes As String() = New String() {[String].Empty, "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة",
     "ستة", "سبعة", "ثمانية", "تسعة", "عشرة", "أحد عشر",
     "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر",
     "ثمانية عشر", "تسعة عشر"}

    Private _arabicFeminineOnes As String() = New String() {[String].Empty, "إحدى", "اثنتان", "ثلاث", "أربع", "خمس",
     "ست", "سبع", "ثمان", "تسع", "عشر", "إحدى عشرة",
     "اثنتا عشرة", "ثلاث عشرة", "أربع عشرة", "خمس عشرة", "ست عشرة", "سبع عشرة",
     "ثماني عشرة", "تسع عشرة"}

    Private _arabicTens As String() = New String() {"عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون",
     "ثمانون", "تسعون"}

    Private _arabicHundreds As String() = New String() {"", "مائة", "مئتان", "ثلاثمائة", "أربعمائة", "خمسمائة",
     "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة"}

    Private _arabicAppendedTwos As String() = New String() {"مئتا", "ألفا", "مليونا", "مليارا", "تريليونا", "كوادريليونا",
     "كوينتليونا", "سكستيليونا"}

    Private _arabicTwos As String() = New String() {"مئتان", "ألفان", "مليونان", "ملياران", "تريليونان", "كوادريليونان",
     "كوينتليونان", "سكستيليونان"}

    Private _arabicGroup As String() = New String() {"مائة", "ألف", "مليون", "مليار", "تريليون", "كوادريليون",
     "كوينتليون", "سكستيليون"}

    Private _arabicAppendedGroup As String() = New String() {"", "ألفاً", "مليوناً", "ملياراً", "تريليوناً", "كوادريليوناً",
     "كوينتليوناً", "سكستيليوناً"}

    Private _arabicPluralGroups As String() = New String() {"", "آلاف", "ملايين", "مليارات", "تريليونات", "كوادريليونات",
     "كوينتليونات", "سكستيليونات"}

#End Region


End Module