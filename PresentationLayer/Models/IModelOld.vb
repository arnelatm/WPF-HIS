' IBModel interface, part of MVP design pattern.
Imports AATM.Libraries

Public Interface IModelOld

    Sub SetService(pService)

    Function GetMainTableColumnProperties(tableName As String) As List(Of TblColPropModel)

    Function GetDefaultFieldValues(tableName As String) As List(Of DefaultFieldValueModel)

    Function GetRecordById(Of TM As New)(idNo As Integer) As TM

    Function GetAll(Of TM As New)(Optional ByRef sortExpression As String = Nothing) As List(Of TM)

    Function AddRecord(Of TBiz)(ByRef displayModel As TBiz) As Integer

    Function GetRecordsWithIdNo(Of TM As New)(idNo As Integer, Optional ByRef sortExpression As String = Nothing) _
        As List(Of TM)

    Function UpdateRecord(Of TBiz)(ByRef modelBiz As TBiz) As Integer

    Function GetSortedRecordNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer

    Function GetSortedRecordPosition(idNo As Integer, tableName As String, sortOrder As String) As Integer

    Function GetRecordCount(tableName As String) As Integer

    Function GetRecordPosition(tableName As String, dno As Integer) As Integer

    Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean) _
        As Integer

    Function FindFieldContinue(tableName As String, idNo As Integer) As Integer

    Function DeleteRecord(idNo As Integer, tableName As String) As Integer

    Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                   returnFieldName As String) As String

    Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer

    Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                 searchFieldName1 As String, searchFieldName2 As String) As Integer

    Function GetRecordWithIdNo(idNo As Integer, tableName As String, returnFieldName As String) As String

    Function GetRecordDateTimeStamp(idNo As Integer, tableName As String,
                                    Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object

    Function HasRecordChanged(idNo As Integer, tableName As String, timeStampedValue As Object,
                              Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean

    Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList

    Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Integer) _
        As Boolean

    Function IsUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Integer) _
        As Boolean

    Function GetLastSortKey(searchValue As String, tableName As String) As String

    Function GetRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData)

    Function GetHRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.HLookupData)

    Function UpdateTvp(ByRef dtTable As DataTable) As Integer

    Function DelUpdateTvp(ByRef dtTable As DataTable, groupKey As Integer) As Integer

    Function InsertTvp(dtTable As DataTable) As Integer

    Function GetRecordsFiltered(tableName As String, sortKey As String, filterKey As String,
                                ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetRecords2Columns(tableName As String, sortKey As String, ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData)

    Function GetRecords2ColumnsFiltered(tableName As String, sortKey As String, filterKey As String,
                                        ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetLookupDataByName(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData)

    Function GetLookupDataByNameWithCode(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData)

    Function GetLookupDataByCode(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData)

    Function GetLookupFilteredDataByName(tableName As String, sortKey As String, filterKey As String,
                                         ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function GetLookupFilteredDataByCode(tableName As String, sortKey As String, filterKey As String,
                                         ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData)

    Function Login(userName As String, password As String) As Boolean

    Sub Logout()
End Interface