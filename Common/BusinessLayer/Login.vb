' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class Login
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property IdNo As Integer

        Public Property UserName As String
        Public Property Password As String
        Public Property SecurityGroupIdNo As Integer
    End Class
End NameSpace