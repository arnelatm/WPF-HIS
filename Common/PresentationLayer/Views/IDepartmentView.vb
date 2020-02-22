Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IDepartmentView
        Inherits IView
        Property IdNo() As Integer
        Property DepartmentCode() As String
        Property DepartmentName() As String
        Property DepartmentNameAra() As String
        Property ParentIdNo() As Integer?
        Property Notes() As String
        Property ProfitCenterIdNo() As Integer
        Property CostCenterIdNo() As Integer
        Property SortKey As String
    End Interface

End Namespace