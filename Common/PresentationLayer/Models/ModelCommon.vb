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

    End Class

    Public Class ModelBranch
        Inherits ModelCommon

        'Private ReadOnly _service As New ServiceBranch()

        Public Overrides Function GetCommonService()
            Return New ServiceBranch()
        End Function

    End Class

    Public Class ModelCostCenter
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceCostCenter()
        End Function

    End Class

    Public Class ModelCountry
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceCountry()
        End Function

    End Class

    Public Class ModelDepartment
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceDepartment()
        End Function

    End Class

    Public Class ModelOriginalMessages
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceOriginalMessages()
        End Function

    End Class

    Public Class ModelProfitCenter
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceProfitCenter()
        End Function

    End Class

    Public Class ModelReligion
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceReligion()
        End Function

    End Class

    Public Class ModelRevenueGroup
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceRevenueGroup()
        End Function

    End Class

    Public Class ModelTranslatedMessages
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceTranslatedMessages()
        End Function

    End Class

    Public Class ModelPhoneType
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServicePhoneType()
        End Function

    End Class

End Namespace