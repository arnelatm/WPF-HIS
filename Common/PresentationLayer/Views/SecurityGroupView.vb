Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views
    Public Class SecurityGroupView
        Implements ISecurityGroupView

        Public Property IdNo As Integer Implements ISecurityGroupView.IdNo

        Public Property ParentIdNo As Integer? Implements ISecurityGroupView.ParentIdNo

        Public Property SecurityGroupName As String Implements ISecurityGroupView.SecurityGroupName

        Public Property SecurityGroupNameAra As String Implements ISecurityGroupView.SecurityGroupNameAra

        Public Property SecurityGroupCode As String Implements ISecurityGroupView.SecurityGroupCode

        Public Property Notes As String Implements ISecurityGroupView.Notes

        Public Property GroupAccesses As List(Of GroupAccessView) Implements ISecurityGroupView.GroupAccesses

        Public Property Errors As List(Of String) Implements IView.Errors
    End Class
End Namespace