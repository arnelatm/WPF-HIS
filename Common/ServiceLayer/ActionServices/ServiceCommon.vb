
Imports System.Configuration
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services
Imports ServicesLayer.Services

Namespace ServiceLayer.ActionServices

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)

        'Public Overrides Function GetDataDao2()
        '    Return GetDataDao3()
        'End Function

        'Public Overridable Function GetDataDao3()
        '    Return Nothing
        'End Function

        Public Overrides Function GetDao() As Object
            Return CommonDaoProp
        End Function

    End Class

End Namespace