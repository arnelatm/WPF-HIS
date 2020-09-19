Namespace PresentationLayer.Models
    Public Class SecurityObjectModel
        Inherits CommonModel

        Public Property IdNo As Int16
        Public Property ParentIdNo As Int16?
        Public Property SecurityObjectCode As String
        Public Property SecurityObjectName As String
        Public Property SecurityObjectNameAra As String
        Public Property Notes As String
    End Class
End Namespace