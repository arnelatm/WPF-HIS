Imports System.Configuration
Imports System.Reflection
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace Services
    ' implementation of IService interface. It can handle different data providers.

    ' ** Facade pattern.
    ' ** Repository pattern (Service could be split up in individual Repositories: Product, Category, etc).

    Public Class Service
        Implements IService

        Protected Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Protected Shared ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Protected Shared ReadOnly TblColPropDao As ITblColPropDao = Factory.TblColPropDao
        Protected Shared ReadOnly BaseDao As IBaseDao = Factory.BaseDao
        Protected Shared ReadOnly DefaultFieldValueDao As IDefaultFieldValueDao = Factory.DefaultFieldValueDao

        Public Property DataDao As Object

        Public Property DataBo As Object

        Public Function GetDefaultFieldValues(ByVal tableName As String) Implements IService.GetDefaultFieldValues
            Return DefaultFieldValueDao.GetTableDefaultValues(tableName)
        End Function

        Public Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp) _
            Implements IService.GetMainTableColumnProperties
            Return TblColPropDao.GetMainTableColumnProperties(tableName)
        End Function

        Public Function GetRecordExternal(Of TM, TD As New)(tableName As String, idNo As Integer, ByRef dataModel As TM,
                                                             ByRef dbDataDao As TD, ByRef externalService As Object) _
            As TM
            Return _
                externalService.InvokeMember("Get" + tableName, BindingFlags.InvokeMethod, Nothing, Me,
                                             New Object() {idNo})
        End Function

        Public Function GetBizObjectErrors()
            Return DataBo.GetErrors()
        End Function

        Public Function GetBizObjectRules()
            Return DataBo.GetRules()
        End Function

#Region "Current Service Function"

        Public Function GetRecordsWithIdNo(Of TM)(idNo As Integer, Optional ByRef sortKey As String = Nothing) _
            As List(Of TM) Implements IService.GetRecordsWithIdNo
            Dim bizData = DataDao.GetRecordsWithIdNo(idNo, sortKey)
            Dim dataModel As New List(Of TM)
            GlobalVariables.Mapper.Map(bizData, dataModel)
            'For Each bObject In bizData

            '    Dim model As TM
            '    model = GlobalVariables.Mapper.Map(Of TM)(bObject)
            '    viewObject.Add(model)
            'Next
            Return dataModel
        End Function

        Public Function AddRecord(ByRef model) As Integer Implements IService.AddRecord
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.AddRecord(DataBo)
        End Function

        Public Function DelUpdateTvp(dtTable As DataTable, ByVal groupKey As Integer) As Integer _
            Implements IService.DelUpdateTvp
            Return DataDao.DelUpdateTvp(dtTable, groupKey)
        End Function

        Public Overloads Function GetAll(Optional ByRef sortKey As String = Nothing) Implements IService.GetAll
            Return DataDao.GetAll(sortKey)
        End Function

        'Public Shadows Function GetRecordById(idNo As Integer) Implements IService.GetRecordById
        '    Return DataDao.GetRecordById(Convert.ToInt32(idNo))
        'End Function

        Public Function GetRecordById(Of TM As New)(idNo As Integer) As TM Implements IService.GetRecordById
            Dim modelPresenter As New TM
            Dim record = DataDao.GetRecordById(Convert.ToInt32(idNo))
            If record IsNot Nothing Then
                GlobalVariables.Mapper.Map(record, modelPresenter)
            End If
            Return modelPresenter
        End Function

        Public Function InsertTvp(dtTable As DataTable) As Integer Implements IService.InsertTvp
            Return DataDao.InsertTvp(dtTable)
        End Function

        Public Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer _
            Implements IService.TransactionUpdate
            Return DataDao.TransactionUpdate(model)
        End Function

        Public Function UpdateRecord(ByVal model) As Integer Implements IService.UpdateRecord
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateRecord(DataBo)
        End Function

        Public Function UpdateRecordWithIdNo(Of T)(ByVal idNo As Integer, ByVal tableName As String,
                                                    ByVal fieldName As String, ByRef value As T) As Integer _
            Implements IService.UpdateRecordWithIdNo
            Return DataDao.UpdateRecordWithIdNo(Of T)(idNo, tableName, fieldName, value)
        End Function

        Public Function UpdateTvp(dtTable As DataTable) As Integer Implements IService.UpdateTvp
            Return DataDao.UpdateTvp(dtTable)
        End Function

        Public Function IsValid(model) As Boolean Implements IService.IsValid
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataBo.IsValid()
        End Function

#End Region

