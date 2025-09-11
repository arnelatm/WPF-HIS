Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IRevenueGroupView
        Inherits IView
        Property IdNo As Int16
        Property ParentIdNo As Int16?
        Property RevenueGroupCode As String
        Property RevenueGroupName As String
        Property RevenueGroupNameAra As String
        Property LevelNumber As Int16
        Property Notes As String
        Property SortKey As String
    End Interface

End Namespace