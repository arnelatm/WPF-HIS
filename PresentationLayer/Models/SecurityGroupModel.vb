Public Class SecurityGroupModel
    Inherits Model

    Public Property IdNo As Int16

    Public Property Notes As String
    Public Property ParentIdNo As Int16?
    Public Property SecurityGroupCode As String
    Public Property SecurityGroupName As String
    Public Property SecurityGroupNameAra As String
    Public Property GroupAccesses As List(Of GroupAccessModel)

End Class