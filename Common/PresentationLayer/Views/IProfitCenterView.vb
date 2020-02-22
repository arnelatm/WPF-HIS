Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IProfitCenterView
        Inherits IView
        Property IdNo As Integer
        Property ParentIdNo As Integer?
        Property ProfitCenterCode As String
        Property ProfitCenterName As String
        Property ProfitCenterNameAra As String
        Property ProfitCenterType As String
        Property LevelNumber As Int16
        Property Notes As String
        Property SortKey As String
    End Interface

End Namespace