Imports System.Configuration
Imports AATM.DataLayer

Namespace Services

    Public Class SecurityObjectService
        Inherits Service

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)

        Public Overrides Function GetDao()
            Return SecurityObjectDao
        End Function

    End Class

End Namespace