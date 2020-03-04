Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Common.BusinessLayer
Imports AATM.Common.ServiceLayer
Imports AATM.PresentationLayer.Models
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Models

    Public Class ModelCommon
        Inherits Model
        Implements IModelCommon

        Private Shared ReadOnly ServiceCommon As New ServiceCommon()

        Public Overrides Function GetDataService()
            Return GetCommonService()
        End Function

        Public Overridable Function GetCommonService()
            Return ServiceCommon
        End Function

    End Class

    
    Public Class ModelSecurityObject
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceSecurityObject()
        End Function

        Public Shadows Function GetBo()
            Return New SecurityObject
        End Function

    End Class

    Public Class ModelUser
        Inherits ModelCommon

        Public Overrides Function GetCommonService()
            Return New ServiceUser
        End Function

        Public Shadows Function GetBo()
            Return New User
        End Function

    End Class

End NameSpace