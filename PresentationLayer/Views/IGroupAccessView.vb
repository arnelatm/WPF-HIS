Public Interface IGroupAccessView

    Property IdNo As Integer
    Property SecurityGroupIdNo As Integer
    Property SecurityObjectIdNo As Integer
    Property Visible As Boolean
    Property Editable As Boolean
    'Property Viewable As Boolean
    'Property Selectable As Boolean
    Property SecurityObjectName() As String
    Property Errors As List(Of String)

End Interface