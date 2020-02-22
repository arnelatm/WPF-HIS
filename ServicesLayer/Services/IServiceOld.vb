Imports AATM.DataLayer

Namespace Services

    Public Interface IServiceOld

        Function GetRecordById(idNo As Integer)

        Function GetAll(Optional ByRef sortKey As String = "")

        Function UpdateRecord(Of TBiz)(ByRef modelBiz As TBiz) As Integer

        Function AddRecord(ByRef modelBiz) As Integer

        Function GetDefaultFieldValues(ByVal tableName As String)

        Function GetRecordsWithIdNo(ByVal idNo As Integer, Optional ByRef sortKey As String = Nothing)

        'Function GetRecordsByIdNo(Of TM As New)(ByVal idNo As Integer, Optional ByRef SortKey As String = nothing) As List(Of TM)
        Function GetSortedRecordNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer

        Function GetSortedRecordPosition(idNo As Integer, tableName As String, sortOrder As String) As Integer

        Function GetRecordCount(tableName As String) As Integer

        Function GetRecordPosition(tableName As String, idNo As Integer) As Integer

        Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean) _
            As Integer

        Function FindFieldContinue(tableName As String, idNo As Integer) As Integer

        Function DeleteRecord(idNo As Integer, tableName As String) As Integer

        Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                       returnFieldName As String) As String

        Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

        Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer

        Function GetRecordWithIdNo(idNo As Integer, tableName As String, returnFieldName As String) As String

        Function HasRecordChanged(idNo As Integer, tableName As String, timeStampedValue As Object,
                                  Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean

        Function GetRecordDateTimeStamp(idNo As Integer, tableName As String,
                                        Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object

        Function GetHRecords(ByVal tableName As String, ByVal sortKey As String, ByVal ParamArray fields() As String) As Object

        Function GetFilteredRecords(filterExpression As String, ByRef Optional sortKey As String = Nothing) As Object

        Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList

        Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean

        Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String

        Function UpdateTvp(dtTable As DataTable) As Integer

        Function DelUpdateTvp(dtTable As DataTable, ByVal groupKey As Integer) As Integer

        Function InsertTvp(dtTable As DataTable) As Integer

        Function GetRecordsFiltered(ByVal tableName As String, ByVal sortKey As String, ByVal filterKey As String, ByVal ParamArray fields() As String) As Object

        Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp)

        Function TransactionUpdate(Of TBiz)(ByRef modelBiz As TBiz) As Integer

    End Interface
End NameSpace