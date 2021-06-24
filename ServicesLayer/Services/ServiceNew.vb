Imports System.Configuration
Imports System.Reflection
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace Services
    ' implementation of IService interface. It can handle different data providers.

    ' ** Facade pattern.
    ' ** Repository pattern (Service could be split up in individual Repositories: Product, Category, etc).

    Public Class ServiceNew
        Implements IServiceNew

        Protected Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Protected Shared ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Protected Shared ReadOnly BaseDao As IBaseDao = Factory.BaseDao
        Protected Shared ReadOnly DefaultFieldValueDao As IDefaultFieldValueDao = Factory.DefaultFieldValueDao
        Protected Shared ReadOnly TblColPropDao As ITblColPropDao = Factory.TblColPropDao

        Public Sub New(objectName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
            CreateBusinessObject(objectName, bizParam)
            CreateDao(objectName, daoParam)
        End Sub

        Public Sub New()
        End Sub

        Public Property DataBo As Object
        Public Property DataDao As Object

        Private ReadOnly Property UserDao As IDaoAll(Of User)
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

        Protected Overridable Sub CreateDao(objectName As String, Optional daoParam As Object = Nothing)
            If daoParam Is Nothing OrElse daoParam.Length = 0 Then
                DataDao = Factory.CreateDao(objectName)
            Else
                DataDao = Factory.CreateDao(objectName, daoParam)
            End If
            If DataDao Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + objectName)
                Debugger.Break()
            End If
        End Sub

        Public Function IsValid(model) As Boolean Implements IServiceNew.IsValid
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataBo.IsValid()
        End Function

    End Class

End Namespace