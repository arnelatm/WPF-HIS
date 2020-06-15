Imports AATM.Accounts.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IErJournalView
        Inherits IView

        Property AccountIdNo As Int32?
        Property Amount As Decimal
        Property Cancelled As Boolean
        Property DateCreated As DateTime?
        Property IdNo As Int32
        Property Notes As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property EmployeeIdNo As Int32?
        Property TotalCredits As Decimal
        Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property TransactionType As String
        Property JournalItems As List(Of JournalItemView)

    End Interface

End Namespace