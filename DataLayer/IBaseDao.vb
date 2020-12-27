Public Interface IBaseDao

    'Function CheckIfUnique(control As Control, tableName As String, fieldName As String, targetIdNo As Int32)
    Function CheckIfUnique(searchValue As String, tableName As String, searchFieldName As String, currentIdNo As Long) _
        As String

    Function CountRecordWith2Key(searchValue1 As Integer, searchValue2 As String, tableName As String,
                                 searchFieldName1 As String, searchFieldName2 As String) As Integer

    Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

    Function DeleteRecord(idNo As Int32, tableName As String) As Int32

    Function FindField(tableName As String, fieldName As String, searchString As String,
                       Optional searchAnywhere As Boolean = False) As Integer

    Function FindFieldContinue(tableName As String, lastIdNo As Int32) As Object

    Function GetControlSecurityIdNo(searchValue As String) As String

    Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object

    Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object

    Function GetFilteredRecords(tableName As String, sortKey As String, filterKey As String, ParamArray fieldNames() As String) As Object

    Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer

    Function GetLastSortKey(searchValue As String, tableName As String) As String

    Function GetMaxValueFiltered(searchFieldName As String, tableName As String, returnFieldName As String, filter As String) As Object

    Function GetRecordCount(tableName As String) As Integer

    Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, dateTimeStampField As String) As Object

    Function GetRecordField(tableName As String, returnFieldName As String) As Object

    Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                    searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) _
        As String

    Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                       returnFieldName As String) As String

    Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String,
                                   returnFieldName As String) As T

    Function GetRecordPosition(tableName As String, idNo As Int32) As Integer

    Function GetRecordPositionByName(tableName As String, sortField As String, nameValue As String) As Integer

    Function GetRecords(tableName As String, sortKey As String, ParamArray fieldNames() As String) As Object

    Function GetFields(tableName As String, sortKey As String, ParamArray fieldNames() As String) As Object

    Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String) As Integer

    Function GetSqlValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType

    Function GetUserSecurity(securityObjectIdNo As Int16, securityGroupIdNo As Int16) As ArrayList

    Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList

    Function HasRecordChanged(idNo As Int32, tableName As String, timeStampValue As Byte,
                              Optional timeStampedField As String = "DateTimeStamp") As Boolean

    Function IsFieldUnique(tableName As String, fieldName As String) As Boolean

    Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) _
        As Integer

End Interface