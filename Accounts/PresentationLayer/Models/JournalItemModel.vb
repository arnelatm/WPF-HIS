' GeneralJournal business object as seen by the Service client.
Namespace PresentationLayer.Models

    Public Class JournalItemModel
        Public Property AccountIdNo As Int32?
        Public Property AccountName As String
        Public Property Cancelled As Boolean
        Public Property Credit As Decimal
        Public Property DiscountTaken As Decimal
        Public Property Debit As Decimal
        Public Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property JournalIdNo As Int32
        Public Property Notes As String
        Public Property OpenInvoiceIdNo As Int32
        Public Property OriginalAmount As Decimal
        Public Property PaidAmount As Decimal
        Public Property PayeeType As String
        Public Property ProfitCenterIdNo As Int32
        Public Property Sequence As Integer
        Public Property SpecialAccount As String

    End Class

End Namespace