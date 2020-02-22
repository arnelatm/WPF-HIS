
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICkdOiItemView
        Inherits IView

        Property AccountIdNo As Integer
        Property Amount As Decimal
        Property Balance As Decimal
        Property CkdIdNo As Integer
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
End NameSpace