Namespace PresentationLayer.Models
    Public Class GroupAccessModel
        Inherits CommonModel
        Public Property IdNo As Int16
        Public Property SecurityGroupIdNo As Int16
        Public Property SecurityObjectIdNo As Int16
        Public Property Visible As Boolean
        Public Property Editable As Boolean
        Public Property SecurityObjectName() As String
    End Class
End Namespace