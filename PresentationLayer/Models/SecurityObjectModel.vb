Public Class SecurityObjectModel
    Public Property IdNo As Integer
    Public Property ParentIdNo As Integer?
    Public Property SecurityObjectName As String
    Public Property SecurityObjectNameAra As String
    Public Property Notes As String
    Public Property Errors As List(Of String)
End Class