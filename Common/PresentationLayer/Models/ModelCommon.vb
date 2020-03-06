
Imports AATM.Common.BusinessLayer
Imports AATM.Common.ServiceLayer
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelCommon
        Inherits Model
        Implements IModelCommon

        Public Overrides Function GetDataService()
            Return GetCommonService()
        End Function

        Public Overridable Function GetCommonService()
            Return New ServiceCommon()
        End Function

    End Class
    
    Public Class ModelBranch
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceBranch()
        End Function

        Public Shadows Function GetBo()
            Return New Branch
        End Function

    End Class

End NameSpace