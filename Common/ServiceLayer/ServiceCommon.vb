Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Protected Shared ReadOnly DaoFactoryCommonFactory As IDaoFactoryCommon = DaoFactoriesCommon.GetCommonFactory(Provider)
        Protected Shared ReadOnly CommonDao As ICommonDao = DaoFactoryCommonFactory.CommonDao

    End Class

    Public Class ServiceBranch
        Inherits ServiceCommon

        Protected ReadOnly BranchDao As IBranchDao = DaoFactoryCommonFactory.BranchDao

        Public Sub New()
            DataDao = BranchDao
            DataBo = New Branch
        End Sub

    End Class

    Public Class ServiceCostCenter
        Inherits ServiceCommon

        Protected ReadOnly CostCenterDao As ICostCenterDao = DaoFactoryCommonFactory.CostCenterDao

        Public Sub New()
            DataDao = CostCenterDao
            DataBo = New CostCenter
        End Sub

    End Class

    Public Class ServiceCountry
        Inherits ServiceCommon

        Protected ReadOnly CountryDao As ICountryDao = DaoFactoryCommonFactory.CountryDao

        Public Sub New()
            DataDao = CountryDao
            DataBo = New Country
        End Sub

    End Class

    Public Class ServiceDepartment
        Inherits ServiceCommon

        Protected ReadOnly DepartmentDao As IDepartmentDao = DaoFactoryCommonFactory.DepartmentDao

        Public Sub New()
            DataDao = DepartmentDao
            DataBo = New Department
        End Sub

    End Class

    Public Class ServiceOriginalMessages
        Inherits ServiceCommon

        Protected ReadOnly OriginalMessagesDao As IOriginalMessagesDao = DaoFactoryCommonFactory.OriginalMessagesDao

        Public Sub New()
            DataDao = OriginalMessagesDao
            DataBo = New OriginalMessages
        End Sub

    End Class

    Public Class ServicePhoneType
        Inherits ServiceCommon

        Protected ReadOnly PhoneTypeDao As IPhoneTypeDao = DaoFactoryCommonFactory.PhoneTypeDao

        Public Sub New()
            DataDao = PhoneTypeDao
            DataBo = New PhoneType
        End Sub

    End Class

    Public Class ServiceProfitCenter
        Inherits ServiceCommon

        Protected ReadOnly ProfitCenterDao As IProfitCenterDao = DaoFactoryCommonFactory.ProfitCenterDao

        Public Sub New()
            DataDao = ProfitCenterDao
            DataBo = New ProfitCenter
        End Sub

    End Class

    Public Class ServiceReligion
        Inherits ServiceCommon

        Protected ReadOnly ReligionDao As IReligionDao = DaoFactoryCommonFactory.ReligionDao

        Public Sub New()
            DataDao = ReligionDao
            DataBo = New Religion
        End Sub

    End Class

    Public Class ServiceRevenueGroup
        Inherits ServiceCommon

        Protected ReadOnly RevenueGroupDao As IRevenueGroupDao = DaoFactoryCommonFactory.RevenueGroupDao

        Public Sub New()
            DataDao = RevenueGroupDao
            DataBo = New RevenueGroup
        End Sub

    End Class

    Public Class ServiceTranslatedMessages
        Inherits ServiceCommon

        Protected ReadOnly TranslatedMessagesDao As ITranslatedMessagesDao = DaoFactoryCommonFactory.TranslatedMessagesDao

        Public Sub New()
            DataDao = TranslatedMessagesDao
            DataBo = New TranslatedMessages
        End Sub

    End Class

End Namespace