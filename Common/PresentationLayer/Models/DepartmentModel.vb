Namespace PresentationLayer.Models

    Public Class DepartmentModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property DepartmentCode() As String
        Public Property DepartmentName() As String
        Public Property DepartmentNameAra() As String
        Public Property ParentIdNo() As Int16?
        Public Property Notes() As String
        Public Property RevCostCenterIdNo() As Int16
        Public Property SortKey As String
    End Class

End Namespace