Namespace PresentationLayer.Models

    Public Class DepartmentModel
        Inherits CommonModel

        Public Property DepartmentCode() As String
        Public Property DepartmentName() As String
        Public Property DepartmentNameAra() As String
        Public Property ParentIdNo() As Integer?
        Public Property Notes() As String
        Public Property RevCostCenterIdNo() As Integer
        Public Property SortKey As String
    End Class

End Namespace