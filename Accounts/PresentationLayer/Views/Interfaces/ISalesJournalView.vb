Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ISalesJournalView
        Inherits IView

        Property AccountIdNo As Int16?
        Property Cancelled As Boolean
        Property IdNo As Int32
        Property Notes As String
        Property ReferenceNo As String
        Property TotalBankCharges As Decimal
        Property TotalBankChargesVat As Decimal
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        Property TotalSales As Decimal
        Property TransactionDate As Date?
        Property TotalDeposits As Decimal
        Property DateCreated As DateTime?
        Property Posted As Boolean
        Property SalesCashItems As List(Of SalesCashItemView)
        Property JournalItems As List(Of JournalItemView)

    End Interface

End Namespace