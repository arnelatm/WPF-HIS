
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Private Shared ReadOnly CommonFactory As ICommonDaoFactory = CommonDaoFactories.GetCommonFactory(Provider)
        Protected Shared ReadOnly CommonDao As ICommonDao = CommonFactory.CommonDao
        Protected Shared ReadOnly BranchDao As IBranchDao = CommonFactory.BranchDao
        
        Public Overrides Function GetDao() As Object
            Return GetBaseDao()
        End Function

        Public Overridable Function GetBaseDao()
            Return BaseDaoProp
        End Function

    End Class

    Public Class ServiceBranch
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return BranchDao
        End Function


    End Class

End Namespace