
Imports System.Configuration
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionServices

    Public Class SecurityGroupService
        Inherits Service

        Protected Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Protected Shared Shadows ReadOnly Factory As ICommonDaoFactory = CommonDaoFactories.GetFactory(Provider)
        Protected Shared ReadOnly SecurityGroupDao As ISecurityGroupDao = Factory.SecurityGroupDao

        Public Sub New()
            DataDao = SecurityGroupDao
        End Sub

    End Class

End Namespace