Imports AATM.Accounts.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICashDisbursementJournalView
        Inherits IView
        Property AccountIdNo As Int32?
        Property Amount As Decimal
        Property Applied As Decimal
        Property Cancelled As Boolean
        Property DateCreated As DateTime?
        Property DiscountAccountIdNo As Int32?
        Property DiscountTaken As Decimal
        Property IdNo As Int32
        Property Notes As String
        Property OrNumber As String
        Property PayeeIdNo As Int32?
        Property PayeeName As String
        Property PaymentType As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property UnApplied As Decimal
        Property VatAmount As Decimal
        Property VatNumber As String
        Property JournalItems As List(Of JournalItemView)
        Property CadOiItems As List(Of CadOiItemView)
    End Interface

End Namespace