' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class JournalItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property AccountIdNo As Int16?
        Public Property AccountName As String
        Public Property DiscountTaken As Decimal
        Public Property OriginalAmount As Decimal
        Public Property Cancelled As Boolean
        Public Property Credit As Decimal
        Public Property Debit As Decimal
        Public Property IdNo As Int32
        Public Property JournalIdNo As Int32
        Public Property Notes As String
        Public Property OpenInvoiceIdNo As Int32
        Public Property PaidAmount As Decimal
        Public Property PayeeType As String
        Public Property RevCostCenterIdNo As Int32
        Public Property Sequence As Int16
        Public Property SpecialAccount As String
    End Class

End Namespace