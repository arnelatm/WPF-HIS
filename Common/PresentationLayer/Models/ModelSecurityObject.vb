
Imports AATM.Common.BusinessLayer
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Models

    Public Class ModelSecurityObject
        Inherits ModelCommon
        Implements IModelCategory

        Private Shared ReadOnly Property Service As New SecurityObjectService()

        Public Overrides Function GetCommonService()
            Return Service
        End Function

        Public Shadows Function GetBo()
            Return New SecurityObject
        End Function

    End Class

    Public Interface IModelCategory
    End Interface
End Namespace