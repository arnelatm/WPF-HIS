Namespace BusinessRules
    ' IP Address validation rule

    Public Class ValidateIpAddress
        Inherits ValidateRegex

        ' Match IP Address
        Public Sub New(propertyName As String)
            MyBase.New(propertyName, "^([0-2]?[0-5]?[0-5]\.){3}[0-2]?[0-5]?[0-5]$")
            [Error] = propertyName & " is not a valid IP Address"
        End Sub

        Public Sub New(propertyName As String, errorMessage As String)
            Me.New(propertyName)
            [Error] = errorMessage
        End Sub

    End Class

End Namespace