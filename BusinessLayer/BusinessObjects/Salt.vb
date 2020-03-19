' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessObjects

    Public Class Salt
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property IdNo As Integer
        Public Property LoginIdNo As Integer
        Public Property Salt As String
    End Class

End Namespace