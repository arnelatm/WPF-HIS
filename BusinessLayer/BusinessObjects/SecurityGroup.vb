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

        Public Property IdNo As Integer
        Public Property ParentIdNo As Integer
        Public Property SecurityGroupName As String
        Public Property SecurityGroupNameAra As String
        Public Property SecurityGroupCode As String
        Public Property Notes As String
    End Class

End Namespace