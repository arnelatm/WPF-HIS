' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class CkdOiItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AccountIdNo as Int32

        Public Property Amount As Decimal
        Public Property Balance As Decimal
        Public Property CkdIdNo As Integer
        Public Property DiscountTaken As Decimal
        Public Property IdNo As Integer
        Public Property InvoiceNo As String
        Public Property JournalCode As String
        Public Property JournalIdNo As Integer
        Public Property JournalItemIdNo As Integer
        Public Property OpenInvoiceIdNo As Integer
        Public Property PreviousBalance As Decimal
        Public Property Sequence As Integer
        Public Property TransactionDate As Date
    End Class

End Namespace