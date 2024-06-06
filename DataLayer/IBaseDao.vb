Imports System.Dynamic
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.AatmInterfaces

Public Interface IBaseDao

    Function AddSecurityObject(securityObject As SecurityObject) As Integer

    Function CheckIfUnique(searchValue As String, tableName As String, searchFieldName As String, currentIdNo As Long) As String

    Function CountRecordWith2Key(Of TS1, TS2)(tableName As String, searchFieldName1 As String, searchFieldName2 As String, searchValue1 As TS1, searchValue2 As TS2) As Integer

    Function CountRecordWith3Key(Of TS1, TS2, TS3)(tableName As String, searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String, searchValue1 As TS1, searchValue2 As TS2, searchValue3 As TS3) As Integer

    Function CountRecordWithKey(Of TS1)(tableName As String, searchFieldName As String, searchValue As TS1) As Integer

    Function DeleteRecord(idNo As Int32, tableName As String) As Int32

    Function DeleteRecord(Of T)(keyFieldValue As T, tableName As String, keyFieldName As String) As Int32

    Function ExecuteTvpSp(ByRef procedureName As String, dataTable As DataTable) As Integer

    Function FieldExistInTable(tableName As String, fieldName As String) As Boolean

    Function FindDateField(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer

    Function FindFieldContinue(tableName As String, lastIdNo As Int32, sortOrderKey As String) As Object

    Function FindFieldNew(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer

    Function GenericUpdateRecordWithIdNo(Of T)(idNo As Integer, tableName As String, fieldName As String, value As T, Optional primaryKey As String = "IdNo") As Integer

    Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String

    Function GetDataSet(storedProcedureName As String, parameters As Object) As DataSet

    Function GetDataTable(tableName As String, Optional sortField As String = Nothing, Optional fieldsList As String = Nothing, Optional filter As String = Nothing) As DataTable

    Function GetField(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String, Optional filter As String = Nothing) As TR
    Function GetField(Of TR, TS1, TS2)(searchValue1 As TS1, searchValue2 As TS2, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String, Optional filter As String = Nothing) As TR

    Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object

    Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object

    Function GetFieldsWithIdNo(idNo As Object, tableName As String, fieldsList As String, Optional primaryFieldName As String = Nothing) As ExpandoObject

    Function GetFieldType(tableName As String, fieldName As String) As Object

    Function GetFieldValue(Of TType)(returnFieldName As String, tableName As String, condition As String) As TType

    Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object

    Function GetIcIdNoWithName(codeGroup As CodeGroupSelection, fieldValue As String, Optional fieldName As String = Nothing, Optional idFieldName As String = Nothing) As Int32

    Function GetIcNameWithIdNo(codeGroup As CodeGroupSelection, fieldValue As Integer, Optional fieldName As String = Nothing, Optional idFieldName As String = Nothing) As String

    Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer

    Function GetIdNoWithKey(Of T)(tableName As String, fieldValue As String, Optional fieldName As String = Nothing, Optional idFieldName As String = Nothing) As T

    Function GetLastSeriesNumber(ByVal seriesName As String) As Integer

    Function GetLastSortKey(searchValue As String, tableName As String) As String

    Function GetMasterList(tableName As String, sortKey As String, fieldNames() As String, Optional filterKey As String = Nothing) As Object

    Function GetNextSeries(ByVal schemaName As String, ByVal seriesName As String) As Integer

    Function GetNextSeries(ByVal seriesName As String) As Integer

    Function GetPrintJobIdNo(reportFileName As String) As Integer

    Function GetRecordCount(tableName As String, Optional Filter As String = Nothing) As Integer
    Function GetRecordCount(Of TS1)(tableName As String, fieldName As String, fieldValue As TS1, Optional filter As String = Nothing) As Integer
    Function GetRecordCount(Of TS1, TS2)(tableName As String, fieldName1 As String, FieldName2 As String, fieldValue1 As TS1, fieldValue2 As TS2, Optional filter As String = Nothing) As Integer
    Function GetRecordCount(Of TS1, TS2, TS3)(tableName As String, fieldName1 As String, FieldName2 As String, FieldName3 As String, fieldValue1 As TS1, fieldValue2 As TS2, fieldValue3 As TS3, Optional filter As String = Nothing) As Integer

    Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, dateTimeStampField As String) As Object

    Function GetRecordField(tableName As String, returnFieldName As String) As Object

    Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String) As ExpandoObject
    Function GetTopOneFields(tableName As String, fieldList As String, filter As String, order As String, orderAscending As Boolean) As ExpandoObject

    Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String

    Function GetRecordFieldWith2KeyG(Of T1, T2, T3)(searchValue1 As T1, SEARCHvALUE2 As T2, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As T3

    Function GetRecordFieldWith3KeyG(Of S1, S2, S3, R1)(tableName As String, searchValue1 As S1, searchValue2 As S2, searchValue3 As S3, searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String, returnFieldName As String) As R1

    Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String

    Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T

    Function GetRecordFieldWithKeyG(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String) As TR

    Function GetRecordPosition(tableName As String, idNo As Int32, Optional IdFieldName As String = Nothing) As Integer
    Function GetRecordPositionByKey(Of T)(keyValue As T, tableName As String, sortKey As String, keyFieldName As String) As Integer

    Function GetRecordPositionByName(tableName As String, sortField As String, nameValue As String) As Integer

    Function GetRecords(tableName As String, sortKey As String, Optional fieldNames As String() = Nothing, Optional filterKey As String = Nothing, Optional ascending As Boolean = True) As Object

    'Function GetRecordsDataTable(tableName As String, sortKey As String, Optional fieldNames() As String = Nothing, Optional filterKey As String = Nothing) As Object

    Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer

    Function GetSpRecords(spName As String, fieldList As String, sortKey As String, filter As String, ParamArray parameters As Array()) As Object

    Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList

    Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList

    Function HasRecordChanged(idNo As Int32, tableName As String, timeStampValue As Byte, Optional timeStampedField As String = "DateTimeStamp") As Boolean

    Function InitializeSecurityObject() As Integer

    Function InsertRecord(tableName As String, fields As Object(), fieldTypes As Object(), ParamArray Values() As Object) As Integer

    Function IsFieldUnique(tableName As String, fieldName As String) As Boolean

    Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) As Integer

    Function UpdateRecordWithKey(Of T1, T2)(tableName As String, keyFieldName As String, keyFieldValue As T1, fieldToReplace As String, replaceValue As T2) As Integer
    Function GetDtRecords(tableName As String, fieldNames As String, filterKey As String, sortKey As String, ascending As Boolean) As DataTable
    Function DeleteRecords(Of T)(keyFieldValue As T, tableName As String, keyFieldName As String) As Integer
    Function RunSpWithRollBack(storedProcedureName As String, parameters As Object) As Object
    Function GetField(Of TR, TS1, TS2, TS3)(searchValue1 As TS1, searchValue2 As TS2, searchValue3 As TS3, tableName As String, searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String, returnFieldName As String, Optional filter As String = Nothing) As TR
    'Function PerformUtility(utilityName As String, Optional parameters As Object = Nothing) As Object
    Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String, parameter As Object) As ExpandoObject
    Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String, parameter As Object, sortKey As String) As ExpandoObject
    Function GetRecordWithIdNo(tableName As String, fieldList As String, IdNo As Integer) As ExpandoObject


End Interface

Public Interface IAutoCodeDao

    Function GenerateCode(idNo As Integer) As String

End Interface

