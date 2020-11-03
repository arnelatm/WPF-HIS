' PaymentType business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PaymentType
        Inherits AATM.BusinessLayer.BusinessObject

        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("PaymentTypeCode"))
                AddRule(New ValidateRequired("PaymentTypeName"))
                AddRule(New ValidateRequired("BankChargesAccountIdNo"))
                AddRule(New ValidateRequired("BankChargesVatAccountIdNo"))
            End If
        End Sub

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AccountIdNo As Int16
        Public Property BankChargesAccountIdNo As Int16
        Public Property BankChargesVatAccountIdNo As Int16
        Public Property PaymentTypeCode As String
        Public Property PaymentTypeName As String
        Public Property PaymentTypeNameAra As String
        Public Property IdNo As Int16
        Public Property Rate As Decimal

    End Class

End Namespace