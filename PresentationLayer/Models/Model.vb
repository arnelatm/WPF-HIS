Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services
Imports AutoMapper

''' <summary>
'''     The Model in MVP design pattern.
'''     Implements IModel and communicates with WCF Service.
''' </summary>
Public Class Model
    Implements IModel

    Protected BizObject
    Private Shared ReadOnly Service As New Service()

    'Public Property CommonService

    Public Property DataService As Object

    Public Overridable Function GetDataService() As Object
        Return Service
    End Function

    Public Overridable Function GetBo() As Object
        Return nothing
    End Function

    Public Function GetRecordById(Of TM As New)(idNo As Integer) As TM _
        Implements IModel.GetRecordById
        Dim modelData As New TM
        If idNo <> 0 Then
            'If idNo = 8 Then
            '    Debugger.Break()
            'End If
            BizObject = GetDataService().GetRecordById(idNo)
            If BizObject IsNot Nothing Then
                'Dim modelData As New TM
                modelData = GlobalVariables.Mapper.Map(Of TM)(BizObject)
                'modelData = Mapper.Map(Of TM)(BizObject)
            End If
        End If
        Return modelData
    End Function

    Public Overridable Function GetBo(ByRef model)
        Return BizObject
    End Function

    Public Overridable Function IsValid(ByRef model)
        Return BizObject.IsValid()
    End Function

    Public Function GetAll(Of TM As New)(Optional ByRef sortExpression As String = Nothing) As List(Of TM) _
        Implements IModel.GetAll
        Dim bizData = GetDataService().GetAll(sortExpression)
        Dim modelObject As New List(Of TM)
        For Each bObject In bizData
            Dim model As TM
            model = GlobalVariables.Mapper.Map(Of TM)(bObject)
            modelObject.Add(model)
        Next
        Return modelObject
    End Function

    Public Function AddRecord(Of TBiz)(ByRef bizObject As TBiz) As Integer _
        Implements IModel.AddRecord
        Dim newlyAddedRecordIdNo As Integer
        newlyAddedRecordIdNo = GetDataService().AddRecord(bizObject)
        Return newlyAddedRecordIdNo
    End Function

    Public Function GetRecordsWithIdNo(Of TM As New)(idNo As Integer, Optional ByRef sortKey As String = Nothing) _
        As List(Of TM) _
        Implements IModel.GetRecordsWithIdNo
        Dim data = GetDataService().GetRecordsWithIdNo(idNo, sortKey)
        Dim bizData = data
        Dim viewObject As New List(Of TM)
        For Each bObject In bizData
            Dim model As TM
            model = GlobalVariables.Mapper.Map(Of TM)(bObject)
            viewObject.Add(model)
        Next
        Return viewObject
    End Function

    Public Function UpdateRecord(Of TM)(ByRef dataModel As TM) As Integer _
        Implements IModel.UpdateRecord
        Dim bo = GetBo()
        GlobalVariables.Mapper.Map(dataModel, Bo)
        Dim updateResult As Integer
        updateResult = GetDataService().UpdateRecord(bo)
        Return updateResult
    End Function

    'Public Function UpdateRecord(Of TBiz)(ByRef modelBiz As TBiz) As Integer _
    '    Implements IModel.UpdateRecord
    '    Dim updateResult As Integer
    '    updateResult = GetDataService().UpdateRecord(modelBiz)
    '    Return updateResult
    'End Function

    'Public Function UpdateRecord(ByRef modelBiz As TBiz) As Integer _
    '    Implements IModel.UpdateRecord
    '    Dim updateResult As Integer
    '    updateResult = GetDataService().UpdateRecord(modelBiz)
    '    Return updateResult
    'End Function

    Public Function UpdateRecordWithIdNo(Of T)(idNo As Integer, tableName As String, fieldName As String, value As T) _
        As Integer _
        Implements IModel.UpdateRecordWithIdNo
        Dim updateResult As Integer
        updateResult = GetDataService().UpdateRecordWithidNo(idNo, tableName, fieldName, value)
        Return updateResult
    End Function

    Public Function GetHRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.HLookupData) _
        Implements IModel.GetHRecords
        Dim data = GetDataService().GetRecords(tableName, sortKey, fields)
        Dim tlData = New List(Of ClassesLibrary.HLookupData)
        For i = 1 To Int(data.Count / 4)
            Dim tData As New ClassesLibrary.HLookupData
            tData.IdNo = data(i * 4 - 4)
            tData.Name = data(i * 4 - 3)
            tData.ParentIdNo = If(data(i * 4 - 2) Is DBNull.Value, 0, data(i * 4 - 2))
            tData.Code = If(data(i * 4 - 2) Is DBNull.Value, Nothing, data(i * 4 - 1))
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData) _
        Implements IModel.GetRecords
        Dim data = GetDataService().GetRecords(tableName, sortKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        If fields.Count = 3 Then
            For i = 1 To Int(data.Count / 3)
                Dim tData As New ClassesLibrary.LookupData
                tData.IdNo = If(data(i * 3 - 3).Equals(DBNull.Value), 0, CInt(data(i * 3 - 3)))
                tData.Name = data(i * 3 - 2) & " | " & data(i * 3 - 3)
                tData.Code = data(i * 3 - 1)
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
        Dim s = GetDataService()
        Dim data = s.GetRecordsFiltered(tableName, sortKey, filterKey, fields)
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
            tData.IdNo = data(i * 3 - 3)
            tData.Name = data(i * 3 - 1) & " | " & data(i * 3 - 2)
            tData.Code = data(i * 3 - 1)
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

    'Public Function Login(userName As String, password As String) As Boolean Implements IModel.Login
    '    Return True
    '    'Return Service.Login(userName, password)
    'End Function

    Public Sub Logout() Implements IModel.Logout
        Throw New NotImplementedException
    End Sub

    Public Function GetSortedRecordNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer _
        Implements IModel.GetSortedRecordNumber
        Return Service.GetSortedRecordNumber(recordNo, tableName, sortOrder)
    End Function

    Public Function GetSortedRecordPosition(idNo As Integer, tableName As String, sortOrderKey As String) As Integer _
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

    Public Function FindFieldContinue(tableName As String, idNo As Integer) As Integer _
        Implements IModel.FindFieldContinue
        Return Service.FindFieldContinue(tableName, idNo)
    End Function

    Public Function DeleteRecord(idNo As Integer, tableName As String) As Integer _
        Implements IModel.DeleteRecord
        Return Service.DeleteRecord(idNo, tableName)
    End Function

    Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                          returnFieldName As String) As String _
        Implements IModel.GetRecordFieldWithKey
        Return Service.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
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

    Public Function GetRecordWithIdNo(idNo As Integer, tableName As String, returnFieldName As String) As String _
        Implements IModel.GetRecordWithIdNo
        Return Service.GetRecordWithIdNo(idNo, tableName, returnFieldName)
    End Function

    Public Function GetRecordDateTimeStamp(idNo As Integer, tableName As String,
                                           Optional dateTimeStampField As String = "DateTimeStamp") As Object _
        Implements IModel.GetRecordDateTimeStamp
        Return Service.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
    End Function

    Public Function HasRecordChanged(idNo As Integer, tableName As String, timeStampedValue As Object,
                                     Optional timeStampField As String = "DateTimeStamp") As Boolean _
        Implements IModel.HasRecordChanged
        Return Service.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
    End Function

    Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList _
        Implements IModel.GetUserSecurity
        Return Service.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
    End Function

    Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Integer) _
        As Boolean _
        Implements IModel.CheckIfUnique
        Return Service.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
    End Function

    Public Function IsUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Integer) _
        As Boolean _
        Implements IModel.IsUnique
        Return Service.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
    End Function

    Public Function GetLastSortKey(searchValue As String, tableName As String) As String _
        Implements IModel.GetLastSortKey
        Return Service.GetLastSortKey(searchValue, tableName)
    End Function

    Public Function UpdateTvp(ByRef dtTable As DataTable) As Integer Implements IModel.UpdateTvp
        Return GetDataService().UpdateTvp(dtTable)
    End Function

    Public Function DelUpdateTvp(ByRef dtTable As DataTable, groupKey As Integer) As Integer _
        Implements IModel.DelUpdateTvp
        Return GetDataService().DelUpdateTvp(dtTable, groupKey)
    End Function

    Public Function InsertTvp(dtTable As DataTable) As Integer _
        Implements IModel.InsertTvp
        Return GetDataService().InsertTvp(dtTable)
    End Function

    Public Function GetSqlValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType _
        Implements IModel.GetSqlValue
        Return Service.GetSqlValue(Of TType)(sqlStatement, tableName, condition)
    End Function


    Public Function GetBizObjectErrors()
        Return BizObject.GetBizObjectErrors()
    End Function


    Public Function GetBizObjectRules()
        Return BizObject.GetBizObjectRules()
    End Function

    Public Function IsValid()
        Return BizObject.IsValid()
    End Function

End Class

Public Class ModelUser
    Inherits Model

    Public Overrides Function GetDataService()
        Return New ServiceUser
    End Function

    Public Shadows Function GetBo()
        Return New User
    End Function

End Class

Public Class ModelSecurityObject
    Inherits Model

    Public Overrides Function GetDataService()
        Return New ServiceSecurityObject()
    End Function

    Public Shadows Function GetBo()
        Return New SecurityObject
    End Function

End Class


Public Class ModelSecurityGroup
    Inherits Model

    Public Overrides Function GetDataService()
        Return New ServiceSecurityGroup()
    End Function

    Public Shadows Function GetBo()
        Return New SecurityGroup
    End Function

End Class


Public Class ModelGroupAccesses
    Inherits Model

    Public Overrides Function GetDataService()
        Return New ServiceGroupAccesses()
    End Function

    Public Shadows Function GetBo()
        Return New ModelGroupAccesses
    End Function

End Class