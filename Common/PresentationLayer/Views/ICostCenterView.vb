Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICostCenterView
        Inherits IView
        Property IdNo As Integer
        Property ParentIdNo As Integer?
        Property CostCenterCode As String
        Property CostCenterName As String
        Property CostCenterNameAra As String
        Property ProfitCenterIdNo As Integer
        Property LevelNumber As Int16
        Property Notes As String
        Property SortKey As String
    End Interface

End Namespace