Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ISalesCashItemView
        Inherits IView

        Property ActualBankCharge As Decimal
        Property ActualBankChargeVat As Decimal
        Property BankChargeDifference As Decimal
        Property BankChargeVatDifference As Decimal
        Property DepositAmount As Decimal
        Property CashCode As String
        Property ComputedBankCharge As Decimal
        Property ComputedBankChargeVat As Decimal
        Property IdNo As Integer
        Property Rate As Decimal
        Property SaleAmount As Decimal
        Property SalesJournalIdNo As Integer
        Property Sequence As Integer

    End Interface

End Namespace