Imports AATM.Accounts.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionService

    Public Class ServiceAccounts
        Inherits ServiceCommon
        Implements IServiceAccounts

        Protected Service As Object

        Private Shared Shadows ReadOnly Provider As String = Configuration.ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IAccountsDaoFactory = AccountsDaoFactories.GetFactory(Provider)

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer Implements IServiceAccounts.UpdateGlReferenceNumber
            Return GetDao().UpdateGlReferenceNumber(model)
        End Function

        'Public Overrides Function GetDataDao3()
        '    Return GetDataDao4()
        'End Function

        'Public Overridable Function GetDataDao4()
        '    Return GetDataDao()
        'End Function

        Public Overrides Function GetDao() As Object
            Return GetServiceDao()
        End Function

        Public Overridable Function GetServiceDao()
            Return CommonDaoProp
        End Function

    End Class

End Namespace