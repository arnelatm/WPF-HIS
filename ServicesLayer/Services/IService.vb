Imports System.Dynamic
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer
Imports AATM.Libraries.AatmInterfaces

Namespace Services

    Public Interface IService
        Function AddRecord(ByRef model As Object) As Integer
        Function AddSecurityObject(securityObjectName As SecurityObject) As Integer
        Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean
        Function CountRecordWith2Key(Of TS1, TS2)(tableName As String, searchFieldName1 As String, searchFieldName2 As String, searchValue1 As TS1, searchValue2 As TS2) As Integer
        Function CountRecordWith3Key(Of TS1, TS2, TS3)(tableName As String, searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String, searchValue1 As TS1, searchValue2 As TS2, searchValue3 As TS3) As Integer
        Function CountRecordWithKey(Of TS1)(tableName As String, searchFieldName As String, searchValue As TS1) As Integer
        Function DeleteRecord(idNo As Int32, tableName As String) As Integer
        Function DelUpdateTvp(dtTable As DataTable, groupKey As Integer) As Integer
        Function ExecuteTvpSp(ByRef userProcedureName As String, dtTable As DataTable) As Integer
        Function FieldExistInTable(ByVal tableName As String, ByVal fieldName As String) As Boolean
        Function FindDateField(tableName As String, findableControl As IFindableControl, Optional filter As String = Nothing) As Integer
        Function FindFieldContinue(tableName As String, idNo As Int32, sortOrderKey As String) As Integer
        Function FindFieldNew(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer
        Function GenericUpdateRecordWithIdNo(Of T)(idNo As Integer, tableName As String, fieldName As String, value As T) As Integer
        Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String
        Function GetDataSet(storedProcedureName As String, parameters As Object) As DataSet
        Function GetField(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String, Optional filter As String = Nothing) As TR
        Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object
        Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object
        Function GetFieldsWithIdNo(idNo As Object, tableName As String, fields As String, Optional primaryFieldName As String = Nothing) As Object
        Function GetFieldType(tableName As String, fieldName As String) As Object
        Function GetFieldValue(Of TType)(ByVal sqlStatement As String, tableName As String, condition As String) As TType
        Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object
        Function GetIcIdNoWithName(groupCode As CodeGroupSelection, itemName As String) As Integer
        Function GetIcNameWithIdNo(groupCode As CodeGroupSelection, idNo As Int32) As String
        Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer
        Function GetIdNoWithName(Of T)(tableName As String, itemName As String, Optional fieldName As String = Nothing, Optional idFieldName As String = Nothing) As T
        Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String
        Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp)
        Function GetNextSeries(seriesName As String) As Integer
        Function GetPrintSetupIdNo(reportName As String) As Integer
        Function GetRecordByIdNo(Of TM As New)(idNo As Int32) As TM
        Function GetRecordCount(tableName As String, Optional filter As String = Nothing) As Integer
        Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object
        Function GetRecordField(tableName As String, returnFieldName As String) As Object
        Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String) As ExpandoObject
        Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String
        Function GetRecordFieldWith2Keyg(Of T1, T2, T3)(searchValue1 As T1, searchValue2 As T2, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As T3
        Function GetRecordFieldWith3Keyg(Of T1, T2, T3, R)(tableName As String, searchValue1 As T1, searchValue2 As T2, searchValue3 As T3, searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String, returnFieldName As String) As R
        Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String
        Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T
        Function GetRecordFieldWithKeyG(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String) As TR
        Function GetRecordPosition(tableName As String, idNo As Int32, Optional IdFieldName As String = Nothing) As Integer
        Function GetRecordPositionByKey(Of T)(keyValue As T, tableName As String, sortKey As String, Optional KeyFieldName As String = Nothing) As Integer
        Function GetRecords(ByVal tableName As String, ByVal sortKey As String, ByVal Optional fields As String() = Nothing, Optional filterKey As String = Nothing) As Object
        'Function GetRecordsDataTable(tableName As String, sortKey As String, Optional fields() As String = Nothing, Optional filterKey As String = Nothing) As DataTable
        Function GetRecordsWithGroupIdNo(Of TM)(ByVal idNo, Optional ByRef sortKey = Nothing) As List(Of TM)
        Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer
        Function GetSpRecords(spName As String, fields As String, sortKey As String, filter As String) As Object
        Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList
        Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList
        Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object, Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean
        Function InitializeSecurityObject() As Integer
        Function InsertRecord(tableName As String, fieldList As Object(), values As Object(), fieldType As Object()) As Integer
        Function InsertTvp(dtTable As DataTable) As Integer
        Function IsValid(ByVal model) As Boolean
        Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer
        Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, groupIdNo As Integer) As Integer
        Function UpdateRecord(ByVal model) As Integer
        Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, ByRef value As T) As Integer
        Function UpdateTable(ByRef data As DataTable, groupIdNo As Integer) As Integer
        Function UpdateTvp(dtTable As DataTable) As Integer
        Function GetDtRecords(tableName As String, Optional fields As String = Nothing, Optional filterKey As String = Nothing, Optional sortKey As String = Nothing) As Object
    End Interface

End Namespace