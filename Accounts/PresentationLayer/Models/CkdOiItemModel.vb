Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class CkdOiItemModel

        Public Property AccountIdNo As Integer
        Public Property Amount As Decimal
        Public Property Balance As Decimal
        Public Property CkdIdNo As Integer
        Public Property DiscountTaken As Decimal
        Public Property Errors As List(Of String)
        Public Property IdNo As Integer
        Public Property InvoiceNo As String
        Public Property JournalCode As String
        Public Property JournalIdNo As Integer
        Public Property JournalItemIdNo As Integer
        Public Property OpenInvoiceIdNo As Integer
        Public Property PreviousBalance As Decimal
        Public Property Sequence As Integer
        Public Property TransactionDate As Date?

    End Class

End Namespace