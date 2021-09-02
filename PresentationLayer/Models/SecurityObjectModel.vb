Public Class SecurityObjectModel
    'Inherits Model

    Public Property IdNo As Int32
    Public Property SystemViewIdNo As Int16
    Public Property ParentIdNo As Int32?
    Public Property SecurityObjectCode As String
    Public Property SecurityObjectName As String
    Public Property SecurityObjectNameAra As String
    Public Property Notes As String
    Public Property ManuallyAdded As Boolean
End Class