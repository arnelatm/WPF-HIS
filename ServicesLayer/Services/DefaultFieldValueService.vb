Imports System.Configuration
Imports AATM.DataLayer

Namespace Services

    Public Class DefaultFieldValueService
        Inherits Service

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared Shadows ReadOnly DefaultFieldValueDao As IDefaultFieldValueDao = Factory.DefaultFieldValueDao

        Public Sub New()
            DataDao = DefaultFieldValueDao
        End Sub

    End Class
End NameSpace