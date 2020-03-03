
Imports System.Configuration
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionServices

    Public Class SecurityGroupService
        Inherits Service

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As ICommonDaoFactory = CommonDaoFactories.GetFactory(Provider)
        Private Shared ReadOnly SecurityGroupDao As ISecurityGroupDao = Factory.SecurityGroupDao

        Public Sub New()
            DataDao = SecurityGroupDao
        End Sub

    End Class

End Namespace