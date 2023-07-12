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

        Public Property DosageMasterList As List(Of DosageMasterDetail)

    End Class

    Public Class DosageMasterDetail
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("DosageName"))
                AddRule(New ValidateRequired("DosageNameAra"))
            End If

        End Sub

        Public Property DosageMasterCode As String
        Public Property DosageMasterName As String
        Public Property DosageMasterNameAra As String
        Public Property IdNo As Int32

    End Class

End Namespace