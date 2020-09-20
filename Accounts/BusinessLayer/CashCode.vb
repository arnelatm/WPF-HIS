' CashCode business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class CashCode
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AccountIdNo As Int16?

        Public Property BankChargesAccountIdNo As Int16?
        Public Property BankChargesVatAccountIdNo As Int16?
        Public Property CashCode As Char
        Public Property CashName As String
        Public Property CashNameAra As String
        Public Property IdNo As Int16
        Public Property Rate As Decimal

    End Class

End Namespace