
Imports System.Configuration
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class TranslatedMessagesService
        Inherits ServiceCommon

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As ICommonDaoFactory = CommonDaoFactories.GetCommonFactory(Provider)
        Private Shared ReadOnly TranslatedMessagesDao As ITranslatedMessagesDao = Factory.TranslatedMessagesDao

        Public Sub New()
            DataDao = TranslatedMessagesDao
        End Sub

    End Class

End Namespace