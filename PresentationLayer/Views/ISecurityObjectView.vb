Public Interface ISecurityObjectView
    Inherits IView
    Property IdNo As Integer
    Property ParentIdNo As Integer?
    Property SecurityObjectName As String
    Property SecurityObjectNameAra As String
    Property Notes As String
End Interface