Public Interface IFindableControl
    Property FindEnabled As Boolean
    Property BegFindValue As Object
    Property EndFindValue As Object
    Property SearchPlace As String
    Property FieldName As String
    ReadOnly Property DataSource As Object
    ReadOnly Property DisplayMember As String
    ReadOnly Property SearchMode As String
    ReadOnly Property ValueMember As String
End Interface