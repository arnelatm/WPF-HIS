Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IJournalItemView
        Inherits IView

        Property AccountIdNo As Int16?
        Property AccountName As String
        Property Cancelled As Boolean
        Property ContactIdNo As Int32?
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
        Property RevCostCenterIdNo As Int16
        Property Sequence As Int16
        Property SpecialAccount As String

    End Interface

End Namespace