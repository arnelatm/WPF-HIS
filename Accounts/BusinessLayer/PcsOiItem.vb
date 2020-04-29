' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class PcsOiItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AccountIdNo as Int32
        Public Property Amount As Decimal
        Public Property Balance As Decimal
        Public Property PcsIdNo As Int32
        Public Property DiscountTaken As Decimal
        Public Property IdNo As Int32
        Public Property InvoiceNo As String
        Public Property JournalCode As String
        Public Property JournalIdNo As Int32
        Public Property JournalItemIdNo As Int32
        Public Property OpenInvoiceIdNo As Int32
        Public Property PreviousBalance As Decimal
        Public Property Sequence As Integer
        Public Property TransactionDate As Date
    End Class

End Namespace