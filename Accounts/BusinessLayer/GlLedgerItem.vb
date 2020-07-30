' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class GlLedgerItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property AccountIdNo As Int32?
        Public Property Credit As Decimal
        Public Property Debit As Decimal
        Public Property IdNo As Int32
        Public Property JournalCode As String
        Public Property JournalIdNo As Int32
        Public Property Notes As String
        Public Property PayDescription As String
        Public Property PayDescriptionAra As String
        Public Property Posted As Boolean
        Public Property RevCostCenterIdNo As Int32
        Public Property ReferenceNo As String
        Public Property Sequence As Integer
        Public Property TransactionDate As Date?

    End Class

End Namespace