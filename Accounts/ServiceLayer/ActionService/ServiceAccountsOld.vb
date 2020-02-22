
Imports System.Configuration
Imports AATM.Accounts.DataLayer
Imports AATM.Common.ServiceLayer.ActionServices

Namespace ServiceLayer.ActionService

    Public Class ServiceAccountsOld
        Inherits ServiceCommonOld
        Implements IServiceAccountsOld

        Protected Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Protected Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)

        Public Shadows DataDao As Object

        Public Function UpdateGlReferenceNumber(Of TBiz)(ByRef model As TBiz, ByRef dbDataDao As Object) As Integer Implements IServiceAccountsOld.UpdateGlReferenceNumber
            Return dbDataDao.UpdateGlReferenceNumber(model)
        End Function

    End Class

End Namespace