Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayGroupView
        Inherits IView
        Property IdNo As Int16
        Property LevelNumber As Int16
        Property ParentIdNo As Int16?
        Property PayGroupCode As String
        Property PayGroupName As String
        Property PayGroupNameAra As String
        Property RevCostCenterIdNo As Int16
        Property Notes As String
    End Interface

End Namespace