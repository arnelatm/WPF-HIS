' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class AccountReconciliationItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property AccountIdNo As Integer
        Public Property AccountReconciliationIdNo As Integer
        Public Property Cleared As Boolean
        Public Property Credit As Decimal
        Public Property Debit As Decimal
        Public Property DocumentNumber As String
        Public Property IdNo As Integer
        Public Property JournalCode As String
        Public Property JournalIdNo As Integer
        Public Property JournalItemIdNo As Integer
        Public Property PayDescription As String
        Public Property PayDescriptionAra As String
        Public Property TransactionDate As Date?
        Public Property ReferenceNo As String
        Public Property Sequence As Integer

    End Class

End Namespace