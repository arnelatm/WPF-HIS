
Imports AATM.Common.ServiceLayer
Imports AATM.Common.ServiceLayer.ActionServices

Namespace ServiceLayer.ActionService

    Public Interface IServiceAccounts
        Inherits IServiceCommon

        Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer

    End Interface

End Namespace