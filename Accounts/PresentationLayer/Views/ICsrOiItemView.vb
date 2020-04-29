Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICsrOiItemView
        Inherits IView

        Property AccountIdNo as Int32
        Property Amount As Decimal
        Property Balance As Decimal
        Property CsrIdNo As Int32
        Property DiscountTaken As Decimal
        Property IdNo As Int32
        Property InvoiceNo As String
        Property JournalCode As String
        Property JournalIdNo As Int32
        Property JournalItemIdNo As Int32
        Property OpenInvoiceIdNo As Int32
        Property PreviousBalance As Decimal
        Property Sequence As Integer
        Property TransactionDate As Date?

    End Interface

End Namespace