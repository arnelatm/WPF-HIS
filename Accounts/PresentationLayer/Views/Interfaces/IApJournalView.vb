Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IApJournalView
        Inherits IView

        Property AccountIdNo As Int16?
        Property Amount As Decimal
        Property Cancelled As Boolean
        Property DateCreated As DateTime?
        Property DueDate As Date?
        Property IdNo As Int32
        Property InvoiceDate As Date?
        Property InvoiceNo As String
        Property Notes As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property SettlementDiscount As Decimal
        Property SettlementDueDate As Date?
        Property SupplierIdNo As Int32?
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property TransactionType As String
        Property VatAmount As Decimal
        Property VatNumber As String
        Property JournalItems As List(Of IJournalItemView)

    End Interface

End Namespace