
Imports System.Configuration
Imports AATM.Common.DataLayer
Imports AATM.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionServices

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Private Shared ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly TblColPropDao As ITblColPropDao = Factory.TblColPropDao
        Private Shared ReadOnly CommonDao As ICommonDao = Factory.CommonDao
        Private Shared ReadOnly DefaultFieldValueDao As IDefaultFieldValueDao = Factory.DefaultFieldValueDao
        Private Shared ReadOnly UserDao As IUserDao = Factory.UserDao

        Public Overrides Function GetDao() As Object
            Return CommonDaoProp
        End Function

    End Class

End Namespace