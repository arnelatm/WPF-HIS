Imports System.Text.RegularExpressions

''' <summary>
''' Provides a set of reusable, globally accessible utility functions for common data validation.
''' </summary>
Public NotInheritable Class ValidationUtils
    Private Sub New()
        ' This is a private constructor to prevent instantiation.
    End Sub

    ''' <summary>
    ''' Checks if a string value is not null, empty, or whitespace.
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
        ' Use a standard regex pattern for email validation.
        Dim pattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        Dim regex As New Regex(pattern, RegexOptions.IgnoreCase)
        Return regex.IsMatch(email)
    End Function

    ''' <summary>
    ''' Checks if a string contains only numeric characters.
    ''' </summary>
    Public Shared Function IsNumeric(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Dim regex As New Regex("^[0-9]+$")
        Return regex.IsMatch(value)
    End Function

    ''' <summary>
    ''' Checks if a string has at least a specified minimum length.
    ''' </summary>
    Public Shared Function HasMinimumLength(value As String, minLength As Integer) As Boolean
        Return If(value Is Nothing, False, value.Length >= minLength)
    End Function

    ''' <summary>
    ''' Checks if a string is not longer than a specified maximum length.
    ''' </summary>
    Public Shared Function HasMaximumLength(value As String, maxLength As Integer) As Boolean
        Return If(value Is Nothing, True, value.Length <= maxLength)
    End Function

    ''' <summary>
    ''' Checks if a string contains only alphabetic characters.
    ''' </summary>
    Public Shared Function IsAlpha(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Dim regex As New Regex("^[a-zA-Z]+$")
        Return regex.IsMatch(value)
    End Function

    ''' <summary>
    ''' Checks if a string contains only alphanumeric characters (letters and numbers).
    ''' </summary>
    Public Shared Function IsAlphaNumeric(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Dim regex As New Regex("^[a-zA-Z0-9]+$")
        Return regex.IsMatch(value)
    End Function

    ''' <summary>
    ''' Checks if a string represents a positive numeric value (greater than zero).
    ''' </summary>
    Public Shared Function IsPositiveNumber(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Dim number As Double
        If Double.TryParse(value, number) Then
            Return number > 0
        End If
        Return False
    End Function

    ''' <summary>
    ''' Checks if a numeric value is within a specified range (inclusive).
    ''' </summary>
    Public Shared Function IsInRange(value As Double, minValue As Double, maxValue As Double) As Boolean
        Return value >= minValue AndAlso value <= maxValue
    End Function

    ''' <summary>
    ''' Checks if a string represents a valid date.
    ''' </summary>
    Public Shared Function IsDate(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Dim tempDate As Date
        Return Date.TryParse(value, tempDate)
    End Function

    ''' <summary>
    ''' Checks if a string represents a positive integer (whole number greater than zero).
    ''' </summary>
    Public Shared Function IsPositiveInteger(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Dim number As Integer
        If Integer.TryParse(value, number) Then
            Return number > 0
        End If
        Return False
    End Function

    ''' <summary>
    ''' Checks if a string is a valid URL.
    ''' </summary>
    Public Shared Function IsValidUrl(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Return Uri.TryCreate(value, UriKind.Absolute, Nothing)
    End Function

    ''' <summary>
    ''' A simple check for a numeric-only phone number.
    ''' This is a basic check and may not cover all international formats.
    ''' </summary>
    Public Shared Function IsPhoneNumber(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        ' Simple regex for a numeric-only string
        Return Regex.IsMatch(value, "^[0-9]+$")
    End Function

    ''' <summary>
    ''' Checks if a string contains any special characters.
    ''' </summary>
    Public Shared Function HasNoSpecialCharacters(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Dim regex As New Regex("^[a-zA-Z0-9\s]+$")
        Return regex.IsMatch(value)
    End Function

    ''' <summary>
    ''' Checks if a string represents a positive or zero numeric value.
    ''' </summary>
    Public Shared Function IsPositiveOrZero(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Dim number As Double
        If Double.TryParse(value, number) Then
            Return number >= 0
        End If
        Return False
    End Function

    ''' <summary>
    ''' Checks if a string is a valid Guid.
    ''' </summary>
    Public Shared Function IsValidGuid(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Dim tempGuid As Guid
        Return Guid.TryParse(value, tempGuid)
    End Function

    ''' <summary>
    ''' Checks if a string is a valid US postal code.
    ''' </summary>
    Public Shared Function IsValidPostalCode(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If
        Dim regex As New Regex("^\d{5}(?:[-\s]\d{4})?$")
        Return regex.IsMatch(value)
    End Function

    ''' <summary>
    ''' Checks if a date is in the future.
    ''' </summary>
    Public Shared Function IsFutureDate(value As Date) As Boolean
        Return value.Date > Date.Today.Date
    End Function
End Class

