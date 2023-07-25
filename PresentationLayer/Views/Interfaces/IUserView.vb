Namespace Interfaces

    Public Interface IUserView
        Inherits IView


        Property Active As Boolean
        Property IdNo As Int32
        Property UserName As String
        Property EmployeeIdNo As Int32?
        Property Password As String
        Property SecurityLevel As Int16
        Property SecurityGroupIdNo As Int16
    End Interface

End Namespace