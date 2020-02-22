Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IRevenueGroupView
        Inherits IView
        Property IdNo As Integer
        Property ParentIdNo As Integer?
        Property RevenueGroupCode As String
        Property RevenueGroupName As String
        Property RevenueGroupNameAra As String
        Property LevelNumber As Int16
        Property Notes As String
        Property SortKey As String
    End Interface

End Namespace