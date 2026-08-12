Imports System.Windows.Forms

Namespace Interfaces

    Public Interface ISecurityGroupView
        Inherits IView

        Property IdNo As Int16
        Property Notes As String
        Property ParentIdNo As Int16?
        Property SecurityGroupCode As String
        Property SecurityGroupName As String
        Property SecurityGroupNameAra As String
        Property GroupAccesses As List(Of GroupAccessView)

        Event CheckAllEvent(propertyName As String)

        Event UncheckAllEvent(propertyName As String)

        Event GroupAccessChanged(groupAccess As GroupAccessView, propertyName As String, value As Boolean)

    End Interface

End Namespace
