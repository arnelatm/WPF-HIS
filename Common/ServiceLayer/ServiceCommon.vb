Imports AATM.Common.DataLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Private Shared ReadOnly CommonFactory As ICommonDaoFactory = CommonDaoFactories.GetCommonFactory(Provider)
        Protected Shared ReadOnly CommonDao As ICommonDao = CommonFactory.CommonDao
        Protected Shared ReadOnly BranchDao As IBranchDao = CommonFactory.BranchDao
        Protected Shared ReadOnly CostCenterDao As ICostCenterDao = CommonFactory.CostCenterDao
        Protected Shared ReadOnly CountryDao As ICountryDao = CommonFactory.CountryDao
        Protected Shared ReadOnly DepartmentDao As IDepartmentDao = CommonFactory.DepartmentDao
        Protected Shared ReadOnly OriginalMessagesDao As IOriginalMessagesDao = CommonFactory.OriginalMessagesDao
        Protected Shared ReadOnly PhoneTypeDao As IPhoneTypeDao = CommonFactory.PhoneTypeDao
        Protected Shared ReadOnly ProfitCenterDao As IProfitCenterDao = CommonFactory.ProfitCenterDao
        Protected Shared ReadOnly ReligionDao As IReligionDao = CommonFactory.ReligionDao
        Protected Shared ReadOnly RevenueGroupDao As IRevenueGroupDao = CommonFactory.RevenueGroupDao
        Protected Shared ReadOnly TranslatedMessagesDao As ITranslatedMessagesDao = CommonFactory.TranslatedMessagesDao

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

    Public Class ServiceCostCenter
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return CostCenterDao
        End Function

    End Class

    Public Class ServiceCountry
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return CountryDao
        End Function

    End Class

    Public Class ServiceDepartment
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return DepartmentDao
        End Function

    End Class

    Public Class ServiceOriginalMessages
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return OriginalMessagesDao
        End Function

    End Class

    Public Class ServicePhoneType
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return PhoneTypeDao
        End Function

    End Class

    Public Class ServiceProfitCenter
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return ProfitCenterDao
        End Function

    End Class

    Public Class ServiceReligion
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return ReligionDao
        End Function

    End Class

    Public Class ServiceRevenueGroup
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return RevenueGroupDao
        End Function

    End Class

    Public Class ServiceTranslatedMessages
        Inherits ServiceCommon

        Public Overrides Function GetDao()
            Return TranslatedMessagesDao
        End Function

    End Class

End Namespace