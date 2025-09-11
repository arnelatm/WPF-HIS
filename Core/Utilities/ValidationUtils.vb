' File: ValidationUtils.vb
Imports System.Text.RegularExpressions

Public NotInheritable Class ValidationUtils
    ' Prevents instantiation of the class
    Private Sub New()
    End Sub

    ''' <summary>
    ''' Checks if a string is not null or empty after trimming whitespace.
    ''' </summary>
    Public Shared Function IsNotNullOrEmpty(value As String) As Boolean
        Return Not String.IsNullOrWhiteSpace(value)
    End Function

    ''' <summary>
    ''' Validates an email address using a regular expression.
    ''' </summary>
    Public Shared Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then
            Return False
        End If

        ' Regular expression for email validation (a common pattern)
        Dim pattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        Dim regex As New Regex(pattern, RegexOptions.IgnoreCase)
        Return regex.IsMatch(email)
    End Function

    ' Add other generic validation methods here, e.g.,
    ' Public Shared Function IsNumeric(value As String) As Boolean
    ' ...
End Class
