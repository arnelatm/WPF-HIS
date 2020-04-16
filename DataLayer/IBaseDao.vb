Public Interface IBaseDao

    'Function CheckIfUnique(control As Control, tableName As String, fieldName As String, targetIdNo As Int32)
    Function CheckIfUnique(searchValue As String, tableName As String, searchFieldName As String, currentIdNo As Long) _
        As String

    Function CountRecordWith2Key(searchValue1 As Integer, searchValue2 As String, tableName As String,
                                 searchFieldName1 As String, searchFieldName2 As String) As Integer

    Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

    Function DeleteRecord(idNo As Integer, tableName As String) As Short

    Function FindField(tableName As String, fieldName As String, searchString As String,
                       Optional searchAnywhere As Boolean = False) As Integer

    Function FindFieldContinue(tableName As String, lastIdNo As Integer) As Object

    Function GetFilteredRecords(filterExpression As String, sortKey As String) As Object

    Function GetFilteredRecords(searchValue As String, tableName As String, searchField As String,
                                returnFieldsArray As Array) As ArrayList

    Function GetLastSortKey(searchValue As String, tableName As String) As String

    Function GetRecordCount(tableName As String) As Integer

    Function GetRecordDateTimeStamp(idNo As Integer, tableName As String, dateTimeStampField As String) As Object

    Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                   returnFieldName As String) As String

    Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String,
                                   returnFieldName As String) As T

    Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                    searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) _
        As String

    Function GetRecordPosition(tableName As String, idNo As Integer) As Integer

    Function GetRecordPositionByName(tableName As String, sortField As String, nameValue As String) As Integer

    Function GetRecords(tableName As String, sortKey As String, ParamArray fieldNames() As String) As Object

    Function GetRecordsFiltered(tableName As String, sortKey As String, filterKey As String,
                                ParamArray fieldNames() As String) As Object

    Function GetRecordWithIdNo(idNo As Integer, tableName As String, returnFieldName As String) As String

    Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer

    Function GetSortedRecordPosition(idNo As Integer, tableName As String, sortOrder As String) As Integer

    'Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList

    Function HasRecordChanged(idNo As Integer, tableName As String, timeStampValue As Byte,
                              Optional timeStampedField As String = "DateTimeStamp") As Boolean

    Function IsFieldUnique(tableName As String, fieldName As String) As Boolean

    Function GetSqlValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType

    Function UpdateRecordWithIdNo(Of T)(idNo As Integer, tableName As String, fieldName As String, value As T) _
        As Integer

End Interface