Public Class SecurityGroupModel

    'Public Sub New()
    '    GroupAccesses = New List(Of GroupAccessModel)()
    'End Sub
    Public Property IdNo As Integer
    Public Property ParentIdNo As Integer
    Public Property SecurityGroupCode As String
    Public Property SecurityGroupName As String
    Public Property SecurityGroupNameAra As String
    Public Property Notes As String

    'Public Property GroupAccesses() As IList(Of GroupAccessModel)
    Public Property Errors As List(Of String)

End Class