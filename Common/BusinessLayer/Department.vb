' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Department
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("DepartmentName"))
            End If
        End Sub

        Public Property IdNo() As Int16
        Public Property DepartmentCode() As String
        Public Property DepartmentName() As String
        Public Property ParentIdNo() As Integer?
        Public Property DepartmentNameAra() As String
        Public Property Notes() As String
        Public Property RevCostCenterIdNo() As Int16
        Public Property SortKey() As String
    End Class

End Namespace