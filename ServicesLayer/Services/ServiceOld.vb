Imports System.Configuration
Imports System.Reflection
Imports AATM.DataLayer

Namespace Services

' implementation of IService interface. It can handle different data providers.

' ** Facade pattern.
' ** Repository pattern (Service could be split up in individual Repositories: Product, Category, etc).

    Public Class ServiceOld
        Implements IServiceOld

        Protected Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)

        Protected Shared ReadOnly CommonDaoOld As ICommonDao = Factory.CommonDaoOld
        Protected Shared ReadOnly DefaultFieldValueDao As IDefaultFieldValueDao = Factory.DefaultFieldValueDao
        Protected Shared ReadOnly TblColPropDao As ITblColPropDao = Factory.TblColPropDao

        Private _dataDao As Object

        Public Property DataDao As Object
            Set(value As Object)
                _dataDao = value
            End Set
            Get
                Return _dataDao
            End Get
        End Property

        Private Sub GetDataDao()

        End Sub

        'Public Function GetRecords (Of TD As New)(tableName As String, sortOrder As String) As List(Of TD) _
        '    Implements IService.GetRecords
        '    Dim p = PluralizationService.CreateService(New CultureInfo("en-US"))
        '    Dim pluralForm = ""
        '    pluralForm = p.Pluralize(tableName)
        '    If tableName = pluralForm Then
        '        ' break the rule because cannot use the same method for the single rule
        '        pluralForm = tableName + "s"
        '    End If
        '    Return Me.GetType.InvokeMember("Get" + pluralForm, BindingFlags.InvokeMethod, Nothing, Me, New Object() {sortOrder})
        'End Function

        Public Function GetDefaultFieldValues(ByVal tableName As String) Implements IServiceOld.GetDefaultFieldValues
            Return DefaultFieldValueDao.GetTableDefaultValues(tableName)
        End Function

        Public Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp) Implements IServiceOld.GetMainTableColumnProperties
            Return TblColPropDao.GetMainTableColumnProperties(tableName)
        End Function

        Public Function GetRecordsWithIdNo(ByVal idNo As Integer, Optional ByRef sortKey As String = Nothing) Implements IServiceOld.GetRecordsWithIdNo
            Return _dataDao.GetRecordsWithIdNo(idNo, sortKey)
        End Function

        Public Function AddRecord(ByRef model) As Integer Implements IServiceOld.AddRecord
            Return _dataDao.AddRecord(model)
        End Function

        Public Function DelUpdateTvp(dtTable As DataTable, ByVal groupKey As Integer) As Integer Implements IServiceOld.DelUpdateTvp
            Return _dataDao.DelUpdateTvp(dtTable, groupKey)
        End Function

        Public Overloads Function GetAll(Optional ByRef sortKey As String = "") Implements IServiceOld.GetAll
            Return _dataDao.GetAll(sortKey)
        End Function

        Public Shadows Function GetRecordById(idNo As Integer) Implements IServiceOld.GetRecordById
            Return _dataDao.GetRecordById(Convert.ToInt32(idNo))
        End Function

        Public Function InsertTvp(dtTable As DataTable) As Integer Implements IServiceOld.InsertTvp
            Return _dataDao.InsertTvp(dtTable)
        End Function

        Public Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer Implements IServiceOld.TransactionUpdate
            Return _dataDao.TransactionUpdate(model)
        End Function

        Public Function UpdateRecord(Of TBiz)(ByRef model As TBiz) As Integer Implements IServiceOld.UpdateRecord
            Return _dataDao.UpdateRecord(model)
        End Function

        Public Function UpdateTvp(dtTable As DataTable) As Integer Implements IServiceOld.UpdateTvp
            Return _dataDao.UpdateTvp(dtTable)
        End Function

        Public Function GetRecordExternal(Of TM, TD As New)(tableName As String, idNo As Integer, ByRef dataModel As TM,
                                                            ByRef dbDataDao As TD, ByRef externalService As Object) As TM
            Return externalService.InvokeMember("Get" + tableName, BindingFlags.InvokeMethod, Nothing, Me, New Object() {idNo})
        End Function

