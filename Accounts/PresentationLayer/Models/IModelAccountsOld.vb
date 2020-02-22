
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Interface IModelAccountsOld
        Inherits IModelCommonOld

        Function UpdateGlReferenceNumber(Of TBiz)(ByRef modelBiz As TBiz) As Integer

    End Interface
End NameSpace