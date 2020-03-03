
Imports System.Configuration
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionServices

    Public Class SecurityObjectService
        Inherits ServiceCommon

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As ICommonDaoFactory = CommonDaoFactories.GetFactory(Provider)
        Private Shared ReadOnly SecurityObjectDao As ISecurityObjectDao = Factory.SecurityObjectDao

        Public Overrides Function GetDao()
            Return SecurityObjectDao
        End Function

        'Public Sub New()
        '    DataDao = SecurityObjectDao
        'End Sub

    End Class

End Namespace