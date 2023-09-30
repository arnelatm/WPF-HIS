Imports System.Configuration
Imports System.Dynamic
Imports System.Globalization
Imports System.Reflection
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace Services
    ' implementation of IService interface. It can handle different data providers.

    ' ** Facade pattern.
    ' ** Repository pattern (Service could be split up in individual Repositories: Product, Category, etc).

    Public Class Service
        Implements IService
        Protected Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Protected Shared ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Protected Shared ReadOnly BaseDao As IBaseDao = Factory.BaseDao
        Protected Shared ReadOnly DataRetriever As IDataPageRetriever = Factory.DataRetriever

        'Protected Shared ReadOnly DefaultFieldValueDao As IDefaultFieldValueDao = Factory.DefaultFieldValueDao
        Protected Shared ReadOnly TblColPropDao As ITblColPropDao = Factory.TblColPropDao

        Public Sub New(objectName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
            CreateBusinessObject(objectName, bizParam)
            CreateDao(objectName, daoParam)
        End Sub

        Public Sub New()
        End Sub

        Public Property DataBo As Object

        Public Property DataDao As Object

        Private ReadOnly Property SecurityGroupDao As IDao(Of SecurityGroup)
            Get
                Return Factory.CreateDao("SecurityGroup")
            End Get
        End Property

        Private ReadOnly Property SecurityObjectDao As IDao(Of SecurityObject)
            Get
                Return Factory.CreateDao("SecurityObject")
            End Get
        End Property

        Private ReadOnly Property UserDao As IDao(Of User)
            Get
                Return Factory.CreateDao("User")
            End Get
        End Property

        Public Function CreateInstance(ByVal strFullyQualifiedName As String, Optional instanceParameters As Object = Nothing) As Object
            Dim type As Type = Type.[GetType](strFullyQualifiedName)
            If type IsNot Nothing Then Return Activator.CreateInstance(type)
            For Each asm In AppDomain.CurrentDomain.GetAssemblies()
                type = asm.[GetType](strFullyQualifiedName)
                If type IsNot Nothing Then
                    If instanceParameters Is Nothing OrElse instanceParameters.Length = 0 Then
                        Return Activator.CreateInstance(type)
                    Else
                        Return Activator.CreateInstance(type, instanceParameters)
                    End If
                End If
            Next
            Return Nothing
        End Function

        Public Function GetBizObject()
            Return DataBo
        End Function

        Public Function GetBizObjectErrors()
            Return DataBo.GetErrors()
        End Function

        Public Function GetBizObjectRules()
            Return DataBo.GetRules()
        End Function

        Public Function GetDao(objectName As String, Optional daoParam As Object = Nothing) As Object
            Dim dao
            If daoParam Is Nothing OrElse daoParam.Length = 0 Then
                dao = Factory.CreateDao(objectName)
            Else
                dao = Factory.CreateDao(objectName, daoParam)
            End If
            If dao Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + objectName)
                Debugger.Break()
            End If
            Return dao
        End Function

        Public Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object Implements IService.GetField
            Return DataDao.GetField(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetField(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String, Optional filter As String = Nothing) As TR Implements IService.GetField
            Return DataDao.GetField(Of TR, TS)(searchValue, tableName, searchFieldName, returnFieldName, filter)
        End Function

        Public Function GetField(Of TR, TS1, TS2)(searchValue1 As TS1, searchValue2 As TS2, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String, Optional filter As String = Nothing) As TR Implements IService.GetField
            Return DataDao.GetField(Of TR, TS1, TS2)(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2, returnFieldName, filter)
        End Function

        Public Function GetField(Of TR, TS1, TS2, TS3)(searchValue1 As TS1, searchValue2 As TS2, searchValue3 As TS3,
                                                       tableName As String,
                                                       searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String,
                                                       returnFieldName As String, Optional filter As String = Nothing) As TR Implements IService.GetField
            Return DataDao.GetField(Of TR, TS1, TS2)(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2, returnFieldName, filter)
        End Function

        Public Function GetHLookup(lookupObj As Lookup) As List(Of Lookup.HLookupData)
            If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
                Dim nameFieldArabic = lookupObj.NameField + "Ara"
                If FieldExistInTable(lookupObj.TableName, nameFieldArabic) Then
                    If lookupObj.SortKey = lookupObj.NameField Then
                        lookupObj.SortKey = nameFieldArabic
                        For Each field In lookupObj.FieldsToShow
                            If field = lookupObj.NameField Then
                                field = nameFieldArabic
                            End If
                        Next
                        lookupObj.NameField = nameFieldArabic
                    End If
                End If
            End If
            Return GetHRecords(lookupObj)
        End Function

        Public Function GetHRecords(lookupObj As Lookup) As List(Of Lookup.HLookupData)
            Dim data = GetRecords(lookupObj.TableName, lookupObj.SortKey, lookupObj.FieldsToShow, lookupObj.FilterKey)
            Dim tlData = New List(Of Lookup.HLookupData)
            For i = 1 To Int(data.Count / 4)
                Dim tData As New Lookup.HLookupData With {
                        .IdNo = data(i * 4 - 4),
                        .Name = data(i * 4 - 3),
                        .Code = If(data(i * 4 - 2) Is DBNull.Value, "", data(i * 4 - 2)),
                        .ParentIdNo = CInt(If(data(i * 4 - 1) Is DBNull.Value, Nothing, data(i * 4 - 1)))
                        }
                tlData.Add(tData)
            Next
            Return tlData
        End Function


        Public Function GetListLookup(lookupObj As Lookup) As List(Of Lookup.LookupData)
            If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
                Dim nameFieldArabic = lookupObj.NameField + "Ara"
                If FieldExistInTable(lookupObj.TableName, nameFieldArabic) Then
                    If lookupObj.SortKey = lookupObj.NameField Then
                        lookupObj.SortKey = nameFieldArabic
                        Dim i As Integer = 0
                        For Each field In lookupObj.FieldsToShow
                            If field = lookupObj.NameField Then
                                lookupObj.FieldsToShow(i) = nameFieldArabic
                            End If
                            i = i + 1
                        Next
                        lookupObj.NameField = nameFieldArabic
                    End If
                End If
            End If
            Dim data = GetRecords(lookupObj.TableName, lookupObj.SortKey, lookupObj.FieldsToShow, lookupObj.FilterKey)
            Dim lookupSetting = GlobalVariables.LookupSetting()
            Return ProcessListLookup(data, lookupObj.FieldsToShow.Count())
        End Function


        Public Function GetListLookupT(lookupObj As LookupTable) As DataTable
            If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
                Dim nameFieldArabic = lookupObj.NameField + "Ara"
                If FieldExistInTable(lookupObj.TableName, nameFieldArabic) Then
                    If lookupObj.SortKey = lookupObj.NameField Then
                        lookupObj.SortKey = nameFieldArabic
                        Dim i As Integer = 0
                        For Each field In lookupObj.FieldsToShow
                            If field = lookupObj.NameField Then
                                lookupObj.FieldsToShow(i) = nameFieldArabic
                            End If
                            i = i + 1
                        Next
                        lookupObj.NameField = nameFieldArabic
                    End If
                End If
            End If
            Return GetRecords(lookupObj.TableName, lookupObj.SortKey, lookupObj.FieldsToShow, lookupObj.FilterKey)
            'Dim lookupSetting = GlobalVariables.LookupSetting()
            'Return ProcessListLookup(data, lookupObj.FieldsToShow.Count())
        End Function

        Public Function GetLookup(lookupObj As Lookup, Optional hierarchical As Boolean = False) As List(Of Lookup.LookupData)
            If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
                Dim nameFieldArabic = lookupObj.NameField + "Ara"
                If FieldExistInTable(lookupObj.TableName, nameFieldArabic) Then
                    If lookupObj.SortKey = lookupObj.NameField Then
                        lookupObj.SortKey = nameFieldArabic
                        Dim i As Integer = 0
                        For Each field In lookupObj.FieldsToShow
                            If field = lookupObj.NameField Then
                                lookupObj.FieldsToShow(i) = nameFieldArabic
                            End If
                            i = i + 1
                        Next
                        lookupObj.NameField = nameFieldArabic
                    End If
                End If
            End If
            If Not hierarchical Then
                Dim data = GetRecords(lookupObj.TableName, lookupObj.SortKey, lookupObj.FieldsToShow, lookupObj.FilterKey)
                Dim lookupSetting = GlobalVariables.LookupSetting()
                If lookupSetting = "NameAndCode" Then
                    Return ProcessLookupByNameCode(data, lookupObj.FieldsToShow.Count())
                ElseIf lookupSetting = "CodeAndName" Then
                    Return ProcessLookupByCodeName(data, lookupObj.FieldsToShow.Count())
                ElseIf lookupSetting = "Name" Then
                    Return ProcessLookupByName(data, lookupObj.FieldsToShow.Count())
                Else
                    Return ProcessLookupByNameCode(data, lookupObj.FieldsToShow.Count())
                End If
            End If
        End Function

        Public Function GetLookup(tableName As String, Optional filter As String = Nothing) As List(Of Lookup.LookupData)
            Dim lookupObj As New Lookup(tableName, filter)
            If tableName = "List" Then
                Return GetListLookup(lookupObj)
            End If
            Return GetLookup(lookupObj)
        End Function

        Public Function GetLookup(tableName As String, sortKey As String, Optional filter As String = Nothing) As List(Of Lookup.LookupData)
            Dim lookupObj As New Lookup(tableName, filter)
            lookupObj.SortKey = sortKey
            Return GetLookup(lookupObj)
        End Function

        Public Function GetLookup(tableName As String, sortKey As String, fieldsToShow As String(), Optional filter As String = Nothing) As List(Of Lookup.LookupData)
            Dim lookupObj As New Lookup(tableName, filter)
            lookupObj.FieldsToShow = fieldsToShow
            lookupObj.SortKey = sortKey
            Return GetLookup(lookupObj)
        End Function

        Public Function GetLookupT(lookupObj As LookupTable, Optional hierarchical As Boolean = False) As DataTable
            If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
                Dim nameFieldArabic = lookupObj.NameField + "Ara"
                If FieldExistInTable(lookupObj.TableName, nameFieldArabic) Then
                    If lookupObj.SortKey = lookupObj.NameField Then
                        lookupObj.SortKey = nameFieldArabic
                        Dim i As Integer = 0
                        For Each field In lookupObj.FieldsToShow
                            If field = lookupObj.NameField Then
                                lookupObj.FieldsToShow(i) = nameFieldArabic
                            End If
                            i = i + 1
                        Next
                        lookupObj.NameField = nameFieldArabic
                    End If
                End If
            End If
            If Not hierarchical Then
                Return GetRecords(lookupObj.TableName, lookupObj.SortKey, lookupObj.FieldsToShow, lookupObj.FilterKey)
                'Dim data = GetRecords(lookupObj.TableName, lookupObj.SortKey, lookupObj.FieldsToShow, lookupObj.FilterKey)
                'Dim lookupSetting = GlobalVariables.LookupSetting()
                'If lookupSetting = "NameAndCode" Then
                '    Return ProcessLookupByNameCode(data, lookupObj.FieldsToShow.Count())
                'ElseIf lookupSetting = "CodeAndName" Then
                '    Return ProcessLookupByCodeName(data, lookupObj.FieldsToShow.Count())
                'ElseIf lookupSetting = "Name" Then
                '    Return ProcessLookupByName(data, lookupObj.FieldsToShow.Count())
                'Else
                '    Return ProcessLookupByNameCode(data, lookupObj.FieldsToShow.Count())
                'End If
            End If
        End Function

        Public Function GetLookupT(tableName As String, Optional filter As String = Nothing) As DataTable
            Dim lookupObj As New LookupTable(tableName, filter)
            If tableName = "List" Then
                Return GetListLookupT(lookupObj)
            End If
            Return GetLookupT(lookupObj)
        End Function

        Public Function GetLookupT(tableName As String, sortKey As String, Optional filter As String = Nothing) As DataTable
            Dim lookupObj As New LookupTable(tableName, filter)
            lookupObj.SortKey = sortKey
            Return GetLookupT(lookupObj)
        End Function

        Public Function GetLookupT(tableName As String, sortKey As String, fieldsToShow As String(), Optional filter As String = Nothing) As DataTable
            Dim lookupObj As New LookupTable(tableName, filter)
            lookupObj.FieldsToShow = fieldsToShow
            lookupObj.SortKey = sortKey
            Return GetLookupT(lookupObj)
        End Function

        Public Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp) Implements IService.GetMainTableColumnProperties
            Return TblColPropDao.GetMainTableColumnProperties(tableName)
        End Function

        Public Function GetRecordExternal(Of TM, TD As New)(tableName As String, idNo As Int32, ByRef externalService As Object) As TM
            Return externalService.InvokeMember("Get" + tableName, BindingFlags.InvokeMethod, Nothing, Me, New Object() {idNo})
        End Function

        Protected Overridable Sub CreateBusinessObject(objectName As String, Optional bizParam As Object = Nothing)
            Dim bizObject = $"AATM.BusinessLayer.BusinessObjects." + objectName
            Dim tType = Type.GetType(bizObject)
            If bizParam IsNot Nothing AndAlso bizParam.Length > 0 Then
                DataBo = CreateInstance(bizObject)
            Else
                DataBo = CreateInstance(bizObject, bizParam)
            End If
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
            End If
        End Sub

        Protected Overridable Sub CreateDao(objectName As String, Optional daoParam As Object = Nothing, Optional connection As String = Nothing)
            If daoParam Is Nothing OrElse daoParam.Length = 0 Then
                If connection Is Nothing Then
                    DataDao = Factory.CreateDao(objectName)
                Else
                    DataDao = Factory.CreateDao(objectName, Nothing, connection)
                End If
            Else
                DataDao = Factory.CreateDao(objectName, daoParam, connection)
            End If
            If DataDao Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + objectName)
                Debugger.Break()
            End If
        End Sub

        Private Function ProcessListLookup(data As Object, fieldCount As UInt16) As List(Of Lookup.LookupData)
            Dim tlData = New List(Of Lookup.LookupData)
            For i = 1 To Int(data.Count / 2)
                Dim tData As New Lookup.LookupData With {.IdNo = data(i * 2 - 2),
                        .Name = data(i * 2 - 1)
                        }
                tlData.Add(tData)
            Next
            Return tlData
        End Function

        Private Function ProcessLookupByCodeName(data As Object, fieldCount As UInt16) As List(Of Lookup.LookupData)
            Dim tlData As New List(Of Lookup.LookupData)
            If fieldCount = 3 Then
                For Each item In data
                    Dim tData As New Lookup.LookupData With {.IdNo = item(0),
                                                             .Name = If(IsDBNull(item(2)), "", item(2)) & " | " & item(1),
                                                             .Code = If(IsDBNull(item(2)), "", item(2))}
                    tlData.Add(tData)
                Next
            Else
                For Each item In data
                    Dim tData As New Lookup.LookupData With {.IdNo = item(0),
                                                             .Name = If(IsDBNull(item(1)), "", item(1)) & " | " & item(0)}
                    tlData.Add(tData)
                Next
            End If
            Return tlData
        End Function

        Private Function ProcessLookupByName(data As Object, fieldCount As UInt16) As List(Of Lookup.LookupData)
            Dim tlData = New List(Of Lookup.LookupData)
            If fieldCount = 3 Then
                For Each item In data
                    Dim tData As New Lookup.LookupData With {.IdNo = item(0),
                                                             .Name = If(IsDBNull(item(1)), "", item(1)),
                                                             .Code = If(IsDBNull(item(2)), "", item(2))}
                    tlData.Add(tData)
                Next
            Else
                For Each item In data
                    Dim tData As New Lookup.LookupData With {.IdNo = item(0),
                                                             .Name = If(IsDBNull(item(1)), "", item(1))}
                    tlData.Add(tData)
                Next
            End If
            Return tlData
        End Function

        Private Function ProcessLookupByNameCode(data As Object, fieldCount As UInt16) As List(Of Lookup.LookupData)
            Dim tlData = New List(Of Lookup.LookupData)
            If fieldCount = 4 Then
                'Dim data = GetRecords(lookupObj.TableName, lookupObj.SortKey, lookupObj.FieldsToShow, lookupObj.FilterKey)
                'Dim tlData = New List(Of Lookup.HLookupData)
                'For i = 1 To Int(data.Count / 4)
                '    Dim tData As New Lookup.HLookupData With {
                '            .IdNo = data(i * 4 - 4),
                '            .Name = data(i * 4 - 3),
                '            .ParentIdNo = CInt(If(data(i * 4 - 2) Is DBNull.Value, Nothing, data(i * 4 - 2))),
                '            .Code = If(data(i * 4 - 1) Is DBNull.Value, "", data(i * 4 - 1))
                '            }
                '    tlData.Add(tData)
                'Next
            ElseIf fieldCount = 3 Then
                For i = 1 To Int(data.Count / 3)
                    Dim tData As New Lookup.LookupData With {.IdNo = data(i * 3 - 3),
                        .Name = data(i * 3 - 2) & " | " & If(IsDBNull(data(i * 3 - 1)), "", data(i * 3 - 1)),
                        .Code = If(IsDBNull(data(i * 3 - 1)), "", data(i * 3 - 1))
                        }
                    tlData.Add(tData)
                Next
            ElseIf fieldCount = 2 Then
                For i = 1 To Int(data.Count / 2)
                    Dim tData As New Lookup.LookupData With {.IdNo = data(i * 2 - 2),
                            .Name = data(i * 2 - 1) & " | " & data(i * 2 - 2)
                            }
                    tlData.Add(tData)
                Next
            Else
                For i As Integer = 0 To data.Count - 1
                    Dim dbLookup = New Lookup.LookupData
                    dbLookup.IdNo = i
                    dbLookup.Name = data(i)
                    dbLookup.Code = ""
                    dbLookup.Index = i
                    tlData.Add(dbLookup)
                Next
            End If
            Return tlData
        End Function

