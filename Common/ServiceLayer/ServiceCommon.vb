Imports AATM.Common.DataLayer
Imports AATM.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Private Shared ReadOnly CommonFactory As ICommonDaoFactory = CommonDaoFactories.GetFactory(Provider)

        Public Overrides Function GetDao() As Object
            Return GetCommonDao()
        End Function

        Public Overridable Function GetCommonDao()
            Return CommonDaoProp
        End Function

    End Class

End Namespace