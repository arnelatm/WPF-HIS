' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class JournalPrefix
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property JournalCode As Decimal
        Public Property JournalName As String
        Public Property IdNo As Int32
        Public Property JournalNameAra As String
        Public Property JournalCodeAra As String

    End Class

End Namespace