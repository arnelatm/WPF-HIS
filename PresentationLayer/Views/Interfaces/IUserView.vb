Namespace Interfaces

    Public Interface IUserView
        Inherits IView

        Property Active As Boolean
        Property IdNo As Int16
        Property UserName As String
        Property EmployeeIdNo As Int32?
        Property Password As String
        Property SecurityLevel As Int16
        Property SecurityGroupIdNo As Int16

    End Interface

    Public Interface IUserSecurityView
        Inherits IUserView

        Property UserAccesses As List(Of UserAccessView)
        Event CheckAllEvent(propertyName As String)
        Event UncheckAllEvent(propertyName As String)

    End Interface

End Namespace