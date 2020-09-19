' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class AccountReconciliationItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property AccountIdNo As Int16?
        Public Property AccountReconciliationIdNo As Int32
        Public Property Cleared As Boolean
        Public Property Credit As Decimal
        Public Property Debit As Decimal
        Public Property DocumentNumber As String
        Public Property IdNo As Int32
        Public Property JournalCode As String
        Public Property JournalIdNo As Int32
        Public Property JournalItemIdNo As Int32
        Public Property PayDescription As String
        Public Property PayDescriptionAra As String
        Public Property TransactionDate As Date?
        Public Property ReferenceNo As String
        Public Property Sequence As Int16

    End Class

End Namespace