#Region "CommonDaoOld"

        Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) _
            As Boolean Implements IServiceOld.CheckIfUnique
            Return CommonDaoOld.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
        End Function

        Public Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer _
            Implements IServiceOld.CountRecordWith2Key
            Return CommonDaoOld.CountRecordWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2)
        End Function

        Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer _
            Implements IServiceOld.CountRecordWithKey
            Return CommonDaoOld.CountRecordWithKey(searchValue, tableName, searchFieldName)
        End Function

        Public Function DeleteRecord(idNo As Integer, tableName As String) As Integer _
            Implements IServiceOld.DeleteRecord
            Return CommonDaoOld.DeleteRecord(idNo, tableName)
        End Function

        Public Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean) As Integer _
            Implements IServiceOld.FindField
            Return CommonDaoOld.FindField(tableName, fieldName, searchString, searchAnywhere)
        End Function

        Public Function FindFieldContinue(tableName As String, idNo As Integer) As Integer _
            Implements IServiceOld.FindFieldContinue
            Return CommonDaoOld.FindFieldContinue(tableName, idNo)
        End Function

        Public Function GetFilteredRecords(filterExpression As String, Optional ByRef sortKey As String = Nothing) As Object _
            Implements IServiceOld.GetFilteredRecords
            Return CommonDaoOld.GetFilteredRecords(filterExpression, sortKey)
        End Function

        Public Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String Implements IServiceOld.GetLastSortKey
            Return CommonDaoOld.GetLastSortKey(searchValue, tableName)
        End Function

        Public Function GetRecordCount(tableName As String) As Integer _
            Implements IServiceOld.GetRecordCount
            Return CommonDaoOld.GetRecordCount(tableName)
        End Function

        Public Function GetRecordDateTimeStamp(idNo As Integer, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object _
            Implements IServiceOld.GetRecordDateTimeStamp
            Return CommonDaoOld.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
        End Function

        Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String _
            Implements IServiceOld.GetRecordFieldWithKey
            Return CommonDaoOld.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordPosition(tableName As String, idNo As Integer) As Integer _
            Implements IServiceOld.GetRecordPosition
            Return CommonDaoOld.GetRecordPosition(tableName, idNo)
        End Function

        Public Overloads Function GetRecords(ByVal tableName As String, ByVal sortKey As String, ByVal ParamArray fields() As String) As Object Implements IServiceOld.GetHRecords
            Return CommonDaoOld.GetRecords(tableName, sortKey, fields)
        End Function

        Public Overloads Function GetRecordsFiltered(ByVal tableName As String, ByVal sortKey As String, ByVal filterKey As String, ByVal ParamArray fields() As String) As Object Implements IServiceOld.GetRecordsFiltered
            Return CommonDaoOld.GetRecordsFiltered(tableName, sortKey, filterKey, fields)
        End Function

        Public Function GetRecordWithIdNo(idNo As Integer, tableName As String, returnFieldName As String) As String _
            Implements IServiceOld.GetRecordWithIdNo
            Return CommonDaoOld.GetRecordWithIdNo(idNo, tableName, returnFieldName)
        End Function

        Public Function GetSortedRecordNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer _
            Implements IServiceOld.GetSortedRecordNumber
            Return CommonDaoOld.GetSortedRecordNumber(recordNo, tableName, sortOrder)
        End Function

        Public Function GetSortedRecordPosition(idNo As Integer, tableName As String, sortOrder As String) As Integer _
            Implements IServiceOld.GetSortedRecordPosition
            Return CommonDaoOld.GetSortedRecordPosition(idNo, tableName, sortOrder)
        End Function

        Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList _
            Implements IServiceOld.GetUserSecurity
            Return CommonDaoOld.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
        End Function

        Public Function HasRecordChanged(idNo As Integer, tableName As String, timeStampedValue As Object,
                                         Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean _
            Implements IServiceOld.HasRecordChanged
            Return CommonDaoOld.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
        End Function

        '' ReSharper disable once UnusedMember.Local
        '    Private Function InvokeMethod(sender As Object, e As WaitWindowEventArgs) As Integer
        '        Thread.Sleep(500)
        '        'System.Threading.Thread.Sleep(0)
        '        Try
        '            Me.GetType.InvokeMember("Update" + e.Arguments(1), BindingFlags.InvokeMethod, Nothing, Me,
        '                                    New Object() {e.Arguments(2)})
        '        Catch ex As Exception
        '            Throw
        '        End Try
        '        e.Result = Me.GetType.InvokeMember("Update" + e.Arguments(1), BindingFlags.InvokeMethod, Nothing, Me,
        '                                           New Object() {e.Arguments(2)})
        '        Return e.Result
        '    End Function

        'Public Function GetRecords (Of TD As New)(tableName As String, sortOrder As String) As List(Of TD) _
        '    Implements IService.GetRecords
        '    Dim p = PluralizationService.CreateService(New CultureInfo("en-US"))
        '    Dim pluralForm = ""
        '    pluralForm = p.Pluralize(tableName)
        '    If tableName = pluralForm Then
        '        ' break the rule because cannot use the same method for the single rule
        '        pluralForm = tableName + "s"
        '    End If
        '    Return Me.GetType.InvokeMember("Get" + pluralForm, BindingFlags.InvokeMethod, Nothing, Me, New Object() {sortOrder})
        'End Function

        ' ReSharper disable once UnusedMember.Local
        ' ReSharper disable once UnusedParameter.Local
        '    Private Sub InvokeMethod2(sender As Object, e As WaitWindowEventArgs)

        '        Thread.Sleep(0)

        '        'AdoNet.CommonDaoOld.HasRecordChanged(eidNo, tableName, timeStampedValue, timeStampField)

        '        If e.Arguments.Count > 0 Then
        '            e.Result = e.Arguments(0).ToString()
        '        Else
        '            e.Result = "Hello World"
        '        End If
        '    End Sub

#End Region

    End Class
End NameSpace