Public Class AccessTypeEventArgs
    Implements IAccessTypeEventArgs

    Public Enum AccessType
        Read
        Add
        Update
        Delete
    End Enum

    Public Property ValuesWereChanged As Boolean Implements IAccessTypeEventArgs.ValuesWereChanged
    Public Property AccessTypeValue As AccessType Implements IAccessTypeEventArgs.AccessTypeValue
End Class