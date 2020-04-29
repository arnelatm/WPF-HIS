Imports AATM.Accounts.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IArJournalView
        Inherits IView

        Property AccountIdNo As Int32
        Property Amount As Decimal
        Property Cancelled As Boolean
        Property DateCreated As DateTime?
        Property DueDate As Date?
        Property IdNo As Int32
        Property InvoiceNo As String
        Property Notes As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property SettlementDiscount As Decimal
        Property SettlementDueDate As Date?
        Property CustomerIdNo As Int32
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property TransactionType As String
        Property JournalItems As List(Of JournalItemView)

    End Interface

End Namespace