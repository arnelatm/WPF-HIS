' CashCode business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class CashCode
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AccountIdNo As Integer

        Public Property BankChargesAccountIdNo As Integer
        Public Property BankChargesVatAccountIdNo As Integer
        Public Property CashCode As String
        Public Property CashName As String
        Public Property CashNameAra As String
        Public Property IdNo As Integer
        Public Property Rate As Decimal

    End Class
End NameSpace