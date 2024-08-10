' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class RevCostCenter
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("RevCostCenterName"))
                AddRule(New ValidateCompare("ParentIdNo", "IdNo", ValidationOperator.NotEqual,
                                            ValidationDataType.Integer))
            End If
        End Sub

        Public Property IdNo As Int16
        Public Property ParentIdNo As Int16?
        Public Property RevCostCenterCode As String
        Public Property RevCostCenterName As String
        Public Property RevCostCenterNameAra As String
        Public Property RCType As String
        Public Property LevelNumber As Int16
        Public Property Notes As String
        Public Property SortKey As String
    End Class

End Namespace