' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class SalesCashItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property ActualBankCharge As Decimal
        Public Property ActualBankChargeVat As Decimal
        Public Property BankChargeDifference As Decimal
        Public Property BankChargeVatDifference As Decimal
        Public Property DepositAmount As Decimal
        Public Property CashCode As String
        Public Property ComputedBankCharge As Decimal
        Public Property ComputedBankChargeVat As Decimal
        Public Property IdNo As Int32
        Public Property Rate As Decimal
        Public Property SaleAmount As Decimal
        Public Property SalesJournalIdNo As Int32
        Public Property Sequence As Integer

    End Class

End Namespace