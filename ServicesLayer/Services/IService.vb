Imports AATM.DataLayer

Namespace Services

    Public Interface IService

        'Function GetRecordById(tableName As String, idNo As Integer)
        Function AddRecord(ByRef model As Object) As Integer

        Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean

        Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer

        Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

        Function DeleteRecord(idNo As Integer, tableName As String) As Integer

        Function DelUpdateTvp(dtTable As DataTable, groupKey As Integer) As Integer

        Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean) As Integer

        Function FindFieldContinue(tableName As String, idNo As Integer) As Integer

        Function GetAll(ByRef Optional sortKey As String = Nothing) As Object

        Function GetDefaultFieldValues(ByVal tableName As String)

        Function GetFilteredRecords(filterExpression As String, Optional ByRef sortKey As String = Nothing) As Object

        Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String

        Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp)

        Function GetRecordById(Of TM As New)(idNo As Integer) As TM

        Function GetRecordCount(tableName As String) As Integer

        Function GetRecordDateTimeStamp(idNo As Integer, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object

        Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String

        Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String

        Function GetRecordPosition(tableName As String, idNo As Integer) As Integer

        Function GetRecords(ByVal tableName As String, ByVal sortKey As String, ByVal ParamArray fields() As String) As Object

        Function GetRecordsFiltered(ByVal tableName As String, ByVal sortKey As String, ByVal filterKey As String, ByVal ParamArray fields() As String) As Object

        Function GetRecordsWithIdNo(Of TM)(ByVal idNo As Integer, Optional ByRef sortKey As String = Nothing) As List(Of TM)

        Function GetRecordWithIdNo(idNo As Integer, tableName As String, returnFieldName As String) As String

        Function GetSortedRecordNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer

        Function GetSortedRecordPosition(idNo As Integer, tableName As String, sortOrder As String) As Integer

        Function GetSqlValue(Of TType)(ByVal sqlStatement As String, tableName As String, condition As String) As TType

        'Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList
        Function HasRecordChanged(idNo As Integer, tableName As String, timeStampedValue As Object, Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean

        Function InsertTvp(dtTable As DataTable) As Integer

        Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer

        Function UpdateRecord(ByVal model) As Integer

        Function UpdateRecordWithIdNo(Of T)(idNo As Integer, tableName As String, fieldName As String, ByRef value As T) As Integer

        Function UpdateTvp(dtTable As DataTable) As Integer

        Function IsValid(ByVal model) As Boolean

    End Interface

End Namespace