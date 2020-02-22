' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Imports AATM.BusinessLayer

Public Class TblColProp
    Inherits BusinessObject

    ' ** Enterprise Design Pattern: Identity field pattern

    Public Property FldName As String
    Public Property FldType As String
    Public Property MaxLength As Long
    Public Property IsNullable As Boolean
    Public Property IsIdentity As Boolean
End Class