#Region "Current Service Function"

        Public Function AddRecord(ByRef model) As Integer Implements IService.AddRecord
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.AddRecord(DataBo)
        End Function

        Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean Implements IService.CheckIfUnique
            Return DataDao.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
        End Function

        Public Function CountRecordWith2Key(Of TS1, TS2)(tableName As String, searchFieldName1 As String, searchFieldName2 As String, searchValue1 As TS1, searchValue2 As TS2) As Integer Implements IService.CountRecordWith2Key
            Return DataDao.CountRecordWith2Key(Of TS1, TS2)(tableName, searchFieldName1, searchFieldName2, searchValue1, searchValue2)
        End Function

        Public Function CountRecordWith3Key(Of TS1, TS2, TS3)(tableName As String, searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String, searchValue1 As TS1, searchValue2 As TS2, searchValue3 As TS3) As Integer Implements IService.CountRecordWith3Key
            Return DataDao.CountRecordWith3Key(Of TS1, TS2, TS3)(tableName, searchFieldName1, searchFieldName2, searchFieldName3, searchValue1, searchValue2, searchValue3)
        End Function

        Public Function CountRecordWithKey(Of TS1)(tableName As String, searchFieldName As String, searchValue As TS1) As Integer Implements IService.CountRecordWithKey
            Return DataDao.CountRecordWithKey(Of TS1)(tableName, searchFieldName, searchValue)
        End Function

        Public Function DeleteRecord(idNo As Int32, tableName As String) As Integer Implements IService.DeleteRecord
            Return DataDao.DeleteRecord(idNo, tableName)
        End Function

        Public Function DeleteRecord(Of T)(keyFieldValue As T, tableName As String, keyFieldName As String) As Integer Implements IService.DeleteRecord
            Return DataDao.DeleteRecord(Of T)(keyFieldValue, tableName, keyFieldName)
        End Function

        Public Function DeleteRecords(Of T)(keyFieldValue As T, tableName As String, keyFieldName As String) As Integer Implements IService.DeleteRecords
            Return DataDao.DeleteRecordS(Of T)(keyFieldValue, tableName, keyFieldName)
        End Function


        Public Function DelUpdateTvp(dtTable As DataTable, ByVal groupKey As Integer) As Integer Implements IService.DelUpdateTvp
            Return DataDao.DelUpdateTvp(dtTable, groupKey)
        End Function

        Public Function ExecuteTvpSp(ByRef userProcedureName As String, dtTable As DataTable) As Integer Implements IService.ExecuteTvpSp
            Return DataDao.ExecuteTvpSp(userProcedureName, dtTable)
        End Function

        Public Function FieldExistInTable(ByVal tableName As String, fieldName As String) As Boolean Implements IService.FieldExistInTable
            Return DataDao.FieldExistInTable(tableName, fieldName)
        End Function

        Public Function FindDateField(tableName As String, findableControl As IFindableControl, Optional filter As String = Nothing) As Integer Implements IService.FindDateField
            Return DataDao.FindDateField(tableName, findableControl, filter)
        End Function

        Public Function FindFieldContinue(tableName As String, idNo As Int32, sortOrderKey As String) As Integer Implements IService.FindFieldContinue
            Return DataDao.FindFieldContinue(tableName, idNo, sortOrderKey)
        End Function

        Public Function FindFieldNew(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer Implements IService.FindFieldNew
            Return DataDao.FindFieldNew(tableName, findableControl, sortOrderKey, filter)
        End Function

        Public Function GenericUpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) As Integer _
            Implements IService.GenericUpdateRecordWithIdNo
            'Dim dDataDao = New BaseDao
            'Return dDataDao.GenericUpdateRecordWithIdNo(idNo, tableName, fieldName, value)
            Return DataDao.GenericUpdateRecordWithIdNo(Of T)(idNo, tableName, fieldName, value)
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing)
            Return DataDao.GetDaoRecords(filter)
        End Function

        Public Function GetDaoRecords(Of TM)(Optional filter As String = Nothing)
            Dim dataModel As New List(Of TM)
            Dim bizData = DataDao.GetDaoRecords(filter)
            GlobalVariables.Mapper.Map(bizData, dataModel)
            Return dataModel
        End Function

        Public Function GetDataSet(ByVal storedProcedureName As String, ByVal parameters As Object) As DataSet Implements IService.GetDataSet
            Return DataDao.GetDataSet(storedProcedureName, parameters)
        End Function

        Public Function GetDataTable(tableName As String, Optional sortField As String = Nothing, Optional fieldList As String = Nothing, Optional filter As String = Nothing) As DataTable
            Return DataDao.GetDataTable(tableName, sortField, fieldList, filter)
        End Function

        Public Function GetDataTable(sqlCommand As String) As DataTable
            Return DataDao.GetDataTable(sqlCommand)
        End Function

        Public Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object Implements IService.GetFieldOnMaxField
            Return DataDao.GetFieldOnMaxField(searchFieldName, tableName, returnFieldName, filter)
        End Function

        Public Function GetFieldsWithIdNo(idNo As Object, tableName As String, fields As String, Optional primaryFieldName As String = Nothing) As Object Implements IService.GetFieldsWithIdNo
            Return DataDao.GetFieldsWithIdNo(idNo, tableName, fields, primaryFieldName)
        End Function

        Public Function GetFieldType(tableName As String, fieldName As String) As Object Implements IService.GetFieldType
            Return DataDao.GetFieldType(tableName, fieldName)
        End Function

        Public Function GetFieldValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType Implements IService.GetFieldValue
            Return DataDao.GetFieldValue(Of TType)(sqlStatement, tableName, condition)
        End Function

        Public Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object Implements IService.GetFieldWithIdNo
            Return DataDao.GetFieldWithIdNo(idNo, tableName, returnFieldName)
        End Function

        Public Function GetIcIdNoWithName(codeGroupSelection As CodeGroupSelection, itemName As String) As Integer Implements IService.GetIcIdNoWithName
            Return DataDao.GetIcIdNoWithIName(codeGroupSelection, itemName)
        End Function

        Public Function GetIcNameWithIdNo(codeGroupSelection As CodeGroupSelection, idNo As Int32) As String Implements IService.GetIcNameWithIdNo
            Return DataDao.GetIcNameWithIdNo(codeGroupSelection, idNo)
        End Function

        Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer Implements IService.GetIdNoOfSortedPositionNumber
            Return DataDao.GetIdNoOfSortedPositionNumber(recordNo, tableName, sortOrder, filter)
        End Function

        Public Function GetIdNoWithKey(Of T)(tableName As String, fieldValue As String, Optional fieldName As String = Nothing, Optional idFieldName As String = Nothing) As T Implements IService.GetIdNoWithKey
            Dim idNo As T = DataDao.GetIdNoWithKey(Of T)(tableName, fieldValue, fieldName, idFieldName)
            Return idNo
        End Function

        Public Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String Implements IService.GetLastSortKey
            Return DataDao.GetLastSortKey(searchValue, tableName)
        End Function

        Public Function GetParametrized(Of TM As New)(parameter As Object, Optional sortOrder As String = "")
            Dim modelOfPresenter As New TM
            Dim record = DataDao.GetParametrized(Of TM)(parameter, sortOrder)
            If record IsNot Nothing Then
                GlobalVariables.Mapper.Map(record, modelOfPresenter)
            End If
            Return modelOfPresenter
        End Function

        Public Function GetPrintJobIdNo(reportName As String) As Integer Implements IService.GetPrintJobIdNo
            Return DataDao.GetPrintJobIdNo(reportName)
        End Function


        Public Function GetAll(Of TM As New)(sortKey As String) As List(Of TM) Implements IService.GetAll
            Dim modelOfPresenter As New List(Of TM)
            Dim record = DataDao.GetAll(Of TM)(sortKey)
            If record IsNot Nothing Then
                GlobalVariables.Mapper.Map(record, modelOfPresenter)
            End If
            Return modelOfPresenter
        End Function

        Public Function GetRecordByIdNo(Of TM As New)(idNo As Int32) As TM Implements IService.GetRecordByIdNo
            Dim modelOfPresenter As New TM
            Dim record = DataDao.GetRecordByIdNo(Convert.ToInt32(idNo))
            If record IsNot Nothing Then
                GlobalVariables.Mapper.Map(record, modelOfPresenter)
            End If
            Return modelOfPresenter
        End Function

        Public Function GetRecordCount(tableName As String, Optional filter As String = Nothing) As Integer Implements IService.GetRecordCount
            Return DataDao.GetRecordCount(tableName, filter)
        End Function

        Public Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object Implements IService.GetRecordDateTimeStamp
            Return DataDao.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
        End Function

        Public Function GetRecordField(tableName As String, returnFieldName As String) As Object Implements IService.GetRecordField
            Return DataDao.GetRecordField(tableName, returnFieldName)
        End Function

        Public Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String) As ExpandoObject Implements IService.GetRecordFieldsFiltered
            Return DataDao.GetRecordFieldsFiltered(tableName, fieldList, filter)
        End Function

        Public Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String, parameter As Object) As ExpandoObject Implements IService.GetRecordFieldsFiltered
            Return DataDao.GetRecordFieldsFiltered(tableName, fieldList, filter, parameter)
        End Function

        Public Function GetTopOneFields(tableName As String, fieldList As String, filter As String, order As String, orderAscending As Boolean) As ExpandoObject Implements IService.GetTopOneFields
            Return DataDao.GetTopOneFields(tableName, fieldList, filter, order, orderAscending)
        End Function

        Public Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String Implements IService.GetRecordFieldWith2Key
            Return DataDao.GetRecordFieldWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2, returnFieldName)
        End Function

        Public Function GetRecordFieldWith2KeyG(Of T1, T2, T3)(searchValue1 As T1, searchValue2 As T2, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As T3 Implements IService.GetRecordFieldWith2Keyg
            Return DataDao.GetRecordFieldWith2KeyG(Of T1, T2, T3)(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2, returnFieldName)
        End Function

        Public Function GetRecordFieldWith3KeyG(Of T1, T2, T3, R)(tableName As String, searchValue1 As T1, searchValue2 As T2, searchValue3 As T3, searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String, returnFieldName As String) As R Implements IService.GetRecordFieldWith3Keyg
            Return DataDao.GetRecordFieldWith3KeyG(Of T1, T2, T3, R)(tableName, searchValue1, searchValue2, searchValue3, searchFieldName1, searchFieldName2, searchFieldName3, returnFieldName)
        End Function

        Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String Implements IService.GetRecordFieldWithKey
            Return DataDao.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T Implements IService.GetRecordFieldWithKeyG
            Return DataDao.GetRecordFieldWithKeyG(Of T)(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordFieldWithKeyG(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String) As TR Implements IService.GetRecordFieldWithKeyG
            Return DataDao.GetRecordFieldWithKeyG(Of TR, TS)(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordPosition(tableName As String, idNo As Int32, Optional IdFieldName As String = Nothing) As Integer Implements IService.GetRecordPosition
            Return DataDao.GetRecordPosition(tableName, idNo, IdFieldName)
        End Function

        Public Function GetRecordPositionByKey(Of T)(keyValue As T, tableName As String, sortKey As String, Optional IdFieldName As String = Nothing) As Integer Implements IService.GetRecordPositionByKey
            Return DataDao.GetRecordPositionByKey(Of T)(keyValue, tableName, sortKey, IdFieldName)
        End Function

        Public Function GetRecords(ByVal tableName As String, ByVal sortKey As String, ByVal Optional fields As String() = Nothing, Optional filterKey As String = Nothing) As Object Implements IService.GetRecords
            Return DataDao.GetRecords(tableName, sortKey, fields, filterKey)
        End Function

        'Public Function GetRecords(Of TM)(ByVal parameters As Object, ByVal Optional sortKey As String = Nothing) As List(Of TM) Implements IService.GetRecords
        '    Dim bizData = DataDao.GetRecordsWithGroupIdNo(parameters, sortKey)
        '    Dim dataModel As New List(Of TM)
        '    GlobalVariables.Mapper.Map(bizData, dataModel)
        '    Return dataModel
        'End Function

        Public Function GetDtRecords(ByVal tableName As String, ByVal Optional fields As String = Nothing, Optional filterKey As String = Nothing, Optional ByVal sortKey As String = Nothing) As Object Implements IService.GetDtRecords
            Return DataDao.GetDtRecords(tableName, fields, filterKey, sortKey)
        End Function

        Public Function GetRecordsWithGroupIdNo(Of TM)(idNo, Optional ByRef sortKey = Nothing) As List(Of TM) Implements IService.GetRecordsWithGroupIdNo
            Dim bizData = DataDao.GetRecordsWithGroupIdNo(idNo, sortKey)
            Dim dataModel As New List(Of TM)
            GlobalVariables.Mapper.Map(bizData, dataModel)
            Return dataModel
        End Function

        Public Function GetRecordsWithParams(Of TM)(parameters As Object) As List(Of TM) Implements IService.GetRecordsWithParams
            Dim bizData = DataDao.GetRecordsWithParams(parameters)
            Dim dataModel As New List(Of TM)
            GlobalVariables.Mapper.Map(bizData, dataModel)
            Return dataModel
        End Function

        Public Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer Implements IService.GetSortedRecordPosition
            Return DataDao.GetSortedRecordPosition(idNo, tableName, sortOrder, filter)
        End Function

        Public Function GetSpRecords(spName As String, fields As String, sortKey As String, filter As String) As Object Implements IService.GetSpRecords
            Return DataDao.GetSpRecords(spName, fields, sortKey, filter)
        End Function

        Public Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object, Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean Implements IService.HasRecordChanged
            Return DataDao.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
        End Function

        Public Function InsertRecord(tableName As String, fieldList As Object(), values As Object(), fieldTypes As Object()) As Integer Implements IService.InsertRecord
            Dim nCount = DataDao.InsertRecord(tableName, fieldList, values, fieldTypes)
            Return Not nCount > 0
        End Function

        Public Function InsertTvp(dtTable As DataTable) As Integer Implements IService.InsertTvp
            Return DataDao.InsertTvp(dtTable)
        End Function

        Public Function IsValid(model) As Boolean Implements IService.IsValid
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataBo.IsValid()
        End Function

        Public Sub RestoreConnectionString()
            DataDao.RestoreConnectionString()
        End Sub

        Public Sub SaveConnectionString()
            DataDao.SaveConnectionString()
        End Sub

        Public Sub SetConnectionString(connectionName As String)
            DataDao.SetConnectionString(connectionName)
        End Sub

        Public Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer Implements IService.TransactionUpdate
            Return DataDao.TransactionUpdate(model)
        End Function

        Public Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, ByVal groupIdNo As Integer) As Integer Implements IService.UpdateInsertTvp
            Return DataDao.UpdateInsertTvp(updateTvpTable, insertTvpTable, groupIdNo)
        End Function

        Public Function UpdateRecord(ByVal model) As Integer Implements IService.UpdateRecord
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateRecord(DataBo)
        End Function

        Public Function UpdateRecordWithIdNo(Of T)(ByVal idNo As Int32, ByVal tableName As String, ByVal fieldName As String, ByRef value As T) As Integer Implements IService.UpdateRecordWithIdNo
            Return DataDao.UpdateRecordWithIdNo(Of T)(idNo, tableName, fieldName, value)
        End Function

        Public Function UpdateTable(ByRef data As DataTable, ByVal groupIdNo As Integer) As Integer Implements IService.UpdateTable
            Return DataDao.UpdateRecord(data, groupIdNo)
        End Function

        Public Function PostData(idNo As Int32) As Boolean Implements IService.PostData
            Return DataDao.PostData(idNo)
        End Function

        Public Function UpdateTvp(dtTable As DataTable) As Integer Implements IService.UpdateTvp
            Return DataDao.UpdateTvp(dtTable)
        End Function

        Public Function UsePayGroups()
            Dim retValue = GetRecordFieldWithKey("PYGP", "Setting", "SettingCode", "Value")
            If retValue Is Nothing Then
                Dim setupName As String = Messaging.TranslateCaption("Use Pay Groups")
                Dim groupSetting As String = "Payroll"
                Messaging.ShowPmMessage(True, "MsgSettingNotSet", {"setupName", setupName, "groupSetting", groupSetting})
                Return Nothing
            End If
            If retValue = "1" Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function RunSpWithRollBack(storeProcedureName As String, parameters As Object) As Object Implements IService.RunSpWithRollBack
            Return DataDao.RunSpWithRollBack(storeProcedureName, parameters)
        End Function


#End Region

#Region "BaseDao Functions"

        Public Function AddSecurityObject(securityObject As SecurityObject) As Int32 Implements IService.AddSecurityObject
            Return BaseDao.AddSecurityObject(securityObject)
        End Function

        Public Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String Implements IService.GetControlSecurityIdNo
            Return BaseDao.GetControlSecurityIdNo(searchValue, menu)
        End Function

        Public Function GetNextSeries(seriesName As String) As Integer Implements IService.GetNextSeries
            Return BaseDao.GetNextSeries(seriesName)
        End Function

        Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList Implements IService.GetUserSecurity
            Return BaseDao.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
        End Function

        Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList Implements IService.GetUserSecurityForKey
            Return BaseDao.GetUserSecurityForKey(securityObjectName, securityGroupIdNo)
        End Function

        Public Function InitializeSecurityObject() As Integer Implements IService.InitializeSecurityObject
            Return BaseDao.InitializeSecurityObject()
        End Function


#End Region

    End Class

End Namespace