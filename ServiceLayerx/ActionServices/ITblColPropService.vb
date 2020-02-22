Public Interface ITblColPropService

    'Function GetControlTblColPropIdNo(searchValue As String) As String
    'Function GetUserTblColProp(tblColPropObjectIdNo As Integer, tblColPropGroupIdNo As Integer) As ArrayList
    Function GetMainTableColumnProperties(tableName As String) As Object

End Interface