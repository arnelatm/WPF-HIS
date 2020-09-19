' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class CsrOiItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AccountIdNo As Int16?
        Public Property Amount As Decimal
        Public Property ArOpenInvoiceIdNo As Int32
        Public Property Balance As Decimal
        Public Property CsrIdNo As Int32
        Public Property DiscountTaken As Decimal
        Public Property IdNo As Int32
        Public Property InvoiceNo As String
        Public Property JournalCode As String
        Public Property JournalIdNo As Int32
        Public Property PreviousBalance As Decimal
        Public Property Sequence As Int16
        Public Property TransactionDate As Date
    End Class

End Namespace