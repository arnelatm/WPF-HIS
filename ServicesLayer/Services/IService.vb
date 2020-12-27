Imports AATM.DataLayer

Namespace Services

    Public Interface IService

        Function AddRecord(ByRef model As Object) As Integer

        Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean

        Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer

        Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

        Function DeleteRecord(idNo As Int32, tableName As String) As Integer

        Function DelUpdateTvp(dtTable As DataTable, groupKey As Integer) As Integer

        Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean) As Integer

        Function FindFieldContinue(tableName As String, idNo As Int32) As Integer

        Function GetAll(ByRef Optional sortKey As String = Nothing) As Object

        Function GetDefaultFieldValues(ByVal tableName As String)

        Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String

        Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp)

        Function GetRecordById(Of TM As New)(idNo As Int32) As TM

        Function GetRecordCount(tableName As String) As Integer

        Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object

        Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String

        Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String

        Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T

        Function GetMaxValueFiltered(searchFieldName As String, tableName As String, returnFieldName As String, filter As String) As Object

        Function GetRecordPosition(tableName As String, idNo As Int32) As Integer

        Function GetRecords(ByVal tableName As String, ByVal sortKey As String, ByVal ParamArray fields() As String) As Object

        Function GetFields(ByVal tableName As String, ByVal sortKey As String, ByVal ParamArray fields() As String) As Object

        Function GetFilteredRecords(ByVal tableName As String, ByVal sortKey As String, ByVal filterKey As String, ByVal ParamArray fields() As String) As Object

        Function GetRecordsWithIdNo(Of TM)(ByVal idNo, Optional ByRef sortKey = Nothing) As List(Of TM)

        Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object

        Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer

        Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String) As Integer

        Function GetSqlValue(Of TType)(ByVal sqlStatement As String, tableName As String, condition As String) As TType

        Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object, Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean

        Function InsertTvp(dtTable As DataTable) As Integer

        Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer

        Function UpdateRecord(ByVal model) As Integer

        Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, ByRef value As T) As Integer

        Function UpdateTvp(dtTable As DataTable) As Integer

        Function IsValid(ByVal model) As Boolean

        Function GetControlSecurityIdNo(searchValue As String) As String

        Function GetUserSecurity(securityObjectIdNo As Int16, securityGroupIdNo As Int16) As ArrayList

        Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList

        Function GetRecordField(tableName As String, returnFieldName As String) As Object

    End Interface

End Namespace