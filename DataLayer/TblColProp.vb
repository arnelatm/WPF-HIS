' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Public Class TblColProp
    Inherits BusinessLayer.BusinessObject

    ' ** Enterprise Design Pattern: Identity field pattern

    Public Property FldName As String
    Public Property FldType As String
    Public Property MaxLength As Long
    Public Property IsNullable As Boolean
    Public Property IsIdentity As Boolean
End Class