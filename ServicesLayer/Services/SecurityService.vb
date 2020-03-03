Imports System.Configuration
Imports AATM.DataLayer

Namespace Services

    Public Class SecurityService
        Implements ISecurityService

        Protected Shared Provider As String
        Protected Shared Factory As IDaoFactory
        Protected Shared TblColPropDao As ITblColPropDao
        Protected Shared DefaultFieldValueDao As IDefaultFieldValueDao
        Protected Shared SecurityDao As ISecurityDao

        'Protected Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        'Protected Shared ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        'Protected Shared ReadOnly TblColPropDao As ITblColPropDao = Factory.TblColPropDao
        'Protected Shared ReadOnly DefaultFieldValueDao As IDefaultFieldValueDao = Factory.DefaultFieldValueDao
        'Protected Shared ReadOnly SecurityDao As ISecurityDao = Factory.SecurityDao

        Public Function GetControlSecurityIdNo(searchValue As String) As String Implements ISecurityService.GetControlSecurityIdNo
            If Provider Is Nothing Then
                Provider = ConfigurationManager.AppSettings.Get("DataProvider")
                Factory = DaoFactories.GetFactory(Provider)
                SecurityDao = Factory.SecurityDao
            End If
            Return SecurityDao.GetControlSecurityIdNo(searchValue)
        End Function

        Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList Implements ISecurityService.GetUserSecurity
            If Provider Is Nothing Then
                Provider = ConfigurationManager.AppSettings.Get("DataProvider")
                Factory = DaoFactories.GetFactory(Provider)
                SecurityDao = Factory.SecurityDao
            End If
            Return SecurityDao.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
        End Function

    End Class
End NameSpace