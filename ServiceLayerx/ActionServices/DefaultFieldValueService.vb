Imports System.Configuration
Imports AATM.DataLayer.DBDataObj

Public Class DefaultFieldValueService
    Inherits ServiceOld

    Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
    Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
    Private Shared Shadows ReadOnly DefaultFieldValueDao As IDefaultFieldValueDao = Factory.DefaultFieldValueDao

    Public Sub New()
        DataDao = DefaultFieldValueDao
    End Sub

End Class