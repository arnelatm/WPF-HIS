Namespace PresentationLayer.Models
    Public Class GroupAccessModel
        Inherits CommonModel
        Public Property SecurityGroupIdNo As Int32
        Public Property SecurityObjectIdNo As Int32
        Public Property Visible As Boolean
        Public Property Editable As Boolean
        Public Property SecurityObjectName() As String
    End Class
End Namespace