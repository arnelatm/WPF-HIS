Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IGeneralJournalView
        Inherits IView
        Property Cancelled As Boolean
        Property ClosingJournal As Boolean
        Property DateCreated As DateTime?
        Property IdNo As Int32
        Property Notes As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property TotalDebits As Decimal
        Property TotalCredits As Decimal
        Property TransactionDate As Date?
        Property JournalItems As List(Of IJournalItemView)
    End Interface

End Namespace