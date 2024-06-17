Namespace Interfaces

    Public Interface IUserSecurityView
        Inherits IView

        Property IdNo As Int16
        Property UserName As String
        Property UserAccesses As List(Of UserAccessView)
        Event CheckAllEvent(propertyName As String)
        Event UncheckAllEvent(propertyName As String)

    End Interface

End Namespace