Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IJournalItemView
        Inherits IView

        Property AccountIdNo As Integer
        Property AccountName As String
        Property Cancelled As Boolean
        Property Credit As Decimal
        Property Debit As Decimal
        Property DiscountTaken As Decimal
        Property IdNo As Integer
        Property JournalIdNo As Integer
        Property Notes As String
        Property OpenInvoiceIdNo As Integer
        Property OriginalAmount As Decimal
        Property PaidAmount As Decimal
        Property PayeeType As String
        Property ProfitCenterIdNo As Integer
        Property Sequence As Integer
        Property SpecialAccount As String

    End Interface
End NameSpace