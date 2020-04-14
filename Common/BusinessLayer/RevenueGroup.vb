' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class RevenueGroup
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("RevenueGroupName"))
            End If
        End Sub

        Public Property IdNo As Integer
        Public Property ParentIdNo As Integer?
        Public Property RevenueGroupCode As String
        Public Property RevenueGroupName As String
        Public Property RevenueGroupNameAra As String
        Public Property LevelNumber As Int16
        Public Property Notes As String
        Public Property SortKey As String
    End Class

End Namespace