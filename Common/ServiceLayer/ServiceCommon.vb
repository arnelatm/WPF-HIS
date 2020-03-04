

Imports AATM.Common.DataLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Private Shared ReadOnly CommonFactory As ICommonDaoFactory = CommonDaoFactories.GetFactory(Provider)
        Protected Shared ReadOnly UserDao As IUserDao = Factory.UserDao
        Protected Shared ReadOnly SecurityObjectDao As ISecurityObjectDao = CommonFactory.SecurityObjectDao

        Public Overrides Function GetDao() As Object
            Return GetCommonDao()
        End Function

        Public Overridable Function GetCommonDao()
            Return CommonDaoProp
        End Function

    End Class


    Public Class ServiceSecurityObject
        Inherits ServiceCommon
        Public Overrides Function GetDao()
            Return SecurityObjectDao
        End Function
    End Class


    Public Class ServiceUser
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return UserDao
        End Function
    End Class



End Namespace