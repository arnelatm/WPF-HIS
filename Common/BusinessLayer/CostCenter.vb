' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class CostCenter
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("CostCenterName"))
            End If
        End Sub

        Public Property IdNo As Integer
        Public Property ParentIdNo As Integer?
        Public Property CostCenterCode As String
        Public Property CostCenterName As String
        Public Property CostCenterNameAra As String
        Public Property ProfitCenterIdNo As Integer
        Public Property LevelNumber As Int16
        Public Property Notes As String
        Public Property SortKey As String

    End Class

End Namespace