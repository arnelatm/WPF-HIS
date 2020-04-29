' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace BusinessObjects

    Public Class Login
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property IdNo As Int32

        Public Property UserName As String
        Public Property Password As String
        Public Property SecurityGroupIdNo As Int32
    End Class

End Namespace