' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class Reconciled
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property IdNo As Integer

        Public Property JournalCode As String
        Public Property JournalItemIdNo As Int32
        Public Property ReconciliationIdNo As Integer

    End Class
End NameSpace