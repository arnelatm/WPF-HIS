Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPettyCashClosingView
        Inherits IView
        Property AccountIdNo As Int16?
        Property Amount As Decimal
        Property Applied As Decimal
        Property Cancelled As Boolean
        Property CheckDate As Date?
        Property CheckNumber As String
        Property DateCreated As DateTime?
        Property IdNo As Int32
        Property Notes As String
        Property PayeeIdNo As Int32?
        Property PayeeName As String
        Property PaymentType As String
        Property PayType As String
        Property PcAccountIdNo As Int16?
        Property PcClosed As Boolean
        Property Posted As Boolean
        Property ReferenceNo As String
        Property TransactionDate As Date?
        Property PcJournals As List(Of IPcJournalView)
        Property JournalItems As List(Of IJournalItemView)

    End Interface

End Namespace