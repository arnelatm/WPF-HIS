Imports System.Configuration
Imports System.Reflection
Imports AATM.HIS.DataLayer

Namespace Services

' implementation of IService interface. It can handle different data providers.

' ** Facade pattern.
' ** Repository pattern (Service could be split up in individual Repositories: Product, Category, etc).

    Public Class Service
        Implements IService

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly TblColPropDao As ITblColPropDao = Factory.TblColPropDao
        Private Shared ReadOnly CommonDao As ICommonDao = Factory.CommonDao
        Private Shared ReadOnly DefaultFieldValueDao As IDefaultFieldValueDao = Factory.DefaultFieldValueDao

        Private _dataDao As Object

        Public Property DataDao As Object
            Set(value As Object)
                _dataDao = value
            End Set
            Get
                Return _dataDao
            End Get
        End Property

        Public ReadOnly Property CommonDaoProp
            Get
                Return CommonDao
            End Get
        End Property

        'Public Overridable Function GetDao() As Object
        '    Return GetDao2()
        'End Function

        'Public Overridable Function GetDao2() As Object
        '    Return CommonDao
        'End Function

        Public Overridable Function GetDao() As Object
            Return CommonDao
        End Function

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

        Public Function GetDefaultFieldValues(ByVal tableName As String) Implements IService.GetDefaultFieldValues
            Return DefaultFieldValueDao.GetTableDefaultValues(tableName)
        End Function

        Public Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp) Implements IService.GetMainTableColumnProperties
            Return TblColPropDao.GetMainTableColumnProperties(tableName)
        End Function

        Public Function GetRecordsWithIdNo(ByVal idNo As Integer, Optional ByRef sortKey As String = Nothing) Implements IService.GetRecordsWithIdNo
            Return GetDao().GetRecordsWithIdNo(idNo, sortKey)
        End Function

        Public Function AddRecord(ByRef model) As Integer Implements IService.AddRecord
            Return GetDao().AddRecord(model)
        End Function

        Public Function DelUpdateTvp(dtTable As DataTable, ByVal groupKey As Integer) As Integer Implements IService.DelUpdateTvp
            Return GetDao().DelUpdateTvp(dtTable, groupKey)
        End Function

        Public Overloads Function GetAll(Optional ByRef sortKey As String = Nothing) Implements IService.GetAll
            Return GetDao().GetAll(sortKey)
        End Function

        Public Shadows Function GetRecordById(idNo As Integer) Implements IService.GetRecordById
            Return GetDao().GetRecordById(Convert.ToInt32(idNo))
        End Function

        Public Function InsertTvp(dtTable As DataTable) As Integer Implements IService.InsertTvp
            Return GetDao().InsertTvp(dtTable)
        End Function

        Public Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer Implements IService.TransactionUpdate
            Return GetDao().TransactionUpdate(model)
        End Function

        Public Function UpdateRecord(Of TBiz)(ByRef model As TBiz) As Integer Implements IService.UpdateRecord
            Return GetDao().UpdateRecord(model)
        End Function

        Public Function UpdateRecordWithIdNo(Of T)(ByVal idNo As Integer, ByVal tableName As String, ByVal fieldName As String, ByRef value As T) As Integer Implements IService.UpdateRecordWithIdNo
            Return GetDao().UpdateRecordWithIdNo(Of T)(idNo, tableName, fieldName, value)
        End Function

        Public Function UpdateTvp(dtTable As DataTable) As Integer Implements IService.UpdateTvp
            Return GetDao().UpdateTvp(dtTable)
        End Function

        Public Function GetSqlValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType Implements IService.GetSqlValue
            Return CommonDao.GetSqlValue(Of TType)(sqlStatement, tableName, condition)
        End Function

        Public Function GetRecordExternal(Of TM, TD As New)(tableName As String, idNo As Integer, ByRef dataModel As TM,
                                                            ByRef dbDataDao As TD, ByRef externalService As Object) As TM
            Return externalService.InvokeMember("Get" + tableName, BindingFlags.InvokeMethod, Nothing, Me, New Object() {idNo})
        End Function

