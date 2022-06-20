Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDjOiItemView
        Inherits IView

        Property AccountIdNo As Int16?
        Property Amount As Decimal
        Property ApOpenInvoiceIdNo As Int32
        Property Balance As Decimal
        Property DjIdNo As Int32
        Property DiscountTaken As Decimal
        Property IdNo As Int32
        Property InvoiceNo As String
        Property JournalCode As String
        Property JournalIdNo As Int32
        Property PreviousBalance As Decimal
        Property Sequence As Int16
        Property TransactionDate As Date?

    End Interface

End Namespace