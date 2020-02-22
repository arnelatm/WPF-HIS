' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Department
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            AddRule(New ValidateRequired("DepartmentName"))
        End Sub

        Public Property IdNo() As Integer
        Public Property DepartmentCode() As String
        Public Property DepartmentName() As String
        Public Property ParentIdNo() As Integer?
        Public Property DepartmentNameAra() As String
        Public Property Notes() As String
        Public Property ProfitCenterIdNo() As Integer
        Public Property CostCenterIdNo() As Integer
        Public Property SortKey() As String

    End Class
End NameSpace