''' <summary>
''' A class to represent the result of a validation operation,
''' used for returning success or failure with a message.
''' </summary>
Public Class ValidationResult
    Public Property IsValid As Boolean
    Public Property ErrorMessage As String

    Public Shared Function Success() As ValidationResult
        Return New ValidationResult() With {.IsValid = True}
    End Function

    Public Shared Function Fail(message As String) As ValidationResult
        Return New ValidationResult() With {.IsValid = False, .ErrorMessage = message}
    End Function
End Class
