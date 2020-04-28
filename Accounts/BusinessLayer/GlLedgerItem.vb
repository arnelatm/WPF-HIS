' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class GlLedgerItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property AccountIdNo as Int32
        Public Property Credit As Decimal
        Public Property Debit As Decimal
        Public Property IdNo As Integer
        Public Property JournalCode As String
        Public Property JournalIdNo As Integer
        Public Property Notes As String
        Public Property PayDescription As String
        Public Property PayDescriptionAra As String
        Public Property Posted As Boolean
        Public Property ProfitCenterIdNo As Integer
        Public Property ReferenceNo As String
        Public Property Sequence As Integer
        Public Property TransactionDate As Date?

    End Class

End Namespace