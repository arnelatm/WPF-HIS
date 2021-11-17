Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IGeneralJournalView
        Inherits IView

        Property Approved As Boolean
        Property Cancelled As Boolean
        Property ClosingJournal As Boolean
        Property DateCreated As DateTime?
        Property IdNo As Int32
        Property Notes As String
        Property Posted As Boolean
        Property ReferenceNo As String
        ReadOnly Property TotalDebits As Decimal
        ReadOnly Property TotalCredits As Decimal
        Property TransactionDate As Date?
        Property JournalItems As List(Of JournalItemView)
        Property AccountsByCode As Object
        Property RevCostCentersByCode As Object
    End Interface

End Namespace