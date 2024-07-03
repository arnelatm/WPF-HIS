Namespace Interfaces

    Public Interface IUserView
        Inherits IView

        Property Active As Boolean
        Property EmployeeIdNo As Int32?
        Property IdNo As Int16
        Property Password As String
        Property SecurityGroupIdNo As Int16
        Property SecurityLevel As Int16
        Property UserName As String
    End Interface

    Public Interface IUserViewNew
        Inherits IViewNew

        Event Login()

        Property Active As Boolean
        Property BranchIdNoData As DataTable
        Property CancelClose As Boolean
        ReadOnly Property ChangePassword As Boolean
        Property EmployeeIdNo As Int32?
        Property IdNo As Int16
        Property NewPassword As String
        Property Password As String
        Property SecurityGroupIdNo As Int16
        Property SecurityLevel As Int16
        Property UserName As String
        Property LoginOk As Boolean
    End Interface

End Namespace