Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ISecurityGroupView
        Inherits IView
        Property IdNo As Int32
        Property ParentIdNo As Int32?
        Property SecurityGroupName As String
        Property SecurityGroupNameAra As String
        Property SecurityGroupCode As String
        Property Notes As String
        Property GroupAccesses As List(Of GroupAccessView)

    End Interface
End NameSpace