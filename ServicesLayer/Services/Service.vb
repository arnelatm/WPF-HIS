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
        Protected Shared ReadOnly BaseDao As IBaseDao = Factory.BaseDao
        Protected Shared ReadOnly DefaultFieldValueDao As IDefaultFieldValueDao = Factory.DefaultFieldValueDao
        Protected Shared ReadOnly TblColPropDao As ITblColPropDao = Factory.TblColPropDao
        'Protected Shared ReadOnly DaoFactory As IDaoFactory = DaoFactories.GetFactory(Provider)

        Public Sub New(objectName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
            'Dim securityGroup As New SecurityGroup
            CreateBusinessObject(objectName, bizParam)
            CreateDao(objectName, daoParam)
        End Sub

        Public Sub New()
        End Sub

        Protected Overridable Sub CreateBusinessObject(objectName As String, Optional bizParam As Object = Nothing)
            Dim bizObject = $"AATM.BusinessLayer.BusinessObjects." + objectName

            Dim tType = Type.GetType(bizObject)
            If bizParam IsNot Nothing AndAlso bizParam.Length > 0 Then
                DataBo = GetInstance(bizObject)
            Else
                DataBo = GetInstance(bizObject)
                'DataBo = Activator.CreateInstance(tType)
            End If
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
            End If
        End Sub

        Protected Overridable Sub CreateDao(objectName As String, Optional daoParam As Object = Nothing)
            'If daoParam Is Nothing Or daoParam.Length = 0 Then
            '    DataDao = Factory.CreateDao(objectName)
            'Else
            '    DataDao = Factory.CreateDao(objectName, daoParam)
            'End If
            Dim dao = objectName + "Dao"
            DataDao = Me.GetType().GetProperty(dao, BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(Me)
            If DataDao Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + objectName)
                Debugger.Break()
            End If
        End Sub

        Public Property DataBo As Object
        Public Property DataDao As Object
        'Public Property SecurityDao = Factory.SecurityDao

        Private ReadOnly Property SecurityGroupDao As IDaoAll(Of SecurityGroup)
            Get
                Return Factory.CreateDao("SecurityGroup")
            End Get
        End Property

        Private ReadOnly Property SecurityObjectDao As IDaoAll(Of SecurityObject)
            Get
                Return Factory.CreateDao("SecurityObject")
            End Get
        End Property

        Private ReadOnly Property UserDao As IDaoAll(Of User)
            Get
                Return Factory.CreateDao("User")
            End Get
        End Property

        Public Function GetBizObjectErrors()
            Return DataBo.GetErrors()
        End Function

        Public Function GetBizObjectRules()
            Return DataBo.GetRules()
        End Function

        Public Function GetDefaultFieldValues(ByVal tableName As String) Implements IService.GetDefaultFieldValues
            Return DefaultFieldValueDao.GetTableDefaultValues(tableName)
        End Function

        Public Function GetInstance(ByVal strFullyQualifiedName As String) As Object
            Dim type As Type = Type.[GetType](strFullyQualifiedName)
            If type IsNot Nothing Then Return Activator.CreateInstance(type)
            For Each asm In AppDomain.CurrentDomain.GetAssemblies()
                type = asm.[GetType](strFullyQualifiedName)
                If type IsNot Nothing Then Return Activator.CreateInstance(type)
            Next
            Return Nothing
        End Function

        Public Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp) Implements IService.GetMainTableColumnProperties
            Return TblColPropDao.GetMainTableColumnProperties(tableName)
        End Function

        Public Function GetRecordExternal(Of TM, TD As New)(tableName As String, idNo As Int32, ByRef externalService As Object) As TM
            Return externalService.InvokeMember("Get" + tableName, BindingFlags.InvokeMethod, Nothing, Me, New Object() {idNo})
        End Function

#Region "Current Service Function"

        Public Function AddRecord(ByRef model) As Integer Implements IService.AddRecord
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.AddRecord(DataBo)
        End Function

        Public Function DelUpdateTvp(dtTable As DataTable, ByVal groupKey As Integer) As Integer Implements IService.DelUpdateTvp
            Return DataDao.DelUpdateTvp(dtTable, groupKey)
        End Function

        Public Overloads Function GetAll(Optional ByRef sortKey As String = Nothing) Implements IService.GetAll
            Return DataDao.GetAll(sortKey)
        End Function

        Public Function GetControlSecurityIdNo(searchValue As String) As String Implements IService.GetControlSecurityIdNo
            Return BaseDao.GetControlSecurityIdNo(searchValue)
        End Function

        Public Function GetRecordById(Of TM As New)(idNo As Int32) As TM Implements IService.GetRecordById
            Dim modelPresenter As New TM
            Dim record = DataDao.GetRecordById(Convert.ToInt32(idNo))
            If record IsNot Nothing Then
                GlobalVariables.Mapper.Map(record, modelPresenter)
            End If
            Return modelPresenter
        End Function

        Public Function GetRecordsWithIdNo(Of TM)(idNo, Optional ByRef sortKey = Nothing) As List(Of TM) Implements IService.GetRecordsWithIdNo
            Dim bizData = DataDao.GetRecordsWithIdNo(idNo, sortKey)
            Dim dataModel As New List(Of TM)
            GlobalVariables.Mapper.Map(bizData, dataModel)
            Return dataModel
        End Function

        Public Function GetUserSecurity(securityObjectIdNo As Int16, securityGroupIdNo As Int16) As ArrayList Implements IService.GetUserSecurity
            Return BaseDao.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
        End Function

        Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList Implements IService.GetUserSecurityForKey
            Return BaseDao.GetUserSecurityForKey(securityObjectName, securityGroupIdNo)
        End Function

        'Public Shadows Function GetRecordById(idNo) Implements IService.GetRecordById
        '    Return DataDao.GetRecordById(Convert.ToInt32(idNo))
        'End Function
        Public Function InsertTvp(dtTable As DataTable) As Integer Implements IService.InsertTvp
            Return DataDao.InsertTvp(dtTable)
        End Function

        Public Function IsValid(model) As Boolean Implements IService.IsValid
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataBo.IsValid()
        End Function

        Public Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer _
                    Implements IService.TransactionUpdate
            Return DataDao.TransactionUpdate(model)
        End Function

        Public Function UpdateRecord(ByVal model) As Integer Implements IService.UpdateRecord
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateRecord(DataBo)
        End Function

        Public Function UpdateRecordWithIdNo(Of T)(ByVal idNo As Int32, ByVal tableName As String, ByVal fieldName As String, ByRef value As T) As Integer Implements IService.UpdateRecordWithIdNo
            Return DataDao.UpdateRecordWithIdNo(Of T)(idNo, tableName, fieldName, value)
        End Function

        Public Function UpdateTvp(dtTable As DataTable) As Integer Implements IService.UpdateTvp
            Return DataDao.UpdateTvp(dtTable)
        End Function

