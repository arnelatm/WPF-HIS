Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IBasicView
        Inherits IView

        ReadOnly Property BranchIdNo As Int16
        Property Code As String
        Property IdNo As Int32
        Property Name As String
        Property NameAra As String
        Property Notes As String

    End Interface

End Namespace