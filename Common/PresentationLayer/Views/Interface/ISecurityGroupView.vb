Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface ISecurityGroupView
        Inherits IView
        Property IdNo As Int16
        Property Notes As String
        Property ParentIdNo As Int16?
        Property SecurityGroupCode As String
        Property SecurityGroupName As String
        Property SecurityGroupNameAra As String
        Property GroupAccesses As List(Of GroupAccessView)

    End Interface

End Namespace