Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

''' <summary>
'''     The Model in MVP design pattern.
'''     Implements IModel and communicates with WCF Service.
''' </summary>
Public Class Model
    Implements IModel

    Private Shared ReadOnly LoginService As New ServiceLogin()
    Private Shared ReadOnly Service As New Service()

    Public Sub New(accountName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
        DataService = New Service(accountName, bizParam, daoParam)
    End Sub

    Public Sub New()
    End Sub

    Public Property DataService As Object

    Public Function AddRecord(Of TM)(ByRef dataModel As TM) As Integer Implements IModel.AddRecord
        Dim newlyAddedRecordIdNo As Int32
        newlyAddedRecordIdNo = DataService.AddRecord(dataModel)
        Return newlyAddedRecordIdNo
    End Function

    Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean Implements IModel.CheckIfUnique
        Return Service.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
    End Function

    Public Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer Implements IModel.CountRecordWith2Key
        Return Service.CountRecordWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2)
    End Function

    Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer Implements IModel.CountRecordWithKey
        Return Service.CountRecordWithKey(searchValue, tableName, searchFieldName)
    End Function

    Public Function DeleteRecord(idNo As Int32, tableName As String) As Integer Implements IModel.DeleteRecord
        Return Service.DeleteRecord(idNo, tableName)
    End Function

    Public Function DelUpdateTvp(ByRef dtTable As DataTable, groupKey As Integer) As Integer Implements IModel.DelUpdateTvp
        Return DataService.DelUpdateTvp(dtTable, groupKey)
    End Function

    Public Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean) As Integer Implements IModel.FindField
        Return Service.FindField(tableName, fieldName, searchString, searchAnywhere)
    End Function

    Public Function FindFieldContinue(tableName As String, idNo As Int32) As Integer Implements IModel.FindFieldContinue
        Return Service.FindFieldContinue(tableName, idNo)
    End Function

    Public Function GetAll(Of TM As New)(Optional ByRef sortExpression As String = Nothing) As List(Of TM) Implements IModel.GetAll
        Dim bizData = DataService.GetAll(sortExpression)
        Dim modelObject As New List(Of TM)
        For Each bObject In bizData
            Dim model As TM
            model = GlobalVariables.Mapper.Map(Of TM)(bObject)
            modelObject.Add(model)
        Next
        Return modelObject
    End Function

    Public Function GetBizObjectErrors() As IEnumerable(Of Object) Implements IModel.GetBizObjectErrors
        Return DataService.GetBizObjectErrors()
    End Function

    Public Function GetBizObjectRules() Implements IModel.GetBizObjectRules
        Return DataService.GetBizObjectRules()
    End Function

    Public Function GetBizObject() Implements IModel.GetBizObject
        Return DataService.GetBizObject()
    End Function

    Public Function GetControlSecurityIdNo(searchValue As String) As String _
        Implements IModel.GetControlSecurityIdNo
        Return Service.GetControlSecurityIdNo(searchValue)
    End Function

    'Public Function GetFields(tableName As String, sortKey As String, ByVal ParamArray fields() As String) Implements IModel.GetFields
    '    Dim data = DataService.GetFields(tableName, sortKey, fields)
    '    'Dim tlData = New List(Of ClassesLibrary.LookupData)
    '    'If fields.Count = 3 Then
    '    '    For i = 1 To Int(data.Count / 3)
    '    '        Dim tData As New ClassesLibrary.LookupData With {
    '    '            .IdNo = If(data(i * 3 - 3).Equals(DBNull.Value), 0, CInt(data(i * 3 - 3))),
    '    '            .Name = data(i * 3 - 2) & " | " & data(i * 3 - 3),
    '    '            .Code = If(data(i * 3 - 1).Equals(DBNull.Value), "", data(i * 3 - 1))
    '    '        }
    '    '        tlData.Add(tData)
    '    '    Next
    '    'Else
    '    '    For i = 1 To Int(data.Count / 2)
    '    '        Dim tData As New ClassesLibrary.LookupData With {
    '    '            .IdNo = If(data(i * 2 - 2).Equals(DBNull.Value), 0, CInt(data(i * 2 - 2))),
    '    '            .Name = data(i * 2 - 1) & " | " & data(i * 2 - 2)
    '    '        }
    '    '        tlData.Add(tData)
    '    '    Next
    '    'End If
    '    Return data
    'End Function

    Public Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object Implements IModel.GetFieldWithIdNo
        Return Service.GetFieldWithIdNo(idNo, tableName, returnFieldName)
    End Function

    Public Function GetFieldsWithIdNo(idNo As Object, tableName As String, fields As String) As Object Implements IModel.GetFieldsWithIdNo
        Return Service.GetFieldsWithIdNo(idNo, tableName, fields)
    End Function

    Public Function GetFilteredLookupByCodeName(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData) Implements IModel.GetFilteredLookupByCodeName
        Dim data = Service.GetFilteredRecords(tableName, sortKey, filterKey, fields)
        Return ProcessLookupByCodeName(data)
    End Function

    Public Function GetFilteredLookupByName(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData) Implements IModel.GetFilteredLookupByName
        Dim data = Service.GetFilteredRecords(tableName, sortKey, filterKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        Return ProcessLookupByName(data)
    End Function

    Public Function GetFilteredLookupByNameCode(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData) Implements IModel.GetFilteredLookupByNameCode
        Dim data = Service.GetFilteredRecords(tableName, sortKey, filterKey, fields)
        Return ProcessLookupByNameCode(data)
    End Function

    Public Function GetFilteredLookupRecords(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData) Implements IModel.GetFilteredLookupRecords
        Dim data = DataService.GetFilteredRecords(tableName, sortKey, filterKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData With {
                .IdNo = data(i * 3 - 3),
                .Name = data(i * 3 - 1) & " | " & data(i * 3 - 2),
                .Code = data(i * 3 - 1)
            }
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetFilteredRecords(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As Object Implements IModel.GetFilteredRecords
        Return DataService.GetFilteredRecords(tableName, sortKey, filterKey, fields)
    End Function

    Public Function GetHRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) _
                    As List(Of ClassesLibrary.HLookupData) _
        Implements IModel.GetHRecords
        Dim data = DataService.GetRecordsByField(tableName, sortKey, fields)
        Dim tlData = New List(Of ClassesLibrary.HLookupData)
        For i = 1 To Int(data.Count / 4)
            Dim tData As New ClassesLibrary.HLookupData With {
                .IdNo = data(i * 4 - 4),
                .Name = data(i * 4 - 3),
                .ParentIdNo = CInt(If(data(i * 4 - 2) Is DBNull.Value, Nothing, data(i * 4 - 2))),
                .Code = If(data(i * 4 - 2) Is DBNull.Value, Nothing, data(i * 4 - 1))
            }
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer _
        Implements IModel.GetIdNoOfSortedPositionNumber
        Return Service.GetIdNoOfSortedPositionNumber(recordNo, tableName, sortOrder)
    End Function

    Public Function GetLastSortKey(searchValue As String, tableName As String) As String _
        Implements IModel.GetLastSortKey
        Return Service.GetLastSortKey(searchValue, tableName)
    End Function

    Public Function GetLookup(tableName As String, sortKey As String, ByVal ParamArray fields() As String) Implements IModel.GetLookup
        Dim data = Service.GetRecordsByField(tableName, sortKey, fields)
        Dim lookupSetting = GlobalVariables.LookupSetting()
        If lookupSetting = "CodeAndName" Then
            Return ProcessLookupByCodeName(data)
        ElseIf lookupSetting = "NameAndCode" Then
            Return ProcessLookupByNameCode(data)
        ElseIf lookupSetting = "Name" Then
            Return ProcessLookupByName(data)
        Else
            Return ProcessLookupByCodeName(data)
        End If
    End Function

    Public Function GetLookupNew(tableName As String, sortKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData) Implements IModel.GetLookupNew
        Dim data = Service.GetRecordsByField(tableName, sortKey, fields)
        Dim lookupSetting = GlobalVariables.LookupSetting()
        If lookupSetting = "CodeAndName" Then
            Return ProcessLookupByCodeName(data)
        ElseIf lookupSetting = "NameAndCode" Then
            Return ProcessLookupByNameCode(data)
        ElseIf lookupSetting = "Name" Then
            Return ProcessLookupByName(data)
        Else
            Return ProcessLookupByCodeName(data)
        End If
    End Function

    Public Function GetLookupRecords(tableName As String, sortKey As String, ByVal ParamArray fields() As String) As Object Implements IModel.GetLookupRecords
        Dim data = DataService.GetRecordsByField(tableName, sortKey, fields)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        If fields.Count = 3 Then
            For i = 1 To Int(data.Count / 3)
                Dim tData As New ClassesLibrary.LookupData With {
                    .IdNo = If(data(i * 3 - 3).Equals(DBNull.Value), 0, CInt(data(i * 3 - 3))),
                    .Name = data(i * 3 - 2) & " | " & data(i * 3 - 3),
                    .Code = If(data(i * 3 - 1).Equals(DBNull.Value), "", data(i * 3 - 1))
                }
                tlData.Add(tData)
            Next
        Else
            For i = 1 To Int(data.Count / 2)
                Dim tData As New ClassesLibrary.LookupData With {
                    .IdNo = If(data(i * 2 - 2).Equals(DBNull.Value), 0, CInt(data(i * 2 - 2))),
                    .Name = data(i * 2 - 1) & " | " & data(i * 2 - 2)
                }
                tlData.Add(tData)
            Next
        End If
        Return tlData
    End Function

    Public Function GetMaxValueFiltered(searchFieldName As String, tableName As String, returnFieldName As String, filter As String) As Object Implements IModel.GetMaxValueFiltered
        Return Service.GetMaxValueFiltered(searchFieldName, tableName, returnFieldName, filter)
    End Function

    Public Function GetRecordByIdNo(Of TM As New)(idNo As Int32) As TM Implements IModel.GetRecordByIdNo
        Dim modelData As New TM
        If idNo <> 0 Then
            modelData = DataService.GetRecordByIdNo(Of TM)(idNo)
        End If
        Return modelData
    End Function

    Public Function GetRecordCount(tableName As String) As Integer Implements IModel.GetRecordCount
        Try
            Return Service.GetRecordCount(tableName)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional dateTimeStampField As String = "DateTimeStamp") As Object Implements IModel.GetRecordDateTimeStamp
        Return Service.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
    End Function

    Public Function GetRecordField(tableName As String, returnFieldName As String) As Object Implements IModel.GetRecordField
        Return Service.GetRecordField(tableName, returnFieldName)
    End Function

    Public Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String Implements IModel.GetRecordFieldWith2Key
        Return _
            Service.GetRecordFieldWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2,
                                           returnFieldName)
    End Function

    Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String Implements IModel.GetRecordFieldWithKey
        Return Service.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
    End Function

    Public Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T Implements IModel.GetRecordFieldWithKeyG
        Return Service.GetRecordFieldWithKeyG(Of T)(searchValue, tableName, searchFieldName, returnFieldName)
    End Function

    Public Function GetRecordPosition(tableName As String, dno As Integer) As Integer Implements IModel.GetRecordPosition
        Return Service.GetRecordPosition(tableName, dno)
    End Function

    Public Function GetRecordsByField(tableName As String, sortKey As String, ByVal ParamArray fields() As String) As Object Implements IModel.GetRecordsByField
        Return DataService.GetRecordsByField(tableName, sortKey, fields)
    End Function

    'Public Function GetRecordsByField(tableName As String, sortKey As String, ByVal ParamArray fields() As String) As Object Implements IModel.GetRecordsByField
    '    Dim data = DataService.GetRecordsByField(tableName, sortKey, fields)
    '    Dim tlData = New List(Of ClassesLibrary.LookupData)
    '    If fields.Count = 3 Then
    '        For i = 1 To Int(data.Count / 3)
    '            Dim tData As New ClassesLibrary.LookupData With {
    '                .IdNo = If(data(i * 3 - 3).Equals(DBNull.Value), 0, CInt(data(i * 3 - 3))),
    '                .Name = data(i * 3 - 2) & " | " & data(i * 3 - 3),
    '                .Code = If(data(i * 3 - 1).Equals(DBNull.Value), "", data(i * 3 - 1))
    '            }
    '            tlData.Add(tData)
    '        Next
    '    Else
    '        For i = 1 To Int(data.Count / 2)
    '            Dim tData As New ClassesLibrary.LookupData With {
    '                .IdNo = If(data(i * 2 - 2).Equals(DBNull.Value), 0, CInt(data(i * 2 - 2))),
    '                .Name = data(i * 2 - 1) & " | " & data(i * 2 - 2)
    '            }
    '            tlData.Add(tData)
    '        Next
    '    End If
    '    Return tlData
    'End Function
    Public Function GetRecordsWithGroupIdNo(Of TM As New)(idNo, Optional ByRef sortKey = Nothing) As List(Of TM) Implements IModel.GetRecordsWithGroupIdNo
        Dim data = DataService.GetRecordsWithGroupIdNo(Of TM)(idNo, sortKey)
        Return data
    End Function

    Public Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrderKey As String) As Integer Implements IModel.GetSortedRecordPosition
        Return Service.GetSortedRecordPosition(idNo, tableName, sortOrderKey)
    End Function

    Public Function GetFieldValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType _
        Implements IModel.GetFieldValue
        Return Service.GetFieldValue(Of TType)(sqlStatement, tableName, condition)
    End Function

    Public Function GetUserSecurity(securityObjectIdNo As Int16, securityGroupIdNo As Int16) As ArrayList _
        Implements IModel.GetUserSecurity
        Return Service.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
    End Function

    Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList _
        Implements IModel.GetUserSecurityForKey
        Return Service.GetUserSecurityForKey(securityObjectName, securityGroupIdNo)
    End Function

    Public Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object,
                                     Optional timeStampField As String = "DateTimeStamp") As Boolean _
        Implements IModel.HasRecordChanged
        Return Service.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
    End Function

    Public Function InsertTvp(dtTable As DataTable) As Integer _
        Implements IModel.InsertTvp
        Return DataService.InsertTvp(dtTable)
    End Function

    Public Function IsUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) _
        As Boolean _
        Implements IModel.IsUnique
        Return Service.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
    End Function

    Public Function IsValid(Of TM)(ByRef dModel As TM) Implements IModel.IsValid
        Return DataService.IsValid(dModel)
    End Function

    Public Function Login(userName As String, password As String) As Boolean Implements IModel.Login
        Return LoginService.Login(userName, password)
    End Function

    Public Sub Logout() Implements IModel.Logout
        Throw New NotImplementedException
    End Sub

    Public Function UpdateRecord(Of TM)(ByRef dataModel As TM) As Integer _
                                                Implements IModel.UpdateRecord
        Dim updateResult As Integer
        updateResult = DataService.UpdateRecord(dataModel)
        Return updateResult
    End Function

    Public Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) _
        As Integer _
        Implements IModel.UpdateRecordWithIdNo
        Dim updateResult As Integer
        updateResult = DataService.UpdateRecordWithidNo(idNo, tableName, fieldName, value)
        Return updateResult
    End Function

    Public Function UpdateTvp(ByRef dtTable As DataTable) As Integer Implements IModel.UpdateTvp
        Return DataService.UpdateTvp(dtTable)
    End Function

    Private Function ProcessLookupByCodeName(data As Object) As List(Of ClassesLibrary.LookupData)
        Dim tlData As New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData With {
                .IdNo = data(i * 3 - 3),
                .Name = data(i * 3 - 1) & " | " & data(i * 3 - 2),
                .Code = If(IsDBNull(data(i * 3 - 1)), "", data(i * 3 - 1))
            }
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Private Function ProcessLookupByName(data As Object) As List(Of ClassesLibrary.LookupData)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData With {
                .IdNo = data(i * 3 - 3),
                .Name = data(i * 3 - 2),
                .Code = data(i * 3 - 1)
            }
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    Private Function ProcessLookupByNameCode(data As Object) As List(Of ClassesLibrary.LookupData)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        For i = 1 To Int(data.Count / 3)
            Dim tData As New ClassesLibrary.LookupData With {
                .IdNo = data(i * 3 - 3),
                .Name = data(i * 3 - 2) & " | " & data(i * 3 - 1),
                .Code = data(i * 3 - 1)
            }
            tlData.Add(tData)
        Next
        Return tlData
    End Function

    'Public Function IsValid(dataModel As Object) As Boolean Implements IModel.IsValid
    '    Throw New NotImplementedException()
    'End Function

    'Private Function IModel_GetBizObjectErrors() As IEnumerable(Of Object) Implements IModel.GetBizObjectErrors
    '    Return DataService.GetBizObjectErrors()
    'End Function

End Class

Public Class ModelLogin
    Inherits Model

    Public Sub New()
        DataService = New ServiceLogin
    End Sub

End Class