#Region "BaseDao Functions"

        Public Function GetSqlValue(Of TType)(sqlStatement As String, tableName As String, condition As String) _
            As TType Implements IService.GetSqlValue
            Return BaseDao.GetSqlValue(Of TType)(sqlStatement, tableName, condition)
        End Function

        Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) _
            As Boolean Implements IService.CheckIfUnique
            Return BaseDao.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
        End Function

        Public Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                            searchFieldName1 As String, searchFieldName2 As String) As Integer _
            Implements IService.CountRecordWith2Key
            Return _
                BaseDao.CountRecordWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2)
        End Function

        Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) _
            As Integer _
            Implements IService.CountRecordWithKey
            Return BaseDao.CountRecordWithKey(searchValue, tableName, searchFieldName)
        End Function

        Public Function DeleteRecord(idNo As Integer, tableName As String) As Integer _
            Implements IService.DeleteRecord
            Return BaseDao.DeleteRecord(idNo, tableName)
        End Function

        Public Function FindField(tableName As String, fieldName As String, searchString As String,
                                  searchAnywhere As Boolean) As Integer _
            Implements IService.FindField
            Return BaseDao.FindField(tableName, fieldName, searchString, searchAnywhere)
        End Function

        Public Function FindFieldContinue(tableName As String, idNo As Integer) As Integer _
            Implements IService.FindFieldContinue
            Return BaseDao.FindFieldContinue(tableName, idNo)
        End Function

        Public Function GetFilteredRecords(filterExpression As String, Optional ByRef sortKey As String = Nothing) _
            As Object _
            Implements IService.GetFilteredRecords
            Return BaseDao.GetFilteredRecords(filterExpression, sortKey)
        End Function

        Public Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String _
            Implements IService.GetLastSortKey
            Return BaseDao.GetLastSortKey(searchValue, tableName)
        End Function

        Public Function GetRecordCount(tableName As String) As Integer _
            Implements IService.GetRecordCount
            Return BaseDao.GetRecordCount(tableName)
        End Function

        Public Function GetRecordDateTimeStamp(idNo As Integer, tableName As String,
                                               Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object _
            Implements IService.GetRecordDateTimeStamp
            Return BaseDao.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
        End Function

        Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                              returnFieldName As String) As String _
            Implements IService.GetRecordFieldWithKey
            Return BaseDao.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String,
                                              returnFieldName As String) As T _
            Implements IService.GetRecordFieldWithKeyG
            Return BaseDao.GetRecordFieldWithKeyG(Of T)(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                               searchFieldName1 As String, searchFieldName2 As String,
                                               returnFieldName As String) As String _
            Implements IService.GetRecordFieldWith2Key
            Return _
                BaseDao.GetRecordFieldWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2,
                                               returnFieldName)
        End Function

        Public Function GetRecordPosition(tableName As String, idNo As Integer) As Integer _
            Implements IService.GetRecordPosition
            Return BaseDao.GetRecordPosition(tableName, idNo)
        End Function

        Public Overloads Function GetRecords(ByVal tableName As String, ByVal sortKey As String,
                                             ByVal ParamArray fields() As String) As Object _
            Implements IService.GetRecords
            Return BaseDao.GetRecords(tableName, sortKey, fields)
        End Function

        Public Overloads Function GetRecordsFiltered(ByVal tableName As String, ByVal sortKey As String,
                                                     ByVal filterKey As String, ByVal ParamArray fields() As String) _
            As Object Implements IService.GetRecordsFiltered
            Return BaseDao.GetRecordsFiltered(tableName, sortKey, filterKey, fields)
        End Function

        Public Function GetRecordWithIdNo(idNo As Integer, tableName As String, returnFieldName As String) As String _
            Implements IService.GetRecordWithIdNo
            Return BaseDao.GetRecordWithIdNo(idNo, tableName, returnFieldName)
        End Function

        Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String) _
            As Integer _
            Implements IService.GetIdNoOfSortedPositionNumber
            Return BaseDao.GetIdNoOfSortedPositionNumber(recordNo, tableName, sortOrder)
        End Function

        Public Function GetSortedRecordPosition(idNo As Integer, tableName As String, sortOrder As String) As Integer _
            Implements IService.GetSortedRecordPosition
            Return BaseDao.GetSortedRecordPosition(idNo, tableName, sortOrder)
        End Function

        Public Function HasRecordChanged(idNo As Integer, tableName As String, timeStampedValue As Object,
                                         Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean _
            Implements IService.HasRecordChanged
            Return BaseDao.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
        End Function

#End Region

        'Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList _
        '    Implements IService.GetUserSecurity
        '    Return BaseDao.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
        'End Function

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

        '        'AdoNet.BaseDao.HasRecordChanged(eidNo, tableName, timeStampedValue, timeStampField)

        '        If e.Arguments.Count > 0 Then
        '            e.Result = e.Arguments(0).ToString()
        '        Else
        '            e.Result = "Hello World"
        '        End If
        '    End Sub
    End Class

    'Public Class ServiceLogin
    '    Inherits Service

    '    Protected Shared ReadOnly LoginDao As ILoginDao = Factory.LoginDao()

    '    Public Sub New()
    '        DataDao = LoginDao
    '        DataBo = New Login
    '    End Sub

    'End Class

    Public Class ServiceUser
        Inherits Service

        Protected ReadOnly UserDao As IDaoAll(Of User) = Factory.UserDao

        Public Sub New()
            DataDao = UserDao
            DataBo = New User
        End Sub

    End Class

    Public Class ServiceSecurityObject
        Inherits Service

        Protected ReadOnly SecurityObjectDao As IDaoAll(Of SecurityObject) = Factory.SecurityObjectDao()

        Public Sub New()
            DataDao = SecurityObjectDao
            DataBo = New SecurityObject
        End Sub

    End Class

    Public Class ServiceSecurityGroup
        Inherits Service

        Protected ReadOnly SecurityGroupDao As IDao(Of SecurityGroup) = Factory.SecurityGroupDao()

        Public Sub New()
            DataDao = SecurityGroupDao
            DataBo = New SecurityGroup
        End Sub

    End Class

    Public Class ServiceGroupAccess
        Inherits Service

        Protected ReadOnly GroupAccessDao As IDaoChild(Of GroupAccess) = Factory.GroupAccessDao()

        Public Sub New()
            DataDao = GroupAccessDao
            DataBo = New GroupAccess
        End Sub

    End Class

End Namespace