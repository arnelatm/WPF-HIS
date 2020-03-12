Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Interface IModelAccounts
        Inherits IModelCommon

        Function UpdateGlReferenceNumber(Of TBiz)(ByRef modelBiz As TBiz) As Integer

    End Interface

End Namespace