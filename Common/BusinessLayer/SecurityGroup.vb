Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class SecurityGroup
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            AddRule(New ValidateRequired("SecurityGroupName"))
        End Sub

        Public Property IdNo As Integer
        Public Property SecurityGroupName As String
        Public Property SecurityGroupNameAra As String
        Public Property SecurityGroupCode As String
        Public Property Notes As String
    End Class
End NameSpace