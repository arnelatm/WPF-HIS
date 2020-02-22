Imports System.Runtime.CompilerServices

Public Module Extensions
    ' Declarations will typically be in a separate module.

    <Extension>
    Public Function Right(stringValue As String, noOfCharacters As Integer)
        Dim strLength = stringValue.Length
        Return stringValue.Substring(strLength - noOfCharacters)
    End Function

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
End Module