Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IErJournalView
        Inherits IView

        Property AccountIdNo As Int16?
        Property Amount As Decimal
        Property Approved As Boolean
        Property Cancelled As Boolean
        Property DateCreated As DateTime?
        Property IdNo As Int32
        Property Notes As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property EmployeeIdNo As Int32?
        ReadOnly Property TotalCredits As Decimal
        ReadOnly Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property TransactionType As String
        Property JournalItems As List(Of JournalItemView)
        Property RevCostCentersByCode
        Property AccountsByCode

    End Interface

End Namespace