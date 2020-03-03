
Imports System.Configuration
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionServices

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Private Shared ReadOnly Factory As ICommonDaoFactory = CommonDaoFactories.GetFactory(Provider)

        Public Overrides Function GetDao() As Object
            Return CommonDaoProp
        End Function

    End Class

End Namespace