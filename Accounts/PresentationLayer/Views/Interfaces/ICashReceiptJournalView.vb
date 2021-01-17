Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ICashReceiptJournalView
        Inherits IView
        Property AccountIdNo As Int16?
        Property Amount As Decimal
        Property Applied As Decimal
        Property Cancelled As Boolean
        Property CheckDate As Date?
        Property CheckNumber As String
        Property DateCreated As DateTime?
        Property DiscountAccountIdNo As Int16?
        Property DiscountTaken As Decimal
        Property IdNo As Int32
        Property Notes As String
        Property OrNumber As String
        Property PayorIdNo As Int32?
        Property PayorName As String
        Property PayorType As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property UnApplied As Decimal
        Property VatAmount As Decimal
        Property VatNumber As String
        Property JournalItems As List(Of IJournalItemView)
        Property CsrOiItems As List(Of CsrOiItemView)
    End Interface

End Namespace