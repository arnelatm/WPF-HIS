


Public Class GroupAccessModel
    Inherits Model
    Public Property IdNo As Int32
    Public Property SecurityGroupIdNo As Int16
    Public Property SecurityObjectIdNo As Int16
    Public Property Visible As Boolean
    Public Property Editable As Boolean
    Public Property SecurityObjectName() As String
End Class