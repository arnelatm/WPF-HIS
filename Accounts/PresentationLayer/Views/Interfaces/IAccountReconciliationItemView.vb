Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Interface IAccountReconciliationItemView
        Inherits IView
        Property AccountIdNo As Int16?
        Property AccountReconciliationIdNo As Int32
        Property Cleared As Boolean
        Property Credit As Decimal
        Property Debit As Decimal
        Property DocumentNumber As String
        Property IdNo As Int32
        Property JournalCode As String
        Property JournalIdNo As Int32
        Property JournalItemIdNo As Int32
        Property PayDescription As String
        Property PayDescriptionAra As String
        Property ReferenceNo As String
        Property Sequence As Int32
        Property TransactionDate As Date?

    End Interface

End Namespace