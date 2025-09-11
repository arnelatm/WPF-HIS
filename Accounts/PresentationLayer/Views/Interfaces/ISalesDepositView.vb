Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ISalesDepositView
        Inherits IView

        Property ActualBankCharge As Decimal
        Property BankChargeDifference As Decimal
        Property BankChargeVatDifference As Decimal
        Property DepositAmount As Decimal
        Property DepositTypeIdNo As Int16
        Property ComputedBankCharge As Decimal
        Property ComputedBankChargeVat As Decimal
        Property IdNo As Int32
        Property Rate As Decimal
        Property SaleAmount As Decimal
        Property SalesJournalIdNo As Int32
        Property Sequence As Int16
        Property VatAmount As Decimal

    End Interface

End Namespace