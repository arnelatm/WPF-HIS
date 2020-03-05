Imports AATM.Common.DataLayer
Imports AATM.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Private Shared ReadOnly CommonFactory As ICommonDaoFactory = CommonDaoFactories.GetFactory(Provider)

        Public Overrides Function GetDao() As Object
            Return GetBaseDao()
        End Function

        Public Overridable Function GetBaseDao()
            Return BaseDaoProp
        End Function

    End Class

End Namespace