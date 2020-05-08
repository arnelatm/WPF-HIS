Imports System.Globalization
Imports System.Linq.Expressions
Imports System.Runtime.CompilerServices

Public Module Extensions
    ' Declarations will typically be in a separate module.

    <Extension>
    Public Function Right(stringValue As String, noOfCharacters As Integer)
        Dim strLength = stringValue.Length
        Return stringValue.Substring(strLength - noOfCharacters)
    End Function

    <Extension()>
    Public Function Interpolate(ByVal template As String, ParamArray values As Expression(Of Func(Of Object, String))()) As String
        Dim result As String = template
        values.ToList().ForEach(Sub(x)
                                    Dim member As MemberExpression = TryCast(x.Body, MemberExpression)
                                    Dim oldValue As String = String.Format("{0}{1}{2}", "{", If(Left(member.Member.Name, 10) = "$VB$Local_", Mid(member.Member.Name, 11), member.Member.Name), "}")
                                    Dim newValue As String = x.Compile().Invoke(Nothing).ToString()
                                    result = Replace(result, oldValue, newValue, 1, -1, CompareMethod.Text)
                                End Sub)
        Return result
    End Function

    <Extension()>
    Public Function ReplaceValues(ByVal template As String, variables As String()) As String
        Dim result As String = template
        Dim oldValue As String
        Dim newValue As String
        For i = 0 To variables.Count - 1 Step 2
            oldValue = "{" & variables(i) & "}"
            newValue = variables(i + 1)
            result = Replace(result, oldValue, newValue, 1, -1, CompareMethod.Text)
        Next
        Return result
    End Function

    <Extension()>
    Public Function TrimMilliseconds(ByVal dt As DateTime) As DateTime
        Return New Date(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0, dt.Kind)
    End Function

    <Extension()>
    Public Function ToMoney(number As Decimal, noOfDigits As Short) As String
        Dim cFormat As String = "C" + noOfDigits.ToString()
        Return number.ToString(cFormat, New Globalization.CultureInfo(GlobalVariables.AppCurrentCultureInfo.Name)).Remove(0, 1)
    End Function

    <Extension()>
    Public Function ToMoney(number As Single, noOfDigits As Short) As String
        Dim cFormat As String = "C" + noOfDigits.ToString()
        Return number.ToString(cFormat, New Globalization.CultureInfo(GlobalVariables.AppCurrentCultureInfo.Name)).Remove(0, 1)
    End Function

    <Extension()>
    Public Function ToMoney(number As Single) As String
        Return number.ToString("C", New Globalization.CultureInfo(GlobalVariables.AppCurrentCultureInfo.Name)).Remove(0, 1)
    End Function

    <Extension()>
    Public Function ToMoney(number As Double) As String
        Return number.ToString("C", New Globalization.CultureInfo(GlobalVariables.AppCurrentCultureInfo.Name)).Remove(0, 1)
    End Function

    <Extension()>
    Public Function ToInt16Number(numberString As String) As Short
        If numberString IsNot Nothing AndAlso numberString.Trim() <> "" Then
            Return Convert.ToInt16(NumParser(Of Int16)(numberString))
        Else
            Return 0S
        End If
    End Function

    <Extension()>
    Public Function ToInt32Number(numberString As String) As Integer
        If numberString IsNot Nothing AndAlso numberString.Trim() <> "" Then
            Return Convert.ToInt32(NumParser(Of Int32)(numberString))
        Else
            Return 0I
        End If
    End Function

    <Extension()>
    Public Function ToInt64Number(numberString As String) As Long
        If numberString IsNot Nothing AndAlso numberString.Trim() <> "" Then
            Return Convert.ToInt64(NumParser(Of Int64)(numberString))
        Else
            Return 0L
        End If
    End Function

    <Extension()>
    Public Function ToByteNumber(numberString As String) As Byte
        If numberString IsNot Nothing AndAlso numberString.Trim() <> "" Then
            Return Convert.ToByte(NumParser(Of Byte)(numberString))
        Else
            Return 0@
        End If
    End Function

    <Extension()>
    Public Function ToDecimalNumber(numberString As String, nfi As NumberFormatInfo) As Decimal
        If numberString IsNot Nothing AndAlso numberString.Trim() <> "" Then
            Return Convert.ToDecimal(NumParser(Of Decimal)(numberString), nfi)
        Else
            Return 0@
        End If
    End Function

    <Extension()>
    Public Function ToSingleNumber(numberString As String, nfi As NumberFormatInfo) As Single
        If numberString IsNot Nothing AndAlso numberString.Trim() <> "" Then
            Return Convert.ToSingle(NumParser(Of Single)(numberString), nfi)
        Else
            Return 0F
        End If
    End Function

    <Extension()>
    Public Function ToDoubleNumber(numberString As String, nfi As NumberFormatInfo) As Double
        If numberString IsNot Nothing AndAlso numberString.Trim() <> "" Then
            Return Convert.ToDouble(NumParser(Of Double)(numberString), nfi)
        Else
            Return 0D
        End If
    End Function

    '<Extension()>
    'Public Function IgnoreAllNonExisting(Of TSource, TDestination)(ByVal expression As IMappingExpression(Of TSource, TDestination)) As IMappingExpression(Of TSource, TDestination)
    '    Dim sourceType = GetType(TSource)
    '    Dim destinationType = GetType(TDestination)
    '    Dim allTypes = GlobalVariables.Mapper.ConfigurationProvider.GetAllTypeMaps()
    '    Dim existingMaps = allTypes.First(Function(x) (x.SourceType Is sourceType) AndAlso (x.DestinationType Is destinationType))

    '    For Each [property] In existingMaps.GetUnmappedPropertyNames()
    '        expression.ForMember([property], Sub(opt) opt.Ignore())
    '    Next

    '    Return expression
    'End Function

    '<Extension()>
    'Public Function AddBusinessDays(ByVal startDate As DateTime, ByVal days As Integer) As DateTime
    '    Dim sign As Double = Convert.ToDouble(Math.Sign(days))
    '    Dim unsignedDays As Integer = Math.Sign(days) * days

    '    For i As Integer = 0 To unsignedDays - 1

    '        Do
    '            startDate = startDate.AddDays(sign)
    '        Loop While startDate.DayOfWeek = DayOfWeek.Saturday OrElse startDate.DayOfWeek = DayOfWeek.Sunday
    '    Next

    '    Return startDate
    'End Function

End Module

'Public Function MakePlural( noun As String) As String
'    Dim pluralName As String
'    Dim lastLetter = noun.Right(1).ToLower()
'    Select Case lastLetter
'        Case "a","b","c","d","g","i","j","k","l","m","n","p","q","r","t","u","v","w"
'            pluralName = noun + "s"
'        Case "o"
'            pluralName = noun + "es"
'        Case Else

'    End Select

'    If lastTwoLetters
'        noun = noun.Substring(0,noun.Length-1) + "ie"
'        pluralname = noun + "s"
'    Elseif noun.Right(1).ToLower() = "s" Then
'        noun = noun.Substring(0,noun.Length-1) + "e"
'        pluralname = noun + "s"
'    End If
'    Return noun
'End Function