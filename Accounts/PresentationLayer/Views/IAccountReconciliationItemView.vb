Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views


    Interface IAccountReconciliationItemView
        Inherits IView

        Property AccountIdNo As Integer
        Property AccountReconciliationIdNo As Integer
        Property Cleared As Boolean
        Property Credit As Decimal
        Property Debit As Decimal
        Property DocumentNumber As String
        Property IdNo As Integer
        Property JournalCode As String
        Property JournalIdNo As Integer
        Property JournalItemIdNo As Integer
        Property PayDescription As String
        Property PayDescriptionAra As String
        Property ReferenceNo As String
        Property TransactionDate As Date?
        Property Sequence As Integer

    End Interface
End NameSpace