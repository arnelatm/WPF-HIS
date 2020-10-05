Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IBranchView
        Inherits IView
        Property IdNo As Int16
        Property BranchCode As String
        Property BranchName As String
        Property BranchNameAra As String
        Property Notes As String
    End Interface

End Namespace