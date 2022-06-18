Imports System.Dynamic
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.AatmInterfaces

Public Interface IBaseDao

    'Function CheckIfUnique(control As Control, tableName As String, fieldName As String, targetIdNo As Int32)
    Function CheckIfUnique(searchValue As String, tableName As String, searchFieldName As String, currentIdNo As Long) _
        As String

    Function CountRecordWith2Key(searchValue1 As Integer, searchValue2 As String, tableName As String,
                                 searchFieldName1 As String, searchFieldName2 As String) As Int32

    'Function CountRecordWith2KeyG(Of T1, T2, T3)(searchValue1 As T1, searchValue2 As T2, tableName As String,
    '                             searchFieldName1 As String, searchFieldName2 As String) As T3

    Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

    Function DeleteRecord(idNo As Int32, tableName As String) As Int32

    'Function FindField(tableName As String, fieldName As String, searchString As String, Optional searchPlace As Char = "A", Optional filter As String = Nothing) As Integer

    Function FindFieldNew(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer

    Function FindDateField(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer

    Function FindFieldContinue(tableName As String, lastIdNo As Int32, sortOrderKey As String) As Object

    Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String

    Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object

    Function GetField(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String, Optional filter As String = Nothing) As TR

    Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String) As ExpandoObject

    Function GetSpRecords(spName As String, fieldList As String, sortKey As String, filter As String, ParamArray parameters As Array()) As Object

    Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object

    Function GetFieldsWithIdNo(idNo As Object, tableName As String, fieldsList As String) As ExpandoObject

    Function GetRecords(tableName As String, sortKey As String, fieldNames As String(), Optional filterKey As String = Nothing) As Object

    Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer

    Function GetLastSortKey(searchValue As String, tableName As String) As String

    Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object

    Function GetRecordCount(tableName As String, Optional Filter As String = Nothing) As Integer

    Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, dateTimeStampField As String) As Object

    Function GetRecordField(tableName As String, returnFieldName As String) As Object

    Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                    searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) _
        As String


    Function GetRecordFieldWith2KeyG(Of T1, T2, T3)(searchValue1 As T1, SEARCHvALUE2 As T2, tableName As String, searchFieldName1 As String, searchFieldName2 as String, returnFieldName As String) As T3

    Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                       returnFieldName As String) As String

    Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String,
                                   returnFieldName As String) As T

    Function GetRecordFieldWithKeyG(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String,
                                          returnFieldName As String) As TR

    Function GetRecordPosition(tableName As String, idNo As Int32) As Integer

    Function GetRecordPositionByName(tableName As String, sortField As String, nameValue As String) As Integer

    'Function GetRecordsByField(tableName As String, sortKey As String, fieldNames As String(), Optional filter As String = Nothing) As Object

    Function FieldExistInTable(tableName As String, fieldName As String) As Boolean

    Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer

    Function GetFieldValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType

    Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList

    Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList

    Function HasRecordChanged(idNo As Int32, tableName As String, timeStampValue As Byte,
                              Optional timeStampedField As String = "DateTimeStamp") As Boolean

    Function IsFieldUnique(tableName As String, fieldName As String) As Boolean

    Function GetFieldType(tableName As String, fieldName As String) As Object

    Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) As Integer

    Function AddSecurityObject(securityObject As SecurityObject) As Integer

    Function InitializeSecurityObject() As Integer

    Function GenericUpdateRecordWithIdNo(Of T)(idNo As Integer, tableName As String, fieldName As String, value As T) As Integer

    Function GetLastSeriesNumber(ByVal seriesName As String) As Integer

    Function GetNextSeries(ByVal seriesName As String) As Integer

    Function GetNextSeries(ByVal schemaName As String, ByVal seriesName As String) As Integer

    Function ExecuteTvpSp(ByRef procedureName As String, dataTable As DataTable) As Integer

    Function GetMasterList(tableName As String, sortKey As String, fieldNames() As String, Optional filterKey As String = Nothing) As Object

    Function GetDataSet(storedProcedureName As String, parameters As Object) As DataSet

    Function InsertRecord(tableName As String, fields As Object(),  fieldTypes As Object(), ParamArray Values() As Object) As Integer
    'Function ExecuteCommand() As Integer

    'Function GetRecords(tableName As String, fieldList As String, filter As String) As ExpandoObject
End Interface