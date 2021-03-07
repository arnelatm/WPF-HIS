' IBModel interface, part of MVP design pattern.
Imports AATM.Libraries

Public Interface IModel

    Function AddRecord(Of TBiz)(ByRef displayModel As TBiz) As Integer

    Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) _
        As Boolean

    Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                 searchFieldName1 As String, searchFieldName2 As String) As Integer

    Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

    Function DeleteRecord(idNo As Int32, tableName As String) As Integer

    Function DelUpdateTvp(ByRef dtTable As DataTable, groupKey As Integer) As Integer

    Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean) As Integer

    Function FindFieldContinue(tableName As String, idNo As Int32) As Integer

    Function GetAll(Of TM As New)(Optional ByRef sortExpression As String = Nothing) As List(Of TM)

    Function GetControlSecurityIdNo(searchValue As String) As String

    Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object

    Function GetFieldsWithIdNo(idNo As Object, tableName As String, fields As String) As Object

    Function GetFilteredLookupByCodeName(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetFilteredLookupByName(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetFilteredLookupByNameCode(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetFilteredLookupRecords(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetFilteredRecords(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As Object

    Function GetHRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.HLookupData)

    Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer

    Function GetLastSortKey(searchValue As String, tableName As String) As String

    Function GetLookup(tableName As String, sortKey As String, ByVal ParamArray fields() As String)

    Function GetLookupNew(tableName As String, sortKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetMaxValueFiltered(searchFieldName As String, tableName As String, returnFieldName As String, filter As String) As Object

    Function GetRecordById(Of TM As New)(idNo As Int32) As TM

    Function GetRecordCount(tableName As String) As Integer

    Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object

    Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String

    Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String

    Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T

    Function GetRecordPosition(tableName As String, dno As Integer) As Integer

    Function GetLookupRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) As Object

    Function GetRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) As Object

    Function GetFields(tableName As String, sortKey As String, ByVal ParamArray fields() As String)

    Function GetRecordsWithGroupIdNo(Of TM As New)(idNo, Optional ByRef sortExpression = Nothing) As List(Of TM)

    Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String) As Integer

    Function GetFieldValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType

    Function GetUserSecurity(securityObjectIdNo As Int16, securityGroupIdNo As Int16) As ArrayList

    Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList

    Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object, Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean

    Function InsertTvp(dtTable As DataTable) As Integer

    Function IsUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean

    Function Login(userName As String, password As String) As Boolean

    Sub Logout()

    'Function UpdateRecord(Of TBiz)(ByRef modelBiz As TBiz) As Integer
    Function UpdateRecord(Of TM)(ByRef modelBiz As TM) As Integer

    Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) As Integer

    Function UpdateTvp(ByRef dtTable As DataTable) As Integer

    'Function IsValid(dataModel As Object) As Boolean

    Function GetBizObjectErrors() As IEnumerable(Of Object)

    Function GetBizObjectRules() As Object

    Function GetBizObject() As Object

    Function IsValid(Of TM)(ByRef dModel As TM) As Object

    Function GetRecordField(tableName As String, returnFieldName As String) As Object

End Interface