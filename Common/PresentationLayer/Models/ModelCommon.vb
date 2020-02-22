

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
End NameSpace