Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ISalesJournalView
        Inherits IView

        Property AccountIdNo As Integer
        Property Cancelled As Boolean
        Property IdNo As Integer
        Property Notes As String
        Property ReferenceNo As String
        Property TotalBankCharges As Decimal
        Property TotalBankChargesVat As Decimal
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        Property TotalSales As Decimal
        Property TransactionDate As Date?
        Property TotalDeposits As Decimal
        ReadOnly Property DateCreated As DateTime?
        ReadOnly Property Posted As Boolean
    End Interface
End NameSpace