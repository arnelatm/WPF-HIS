
Imports System.Configuration
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionServices

    Public Class OriginalMessagesService
        Inherits ServiceOld

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        Private Shared ReadOnly OriginalMessagesDao As IOriginalMessagesDao = Factory.OriginalMessagesDao

        Public Sub New()
            DataDao = OriginalMessagesDao
        End Sub

    End Class

End Namespace