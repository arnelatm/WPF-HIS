Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IUserView
        Inherits IView

        Property IdNo As Int32
        Property UserName As String
        Property Password As String
        Property FullName As String
        Property FullNameAra As String
        Property SecurityLevel As Int16
        Property SecurityGroupIdNo As Int16
    End Interface

End Namespace