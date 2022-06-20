Imports System.Dynamic
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer
Imports AATM.Libraries.AatmInterfaces

Namespace Services

    Public Interface IService

        Function AddRecord(ByRef model As Object) As Integer

        Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean

        Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer

        Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

        Function DeleteRecord(idNo As Int32, tableName As String) As Integer

        Function DelUpdateTvp(dtTable As DataTable, groupKey As Integer) As Integer

        'Function FindField(tableName As String, fieldName As String, searchString As String, searchPlace As Char, Optional filter As String = Nothing) As Integer

        Function FindFieldNew(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer

        Function FindDateField(tableName As String, findableControl As IFindableControl, Optional filter As String = Nothing) As Integer

        Function FindFieldContinue(tableName As String, idNo As Int32, sortOrderKey As String) As Integer

        'Function GetAll(ByRef Optional sortKey As String = Nothing) As Object

        'Function GetDefaultFieldValues(ByVal tableName As String)

        Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String

        Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp)

        Function GetRecordByIdNo(Of TM As New)(idNo As Int32) As TM

        Function GetRecordCount(tableName As String, Optional filter As String = Nothing) As Integer

        Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object

        Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String
        Function GetRecordFieldWith2Keyg(oF T1, T2, T3)(searchValue1 As T1, searchValue2 As T2, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As T3

        Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String

        Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T

        Function GetRecordFieldWithKeyG(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String) As TR

        Function GetRecordPosition(tableName As String, idNo As Int32) As Integer

        Function FieldExistInTable(ByVal tableName As String, ByVal fieldName As String) As Boolean

        Function GetRecords(ByVal tableName As String, ByVal sortKey As String, ByVal fields As String(), Optional filterKey As String = Nothing) As Object

        Function GetRecordsWithGroupIdNo(Of TM)(ByVal idNo, Optional ByRef sortKey = Nothing) As List(Of TM)

        Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object

        Function GetFieldsWithIdNo(idNo As Object, tableName As String, fields As String) As Object

        Function GetSpRecords(spName As String, fields As String, sortKey As String, filter As String) As Object

        Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer

        Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer

        Function GetFieldValue(Of TType)(ByVal sqlStatement As String, tableName As String, condition As String) As TType

        Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object, Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean

        Function InsertTvp(dtTable As DataTable) As Integer

        Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer

        Function UpdateRecord(ByVal model) As Integer

        Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, ByRef value As T) As Integer

        Function UpdateTvp(dtTable As DataTable) As Integer

        Function IsValid(ByVal model) As Boolean

        Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String

        Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList

        Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList

        Function GetRecordField(tableName As String, returnFieldName As String) As Object

        Function GetFieldType(tableName As String, fieldName As String) As Object

        Function AddSecurityObject(securityObjectName As SecurityObject) As Integer

        Function InitializeSecurityObject() As Integer

        Function GenericUpdateRecordWithIdNo(Of T)(idNo As Integer, tableName As String, fieldName As String, value As T) As Integer

        Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object

        Function GetField(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String, Optional filter As String = Nothing) As TR

        Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, groupIdNo As Integer) As Integer

        Function GetNextSeries(seriesName As String) As Integer

        Function ExecuteTvpSp(ByRef userProcedureName As String, dtTable As DataTable) As Integer

        Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String) As ExpandoObject

        Function GetDataSet(storedProcedureName As String, parameters As Object) As DataSet

        Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object
        Function InsertRecord(tableName As String, fieldList As Object(), values As Object(), fieldType As Object()) As Integer
        Function UpdateTable(ByRef data As DataTable, groupIdNo As Integer) As Integer
    End Interface

End Namespace