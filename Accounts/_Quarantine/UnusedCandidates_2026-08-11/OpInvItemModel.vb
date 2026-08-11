Namespace PresentationLayer.Models

    Public Class OpInvItemModel
        Public Property AccountIdNo As Int16?
        Public Property Amount As Decimal
        Public Property OpenInvoiceIdNo As Int32
        Public Property Balance As Decimal
        Public Property DjIdNo As Int32
        Public Property DiscountTaken As Decimal
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property InvoiceNo As String
        Public Property JournalCode As String
        Public Property JournalIdNo As Int32
        Public Property PreviousBalance As Decimal
        Public Property Sequence As Int16
        Public Property TransactionDate As Date?
    End Class

End Namespace
