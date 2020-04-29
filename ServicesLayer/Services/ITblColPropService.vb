Namespace Services

    Public Interface ITblColPropService

        'Function GetControlTblColPropIdNo(searchValue As String) As String
        'Function GetUserTblColProp(tblColPropObjectIdNo As Int32, tblColPropGroupIdNo As Int32) As ArrayList
        Function GetMainTableColumnProperties(tableName As String) As Object

    End Interface

End Namespace