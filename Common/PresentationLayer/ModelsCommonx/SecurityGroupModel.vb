

Public Class SecurityGroupModel

    'Public Sub New()
    '    GroupAccesses = New List(Of GroupAccessModel)()
    'End Sub
    Public Property IdNo As Integer

    Public Property SecurityGroupCode As String
    Public Property SecurityGroupName As String
    Public Property Notes As String

    Public Property GroupAccesses() As IList(Of GroupAccessModel)

End Class

'Public Class SecurityGroupModel
'    Public Property IDNo() As Integer
'    Public Property SecurityGroupName() As String
'    Public Property Description() As String
'End Class