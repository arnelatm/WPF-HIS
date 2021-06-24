Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer

Namespace Services

    Public Class SecurityService
        Inherits ServiceNew
        Implements ISecurityService

        Public Shared SecurityService As SecurityService

        Public Sub New(objectName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
            CreateBusinessObject(objectName, bizParam)
            CreateDao(objectName, daoParam)
            SecurityService = New SecurityService()
        End Sub

        Public Sub New()
            SecurityService = New SecurityService()
        End Sub

        Public Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String Implements ISecurityService.GetControlSecurityIdNo
            Return BaseDao.GetControlSecurityIdNo(searchValue, menu)
        End Function

        Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList Implements ISecurityService.GetUserSecurity
            Return BaseDao.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
        End Function

        Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList Implements ISecurityService.GetUserSecurityForKey
            Return BaseDao.GetUserSecurityForKey(securityObjectName, securityGroupIdNo)
        End Function

        Public Function AddSecurityObject(securityObject As SecurityObject) As Int32 Implements ISecurityService.AddSecurityObject
            Return BaseDao.AddSecurityObject(securityObject)
        End Function

        Public Function InitializeSecurityObject() As Integer Implements ISecurityService.InitializeSecurityObject
            Return BaseDao.InitializeSecurityObject()
        End Function

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

    End Class

End Namespace