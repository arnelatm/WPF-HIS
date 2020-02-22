Public Interface IModelTblColProp
    'Function GetControlTblColPropIdNo(searchValue As String) As String
    'Function GetUserTblColProp(TblColPropObjectIdNo As Integer, TblColPropGroupIdNo As Integer) As ArrayList
    Function GetMainTableColumnProperties(tableName As String) As List(Of TblColPropModel)
End Interface