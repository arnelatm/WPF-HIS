Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PcsOiItemModel

        Public Property AccountIdNo As Int32?
        Public Property Amount As Decimal
        Public Property Balance As Decimal
        Public Property PcsIdNo As Int32
        Public Property DiscountTaken As Decimal
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property InvoiceNo As String
        Public Property JournalCode As String
        Public Property JournalIdNo As Int32
        Public Property JournalItemIdNo As Int32
        Public Property OpenInvoiceIdNo As Int32
        Public Property PreviousBalance As Decimal
        Public Property Sequence As Integer
        Public Property TransactionDate As Date?

    End Class

End Namespace