#Region "CommonDao"

        Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) _
            As Boolean Implements IService.CheckIfUnique
            Return CommonDao.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
        End Function

        Public Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer _
            Implements IService.CountRecordWith2Key
            Return CommonDao.CountRecordWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2)
        End Function

        Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer _
            Implements IService.CountRecordWithKey
            Return CommonDao.CountRecordWithKey(searchValue, tableName, searchFieldName)
        End Function

        Public Function DeleteRecord(idNo As Integer, tableName As String) As Integer _
            Implements IService.DeleteRecord
            Return CommonDao.DeleteRecord(idNo, tableName)
        End Function

        Public Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean) As Integer _
            Implements IService.FindField
            Return CommonDao.FindField(tableName, fieldName, searchString, searchAnywhere)
        End Function

        Public Function FindFieldContinue(tableName As String, idNo As Integer) As Integer _
            Implements IService.FindFieldContinue
            Return CommonDao.FindFieldContinue(tableName, idNo)
        End Function

        Public Function GetFilteredRecords(filterExpression As String, Optional ByRef sortKey As String = Nothing) As Object _
            Implements IService.GetFilteredRecords
            Return CommonDao.GetFilteredRecords(filterExpression, sortKey)
        End Function

        Public Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String Implements IService.GetLastSortKey
            Return CommonDao.GetLastSortKey(searchValue, tableName)
        End Function

        Public Function GetRecordCount(tableName As String) As Integer _
            Implements IService.GetRecordCount
            Return CommonDao.GetRecordCount(tableName)
        End Function

        Public Function GetRecordDateTimeStamp(idNo As Integer, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object _
            Implements IService.GetRecordDateTimeStamp
            Return CommonDao.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
        End Function

        Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String _
            Implements IService.GetRecordFieldWithKey
            Return CommonDao.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String _
            Implements IService.GetRecordFieldWith2Key
            Return CommonDao.GetRecordFieldWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2, returnFieldName)
        End Function

        Public Function GetRecordPosition(tableName As String, idNo As Integer) As Integer _
            Implements IService.GetRecordPosition
            Return CommonDao.GetRecordPosition(tableName, idNo)
        End Function

        Public Overloads Function GetRecords(ByVal tableName As String, ByVal sortKey As String, ByVal ParamArray fields() As String) As Object Implements IService.GetRecords
            Return CommonDao.GetRecords(tableName, sortKey, fields)
        End Function

        Public Overloads Function GetRecordsFiltered(ByVal tableName As String, ByVal sortKey As String, ByVal filterKey As String, ByVal ParamArray fields() As String) As Object Implements IService.GetRecordsFiltered
            Return CommonDao.GetRecordsFiltered(tableName, sortKey, filterKey, fields)
        End Function

        Public Function GetRecordWithIdNo(idNo As Integer, tableName As String, returnFieldName As String) As String _
            Implements IService.GetRecordWithIdNo
            Return CommonDao.GetRecordWithIdNo(idNo, tableName, returnFieldName)
        End Function

        Public Function GetSortedRecordNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer _
            Implements IService.GetSortedRecordNumber
            Return CommonDao.GetSortedRecordNumber(recordNo, tableName, sortOrder)
        End Function

        Public Function GetSortedRecordPosition(idNo As Integer, tableName As String, sortOrder As String) As Integer _
            Implements IService.GetSortedRecordPosition
            Return CommonDao.GetSortedRecordPosition(idNo, tableName, sortOrder)
        End Function

        Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList _
            Implements IService.GetUserSecurity
            Return CommonDao.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
        End Function

        Public Function HasRecordChanged(idNo As Integer, tableName As String, timeStampedValue As Object,
                                         Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean _
            Implements IService.HasRecordChanged
            Return CommonDao.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
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

        '        'AdoNet.CommonDao.HasRecordChanged(eidNo, tableName, timeStampedValue, timeStampField)

        '        If e.Arguments.Count > 0 Then
        '            e.Result = e.Arguments(0).ToString()
        '        Else
        '            e.Result = "Hello World"
        '        End If
        '    End Sub

#End Region

    End Class
End NameSpace