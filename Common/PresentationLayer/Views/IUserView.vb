Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views
    Public Interface IUserView
        Inherits IView

        Property IdNo As Integer
        Property UserName As String
        Property Password As String
        Property FullName As String
        Property FullNameAra As String
        Property SecurityLevel As Int16
        Property SecurityGroupIdNo As Integer
    End Interface
End NameSpace