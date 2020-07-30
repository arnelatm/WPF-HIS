Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IJournalItemView
        Inherits IView

        Property AccountIdNo As Int32?
        Property AccountName As String
        Property Cancelled As Boolean
        Property Credit As Decimal
        Property Debit As Decimal
        Property DiscountTaken As Decimal
        Property IdNo As Int32
        Property JournalIdNo As Int32
        Property Notes As String
        Property OpenInvoiceIdNo As Int32
        Property OriginalAmount As Decimal
        Property PaidAmount As Decimal
        Property PayeeType As String
        Property RevCostCenterIdNo As Int32
        Property Sequence As Integer
        Property SpecialAccount As String

    End Interface

End Namespace