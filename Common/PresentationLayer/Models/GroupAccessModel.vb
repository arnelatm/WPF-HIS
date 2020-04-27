Namespace PresentationLayer.Models
    Public Class GroupAccessModel
        Inherits CommonModel
        Public Property IdNo As Integer
        Public Property SecurityGroupIdNo As Integer
        Public Property SecurityObjectIdNo As Integer
        Public Property Visible As Boolean
        Public Property Editable As Boolean
        Public Property SecurityObjectName() As String
        Public Property Errors As List(Of String)
    End Class
End Namespace