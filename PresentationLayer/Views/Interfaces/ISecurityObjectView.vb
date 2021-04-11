Namespace Interfaces

    Public Interface ISecurityObjectView
        Inherits IView
        Property IdNo As Int32
        Property ParentIdNo As Int32?
        Property SystemViewIdNo As Int16?
        Property SecurityObjectCode As String
        Property SecurityObjectName As String
        Property SecurityObjectNameAra As String
        Property Notes As String
        Property ManuallyAdded As Boolean
    End Interface

End Namespace