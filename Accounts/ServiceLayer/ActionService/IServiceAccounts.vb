Imports AATM.Common.ServiceLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionService

    Public Interface IServiceAccounts
        Inherits IServiceCommon

        Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer

    End Interface

End Namespace