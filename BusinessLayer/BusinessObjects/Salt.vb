' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessObjects

    Public Class Salt
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property IdNo As Int32
        Public Property LoginIdNo As Int32
        Public Property Salt As String
    End Class

End Namespace