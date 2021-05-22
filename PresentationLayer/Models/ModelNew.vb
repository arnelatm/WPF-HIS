Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

''' <summary>
'''     The Model in MVP design pattern.
'''     Implements IModelNew and communicates with WCF Service.
''' </summary>
Public Class ModelNew
    Implements IModelNew

    'Private Shared ReadOnly LoginService As New ServiceLogin()
    Protected Shared ReadOnly Service As New Service()

    Public Sub New(accountName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
        DataService = New Service(accountName, bizParam, daoParam)
    End Sub

    Public Sub New()
    End Sub

    Public Property DataService As Object

    Public Function AddRecord(Of TM)(ByRef dataModel As TM) As Integer Implements IModelNew.AddRecord
        Dim newlyAddedRecordIdNo As Int32
        newlyAddedRecordIdNo = DataService.AddRecord(dataModel)
        Return newlyAddedRecordIdNo
    End Function

    Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean Implements IModelNew.CheckIfUnique
        Return Service.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
    End Function

    Public Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer Implements IModelNew.CountRecordWith2Key
        Return Service.CountRecordWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2)
    End Function

    Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer Implements IModelNew.CountRecordWithKey
        Return Service.CountRecordWithKey(searchValue, tableName, searchFieldName)
    End Function

    Public Function DeleteRecord(idNo As Int32, tableName As String) As Integer Implements IModelNew.DeleteRecord
        Return Service.DeleteRecord(idNo, tableName)
    End Function

    Public Function DelUpdateTvp(ByRef dtTable As DataTable, groupKey As Integer) As Integer Implements IModelNew.DelUpdateTvp
        Return DataService.DelUpdateTvp(dtTable, groupKey)
    End Function

    'Public Function FindField(tableName As String, fieldName As String, searchString As String, searchPlace As Char, Optional filter As String = Nothing) As Integer Implements IModelNew.FindField
    '    Return Service.FindField(tableName, fieldName, searchString, searchPlace, filter)
    'End Function

    Public Function FindFieldNew(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer Implements IModelNew.FindFieldNew
        Return Service.FindFieldNew(tableName, findableControl, sortOrderKey, filter)
    End Function

    Public Function FindDateField(tableName As String, findableControl As IFindableControl, Optional filter As String = Nothing) As Integer Implements IModelNew.FindDateField
        Return Service.FindDateField(tableName, findableControl, filter)
    End Function

    Public Function FindFieldContinue(tableName As String, idNo As Int32, sortOrderKey As String) As Integer Implements IModelNew.FindFieldContinue
        Return Service.FindFieldContinue(tableName, idNo, sortOrderKey)
    End Function

    Public Function GetAll(Of TM As New)(Optional ByRef sortExpression As String = Nothing) As List(Of TM) Implements IModelNew.GetAll
        Dim bizData = DataService.GetAll(sortExpression)
        Dim modelObject As New List(Of TM)
        For Each bObject In bizData
            Dim model As TM
            model = GlobalVariables.Mapper.Map(Of TM)(bObject)
            modelObject.Add(model)
        Next
        Return modelObject
    End Function

    Public Function GetBizObjectErrors() As IEnumerable(Of Object) Implements IModelNew.GetBizObjectErrors
        Return DataService.GetBizObjectErrors()
    End Function

    Public Function GetBizObjectRules() Implements IModelNew.GetBizObjectRules
        Return DataService.GetBizObjectRules()
    End Function

    Public Function GetBizObject() Implements IModelNew.GetBizObject
        Return DataService.GetBizObject()
    End Function

    Public Function GetControlSecurityIdNo(searchValue As String) As String _
        Implements IModelNew.GetControlSecurityIdNo
        Return Service.GetControlSecurityIdNo(searchValue)
    End Function

    Public Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object Implements IModelNew.GetField
        Return Service.GetField(searchValue, tableName, searchFieldName, returnFieldName)
    End Function

    'Public Function GetFields(tableName As String, sortKey As String, ByVal ParamArray fields() As String) Implements IModelNew.GetFields
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

    Public Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object Implements IModelNew.GetFieldWithIdNo
        Return Service.GetFieldWithIdNo(idNo, tableName, returnFieldName)
    End Function

    Public Function GetFieldsWithIdNo(idNo As Object, tableName As String, fields As String) As Object Implements IModelNew.GetFieldsWithIdNo
        Return Service.GetFieldsWithIdNo(idNo, tableName, fields)
    End Function

    Public Function GetLookupByCodeName(tableName As String, sortKey As String, fields As String(), Optional filterKey As String = Nothing) As List(Of ClassesLibrary.LookupData) Implements IModelNew.GetLookupByCodeName
        Dim data = Service.GetRecords(tableName, sortKey, fields, filterKey)
        Return ProcessLookupByCodeName(data, fields.Count())
    End Function

    Public Function GetLookupByName(tableName As String, sortKey As String, fields As String(), Optional filterKey As String = Nothing) As List(Of ClassesLibrary.LookupData) Implements IModelNew.GetLookupByName
        Dim data = Service.GetRecords(tableName, sortKey, fields, filterKey)
        Return ProcessLookupByName(data, fields.Count())
    End Function

    Public Function GetLookupByNameCode(tableName As String, sortKey As String, fields As String(), Optional filterKey As String = Nothing) As List(Of ClassesLibrary.LookupData) Implements IModelNew.GetLookupByNameCode
        Dim data = Service.GetRecords(tableName, sortKey, fields, filterKey)
        Return ProcessLookupByNameCode(data, fields.Count())
    End Function

    'Public Function GetLookupRecords(tableName As String, sortKey As String, filterKey As String, ByVal ParamArray fields() As String) As List(Of ClassesLibrary.LookupData) Implements IModelNew.GetLookupRecords
    '    Dim data = DataService.GetRecords(tableName, sortKey, fields, filterKey)
    '    Dim tlData = New List(Of ClassesLibrary.LookupData)
    '    For i = 1 To Int(data.Count / 3)
    '        Dim tData As New ClassesLibrary.LookupData With {
    '            .IdNo = data(i * 3 - 3),
    '            .Name = data(i * 3 - 1) & " | " & data(i * 3 - 2),
    '            .Code = data(i * 3 - 1)
    '        }
    '        tlData.Add(tData)
    '    Next
    '    Return tlData
    'End Function

    Public Function GetRecords(tableName As String, sortKey As String, fields As String(), Optional filterKey As String = Nothing) As Object Implements IModelNew.GetRecords
        Return Service.GetRecords(tableName, sortKey, fields, filterKey)
    End Function

    Public Function GetHRecords(tableName As String, sortKey As String, fields As String(), Optional Filter As String = Nothing) As List(Of ClassesLibrary.HLookupData) Implements IModelNew.GetHRecords
        Dim data = Service.GetRecords(tableName, sortKey, fields, Filter)
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

    Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer Implements IModelNew.GetIdNoOfSortedPositionNumber
        Return Service.GetIdNoOfSortedPositionNumber(recordNo, tableName, sortOrder, filter)
    End Function

    Public Function GetLastSortKey(searchValue As String, tableName As String) As String _
        Implements IModelNew.GetLastSortKey
        Return Service.GetLastSortKey(searchValue, tableName)
    End Function

    Public Function GetLookup(tableName As String, sortKey As String, fields As String(), Optional filter As String = Nothing) As List(Of ClassesLibrary.LookupData) Implements IModelNew.GetLookup
        Dim data = Service.GetRecords(tableName, sortKey, fields, filter)
        Dim lookupSetting = GlobalVariables.LookupSetting()
        If lookupSetting = "CodeAndName" Then
            Return ProcessLookupByCodeName(data, fields.Count())
        ElseIf lookupSetting = "NameAndCode" Then
            Return ProcessLookupByNameCode(data, fields.Count())
        ElseIf lookupSetting = "Name" Then
            Return ProcessLookupByName(data, fields.Count())
        Else
            Return ProcessLookupByCodeName(data, fields.Count())
        End If
    End Function

    Public Function GetLookupRecords(tableName As String, sortKey As String, fields As String(), Optional filter As String = Nothing) As Object Implements IModelNew.GetLookupRecords
        Dim data = Service.GetRecords(tableName, sortKey, fields, filter)
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

    Public Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object Implements IModelNew.GetFieldOnMaxField
        Return Service.GetFieldOnMaxField(searchFieldName, tableName, returnFieldName, filter)
    End Function

    Public Function GetRecordByIdNo(Of TM As New)(idNo As Int32) As TM Implements IModelNew.GetRecordByIdNo
        Dim modelData As New TM
        If idNo <> 0 Then
            modelData = DataService.GetRecordByIdNo(Of TM)(idNo)
        End If
        Return modelData
    End Function

    Public Function GetRecordCount(tableName As String, Optional filter As String = Nothing) As Integer Implements IModelNew.GetRecordCount
        Try
            Return Service.GetRecordCount(tableName, filter)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional dateTimeStampField As String = "DateTimeStamp") As Object Implements IModelNew.GetRecordDateTimeStamp
        Return Service.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
    End Function

    Public Function GetRecordField(tableName As String, returnFieldName As String) As Object Implements IModelNew.GetRecordField
        Return Service.GetRecordField(tableName, returnFieldName)
    End Function

    Public Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String Implements IModelNew.GetRecordFieldWith2Key
        Return _
            Service.GetRecordFieldWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2,
                                           returnFieldName)
    End Function

    Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String Implements IModelNew.GetRecordFieldWithKey
        Return Service.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
    End Function

    Public Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T Implements IModelNew.GetRecordFieldWithKeyG
        Return Service.GetRecordFieldWithKeyG(Of T)(searchValue, tableName, searchFieldName, returnFieldName)
    End Function

    Public Function GetRecordPosition(tableName As String, dno As Integer) As Integer Implements IModelNew.GetRecordPosition
        Return Service.GetRecordPosition(tableName, dno)
    End Function

    Public Function FieldExistInTable(tableName As String, fieldName As String) As Boolean Implements IModelNew.FieldExistInTable
        Return Service.FieldExistInTable(tableName, fieldName)
    End Function

    'Public Function GetRecordsByField(tableName As String, sortKey As String, fields As String(), Optional filter As String = Nothing) As Object Implements IModelNew.GetRecordsByField
    '    Return DataService.GetRecordsByField(tableName, sortKey, fields, filter)
    'End Function

    'Public Function GetRecordsByField(tableName As String, sortKey As String, ByVal ParamArray fields() As String) As Object Implements IModelNew.GetRecordsByField
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
    Public Function GetRecordsWithGroupIdNo(Of TM As New)(idNo, Optional ByRef sortKey = Nothing) As List(Of TM) Implements IModelNew.GetRecordsWithGroupIdNo
        Dim data = DataService.GetRecordsWithGroupIdNo(Of TM)(idNo, sortKey)
        Return data
    End Function

    Public Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrderKey As String, Optional filter As String = Nothing) As Integer Implements IModelNew.GetSortedRecordPosition
        Return Service.GetSortedRecordPosition(idNo, tableName, sortOrderKey, filter)
    End Function

    Public Function GetFieldValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType _
        Implements IModelNew.GetFieldValue
        Return Service.GetFieldValue(Of TType)(sqlStatement, tableName, condition)
    End Function

    Public Function GetFieldType(tableName As String, fieldName As String) As Object Implements IModelNew.GetFieldType
        Return Service.GetFieldType(tableName, fieldName)
    End Function

    Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList _
        Implements IModelNew.GetUserSecurity
        Return Service.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
    End Function

    Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList _
        Implements IModelNew.GetUserSecurityForKey
        Return Service.GetUserSecurityForKey(securityObjectName, securityGroupIdNo)
    End Function

    Public Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object,
                                     Optional timeStampField As String = "DateTimeStamp") As Boolean _
        Implements IModelNew.HasRecordChanged
        Return Service.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
    End Function

    Public Function AddSecurityModel(securityObject) As Int32 Implements IModelNew.AddSecurityObject
        Return Service.AddSecurityObject(securityObject)
    End Function

    Public Function InitializeSecurityObject() As Integer Implements IModelNew.InitializeSecurityObject
        Return Service.InitializeSecurityObject()
    End Function

    Public Function InsertTvp(dtTable As DataTable) As Integer _
        Implements IModelNew.InsertTvp
        Return DataService.InsertTvp(dtTable)
    End Function

    Public Function IsUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) _
        As Boolean _
        Implements IModelNew.IsUnique
        Return Service.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
    End Function

    Public Function IsValid(Of TM)(ByRef dModel As TM) Implements IModelNew.IsValid
        Return DataService.IsValid(dModel)
    End Function

    Public Sub Logout() Implements IModelNew.Logout
        Throw New NotImplementedException
    End Sub

    Public Function UpdateRecord(Of TM)(ByRef dataModel As TM) As Integer _
                                                Implements IModelNew.UpdateRecord
        Dim updateResult As Integer
        updateResult = DataService.UpdateRecord(dataModel)
        Return updateResult
    End Function

    Public Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) _
        As Integer _
        Implements IModelNew.UpdateRecordWithIdNo
        Dim updateResult As Integer
        updateResult = DataService.UpdateRecordWithidNo(idNo, tableName, fieldName, value)
        Return updateResult
    End Function

    Public Function GenericUpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) As Integer _
        Implements IModelNew.GenericUpdateRecordWithIdNo
        Return DataService.GenericUpdateRecordWithIdNo(idNo, tableName, fieldName, value)
    End Function

    Public Function UpdateTvp(ByRef dtTable As DataTable) As Integer Implements IModelNew.UpdateTvp
        Return DataService.UpdateTvp(dtTable)
    End Function

    Private Function ProcessLookupByCodeName(data As Object, fieldCount As UInt16) As List(Of ClassesLibrary.LookupData)
        Dim tlData As New List(Of ClassesLibrary.LookupData)
        If fieldCount = 3 Then
            For i = 1 To Int(data.Count / 3)
                Dim tData As New ClassesLibrary.LookupData With {.IdNo = data(i * 3 - 3),
                                                                  .Name = If(IsDBNull(data(i * 3 - 1)), "", data(i * 3 - 1)) & " | " & data(i * 3 - 2),
                                                                  .Code = If(IsDBNull(data(i * 3 - 1)), "", data(i * 3 - 1))
                                                                }
                tlData.Add(tData)
            Next
        Else
            For i = 1 To Int(data.Count / 2)
                Dim tData As New ClassesLibrary.LookupData With {.IdNo = data(i * 2 - 2),
                                                                  .Name = If(IsDBNull(data(i * 2 - 1)), "", data(i * 2 - 1)) & " | " & data(i * 2 - 2)
                                                                 }
                tlData.Add(tData)
            Next
        End If
        Return tlData
    End Function

    Private Function ProcessLookupByName(data As Object, fieldCount As UInt16) As List(Of ClassesLibrary.LookupData)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        If fieldCount = 3 Then
            For i = 1 To Int(data.Count / 3)
                Dim tData As New ClassesLibrary.LookupData With {.IdNo = data(i * 3 - 3),
                                                                  .Name = data(i * 3 - 2),
                                                                  .Code = If(IsDBNull(data(i * 3 - 1)), "", data(i * 3 - 1))
                                                                }
                tlData.Add(tData)
            Next
        Else
            For i = 1 To Int(data.Count / 2)
                Dim tData As New ClassesLibrary.LookupData With {.IdNo = data(i * 2 - 2),
                                                                  .Name = data(i * 2 - 1)
                                                                 }
                tlData.Add(tData)
            Next
        End If
        Return tlData
    End Function

    Private Function ProcessLookupByNameCode(data As Object, fieldCount As UInt16) As List(Of ClassesLibrary.LookupData)
        Dim tlData = New List(Of ClassesLibrary.LookupData)
        If fieldCount = 3 Then
            For i = 1 To Int(data.Count / 3)
                Dim tData As New ClassesLibrary.LookupData With {.IdNo = data(i * 3 - 3),
                                                                  .Name = data(i * 3 - 2) & " | " & If(IsDBNull(data(i * 3 - 1)), "", data(i * 3 - 1)),
                                                                  .Code = If(IsDBNull(data(i * 3 - 1)), "", data(i * 3 - 1))
                                                                }
                tlData.Add(tData)
            Next
        Else
            For i = 1 To Int(data.Count / 2)
                Dim tData As New ClassesLibrary.LookupData With {.IdNo = data(i * 2 - 2),
                                                                  .Name = data(i * 2 - 1) & " | " & data(i * 2 - 2)
                                                                }
                tlData.Add(tData)
            Next
        End If
        Return tlData
    End Function

End Class