' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class DosageMaster
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property DosageMasterCode As String
        Public Property DosageMasterName As String
        Public Property DosageMasterNameAra As String
        Public Property IdNo As Int32

    End Class

    Public Class DosageMasterList
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property DosageMasterList As List(Of DosageMaster)

    End Class

End Namespace