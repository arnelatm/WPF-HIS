Imports AATM.Libraries.Messaging

Namespace BusinessRules
    ' base class for regex based validation rules.

    Public Class ValidateVatNumber
        Inherits ValidateRegex

        Private Const VatPattern = "^$|[0-9]{15}"

        Public Sub New(propertyName As String)
            MyBase.New(propertyName, VatPattern)
            Pattern = VatPattern
            [Error] = MessagingService.GetMessage(True, "MsgInvalidVatNumber")
        End Sub

        Public Sub New(propertyName As String, errorMessage As String)
            Me.New(propertyName)
            [Error] = errorMessage
        End Sub

    End Class

End Namespace