' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Category
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("CategoryName"))
                AddRule(New ValidateRequired("CategoryCode"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property CategoryCode As String
        Public Property CategoryName As String
        Public Property CategoryNameAra As String
        Public Property Notes As String
    End Class

End Namespace