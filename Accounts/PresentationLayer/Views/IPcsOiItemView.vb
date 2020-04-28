Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IPcsOiItemView
        Inherits IView

        Property AccountIdNo as Int32
        Property Amount As Decimal
        Property Balance As Decimal
        Property PcsIdNo As Integer
        Property DiscountTaken As Decimal
        Property IdNo As Integer
        Property InvoiceNo As String
        Property JournalCode As String
        Property JournalIdNo As Integer
        Property JournalItemIdNo As Integer
        Property OpenInvoiceIdNo As Integer
        Property PreviousBalance As Decimal
        Property Sequence As Integer
        Property TransactionDate As Date?

    End Interface

End Namespace