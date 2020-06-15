Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IPurchaseJournalView
        Inherits IView

        Property AccountIdNo As Int32?
        Property Amount As Decimal
        Property Cancelled As Boolean
        Property DateCreated As DateTime?
        Property DueDate As Date?
        Property IdNo As Int32
        Property InvoiceDate As Date?
        Property InvoiceNo As String
        Property Notes As String
        Property ReferenceNo As String
        Property SettlementDiscount As Decimal
        Property SettlementDueDate As Date?
        Property SupplierIdNo As Int32
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property VatAmount As Decimal
        Property VatNumber As String
        Property Posted As Boolean

    End Interface

End Namespace