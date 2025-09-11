Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ISalesJournalView
        Inherits IView

        Property AccountIdNo As Int16?
        Property Approved As Boolean
        Property Cancelled As Boolean
        Property IdNo As Int32
        Property Notes As String
        Property ReferenceNo As String
        ReadOnly Property TotalBankCharges As Decimal
        ReadOnly Property TotalBankChargesVat As Decimal
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        ReadOnly Property TotalSales As Decimal
        Property TransactionDate As Date?
        ReadOnly Property TotalDeposits As Decimal
        Property DateCreated As DateTime?
        Property Posted As Boolean
        Property SalesDeposits As List(Of SalesDepositView)
        Property JournalItems As List(Of JournalItemView)
        Property AccountsByCode
        Property DepositTypesByCode
        Property RevCostCentersByCode

    End Interface

End Namespace