
Imports System.Configuration
Imports AATM.DataLayer

Namespace Services

    Public Class GroupAccessService
        Inherits Service

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly GroupAccessDao As IGroupAccessDao = Factory.GroupAccessDao

        Public Sub New()
            DataDao = GroupAccessDao
        End Sub

    End Class

End Namespace