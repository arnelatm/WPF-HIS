' GeneralJournal business object as seen by the Service client.
Namespace PresentationLayer.Models

    Public Class JournalItemModel

        Public Sub New()
        End Sub

        Public Property AccountIdNo As Int16?
        Public Property AccountName As String
        Public Property Cancelled As Boolean
        Public Property Credit As Decimal
        Public Property DiscountTaken As Decimal
        Public Property Debit As Decimal
        Public Property IdNo As Int32
        Public Property JournalIdNo As Int32
        Public Property Notes As String
        Public Property OpenInvoiceIdNo As Int32
        Public Property OriginalAmount As Decimal
        Public Property PaidAmount As Decimal
        Public Property PayeeType As String
        Public Property PayIdNo as Int32
        Public Property RevCostCenterIdNo As Int16
        Public Property Sequence As Int16
        Public Property SpecialAccount As String

    End Class

End Namespace