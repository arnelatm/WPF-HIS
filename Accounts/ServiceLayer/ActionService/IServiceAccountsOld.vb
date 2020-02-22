
Imports AATM.Common.ServiceLayer.ActionServices

Namespace ServiceLayer.ActionService

    Public Interface IServiceAccountsOld
        Inherits IServiceCommonOld

        Function UpdateGlReferenceNumber(Of TBiz)(ByRef model As TBiz, ByRef dbDataDao As Object) As Integer

    End Interface

End Namespace