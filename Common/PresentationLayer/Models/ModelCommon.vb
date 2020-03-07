
Imports AATM.Common.BusinessLayer
Imports AATM.Common.ServiceLayer
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelCommon
        Inherits Model
        Implements IModelCommon

        Public Overrides Function GetDataService() Implements IModelCommon.GetDataService
            Return GetCommonService()
        End Function

        Public Overridable Function GetCommonService() Implements IModelCommon.GetCommonService
            Return New ServiceCommon()
        End Function

        Public Overrides Function GetBo() Implements IModelCommon.GetBo
            Return Nothing
        End Function

    End Class
    
    Public Class ModelBranch
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceBranch()
        End Function

        Public Overrides Function GetBo()
            Return New Branch
        End Function

    End Class

    Public Class ModelCostCenter
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceCostCenter()
        End Function

        Public Overrides Function GetBo()
            Return New CostCenter
        End Function

    End Class

    Public Class ModelCountry
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceCountry()
        End Function

        Public Overrides Function GetBo()
            Return New Country
        End Function

    End Class

    Public Class ModelDepartment
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceDepartment()
        End Function

        Public Overrides Function GetBo()
            Return New Department
        End Function

    End Class

    Public Class ModelOriginalMessages
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceOriginalMessages()
        End Function

        Public Overrides Function GetBo()
            Return New OriginalMessages
        End Function

    End Class

    Public Class ModelProfitCenter
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceProfitCenter()
        End Function

        Public Overrides Function GetBo()
            Return New ProfitCenter
        End Function

    End Class

    Public Class ModelReligion
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceReligion()
        End Function

        Public Overrides Function GetBo()
            Return New Religion
        End Function

    End Class

    Public Class ModelRevenueGroup
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceRevenueGroup()
        End Function

        Public Overrides Function GetBo()
            Return New RevenueGroup
        End Function

    End Class

    Public Class ModelTranslatedMessages
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceTranslatedMessages()
        End Function

        Public Overrides Function GetBo()
            Return New TranslatedMessages
        End Function

    End Class


End NameSpace