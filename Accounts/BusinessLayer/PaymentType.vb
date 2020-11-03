' PaymentType business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class PaymentType
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AccountIdNo As Int16?

        Public Property BankChargesAccountIdNo As Int16?
        Public Property BankChargesVatAccountIdNo As Int16?
        Public Property PaymentTypeCode As String
        Public Property PaymentTypeName As String
        Public Property PaymentTypeNameAra As String
        Public Property IdNo As Int16
        Public Property Rate As Decimal

    End Class

End Namespace