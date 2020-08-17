Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessObjects

    Public Class SecurityGroup
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("SecurityGroupName"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property ParentIdNo As Int32?
        Public Property SecurityGroupCode As String
        Public Property SecurityGroupName As String
        Public Property SecurityGroupNameAra As String
        Public Property GroupAccesses As List(Of GroupAccess)
    End Class

End Namespace