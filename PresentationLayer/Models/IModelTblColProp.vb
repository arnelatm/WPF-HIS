Public Interface IModelTblColProp

    'Function GetControlTblColPropIdNo(searchValue As String) As String
    'Function GetUserTblColProp(TblColPropObjectIdNo As Int32, TblColPropGroupIdNo As Int32) As ArrayList
    Function GetMainTableColumnProperties(tableName As String) As List(Of TblColPropModel)

End Interface