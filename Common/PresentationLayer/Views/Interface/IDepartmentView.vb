' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IDepartmentView
        Inherits IView
        Property IdNo() As Int16
        Property DepartmentCode() As String
        Property DepartmentName() As String
        Property DepartmentNameAra() As String
        Property ParentIdNo As Int16?
        Property RevCostCenterIdNo As Int16
        Property Notes As String
        Property SortKey As String
    End Interface

End Namespace