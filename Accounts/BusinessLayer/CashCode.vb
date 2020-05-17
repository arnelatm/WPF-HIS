' CashCode business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class CashCode
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AccountIdNo As Int32?

        Public Property BankChargesAccountIdNo As Int32?
        Public Property BankChargesVatAccountIdNo As Int32?
        Public Property CashCode As String
        Public Property CashName As String
        Public Property CashNameAra As String
        Public Property IdNo As Int32
        Public Property Rate As Decimal

    End Class

End Namespace