#End Region

#Region "BaseDao Functions"

        Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean Implements IService.CheckIfUnique
            Return BaseDao.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
        End Function

        Public Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer Implements IService.CountRecordWith2Key
            Return _
                BaseDao.CountRecordWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2)
        End Function

        Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer Implements IService.CountRecordWithKey
            Return BaseDao.CountRecordWithKey(searchValue, tableName, searchFieldName)
        End Function

        Public Function DeleteRecord(idNo As Int32, tableName As String) As Integer _
            Implements IService.DeleteRecord
            Return BaseDao.DeleteRecord(idNo, tableName)
        End Function

        Public Function FindField(tableName As String, fieldName As String, searchString As String, searchAnywhere As Boolean) As Integer Implements IService.FindField
            Return BaseDao.FindField(tableName, fieldName, searchString, searchAnywhere)
        End Function

        Public Function FindFieldContinue(tableName As String, idNo As Int32) As Integer Implements IService.FindFieldContinue
            Return BaseDao.FindFieldContinue(tableName, idNo)
        End Function

        Public Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object Implements IService.GetFieldWithIdNo
            Return BaseDao.GetFieldWithIdNo(idNo, tableName, returnFieldName)
        End Function

        Public Function GetFilteredRecords(ByVal tableName As String, ByVal sortKey As String, ByVal filterKey As String, ByVal ParamArray fields() As String) As Object Implements IService.GetFilteredRecords
            Return BaseDao.GetFilteredRecords(tableName, sortKey, filterKey, fields)
        End Function

        Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer Implements IService.GetIdNoOfSortedPositionNumber
            Return BaseDao.GetIdNoOfSortedPositionNumber(recordNo, tableName, sortOrder)
        End Function

        Public Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String Implements IService.GetLastSortKey
            Return BaseDao.GetLastSortKey(searchValue, tableName)
        End Function

        Public Function GetMaxValueFiltered(searchFieldName As String, tableName As String, returnFieldName As String, filter As String) As Object Implements IService.GetMaxValueFiltered
            Return BaseDao.GetMaxValueFiltered(searchFieldName, tableName, returnFieldName, filter)
        End Function

        Public Function GetRecordCount(tableName As String) As Integer Implements IService.GetRecordCount
            Return BaseDao.GetRecordCount(tableName)
        End Function

        Public Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object Implements IService.GetRecordDateTimeStamp
            Return BaseDao.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
        End Function

        Public Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String Implements IService.GetRecordFieldWith2Key
            Return BaseDao.GetRecordFieldWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2, returnFieldName)
        End Function

        Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String Implements IService.GetRecordFieldWithKey
            Return BaseDao.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T Implements IService.GetRecordFieldWithKeyG
            Return BaseDao.GetRecordFieldWithKeyG(Of T)(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordField(tableName As String, returnFieldName As String) As Object Implements IService.GetRecordField
            Return BaseDao.GetRecordField(tableName, returnFieldName)
        End Function

        Public Function GetRecordPosition(tableName As String, idNo As Int32) As Integer Implements IService.GetRecordPosition
            Return BaseDao.GetRecordPosition(tableName, idNo)
        End Function

        Public Overloads Function GetRecords(ByVal tableName As String, ByVal sortKey As String, ByVal ParamArray fields() As String) As Object Implements IService.GetRecords
            Return BaseDao.GetRecords(tableName, sortKey, fields)
        End Function

        'Public Overloads Function GetFields(ByVal tableName As String, ByVal sortKey As String, ByVal ParamArray fields() As String) As Object Implements IService.GetFields
        '    Return BaseDao.GetFields(tableName, sortKey, fields)
        'End Function

        Public Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String) As Integer Implements IService.GetSortedRecordPosition
            Return BaseDao.GetSortedRecordPosition(idNo, tableName, sortOrder)
        End Function

        Public Function GetSqlValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType Implements IService.GetSqlValue
            Return BaseDao.GetSqlValue(Of TType)(sqlStatement, tableName, condition)
        End Function

        Public Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object, Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean Implements IService.HasRecordChanged
            Return BaseDao.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
        End Function

#End Region

    End Class

End Namespace