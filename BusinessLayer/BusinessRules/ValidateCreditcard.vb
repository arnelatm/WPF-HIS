Namespace BusinessRules
    'Namespace BusinessObjects.BusinessRules

    ' credit card validation rule.
    ' match a credit card number to be entered as four sets of four digits separated
    ' by a space, -, or no character at all

    Public Class ValidateCreditcard
        Inherits ValidateRegex

        Public Sub New(propertyName As String)
            MyBase.New(propertyName, "^((\d{4}[- ]?){3}\d{4})$")
            [Error] = propertyName & " is not a valid credit card number"
        End Sub

        Public Sub New(propertyName As String, errorMessage As String)
            Me.New(propertyName)
            [Error] = errorMessage
        End Sub

    End Class

End Namespace