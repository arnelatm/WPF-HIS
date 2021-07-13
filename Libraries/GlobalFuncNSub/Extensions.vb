Imports System.ComponentModel
Imports System.Globalization
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

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
        Return number.ToString(cFormat, New Globalization.CultureInfo(GlobalVariables.AppCurrentCultureInfo.Name))
    End Function

    <Extension()>
    Public Function ToMoney(number As Single, noOfDigits As Short) As String
        Dim cFormat As String = "C" + noOfDigits.ToString()
        Return number.ToString(cFormat, New Globalization.CultureInfo(GlobalVariables.AppCurrentCultureInfo.Name))
    End Function

    <Extension()>
    Public Function ToMoney(number As Single) As String
        Return number.ToString("C", New Globalization.CultureInfo(GlobalVariables.AppCurrentCultureInfo.Name))
    End Function

    '<Extension()>
    Public Function ToMoney(number As Double) As String
        Return number.ToString("C", New Globalization.CultureInfo(GlobalVariables.AppCurrentCultureInfo.Name))
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

    <Extension()>
    Public Function SplitCamelCase(ByVal inputString As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(inputString, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
        'Return Regex.Replace(Regex.Replace(str, "(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), "(\p{Ll})(\P{Ll})", "$1 $2")
    End Function

    'Public Function SplitCamelCase(ByVal input As String) As String
    '    'Return System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
    'End Function

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

    <Extension()>
    Public Function GetAttribute(Of T As Structure)(ByVal enumerationValue As Object) As String
        Dim type As Type = enumerationValue.[GetType]()
        If Not type.IsEnum Then Throw New ArgumentException("EnumerationValue must be of Enum type", "enumerationValue")
        Dim memberInfo As MemberInfo() = type.GetMember(enumerationValue.ToString())

        If memberInfo IsNot Nothing AndAlso memberInfo.Length > 0 Then
            Dim attrs As Object() = memberInfo(0).GetCustomAttributes(GetType(DescriptionAttribute), False)

            If attrs IsNot Nothing AndAlso attrs.Length > 0 Then
                Return (CType(attrs(0), DescriptionAttribute)).Description
            End If
        End If

        Return enumerationValue.ToString()
    End Function

    <Extension()>
    Function GetAttributeOfType(Of T As System.Attribute)(ByVal enumVal As [Enum]) As T
        Dim type = enumVal.[GetType]()
        Dim memInfo = type.GetMember(enumVal.ToString())
        Dim attributes = memInfo(0).GetCustomAttributes(GetType(T), False)
        Return If((attributes.Length > 0), CType(attributes(0), T), Nothing)
    End Function

    <Extension()>
    Sub UiThread(ByVal this As Control, ByVal code As Action)
        If this.InvokeRequired Then
            this.BeginInvoke(code)
        Else
            code.Invoke()
        End If
    End Sub

    <DllImport("user32.dll")>
    Private Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Boolean, ByVal lParam As IntPtr) As Integer
    End Function

    Private Const WmSetRedraw As Integer = 11

    ' Extension methods for Control
    <Extension()>
    Public Sub ResumeDrawing(ByVal target As Control, ByVal redraw As Boolean)
        If target IsNot Nothing Then
            SendMessage(target.Handle, WmSetRedraw, True, 0)
            If redraw Then
                target.Refresh()
            End If
        End If
    End Sub

    <Extension()>
    Public Sub SuspendDrawing(ByVal target As Control)
        If target IsNot Nothing Then
            SendMessage(target.Handle, WmSetRedraw, False, 0)
        End If
    End Sub

    <Extension()>
    Public Sub ResumeDrawing(target As Control)
        If target IsNot Nothing Then
            target.ResumeDrawing(True)
        End If
    End Sub

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