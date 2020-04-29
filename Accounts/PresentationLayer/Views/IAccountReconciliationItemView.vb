Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Interface IAccountReconciliationItemView
        Inherits IView

        Property AccountIdNo as Int32
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
        Property TransactionDate As Date?
        Property Sequence As Integer

    End Interface

End Namespace