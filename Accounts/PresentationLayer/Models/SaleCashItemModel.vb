Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class SalesCashItemModel

        Public Property ActualBankCharge As Decimal
        Public Property ActualBankChargeVat As Decimal
        Public Property BankChargeDifference As Decimal
        Public Property BankChargeVatDifference As Decimal
        Public Property DepositAmount As Decimal
        Public Property PaymentTypeIdNo As Int16
        Public Property ComputedBankCharge As Decimal
        Public Property ComputedBankChargeVat As Decimal
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Rate As Decimal
        Public Property SaleAmount As Decimal
        Public Property SalesJournalIdNo As Int32
        Public Property Sequence As Int16

    End Class

End Namespace