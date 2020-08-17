Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views
    Public Interface ISecurityObjectView
        Inherits IView
        Property IdNo As Int32
        Property ParentIdNo As Int32?
        Property SecurityObjectCode As String
        Property SecurityObjectName As String
        Property SecurityObjectNameAra As String
        Property Notes As String
    End Interface
End NameSpace