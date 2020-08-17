Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ISecurityGroupView
        Inherits IView
        Property IdNo As Int32
        Property Notes As String
        Property ParentIdNo As Int32?
        Property SecurityGroupCode As String
        Property SecurityGroupName As String
        Property SecurityGroupNameAra As String
        Property GroupAccesses As List(Of GroupAccessView)

    End Interface
End Namespace