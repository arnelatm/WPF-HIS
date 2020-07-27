Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IRevCostCenterView
        Inherits IView
        Property IdNo As Int32
        Property ParentIdNo As Int32?
        Property RevCostCenterCode As String
        Property RevCostCenterName As String
        Property RevCostCenterNameAra As String
        Property RCType As String
        Property LevelNumber As Int16
        Property Notes As String
        Property SortKey As String
    End Interface

End Namespace