Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views
    Public Interface IUserView
        Inherits IView

        Property IdNo As Int32
        Property UserName As String
        Property Password As String
        Property FullName As String
        Property FullNameAra As String
        Property SecurityLevel As Int16
        Property SecurityGroupIdNo As Int32
    End Interface
End NameSpace