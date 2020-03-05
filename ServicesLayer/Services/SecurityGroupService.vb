
Imports System.Configuration
Imports AATM.DataLayer

Namespace Services

    Public Class SecurityGroupService
        Inherits Service

        Protected Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Protected Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)

        Public Sub New()
            DataDao = SecurityGroupDao
        End Sub

    End Class

End Namespace