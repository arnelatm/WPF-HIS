Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

''' <summary>
'''     The Model in MVP design pattern.
'''     Implements IModel and communicates with WCF Service.
''' </summary>
Public Class ModelOld
    Implements IModelOld

    Protected BizObject
    Protected Service

    Public Function GetMainTableColumnProperties(tableName As String) As List(Of TblColPropModel) _
        Implements IModelOld.GetMainTableColumnProperties

        Service = New ServiceOld()
        Dim mainTableColumnProperties = Service.GetMainTableColumnProperties(tableName)
        Dim tblColPropModel As TblColPropModel
        Dim retTblColPropL As New List(Of TblColPropModel)
        For Each TblColProp In mainTableColumnProperties
            tblColPropModel = New TblColPropModel With {
                .FldName = TblColProp.FldName,
                .FldType = TblColProp.FldType,
                .MaxLength = TblColProp.MaxLength,
                .IsIdentity = TblColProp.IsIdentity,
                .IsNullable = TblColProp.IsNullable
                }
            retTblColPropL.Add(tblColPropModel)
        Next
        Return retTblColPropL
    End Function

    Public Sub SetService(pService) Implements IModelOld.SetService
        Service = pService
    End Sub

    Public Function GetDefaultFieldValues(tableName As String) As List(Of DefaultFieldValueModel) _
        Implements IModelOld.GetDefaultFieldValues
        Dim dfvService = New DefaultFieldValueService
        Dim data = dfvService.GetDefaultFieldValues(tableName)
        Dim result = New List(Of DefaultFieldValueModel)
        For Each item In data
            Dim dM = New DefaultFieldValueModel
            MapObject(item, dM)
            result.Add(dM)
        Next
        Return result
    End Function

    Public Function GetRecordById(Of TM As New)(idNo As Integer) As TM _
        Implements IModelOld.GetRecordById
        Dim modelData As New TM
        If idNo <> 0 Then
            'If idNo = 8 Then
            '    Debugger.Break()
            'End If
            BizObject = Service.GetRecordById(idNo)
            If BizObject IsNot Nothing Then
                'Dim modelData As New TM
                MapObject(BizObject, modelData)
            End If
        End If
        Return modelData
    End Function

    Public Function GetAll(Of TM As New)(Optional ByRef sortExpression As String = Nothing) As List(Of TM) _
        Implements IModelOld.GetAll
        Dim bizData = Service.GetAll(sortExpression)
        Dim viewObject As New List(Of TM)
        For Each bObject In bizData
            Dim model As New TM
            MapObject(bObject, model)
            viewObject.Add(model)
        Next
        Return viewObject
    End Function

    Public Function AddRecord(Of TBiz)(ByRef displayModel As TBiz) As Integer _
        Implements IModelOld.AddRecord
        Dim newlyAddedRecordIdNo As Integer
        newlyAddedRecordIdNo = Service.AddRecord(displayModel)
        Return newlyAddedRecordIdNo
    End Function

    Public Function GetRecordsWithIdNo(Of TM As New)(idNo As Integer, Optional ByRef sortKey As String = Nothing) _
        As List(Of TM) _
        Implements IModelOld.GetRecordsWithIdNo
        Dim bizData = Service.GetRecordsWithIdNo(idNo, sortKey)
        Dim viewObject As New List(Of TM)
        For Each bObject In bizData
            Dim model As New TM
            MapObject(bObject, model)
            viewObject.Add(model)
        Next
        Return viewObject
    End Function

    Public Function UpdateRecord(Of TBiz)(ByRef modelBiz As TBiz) As Integer _
        Implements IModelOld.UpdateRecord
        Dim updateResult As Integer
        updateResult = Service.UpdateRecord(modelBiz)
        Return updateResult
    End Function

    Public Function GetHRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.HLookupData) _
        Implements IModelOld.GetHRecords
        Dim data = Service.GetRecords(tableName, sortKey, fields)
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
        Implements IModelOld.GetRecords
        Dim data = Service.GetRecords(tableName, sortKey, fields)
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
        Implements IModelOld.GetRecordsFiltered
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

    Public Function GetRecords2Columns(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
        As List(Of ClassesLibrary.LookupData) _
        Implements IModelOld.GetRecords2Columns

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
        Implements IModelOld.GetRecords2ColumnsFiltered

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
        Implements IModelOld.GetLookupDataByName
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
        Implements IModelOld.GetLookupDataByNameWithCode
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
        Implements IModelOld.GetLookupDataByCode
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
        Implements IModelOld.GetLookupFilteredDataByName
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
        Implements IModelOld.GetLookupFilteredDataByCode
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

    'Public Function Login(userName As String, password As String) As Boolean Implements IModelOld.Login
    '    Return Service.Login(userName, password)
    'End Function

    Public Sub Logout() Implements IModelOld.Logout
        Throw New NotImplementedException
    End Sub

    Public Function GetSortedRecordNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer _
        Implements IModelOld.GetSortedRecordNumber
        Return Service.GetSortedRecordNumber(recordNo, tableName, sortOrder)
    End Function

    Public Function GetSortedRecordPosition(idNo As Integer, tableName As String, sortOrderKey As String) As Integer _
        Implements IModelOld.GetSortedRecordPosition
        Return Service.GetSortedRecordPosition(idNo, tableName, sortOrderKey)
    End Function

    Public Function GetRecordCount(tableName As String) As Integer Implements IModelOld.GetRecordCount
        Try
            Return Service.GetRecordCount(tableName)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetRecordPosition(tableName As String, dno As Integer) As Integer _
        Implements IModelOld.GetRecordPosition
        Return Service.GetRecordPosition(tableName, dno)
    End Function

    Public Function FindField(tableName As String, fieldName As String, searchString As String,
                              searchAnywhere As Boolean) As Integer _
        Implements IModelOld.FindField
        Return Service.FindField(tableName, fieldName, searchString, searchAnywhere)
    End Function

    Public Function FindFieldContinue(tableName As String, idNo As Integer) As Integer _
        Implements IModelOld.FindFieldContinue
        Return Service.FindFieldContinue(tableName, idNo)
    End Function

    Public Function DeleteRecord(idNo As Integer, tableName As String) As Integer _
        Implements IModelOld.DeleteRecord
        Return Service.DeleteRecord(idNo, tableName)
    End Function

    Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                          returnFieldName As String) As String _
        Implements IModelOld.GetRecordFieldWithKey
        Return Service.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
    End Function

    Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer _
        Implements IModelOld.CountRecordWithKey
        Return Service.CountRecordWithKey(searchValue, tableName, searchFieldName)
    End Function

    Public Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                        searchFieldName1 As String, searchFieldName2 As String) As Integer _
        Implements IModelOld.CountRecordWith2Key
        Return Service.CountRecordWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2)
    End Function

    Public Function GetRecordWithIdNo(idNo As Integer, tableName As String, returnFieldName As String) As String _
        Implements IModelOld.GetRecordWithIdNo
        Return Service.GetRecordWithIdNo(idNo, tableName, returnFieldName)
    End Function

    Public Function GetRecordDateTimeStamp(idNo As Integer, tableName As String,
                                           Optional dateTimeStampField As String = "DateTimeStamp") As Object _
        Implements IModelOld.GetRecordDateTimeStamp
        Return Service.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
    End Function

    Public Function HasRecordChanged(idNo As Integer, tableName As String, timeStampedValue As Object,
                                     Optional timeStampField As String = "DateTimeStamp") As Boolean _
        Implements IModelOld.HasRecordChanged
        Return Service.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
    End Function

    Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList _
        Implements IModelOld.GetUserSecurity
        Return Service.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
    End Function

    Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Integer) _
        As Boolean _
        Implements IModelOld.CheckIfUnique
        Return Service.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
    End Function

    Public Function IsUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Integer) _
        As Boolean _
        Implements IModelOld.IsUnique
        Return Service.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
    End Function

    Public Function GetLastSortKey(searchValue As String, tableName As String) As String _
        Implements IModelOld.GetLastSortKey
        Return Service.GetLastSortKey(searchValue, tableName)
    End Function

    Public Function UpdateTvp(ByRef dtTable As DataTable) As Integer Implements IModelOld.UpdateTvp
        Return Service.UpdateTVP(dtTable)
    End Function

    Public Function DelUpdateTvp(ByRef dtTable As DataTable, groupKey As Integer) As Integer _
        Implements IModelOld.DelUpdateTvp
        Return Service.DelUpdateTVP(dtTable, groupKey)
    End Function

    Public Function InsertTvp(dtTable As DataTable) As Integer _
        Implements IModelOld.InsertTvp
        Return Service.InsertTVP(dtTable)
    End Function
End Class

'Public Class LookupData
'    Property IdNo As Int32
'    Property Name As String
'    Property Code As String

'    Public Overrides Function ToString() as String
'        return Name.ToString()
'    End Function
'End Class

'Public Class HLookupData
'    Property IdNo As Int32
'    Property Name As String
'    Property ParentIdNo As Int32
'    Property Code As String
'End Class

'Public Class LookupData
'    Public Property IdNo As Int32
'    Public Property Name As String
'    Public Property Code As String
'End Class