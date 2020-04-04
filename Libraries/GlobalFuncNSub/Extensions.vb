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
        values.ToList().ForEach(Function(x)
                                    Dim member As MemberExpression = TryCast(x.Body, MemberExpression)
                                    Dim oldValue As String = String.Format("{0}{1}{2}", "{", If(Strings.Left(member.Member.Name, 10) = "$VB$Local_", Mid(member.Member.Name, 11), member.Member.Name), "}")
                                    Dim newValue As String = x.Compile().Invoke(Nothing).ToString()
                                    result = Replace(result, oldValue, newValue, 1, -1, CompareMethod.Text)
                                End Function)
        Return result
    End Function

    <Extension()>
    Public Function ReplaceValues(ByVal template As String, variables As String() ) As String
        Dim result As String = template
        Dim oldValue As String = ""
        Dim newValue As String = ""
        For i = 0 To variables.Count - 1 step 2
            oldValue = "{" & variables(i) & "}"
            newValue = variables(i+1)
            result =  Replace(result, oldValue, newValue, 1, -1, CompareMethod.Text)
        Next
        Return result
    End Function

End Module

'Public Function MakePlural( noun As String) As String
'    Dim pluralname As String
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