' IBModel interface, part of MVP design pattern.
Imports AATM.Libraries

Public Interface IModel

    Function AddRecord(Of TBiz)(ByRef displayModel As TBiz) As Integer

    Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean

    Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer

    Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

    Function DeleteRecord(idNo As Int32, tableName As String) As Integer

    Function DelUpdateTvp(ByRef dtTable As DataTable, groupKey As Integer) As Integer

    Function FieldExistInTable(tableName As String, fieldName As String) As Boolean

    Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean, Optional filter As String = Nothing) As Integer

    Function FindFieldContinue(tableName As String, idNo As Int32) As Integer

    Function GetAll(Of TM As New)(Optional ByRef sortExpression As String = Nothing) As List(Of TM)

    Function GetBizObject() As Object

    Function GetBizObjectErrors() As IEnumerable(Of Object)

    Function GetBizObjectRules() As Object

    Function GetControlSecurityIdNo(searchValue As String) As String

    Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object

    Function GetFieldsWithIdNo(idNo As Object, tableName As String, fields As String) As Object

    Function GetFieldValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType

    Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object

    Function GetLookupByCodeName(tableName As String, sortKey As String, fields As String(), Optional filterKey As String = Nothing) As List(Of ClassesLibrary.LookupData)

    Function GetLookupByName(tableName As String, sortKey As String, fields As String(), Optional filterKey As String = Nothing) As List(Of ClassesLibrary.LookupData)

    Function GetLookupByNameCode(tableName As String, sortKey As String, fields As String(), Optional filterKey As String = Nothing) As List(Of ClassesLibrary.LookupData)

    Function GetHRecords(tableName As String, sortKey As String, fields As String(), Optional filter As String = Nothing) As List(Of ClassesLibrary.HLookupData)

    Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer

    Function GetLastSortKey(searchValue As String, tableName As String) As String

    Function GetLookup(tableName As String, sortKey As String, fields As String(), Optional filter As String = Nothing) As List(Of ClassesLibrary.LookupData)

    Function GetLookupRecords(tableName As String, sortKey As String, fields As String(), Optional filter As String = Nothing) As Object

    Function GetRecordByIdNo(Of TM As New)(idNo As Int32) As TM

    Function GetRecordCount(tableName As String, Optional filter As String = Nothing) As Integer

    Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object

    Function GetRecordField(tableName As String, returnFieldName As String) As Object

    Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String

    Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String

    Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T

    Function GetRecordPosition(tableName As String, dno As Integer) As Integer

    Function GetRecords(tableName As String, sortKey As String, fields As String(), Optional filterKey As String = Nothing) As Object

    'Function GetRecordsByField(tableName As String, sortKey As String, fields As String(), Optional filter As String = Nothing) As Object

    Function GetRecordsWithGroupIdNo(Of TM As New)(idNo, Optional ByRef sortExpression = Nothing) As List(Of TM)

    Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer

    Function GetUserSecurity(securityObjectIdNo As Int16, securityGroupIdNo As Int16) As ArrayList

    Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList

    Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object, Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean

    Function InsertTvp(dtTable As DataTable) As Integer

    Function IsUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean

    Function IsValid(Of TM)(ByRef dModel As TM) As Object

    Function Login(userName As String, password As String) As Boolean

    Function UpdateRecord(Of TM)(ByRef modelBiz As TM) As Integer

    Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) As Integer

    Function UpdateTvp(ByRef dtTable As DataTable) As Integer

    Sub Logout()

End Interface