Imports AATM.Accounts.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IGeneralJournalView
        Inherits IView
        Property Cancelled As Boolean
        ReadOnly Property DateCreated As DateTime?
        Property IdNo As Integer
        Property Notes As String
        ReadOnly Property Posted As Boolean
        Property ReferenceNo As String
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property JournalItems As List(Of JournalItemView)
    End Interface

End Namespace