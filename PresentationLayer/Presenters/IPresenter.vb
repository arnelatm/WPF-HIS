Public Interface IPresenter

    Function MakeEnumComboList(Of TE)()
    Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String)

End Interface
