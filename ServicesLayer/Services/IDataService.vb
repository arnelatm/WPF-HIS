Imports AATM.DataLayer
Imports AATM.Libraries.AatmInterfaces

Namespace Services

    Public Interface IDataService

        Function AddRecord(ByRef model As Object) As Integer

        Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean

        Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer

        Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

        Function DeleteRecord(idNo As Int32, tableName As String) As Integer

        Function DelUpdateTvp(dtTable As DataTable, groupKey As Integer) As Integer

        Function FindFieldNew(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer

        Function FindDateField(tableName As String, findableControl As IFindableControl, Optional filter As String = Nothing) As Integer

        Function FindFieldContinue(tableName As String, idNo As Int32, sortOrderKey As String) As Integer

        Function GetAll(ByRef Optional sortKey As String = Nothing) As Object

        Function GetDefaultFieldValues(tableName As String)

        Function GetLastSortKey(searchValue As String, tableName As String) As String

        Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp)

        Function GetRecordByIdNo(Of TM As New)(idNo As Int32) As TM

        Function GetRecordCount(tableName As String, Optional filter As String = Nothing) As Integer

        Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object

        Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String

        Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String

        Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T

        Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object

        Function GetRecordPosition(tableName As String, idNo As Int32) As Integer

        Function FieldExistInTable(tableName As String, fieldName As String) As Boolean

        Function GetRecords(tableName As String, sortKey As String, fields As String(), Optional filterKey As String = Nothing) As Object

        Function GetRecordsWithGroupIdNo(Of TM)(idNo, Optional ByRef sortKey = Nothing) As List(Of TM)

        Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object

        Function GetFieldsWithIdNo(idNo As Object, tableName As String, fields As String) As Object

        Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer

        Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer

        Function GetFieldValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType

        Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object, Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean

        Function InsertTvp(dtTable As DataTable) As Integer

        Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer

        Function UpdateRecord(model) As Integer

        Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, ByRef value As T) As Integer

        Function UpdateTvp(dtTable As DataTable) As Integer

        Function GetRecordField(tableName As String, returnFieldName As String) As Object

        Function GetFieldType(tableName As String, fieldName As String) As Object

        Function GenericUpdateRecordWithIdNo(Of T)(idNo As Integer, tableName As String, fieldName As String, value As T) As Integer

        Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object

        Function GetField(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String, Optional filter As String = Nothing) As TR

    End Interface

End Namespace