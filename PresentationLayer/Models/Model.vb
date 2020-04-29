Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

''' <summary>
'''     The Model in MVP design pattern.
'''     Implements IModel and communicates with WCF Service.
''' </summary>
Public Class Model
    Implements IModel

    Private Shared ReadOnly Service As New Service()

    Private Shared ReadOnly LoginService As New ServiceLogin()

    Public Property DataService As Object

    Public Sub New(accountName As String)
        DataService = New Service(accountName)
    End Sub

    Public Sub New()
    End Sub

    Public Function GetRecordById(Of TM As New)(idNo As Int32) As TM _
        Implements IModel.GetRecordById
        Dim modelData As New TM
        If idNo <> 0 Then
            modelData = DataService.GetRecordById(Of TM)(idNo)
        End If
        Return modelData
    End Function

    Public Function GetAll(Of TM As New)(Optional ByRef sortExpression As String = Nothing) As List(Of TM) _
        Implements IModel.GetAll
        Dim bizData = DataService.GetAll(sortExpression)
        Dim modelObject As New List(Of TM)
        For Each bObject In bizData
            Dim model As TM
            model = GlobalVariables.Mapper.Map(Of TM)(bObject)
            modelObject.Add(model)
        Next
        Return modelObject
    End Function

    Public Function AddRecord(Of TM)(ByRef dataModel As TM) As Integer Implements IModel.AddRecord
        Dim newlyAddedRecordIdNo As Int32
        newlyAddedRecordIdNo = DataService.AddRecord(dataModel)
        Return newlyAddedRecordIdNo
    End Function

    Public Function GetRecordsWithIdNo(Of TM As New)(idNo As Int32, Optional ByRef sortKey As String = Nothing) As List(Of TM) _
        Implements IModel.GetRecordsWithIdNo
        Dim data = DataService.GetRecordsWithIdNo(Of TM)(idNo, sortKey)
        Return data
    End Function

    Public Function UpdateRecord(Of TM)(ByRef dataModel As TM) As Integer _
        Implements IModel.UpdateRecord
        Dim updateResult As Integer
        updateResult = DataService.UpdateRecord(dataModel)
        Return updateResult
    End Function

    'Public Function UpdateRecord(Of TBiz)(ByRef modelBiz As TBiz) As Integer _
    '    Implements IModel.UpdateRecord
    '    Dim updateResult As Integer
    '    updateResult = DataService.UpdateRecord(modelBiz)
    '    Return updateResult
    'End Function

    'Public Function UpdateRecord(ByRef modelBiz As TBiz) As Integer _
    '    Implements IModel.UpdateRecord
    '    Dim updateResult As Integer
    '    updateResult = DataService.UpdateRecord(modelBiz)
    '    Return updateResult
    'End Function

    Public Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) _
        As Integer _
        Implements IModel.UpdateRecordWithIdNo
        Dim updateResult As Integer
        updateResult = DataService.UpdateRecordWithidNo(idNo, tableName, fieldName, value)
        Return updateResult
    End Function

    Public Function GetHRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.HLookupData) _
        Implements IModel.GetHRecords
        Dim data = DataService.GetRecords(tableName, sortKey, fields)
        Dim tlData = New List(Of ClassesLibrary.HLookupData)
        For i = 1 To Int(data.Count / 4)
            Dim tData As New ClassesLibrary.HLookupData
            tData.IdNo = data(i * 4 - 4)
            tData.Name = data(i * 4 - 3)
            tData.ParentIdNo = CInt(If(data(i * 4 - 2) Is DBNull.Value, Nothing, data(i * 4 - 2)))
            tData.Code = If(data(i * 4 - 2) Is DBNull.Value, Nothing, data(i * 4 - 1))
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData) _
        Implements IModel.GetRecords
        Dim data = DataService.GetRecords(tableName, sortKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        If fields.Count = 3 Then
            For i = 1 To Int(data.Count / 3)
                Dim tData As New ClassesLibrary.LookupData
                tData.IdNo = If(data(i * 3 - 3).Equals(DBNull.Value), 0, CInt(data(i * 3 - 3)))
                tData.Name = data(i * 3 - 2) & " | " & data(i * 3 - 3)
                tData.Code = If(data(i * 3 - 1).Equals(DBNull.Value), "", data(i * 3 - 1))
                tlData.Add(tData)
            Next
        Else
            For i = 1 To Int(data.Count / 2)
                Dim tData As New ClassesLibrary.LookupData
                tData.IdNo = If(data(i * 2 - 2).Equals(DBNull.Value), 0, CInt(data(i * 2 - 2)))
                tData.Name = data(i * 2 - 1) & " | " & data(i * 2 - 2)
                tlData.Add(tData)
            Next
        End If
        Return tlData
    End Function

    Public Function GetRecordsFiltered(tableName As String, sortKey As String, filterKey As String,
                                       ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData) _
        Implements IModel.GetRecordsFiltered
        'Dim s = GetDataService()
        Dim data = DataService.GetRecordsFiltered(tableName, sortKey, filterKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData
            tData.IdNo = data(i * 3 - 3)
            tData.Name = data(i * 3 - 1) & " | " & data(i * 3 - 2)
            tData.Code = data(i * 3 - 1)
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetRecords2Columns(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData) _
        Implements IModel.GetRecords2Columns

        Dim data = Service.GetRecords(tableName, sortKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData
            tData.IdNo = data(i * 3 - 3)
            tData.Name = data(i * 3 - 2) & " | " & data(i * 3 - 1)
            tData.Code = data(i * 3 - 1) & " | " & data(i * 3 - 2)
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetRecords2ColumnsFiltered(tableName As String, sortKey As String, filterKey As String,
                                               ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData) _
        Implements IModel.GetRecords2ColumnsFiltered

        Dim data = Service.GetRecordsFiltered(tableName, sortKey, filterKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData
            tData.IdNo = data(i * 3 - 3)
            tData.Name = data(i * 3 - 2) & " | " & data(i * 3 - 1)
            tData.Code = data(i * 3 - 1) & " | " & data(i * 3 - 2)
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetLookupDataByName(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData) _
        Implements IModel.GetLookupDataByName
        Dim data = Service.GetRecords(tableName, sortKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData
            tData.IdNo = data(i * 3 - 3)
            tData.Name = data(i * 3 - 2)
            tData.Code = data(i * 3 - 2) & " | " & data(i * 3 - 1)
            tData.Index = Convert.ChangeType(i, GetType(Integer))
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetLookupDataByNameWithCode(tableName As String, sortKey As String,
                                                ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData) _
        Implements IModel.GetLookupDataByNameWithCode
        Dim data = Service.GetRecords(tableName, sortKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData
            tData.IdNo = data(i * 3 - 3)
            tData.Name = data(i * 3 - 2) & " | " & data(i * 3 - 1)
            tData.Code = data(i * 3 - 1)
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetLookupDataByCode(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData) _
        Implements IModel.GetLookupDataByCode
        Dim data = Service.GetRecords(tableName, sortKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData
            Dim x = data(i * 3 - 1)
            tData.IdNo = data(i * 3 - 3)
            tData.Name = data(i * 3 - 1) & " | " & data(i * 3 - 2)
            If x.Equals(DBNull.Value) Then
                tData.Code = ""
            Else
                tData.Code = data(i * 3 - 1)
            End If
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetLookupFilteredDataByName(tableName As String, sortKey As String, filterKey As String,
                                                ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData) _
        Implements IModel.GetLookupFilteredDataByName
        Dim data = Service.GetRecordsFiltered(tableName, sortKey, filterKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData
            tData.IdNo = data(i * 3 - 3)
            tData.Name = data(i * 3 - 2)
            tData.Code = data(i * 3 - 2) & " | " & data(i * 3 - 1)
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetLookupFilteredDataByCode(tableName As String, sortKey As String, filterKey As String,
                                                ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData) _
        Implements IModel.GetLookupFilteredDataByCode
        Dim data = Service.GetRecordsFiltered(tableName, sortKey, filterKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData
            tData.IdNo = data(i * 3 - 3)
            tData.Name = data(i * 3 - 1) & " | " & data(i * 3 - 2)
            tData.Code = data(i * 3 - 1)
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function Login(userName As String, password As String) As Boolean Implements IModel.Login
        Return LoginService.Login(userName, password)
    End Function

    Public Sub Logout() Implements IModel.Logout
        Throw New NotImplementedException
    End Sub

    Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer _
        Implements IModel.GetIdNoOfSortedPositionNumber
        Return Service.GetIdNoOfSortedPositionNumber(recordNo, tableName, sortOrder)
    End Function

    Public Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrderKey As String) As Integer _
        Implements IModel.GetSortedRecordPosition
        Return Service.GetSortedRecordPosition(idNo, tableName, sortOrderKey)
    End Function

    Public Function GetRecordCount(tableName As String) As Integer Implements IModel.GetRecordCount
        Try
            Return Service.GetRecordCount(tableName)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetRecordPosition(tableName As String, dno As Integer) As Integer _
        Implements IModel.GetRecordPosition
        Return Service.GetRecordPosition(tableName, dno)
    End Function

    Public Function FindField(tableName As String, fieldName As String, searchString As String,
                              searchAnywhere As Boolean) As Integer _
        Implements IModel.FindField
        Return Service.FindField(tableName, fieldName, searchString, searchAnywhere)
    End Function

    Public Function FindFieldContinue(tableName As String, idNo As Int32) As Integer _
        Implements IModel.FindFieldContinue
        Return Service.FindFieldContinue(tableName, idNo)
    End Function

    Public Function DeleteRecord(idNo As Int32, tableName As String) As Integer _
        Implements IModel.DeleteRecord
        Return Service.DeleteRecord(idNo, tableName)
    End Function

    Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                          returnFieldName As String) As String _
        Implements IModel.GetRecordFieldWithKey
        Return Service.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
    End Function

    Public Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String,
                                          returnFieldName As String) As T _
        Implements IModel.GetRecordFieldWithKeyG
        Return Service.GetRecordFieldWithKeyG(Of T)(searchValue, tableName, searchFieldName, returnFieldName)
    End Function

    Public Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                           searchFieldName1 As String,
                                           searchFieldName2 As String, returnFieldName As String) As String _
        Implements IModel.GetRecordFieldWith2Key
        Return _
            Service.GetRecordFieldWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2,
                                           returnFieldName)
    End Function

    Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer _
        Implements IModel.CountRecordWithKey
        Return Service.CountRecordWithKey(searchValue, tableName, searchFieldName)
    End Function

    Public Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                        searchFieldName1 As String, searchFieldName2 As String) As Integer _
        Implements IModel.CountRecordWith2Key
        Return Service.CountRecordWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2)
    End Function

    Public Function GetRecordWithIdNo(idNo As Int32, tableName As String, returnFieldName As String) As String _
        Implements IModel.GetRecordWithIdNo
        Return Service.GetRecordWithIdNo(idNo, tableName, returnFieldName)
    End Function

    Public Function GetRecordDateTimeStamp(idNo As Int32, tableName As String,
                                           Optional dateTimeStampField As String = "DateTimeStamp") As Object _
        Implements IModel.GetRecordDateTimeStamp
        Return Service.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
    End Function

    Public Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object,
                                     Optional timeStampField As String = "DateTimeStamp") As Boolean _
        Implements IModel.HasRecordChanged
        Return Service.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
    End Function

    'Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int32) As ArrayList _
    '    Implements IModel.GetUserSecurity
    '    Return SecurityService.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
    'End Function

    Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) _
        As Boolean _
        Implements IModel.CheckIfUnique
        Return Service.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
    End Function

    Public Function IsUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) _
        As Boolean _
        Implements IModel.IsUnique
        Return Service.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
    End Function

    Public Function GetLastSortKey(searchValue As String, tableName As String) As String _
        Implements IModel.GetLastSortKey
        Return Service.GetLastSortKey(searchValue, tableName)
    End Function

    Public Function UpdateTvp(ByRef dtTable As DataTable) As Integer Implements IModel.UpdateTvp
        Return DataService.UpdateTvp(dtTable)
    End Function

    Public Function DelUpdateTvp(ByRef dtTable As DataTable, groupKey As Integer) As Integer _
        Implements IModel.DelUpdateTvp
        Return DataService.DelUpdateTvp(dtTable, groupKey)
    End Function

    Public Function InsertTvp(dtTable As DataTable) As Integer _
        Implements IModel.InsertTvp
        Return DataService.InsertTvp(dtTable)
    End Function

    Public Function GetSqlValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType _
        Implements IModel.GetSqlValue
        Return Service.GetSqlValue(Of TType)(sqlStatement, tableName, condition)
    End Function

    Public Function GetBizObjectErrors()
        Return DataService.GetBizObjectErrors()
    End Function

    Public Function GetBizObjectRules()
        Return DataService.GetBizObjectRules()
    End Function

    Public Function IsValid(Of TM)(ByRef dModel As TM)
        Return DataService.IsValid(dModel)
    End Function

    Public Function GetControlSecurityIdNo(searchValue As String) As String _
        Implements IModel.GetControlSecurityIdNo
        Return Service.GetControlSecurityIdNo(searchValue)
    End Function

    Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int32) As ArrayList _
        Implements IModel.GetUserSecurity
        Return Service.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
    End Function

    Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int32) As ArrayList _
        Implements IModel.GetUserSecurityForKey
        Return Service.GetUserSecurityForKey(securityObjectName, securityGroupIdNo)
    End Function

End Class

Public Class ModelLogin
    Inherits Model

    Public Sub New()
        DataService = New ServiceLogin
    End Sub

End Class

