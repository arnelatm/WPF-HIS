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

    Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean) _
        As Integer

    Function FindFieldContinue(tableName As String, idNo As Int32) As Integer

    Function GetAll(Of TM As New)(Optional ByRef sortExpression As String = Nothing) As List(Of TM)

    Function GetHRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.HLookupData)

    Function GetLastSortKey(searchValue As String, tableName As String) As String

    Function GetLookupDataByCode(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData)

    Function GetLookupDataByName(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData)

    Function GetLookupDataByNameWithCode(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData)

    Function GetLookupFilteredDataByCode(tableName As String, sortKey As String, filterKey As String,
                                         ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetLookupFilteredDataByName(tableName As String, sortKey As String, filterKey As String,
                                         ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetRecordById(Of TM As New)(idNo As Int32) As TM

    'Function GetRecordByIdNo(Of TM As New)(idNo As Int32) As TM

    Function GetRecordCount(tableName As String) As Integer

    Function GetRecordDateTimeStamp(idNo As Int32, tableName As String,
                                    Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object

    Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                   returnFieldName As String) As String

    Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String,
                                   returnFieldName As String) As T

    Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                    searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) _
        As String

    Function GetRecordPosition(tableName As String, dno As Integer) As Integer

    Function GetRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData)

    Function GetRecords2Columns(tableName As String, sortKey As String, ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData)

    Function GetRecords2ColumnsFiltered(tableName As String, sortKey As String, filterKey As String,
                                        ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) _
        As Integer

    Function GetRecordsFiltered(tableName As String, sortKey As String, filterKey As String,
                                ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetRecordsWithIdNo(Of TM As New)(idNo As Int32, Optional ByRef sortExpression As String = Nothing) _
        As List(Of TM)

    Function GetRecordWithIdNo(idNo As Int32, tableName As String, returnFieldName As String) As String

    Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer

    Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String) As Integer

    'Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int32) As ArrayList

    Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object,
                              Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean

    Function InsertTvp(dtTable As DataTable) As Integer

    Function IsUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean

    Function Login(userName As String, password As String) As Boolean

    'Function UpdateRecord(Of TBiz)(ByRef modelBiz As TBiz) As Integer
    Function UpdateRecord(Of TM)(ByRef modelBiz As TM) As Integer

    Function UpdateTvp(ByRef dtTable As DataTable) As Integer

    Sub Logout()

    Function GetSqlValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType
    Function GetControlSecurityIdNo(searchValue As String) As String
    Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int32) As ArrayList
    Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int32) As ArrayList
End Interface