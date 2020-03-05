
Imports AATM.DataLayer

Namespace Services

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Private Shared ReadOnly CommonFactory As IDaoFactory = DaoFactories.GetFactory(Provider)

        Public Overrides Function GetDao() As Object
            Return GetCommonDao()
        End Function

        Public Overridable Function GetCommonDao()
            Return CommonDaoProp
        End Function

    End Class

End Namespace